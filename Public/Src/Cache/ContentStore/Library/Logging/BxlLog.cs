// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using BuildXL.Utilities.Instrumentation.Common;
using BuildXL.Utilities.Tracing;
using BuildXL.Tracing;
using BuildXL.Cache.ContentStore.Logging;
using BuildXL.Cache.ContentStore.Interfaces.Logging;
using System;
using System.Globalization;

namespace BuildXL.Cache.ContentStore.Logging
{
    /// <summary>
    ///     An <see cref="ILog"/> that uses the BuildXL tracing infrastructure based
    ///     on automatically generatd log events.  All generated log events are found
    ///     in the <see cref="Tracing.Logger"/> log. 
    /// </summary>
    public sealed class BxlLog : ILog
    {
        private readonly LoggingContext _loggingContext;

        /// <inheritdoc />
        public Severity CurrentSeverity { get; }

        /// <summary>
        ///     Assigns args to fields and nothing more.
        /// </summary>
        public BxlLog
            (
            LoggingContext loggingContext,
            Severity severity = Severity.Diagnostic
            )
        {
            CurrentSeverity = severity;
            _loggingContext = loggingContext;
        }

        /// <summary>
        ///     Nothing needs to be disposed.
        /// </summary>
        public void Dispose() { }

        /// <summary>
        ///     Nothing needs to be flushed.
        /// </summary>
        public void Flush() { }

        /// <summary>
        ///     Delegates to <see cref="Tracing.Logger.Z_tmp_ContentAddressableStoreLogMessage"/>
        /// </summary>
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

            var dateTimeStr = string.Format(CultureInfo.CurrentCulture, "{0:yyyy-MM-dd HH:mm:ss,fff}", dateTime);
            Tracing.Logger.Log.Z_tmp_ContentAddressableStoreLogMessage(_loggingContext, dateTimeStr, threadId, severity, message);
        }
    }
}
