// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Diagnostics.ContractsLight;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildXL.Utilities;

namespace BuildXL.Execution.Analyzer
{
    public class LogEvent
    {
        public long StartLine;
        public long EndLine;
    }

    struct LogLine
    {
        private readonly Lazy<LogEvent> m_lazyLogEvent;

        public string Line { get; }

        public LogEvent LogEvent => m_lazyLogEvent.Value;

        public LogLine(string line, Func<LogEvent> parser)
        {
            Line = line;
            m_lazyLogEvent = Lazy.Create(parser);
        }
    }

    /// <nodoc />
    public class LogParser
    {
        private readonly string m_logFilePath;

        private Lazy<LogLine[]> m_lazyLogLines;

        private LogLine[] Lines => m_lazyLogLines.Value;

        public LogParser(string logFilePath)
        {
            Contract.Requires(File.Exists(logFilePath));

            m_logFilePath = logFilePath;
            m_lazyLogLines = Lazy.Create(() =>
            {
                var lines = File.ReadAllLines(m_logFilePath);
                var result = new LogLine[lines.LongLength];
                for (long i = 0; i < lines.LongLength; i++)
                {
                    result[i] = new LogLine(lines[i], () => ParseLine(i));
                }
                return result;
            });
        }

        private LogEvent ParseLine(long lineIdx)
        {
            throw new NotImplementedException();
        }
    }
}
