// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Diagnostics.ContractsLight;
using System.IO;
using System.Linq;
using BuildXL.Pips.Operations;
using BuildXL.Utilities;
using BuildXL.Utilities.Collections;

namespace BuildXL.Processes
{
    /// <summary>
    /// TODO 
    /// </summary>
    /// <remarks>
    /// NOTE: not thread-safe
    /// </remarks>
    public sealed class SharedOpaqueJournal : IDisposable
    {
        private readonly PipExecutionContext m_context;
        private readonly DirectoryArtifact[] m_sharedOpaqueDirectories;
        private readonly string m_journalPath;
        private readonly BuildXLWriter m_bxlWriter;

        /// <nodoc />
        public SharedOpaqueJournal(Process process, PipExecutionContext context, AbsolutePath journalDirectory)
        {
            Contract.Requires(process != null);
            Contract.Requires(context != null);
            Contract.Requires(journalDirectory.IsValid);
            Contract.Requires(Directory.Exists(journalDirectory.ToString(context.PathTable)));

            m_context = context;
            m_sharedOpaqueDirectories = process.DirectoryOutputs.Where(d => d.IsSharedOpaque).ToArray();

            m_journalPath = Path.Combine(journalDirectory.ToString(context.PathTable), process.FormattedSemiStableHash);
            m_bxlWriter = new BuildXLWriter(
                stream: new FileStream(m_journalPath, FileMode.Create, FileAccess.Write, FileShare.Read | FileShare.Delete),
                debug: false,
                logStats: false,
                leaveOpen: false);
        }

        /// <summary>
        /// Finds and returns all journal files that exist in directory denoted by <paramref name="directory"/>
        /// </summary>
        public static IEnumerable<string> FindAllJournalFiles(string directory)
        {
            return Directory.Exists(directory)
                ? Directory.EnumerateFiles(directory, "*", SearchOption.TopDirectoryOnly)
                : CollectionUtilities.EmptyArray<string>();
        }

        /// <summary>
        /// Returns all paths recorded in the journal file <paramref name="journalFile"/>.
        /// </summary>
        /// <remarks>
        /// Those paths are expected to be absolute paths of files/directories that were written to by the previous build.
        ///
        /// NOTE: this method does not validate the recorded paths in any way.  That means that each returned string may be
        ///   - an invalid path
        ///   - a path pointing to an absent file
        ///   - a path pointing to a file
        ///   - a path poiting to a directory.
        ///
        /// NOTE: the strings in the returned enumerable are neither sorted nor deduplicated.
        /// </remarks>
        public static IEnumerable<string> ReadRecordedWritesFromJournal(string journalFile)
        {
            using (var fileStream = new FileStream(journalFile, FileMode.Open, FileAccess.Read, FileShare.Read | FileShare.Delete))
            using (var bxlReader = new BuildXLReader(stream: fileStream, debug: false, leaveOpen: false))
            {
                string nextString = null;
                while ((nextString = ReadStringOrNull(bxlReader)) != null)
                {
                    yield return nextString;
                }
            }
        }

        private static string ReadStringOrNull(BuildXLReader bxlReader)
        {
            try
            {
                return bxlReader.ReadString();
            }
            catch (IOException)
            {
                return null;
            }
        }

        /// <summary>
        /// Records that the file at location <paramref name="path"/> was written to.
        /// </summary>
        /// <remarks>
        /// NOT THREAD-SAFE.
        /// </remarks>
        public void RecordFileWrite(AbsolutePath path)
        {
            bool isUnderSharedOpaqueDirectory = m_sharedOpaqueDirectories.Any(d => path.IsWithin(m_context.PathTable, d.Path));
            if (!isUnderSharedOpaqueDirectory)
            {
                return;
            }

            m_bxlWriter.Write(path.ToString(m_context.PathTable));
            m_bxlWriter.Flush();
        }

        /// <nodoc />
        public void Dispose()
        {
            m_bxlWriter?.Dispose();
        }
    }
}