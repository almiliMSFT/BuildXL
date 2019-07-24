// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using BuildXL.Engine;
using BuildXL.FrontEnd.Script;
using BuildXL.FrontEnd.Script.Debugger;
using BuildXL.Pips;
using BuildXL.Scheduler.Graph;
using BuildXL.Utilities;
using static BuildXL.FrontEnd.Script.Debugger.Matcher;

namespace BuildXL.Execution.Analyzer
{
    /// <summary>
    /// Global XLG state (where all pips, artifacts, etc. are displayed)
    /// </summary>
    public class XlgThreadState : ThreadState
    {
        private CachedGraph CachedGraph { get; }

        private AnalysisInput Input { get; }

        private PipGraph PipGraph => CachedGraph.PipGraph;

        private PathTable PathTable => CachedGraph.Context.PathTable;

        private StringTable StringTable => PathTable.StringTable;

        /// <inheritdoc />
        public override IReadOnlyList<DisplayStackTraceEntry> StackTrace { get; }

        /// <nodoc />
        public XlgThreadState(AnalysisInput input, CachedGraph cachedGraph)
            : base(0)
        {
            Input = input;
            CachedGraph = cachedGraph;

            var logFile = Path.Combine(Path.GetDirectoryName(input.ExecutionLogPath), "BuildXL.log");

            StackTrace = new[]
            {
                new DisplayStackTraceEntry(file: logFile, line: 1, position: 1, functionName: "<main>", entry: null)
            };
        }

        /// <inheritdoc />
        public override string ThreadName() => "Full XLG";

        /// <inheritdoc />
        public override IEnumerable<ObjectContext> GetSupportedScopes(int frameIndex)
        {
            return new[]
            {
                new ObjectContext(context: this, obj: CachedGraph)
            };
        }


        /// <nodoc />
        public ObjectInfo Render(Renderer renderer, object ctx, object obj)
        {
            return Match(obj, new CaseMatcher<ObjectInfo>[]
                {
                    Case<CachedGraph>(CachedGraphInfo),
                    Case<PipsScope>(PipsInfo),
                    Case<FileArtifact>(FileArtifactInfo),
                    Case<DirectoryArtifact>(DirectoryArtifactInfo),
                    Case<PipId>(pipId => renderer.GetObjectInfo(ctx, obj: CachedGraph.PipTable.HydratePip(pipId, PipQueryContext.Explorer)))
                },
                defaultResult: null);
        }

        private static readonly Type s_pipTypeType = typeof(Pips.Operations.PipType);

        private ObjectInfo FileArtifactInfo(FileArtifact f)
        {
            if (!f.IsValid)
            {
                return new ObjectInfo("Invalid");
            }

            var name = f.Path.GetName(PathTable).ToString(StringTable);
            var kind = f.IsSourceFile ? "source" : "output";
            return new ObjectInfo(
                preview: $"{name} [{kind}]", 
                properties: new[]
                {
                    new Property("Path", f.Path.ToString(PathTable)),
                    new Property("Rewrite Count", f.RewriteCount),
                    f.IsOutputFile ? new Property("Producer", PipGraph.GetProducer(f)) : null,
                    new Property("Consumers", PipGraph.GetConsumingPips(f.Path))
                }
                .Where(p => p != null).ToArray());
        }

        private ObjectInfo DirectoryArtifactInfo(DirectoryArtifact d)
        {
            if (!d.IsValid)
            {
                return new ObjectInfo("Invalid");
            }

            var name = d.Path.GetName(PathTable).ToString(StringTable);
            var kind = d.IsSharedOpaque ? "shared opaque" : d.IsOutputDirectory() ? "exclusive opaque" : "source";
            return new ObjectInfo(
                preview: $"{name} [{kind}]",
                properties: new[]
                {
                    new Property("Path", d.Path.ToString(PathTable)),
                    new Property("PartialSealId", d.PartialSealId),
                    d.IsOutputDirectory() ? new Property("Producer", PipGraph.GetProducer(d)) : null,
                    new Property("Consumers", PipGraph.GetConsumingPips(d.Path)),
                    d.PartialSealId > 0 ? new Property("Members", PipGraph.ListSealedDirectoryContents(d)) : null
                }
                .Where(p => p != null));
        }

        private ObjectInfo PipsInfo(PipsScope _)
        {
            return new ObjectInfo(
                preview: "",
                properties: Enum
                    .GetValues(s_pipTypeType)
                    .Cast<Pips.Operations.PipType>()
                    .Select(pipType => new Property(Enum.GetName(s_pipTypeType, pipType), CachedGraph.PipGraph.RetrievePipsOfType(pipType)))
                );
        }

        private ObjectInfo CachedGraphInfo(CachedGraph graph)
        {
            return new ObjectInfo(
                preview: "Graph",
                properties: new[]
                {
                    new Property(name: $"Pips", value: new PipsScope()),
                    new Property(name: $"Files", value: GroupFiles(PipGraph.AllFiles)),
                    new Property(name: $"Seal Directories", value: GroupDirs(PipGraph.AllSealDirectories)),
                    new Property(name: $"Output Directories", value: GroupDirs(PipGraph.AllOutputDirectoriesAndProducers.Select(kvp => kvp.Key)))
                });
        }

        private ObjectInfo GroupFiles(IEnumerable<FileArtifact> files)
        {
            return new ObjectInfo(properties: new[]
            {
                new Property("Source Files", GroupByFirstFileNameLetter(files.Where(f => f.IsSourceFile), f => f.Path)),
                new Property("Output Files", GroupByFirstFileNameLetter(files.Where(f => f.IsOutputFile), f => f.Path))
            });
        }

        private ObjectInfo GroupDirs(IEnumerable<DirectoryArtifact> dirs)
        {
            return new ObjectInfo(properties: new[]
            {
                new Property("Source Dirs", GroupByFirstFileNameLetter(dirs.Where(d => !d.IsOutputDirectory()), d => d.Path)),
                new Property("Exclusive Opaque Dirs", GroupByFirstFileNameLetter(dirs.Where(d => d.IsOutputDirectory() && !d.IsSharedOpaque), d => d.Path)),
                new Property("Shared Opaque Dirs", GroupByFirstFileNameLetter(dirs.Where(d => d.IsSharedOpaque), d => d.Path))
            });
        }

        private ObjectInfo GroupByFirstFileNameLetter<T>(IEnumerable<T> elems, Func<T, AbsolutePath> toPath)
        {
            var properties = elems
                .GroupBy(t => "'" + toPath(t).GetName(PathTable).ToString(StringTable)[0].ToUpperInvariantFast() + "'")
                .OrderBy(grp => grp.Key)
                .Select(grp => new Property(name: grp.Key, value: grp.ToArray()));

            return new ObjectInfo(properties: properties);
        }

        private static CaseMatcher<T, ObjectInfo> Case<T>(Func<T, ObjectInfo> func)
        {
            return Case<T, ObjectInfo>(func);
        }

        private class PipsScope { }
        private class FilesScope { }
    }
}
