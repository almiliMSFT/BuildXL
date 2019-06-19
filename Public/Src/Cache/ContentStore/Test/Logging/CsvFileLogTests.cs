// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using BuildXL.Cache.ContentStore.FileSystem;
using BuildXL.Cache.ContentStore.Logging;
using BuildXL.Cache.ContentStore.Interfaces.Extensions;
using BuildXL.Cache.ContentStore.Interfaces.FileSystem;
using BuildXL.Cache.ContentStore.Interfaces.Logging;
using ContentStoreTest.Test;
using FluentAssertions;
using Xunit;

namespace ContentStoreTest.Logging
{
    public class CsvFileLogTests : TestBase
    {
        public CsvFileLogTests()
            : base(() => new PassThroughFileSystem(TestGlobal.Logger), NullLogger.Instance)
        {
        }

        [Fact]
        public void TestRenderSchema()
        {
            string logFile = Path.Combine(Path.GetTempPath(), GetRandomFileName());
            using (var log = new CsvFileLog(logFile, schema))
            {
                File.Exists(log.FilePath).Should().BeTrue();
                log.FilePath.Should().StartWith(Path.GetTempPath());
            }
        }
    }
}
