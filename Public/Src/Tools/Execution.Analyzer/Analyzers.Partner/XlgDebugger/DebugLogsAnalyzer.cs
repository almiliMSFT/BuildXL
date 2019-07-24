// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BuildXL.Engine;
using BuildXL.FrontEnd.Script.Debugger;
using BuildXL.Scheduler.Tracing;
using BuildXL.Storage;
using BuildXL.ToolSupport;
using BuildXL.Utilities;
using VSCode.DebugAdapter;
using VSCode.DebugProtocol;
using static BuildXL.FrontEnd.Script.Debugger.Matcher;

namespace BuildXL.Execution.Analyzer
{
    internal partial class Args
    {
        public const int XlgDebuggerPort = 41188;

        public Analyzer InitializeDebugLogsAnalyzer()
        {
            int port = XlgDebuggerPort;
            foreach (var opt in AnalyzerOptions)
            {
                if (opt.Name.Equals("port", StringComparison.OrdinalIgnoreCase) ||
                   opt.Name.Equals("p", StringComparison.OrdinalIgnoreCase))
                {
                    port = ParseInt32Option(opt, 0, 100000);
                }
                else
                {
                    throw Error("Unknown option for fingerprint text analysis: {0}", opt.Name);
                }
            }

            return new DebugLogsAnalyzer(GetAnalysisInput(), port);
        }

        private static void WriteDebugLogsAnalyzerHelp(HelpWriter writer)
        {
            writer.WriteBanner("XLG Debugger");
        }
    }

    /// <summary>
    /// XLG debugger
    /// </summary>
    internal sealed class DebugLogsAnalyzer : Analyzer
    {
        private readonly IList<PipExecutionPerformanceEventData> m_writeExecutionEntries = new List<PipExecutionPerformanceEventData>();
        private readonly Dictionary<FileArtifact, FileContentInfo> m_fileContentMap = new Dictionary<FileArtifact, FileContentInfo>(capacity: 10 * 1000);
        private string[] m_workers;

        private readonly int m_port;
        private readonly DebuggerState m_state;

        private XlgThreadState XlgThread { get; }

        private IDebugger Debugger { get; set; }

        private DebugSession Session { get; set; }

        /// <nodoc />
        public bool IsDebugging => Debugger != null;

        /// <nodoc />
        internal DebugLogsAnalyzer(AnalysisInput input, int port)
            : base(input)
        {
            XlgThread = new XlgThreadState(Input, CachedGraph);
            m_port = port;
            m_state = new DebuggerState(XlgThread.Render, PathTable, LoggingContext);
        }

        /// <inheritdoc />
        public override void Dispose()
        {
            base.Dispose();
        }

        private async Task<int> AnalyzeAsync()
        {
            var debugServer = new DebugServer(LoggingContext, m_port, (d) => new DebugSession(m_state, null, d));
            Debugger = await debugServer.StartAsync();
            Session = (DebugSession)Debugger.Session;
            Session.WaitSessionInitialized();

            m_state.SetThreadState(XlgThread);
            Debugger.SendEvent(new StoppedEvent(XlgThread.ThreadId, "Break on start", "txt..."));

            await Session.Completion;
            return 0;
        }

        /// <inheritdoc />
        public override int Analyze()
        {
            return AnalyzeAsync().GetAwaiter().GetResult();
        }

        #region Log processing

        /// <inheritdoc />
        public override void FileArtifactContentDecided(FileArtifactContentDecidedEventData data)
        {
            m_fileContentMap[data.FileArtifact] = data.FileContentInfo;
        }

        /// <inheritdoc />
        public override void WorkerList(WorkerListEventData data)
        {
            m_workers = data.Workers;
        }

        /// <inheritdoc />
        public override void PipExecutionPerformance(PipExecutionPerformanceEventData data)
        {
            m_writeExecutionEntries.Add(data);
        }

        #endregion
    }
}
