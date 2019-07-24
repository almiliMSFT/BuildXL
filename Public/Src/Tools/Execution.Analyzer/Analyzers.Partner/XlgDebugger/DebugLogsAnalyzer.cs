// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuildXL.Engine;
using BuildXL.FrontEnd.Script.Debugger;
using BuildXL.Pips;
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
    public sealed class DebugLogsAnalyzer : Analyzer
    {
        private readonly IList<PipExecutionPerformanceEventData> m_writeExecutionEntries = new List<PipExecutionPerformanceEventData>();
        private readonly Dictionary<FileArtifact, FileContentInfo> m_fileContentMap = new Dictionary<FileArtifact, FileContentInfo>(capacity: 10 * 1000);
        private readonly Lazy<Dictionary<PipId, PipExecutionPerformance>> m_lazyPipPerfDict;
        private string[] m_workers;
        private readonly int m_port;
        private readonly DebuggerState m_state;

        private Dictionary<PipId, PipExecutionPerformance> CopmutePipPerfDict()
        {
            return m_writeExecutionEntries.ToDictionary(e => e.PipId, e => e.ExecutionPerformance);
        }

        private XlgState XlgState { get; }

        private IDebugger Debugger { get; set; }

        private DebugSession Session { get; set; }

        /// <nodoc />
        public bool IsDebugging => Debugger != null;

        /// <nodoc />
        internal DebugLogsAnalyzer(AnalysisInput input, int port)
            : base(input)
        {
            XlgState = new XlgState(this);
            m_port = port;
            m_state = new DebuggerState(XlgState.Render, PathTable, LoggingContext);
            m_lazyPipPerfDict = new Lazy<Dictionary<PipId, PipExecutionPerformance>>(CopmutePipPerfDict);
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

            m_state.SetThreadState(XlgState);
            Debugger.SendEvent(new StoppedEvent(XlgState.ThreadId, "Break on start", "txt..."));

            await Session.Completion;
            return 0;
        }

        /// <inheritdoc />
        public override int Analyze()
        {
            return AnalyzeAsync().GetAwaiter().GetResult();
        }

        /// <nodoc />
        public IReadOnlyDictionary<PipId, PipExecutionPerformance> Pip2Perf => m_lazyPipPerfDict.Value;

        /// <nodoc />
        public PipExecutionPerformance GetPipExePerf(PipId pipId)
        {
            return Pip2Perf.TryGetValue(pipId, out var result) ? result : null;
        }

        #region Log processing

        /// <inheritdoc />
        public override void DominoInvocation(DominoInvocationEventData data)
        {
            
        }

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
