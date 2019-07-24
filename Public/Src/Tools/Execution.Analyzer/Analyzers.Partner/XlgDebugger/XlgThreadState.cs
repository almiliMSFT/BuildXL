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
                preview: $"{name} ({f.RewriteCount}) [{kind}]", 
                properties: new[]
                {
                    new Property("Path", f.Path),
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
                preview: $"{name} ({d.PartialSealId}) [{kind}]",
                properties: new[]
                {
                    new Property("Path", d.Path),
                    d.IsOutputDirectory() ? new Property("Producer", PipGraph.GetProducer(d)) : null,
                    new Property("Consumers", PipGraph.GetConsumingPips(d.Path))
                }
                .Where(p => p != null).ToArray());
        }

        private ObjectInfo PipsInfo(PipsScope _)
        {
            return new ObjectInfo(
                preview: "",
                properties: Enum
                    .GetValues(s_pipTypeType)
                    .Cast<Pips.Operations.PipType>()
                    .Select(pipType => new Property(Enum.GetName(s_pipTypeType, pipType), CachedGraph.PipGraph.RetrievePipsOfType(pipType)))
                    .ToList()
                );
        }

        private ObjectInfo CachedGraphInfo(CachedGraph graph)
        {
            return new ObjectInfo(
                preview: "Graph",
                properties: new[]
                {
                    new Property(name: $"Pips", value: new PipsScope()),
                    new Property(name: $"Files", value: GroupByFirstFileNameLetter(PipGraph.AllFiles, f => f.Path)),
                    new Property(name: $"Seal Directories", value: GroupByFirstFileNameLetter(PipGraph.AllSealDirectories, d => d.Path)),
                    new Property(name: $"Output Directories", value: GroupByFirstFileNameLetter(PipGraph.AllOutputDirectoriesAndProducers.Select(kvp => kvp.Key), d => d.Path)),
                });
        }

        private ObjectInfo GroupByFirstFileNameLetter<T>(IEnumerable<T> allFiles, Func<T, AbsolutePath> toPath)
        {
            var properties = allFiles
                .GroupBy(t => "'" + toPath(t).GetName(PathTable).ToString(StringTable)[0].ToUpperInvariantFast() + "'")
                .OrderBy(grp => grp.Key)
                .Select(grp => new Property(name: grp.Key, value: grp.ToArray()))
                .ToList();

            return new ObjectInfo(properties: properties);
        }

        private IDictionary<char, T[]> GroupByFirstFileNameLetter2<T>(IEnumerable<T> allFiles, Func<T, AbsolutePath> toPath)
        {
            IDictionary<char, T[]> dict = allFiles
                .GroupBy(t => toPath(t).GetName(PathTable).ToString(StringTable)[0].ToUpperInvariantFast())
                .ToDictionary(grp => grp.Key, grp => grp.OrderBy(t => toPath(t).ToString(PathTable).ToUpperInvariant()).ToArray());
            return new SortedDictionary<char, T[]>(dict);
        }

        private static CaseMatcher<T, ObjectInfo> Case<T>(Func<T, ObjectInfo> func)
        {
            return Case<T, ObjectInfo>(func);
        }

        private class PipsScope { }
        private class FilesScope { }
    }
}
