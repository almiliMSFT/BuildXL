// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using BuildXL.Utilities.Instrumentation.Common;
using BuildXL.Utilities.Tracing;
using BuildXL.Tracing;
using BuildXL.Cache.ContentStore.Logging;
using BuildXL.Cache.ContentStore.Interfaces.Logging;
using System;
using System.Globalization;

namespace BuildXL.Cache.ContentStore.Logging.Tracing
{
    /// <summary>
    /// Logging
    /// </summary>
    [EventKeywordsType(typeof(Events.Keywords))]
    [EventTasksType(typeof(Events.Tasks))]
    public abstract partial class Logger
    {
        /// <summary>
        ///     Returns the logger instance
        /// </summary>
        public static Logger Log => m_log;

        /// <summary>
        ///     A generic log event for all messages to be sent to telemetry.
        /// </summary>
        [GeneratedEvent(
            (ushort)EventId.ContentAddressableStoreLogMessage,
            EventGenerators = EventGenerators.TelemetryOnly,
            EventLevel = Level.Verbose,
            Message = "{dateTime} {threadId} {severity} {message}")]
        public abstract void Z_tmp_ContentAddressableStoreLogMessage
            (
            LoggingContext context,
            string dateTime,
            int threadId,
            Severity severity,
            string message
            );
    }
}
