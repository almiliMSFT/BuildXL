// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using BuildXL.Utilities.Instrumentation.Common;
using BuildXL.Utilities.Tracing;
using BuildXL.Tracing;
using BuildXL.Cache.ContentStore.Logging;
using BuildXL.Cache.ContentStore.Interfaces.Logging;
using System;
using System.Globalization;

namespace ContentStoreApp
{
    /// <summary>
    /// Logging
    /// </summary>
    [EventKeywordsType(typeof(Events.Keywords))]
    [EventTasksType(typeof(Events.Tasks))]
    public abstract partial class Logger
    {
        /// <summary>
        /// Returns the logger instance
        /// </summary>
        public static Logger Log => m_log;

        [GeneratedEvent(
            (ushort)EventId.StartupCurrentDirectory,
            EventGenerators = EventGenerators.TelemetryOnly,
            EventLevel = Level.Verbose,
            Message = "{message}")]
        public abstract void Z_tmp_ContentAddressableStoreLogMessage
            (
            LoggingContext context,
            string message
            );
    }

    public sealed class AriaLog : ILog
    {
        private readonly LoggingContext _loggingContext;

        public Severity CurrentSeverity { get; }

        public AriaLog
            (
            LoggingContext loggingContext,
            Severity severity = Severity.Diagnostic
            )
        {
            CurrentSeverity = severity;
            _loggingContext = loggingContext;
        }

        public void Dispose() { }

        public void Flush() { }

        public void Write
            (
            DateTime dateTime,
            int threadId,
            Severity severity,
            string message
            )
        {
            if (severity < CurrentSeverity)
            {
                return;
            }

            var line = string.Format
                (
                    CultureInfo.CurrentCulture,
                    "{0:yyyy-MM-dd HH:mm:ss,fff} {1,3} {2} {3}",
                    dateTime,
                    threadId,
                    severity,
                    message
                );
            Logger.Log.Z_tmp_ContentAddressableStoreLogMessage(_loggingContext, line);
        }
    }
}
