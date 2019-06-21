// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks.Dataflow;
using BuildXL.Cache.ContentStore.Interfaces.Logging;
using Kusto.Ingest;

namespace BuildXL.Cache.ContentStore.Logging
{
    /// <summary>
    ///     TODO
    /// </summary>
    public sealed class KustoUploader : IDisposable
    {
        private readonly ILog _log;
        private readonly bool _deleteFilesOnSuccess;
        private readonly bool _checkForIngestionErrors;
        private readonly IKustoQueuedIngestClient _client;
        private readonly KustoQueuedIngestionProperties _ingestionProperties;
        private readonly ActionBlock<FileDescription> _block;

        /// <summary>
        ///     Constructor.  Initializes this object and does perform anything else.
        /// </summary>
        /// <param name="connectionString">Kusto connection string.</param>
        /// <param name="database">Database into which to ingest.</param>
        /// <param name="table">Table into which to ingest.</param>
        /// <param name="deleteFilesOnSuccess">Whether to delete files upon successful ingestion.</param>
        /// <param name="checkForIngestionErrors">Whether to check for ingestion errors before disposing this object.</param>
        /// <param name="log">Optional log to which to write some debug information.</param>
        public KustoUploader
            (
            string connectionString,
            string database,
            string table,
            bool deleteFilesOnSuccess,
            bool checkForIngestionErrors,
            ILog log = null
            )
        {
            _log = log;
            _deleteFilesOnSuccess = deleteFilesOnSuccess;
            _checkForIngestionErrors = checkForIngestionErrors;
            _client = KustoIngestFactory.CreateQueuedIngestClient(connectionString);
            _ingestionProperties = new KustoQueuedIngestionProperties(database, table)
            {
                ReportLevel = IngestionReportLevel.FailuresOnly,
                ReportMethod = IngestionReportMethod.Queue
            };
            _block = new ActionBlock<FileDescription>
                (
                    (fileDesc) =>
                    {
                        var start = DateTime.UtcNow;
                        var result = _client.IngestFromSingleFile(fileDesc, _deleteFilesOnSuccess, _ingestionProperties);
                        var duration = DateTime.UtcNow.Subtract(start);

                        Info("Ingesting file '{0}' took {1}", fileDesc.FilePath, duration);
                    },
                    new ExecutionDataflowBlockOptions()
                    {
                        MaxDegreeOfParallelism = 1,
                        BoundedCapacity = DataflowBlockOptions.Unbounded
                    }
                );
        }

        /// <summary>
        ///     Posts <paramref name="filePath"/> for ingestion and returns immediately.
        /// </summary>
        public void PostFileForIngestion(string filePath, Guid sourceId)
        {
            Info("Posting file '{0}' for ingestion", filePath);
            _block.Post(new FileDescription
            {
                FilePath = filePath,
                SourceId = sourceId
            });
        }

        /// <summary>
        ///     Synchronously waits until all posted files for ingestion complete.
        /// </summary>
        /// <returns>Whether any ingestion failures were encountered.</returns>
        public bool WaitForCompletion()
        {
            if (_block.Completion.IsCompleted)
            {
                return true;
            }

            _block.Complete();

            var start = DateTime.UtcNow;
            _block.Completion.GetAwaiter().GetResult();
            var duration = DateTime.UtcNow.Subtract(start);
            Info("Waited {0} for queued ingestion tasks to complete", duration);

            return CheckForIngestionFailuresIfNeeded();
        }

        /// <summary>
        ///     Synchronously waits until all posted files for ingestion complete, then disposes the internal Kusto client.
        /// </summary>
        public void Dispose()
        {
            WaitForCompletion();
            _client.Dispose();
        }

        private bool CheckForIngestionFailuresIfNeeded()
        {
            if (!_checkForIngestionErrors)
            {
                return true;
            }

            var start = DateTime.UtcNow;
            var ingestionFailures = _client.GetAndDiscardTopIngestionFailures().GetAwaiter().GetResult().ToList();
            var duration = DateTime.UtcNow.Subtract(start);
            Info("Checking for ingestion failures took {0}", duration);

            if (ingestionFailures.Any() && _log != null)
            {
                var failures = ingestionFailures.Select(f => $"{Environment.NewLine}  {RenderIngestionFailure(f)}");
                Error("The following ingestions failed:{0}", string.Join(string.Empty, failures));
            }

            return ingestionFailures.Count == 0;
        }

        private string RenderIngestionFailure(IngestionFailure f)
        {
            return $"File: {f.Info.IngestionSourcePath}, Status: {f.Info.FailureStatus}, Error code: {f.Info.ErrorCode}, Details: {f.Info.Details}";
        }

        private void Info(string format, params object[] args) => Log(Severity.Always, format, args);
        private void Error(string format, params object[] args) => Log(Severity.Error, format, args);

        private void Log(Severity severity, string format, params object[] args)
        {
            if (_log == null)
            {
                return;
            }

            var message = string.Format(CultureInfo.InvariantCulture, format, args);
            _log.Write(DateTime.UtcNow, Environment.CurrentManagedThreadId, severity, message);
        }
    }
}
