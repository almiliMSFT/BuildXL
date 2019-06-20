// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Diagnostics.ContractsLight;
using System.Globalization;
using System.Linq;
using System.Text;
using BuildXL.Cache.ContentStore.Interfaces.Logging;
using BuildXL.Utilities;

namespace BuildXL.Cache.ContentStore.Logging
{
    /// <summary>
    ///     TODO
    /// </summary>
    public sealed class KustoUploader : IDisposable
    {
        private readonly IKustoQueuedIngestClient _client;
        private readonly KustoQueuedIngestionProperties _ingestionProperties;

        public KustoUploader(string connectionString, string database, string table)
        {
            _client = KustoIngestFactory.CreateQueuedIngestClient(cs);
            _ingestionProperties = new KustoQueuedIngestionProperties(database, table)
            {
                ReportLevel = IngestionReportLevel.FailuresOnly,
                ReportMethod = IngestionReportMethod.Queue
            };
        }

        public void IngestSingleFile(string fullFilePath, bool deleteFileOnSuccess = true)
        {
            _client.IngestSingleFile(fullFilePath, deleteFileOnSuccess, _ingestionProperties);
        }

        public void Dispose()
        {
            _client.Dispose();
        }
    }
}