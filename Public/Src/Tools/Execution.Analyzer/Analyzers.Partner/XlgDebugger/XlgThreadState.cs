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
using BuildXL.Pips.Operations;
using BuildXL.Scheduler.Graph;
using BuildXL.Utilities;
using static BuildXL.FrontEnd.Script.Debugger.Matcher;
using static BuildXL.FrontEnd.Script.Debugger.Renderer;

namespace BuildXL.Execution.Analyzer
{
    /// <summary>
    /// Global XLG state (where all pips, artifacts, etc. are displayed)
    /// </summary>
    public class XlgState : ThreadState, IExpressionEvaluator
    {
        private const string ExeLevelNotCompleted = "NotCompleted";
        private const int XlgThreadId = 1;

        private DebugLogsAnalyzer Analyzer { get; }

        private CachedGraph CachedGraph => Analyzer.CachedGraph;

        private PipGraph PipGraph => CachedGraph.PipGraph;

        private PathTable PathTable => CachedGraph.Context.PathTable;

        private StringTable StringTable => PathTable.StringTable;

        private ObjectInfo PipsByType { get; }
        private ObjectInfo PipsByStatus { get; }


        /// <inheritdoc />
        public override IReadOnlyList<DisplayStackTraceEntry> StackTrace { get; }

        /// <nodoc />
        public XlgState(DebugLogsAnalyzer analyzer)
            : base(XlgThreadId)
        {
            Analyzer = analyzer;

            var logFile = Path.Combine(Path.GetDirectoryName(Analyzer.Input.ExecutionLogPath), "BuildXL.log");
            StackTrace = new[]
            {
                new DisplayStackTraceEntry(file: logFile, line: 1, position: 1, functionName: "<main>", entry: null)
            };

            PipsByType = new ObjectInfo(Lazy.Create(() =>
            {
                return new[] 
                    {
                        PipType.Process, PipType.SealDirectory, PipType.CopyFile, PipType.WriteFile, PipType.Ipc, PipType.Module, PipType.Value, PipType.HashSourceFile
                    }
                    .Select(pipType => new Property(name: pipType.ToString(), value: PipGraph.RetrievePipReferencesOfType(pipType)));
            }));

            PipsByStatus = new ObjectInfo(Lazy.Create(() =>
            {
                return PipGraph
                    .RetrievePipReferencesOfType(PipType.Process)
                    .GroupBy(pipRef => Analyzer.GetPipExePerf(pipRef.PipId)?.ExecutionLevel.ToString() ?? ExeLevelNotCompleted)
                    .Select(grp => new Property(grp.Key, grp.ToArray()));
            }));
        }

        #region Expression Evaluator

        /// <inheritdoc />
        public Possible<ObjectContext, Failure> EvaluateExpression(ThreadState threadState, int frameIndex, string expr)
        {
            if (Pip.TryParseSemiStableHash(expr, out var hash) && Analyzer.SemiStableHash2Pip.TryGetValue(hash, out var pipId))
            {
                return new ObjectContext(context: this, Analyzer.AsPipReference(pipId));
            }

            string translatedPath = Analyzer.Session.TranslateUserPath(expr);
            if (AbsolutePath.TryCreate(PathTable, translatedPath, out var path) && path.IsValid)
            {
                return new ObjectContext(context: this, new AnalyzePath(path));
            }

            return new Failure<string>($"Can't parse expression '{expr}'");
        }

        #endregion

        /// <inheritdoc />
        public override string ThreadName() => "Full XLG";

        /// <inheritdoc />
        public override IEnumerable<ObjectContext> GetSupportedScopes(int frameIndex)
        {
            return new[]
            {
                new ObjectContext(context: this, obj: new ObjectInfo(preview: "Global Scope", properties: new[]
                    {
                        new Property(name: $"Pips", value: new PipsScope()),
                        new Property(name: $"Files", value: GroupFiles(PipGraph.AllFiles)),
                        new Property(name: $"Seal Directories", value: GroupDirs(PipGraph.AllSealDirectories)),
                        new Property(name: $"Output Directories", value: GroupDirs(PipGraph.AllOutputDirectoriesAndProducers.Select(kvp => kvp.Key)))
                    }))
            };
        }


        /// <nodoc />
        public ObjectInfo Render(Renderer renderer, object ctx, object obj)
        {
            switch (obj)
            {
                case PipsScope ps:                 return PipsInfo(ps);
                case AbsolutePath p:               return new ObjectInfo(Analyzer.Session.TranslateBuildXLPath(p.ToString(PathTable)));
                case FileArtifact f:               return FileArtifactInfo(f);
                case DirectoryArtifact d:          return DirectoryArtifactInfo(d);
                case AnalyzePath ap:               return AnalyzePathInfo(ap);
                case PipId pipId:                  return Render(renderer, ctx, Analyzer.GetPip(pipId)).WithPreview(pipId.ToString());
                case PipReference pipRef:          return Render(renderer, ctx, Analyzer.GetPip(pipRef.PipId));
                case Process proc:                 return ProcessInfo(proc);
                case Pip pip:                      return GenericObjectInfo(pip, preview: PipPreview(pip));
                case FileArtifactWithAttributes f: return GenericObjectInfo(f, preview: FileArtifactPreview(f.ToFileArtifact()));
                default:
                    return null;
            }
        }

        private ObjectInfo AnalyzePathInfo(AnalyzePath ap)
        {
            var props = new List<Property>()
            {
                new Property("Path", ap.Path)
            };

            var latestFileArtifact = PipGraph.TryGetLatestFileArtifactForPath(ap.Path);
            if (latestFileArtifact.IsValid)
            {
                props.Add(new Property("LastestFileArtifact", latestFileArtifact));
            }

            var dirArtifact = PipGraph.TryGetDirectoryArtifactForPath(ap.Path);
            if (dirArtifact.IsValid)
            {
                props.Add(new Property("DirectoryArtifact", dirArtifact));
            }

            return new ObjectInfo(props);
        }

        private string PipPreview(Pip pip)
        {
            return $"<{pip.PipType.ToString().ToUpperInvariant()}> {pip.GetShortDescription(PipGraph.Context)}";
        }

        private ObjectInfo ProcessInfo(Process proc)
        {
            return new ObjectInfo(preview: PipPreview(proc), properties: Lazy.Create(() =>
            {
                var pipExePerf = Analyzer.GetPipExePerf(proc.PipId);
                return new[]
                {
                    new Property("PipType", proc.PipType),
                    new Property("SemiStableHash", proc.SemiStableHash),
                    new Property("Description", proc.GetDescription(PipGraph.Context)),
                    new Property("ExecutionLevel", pipExePerf?.ExecutionLevel.ToString() ?? ExeLevelNotCompleted),
                    new Property("EXE", proc.Executable),
                    new Property("CMD", Analyzer.RenderProcessArguments(proc)),
                    new Property("Inputs", new ObjectInfo(properties: new[]
                    {
                        new Property("Files", proc.Dependencies),
                        new Property("Directories", proc.DirectoryDependencies)
                    })),
                    new Property("Outputs", new ObjectInfo(properties: new[]
                    {
                        new Property("Files", proc.FileOutputs),
                        new Property("Directories", proc.DirectoryOutputs)
                    })),
                    new Property("ExecutionPerformance", pipExePerf),
                    new Property("GenericInfo", GenericObjectInfo(proc, preview: ""))
                };
            }));
        }

        private string FileArtifactPreview(FileArtifact f)
        {
            var name = f.Path.GetName(PathTable).ToString(StringTable);
            var kind = f.IsSourceFile ? "source" : "output";
            return $"{name} [{kind}]";
        }

        private ObjectInfo FileArtifactInfo(FileArtifact f)
        {
            if (!f.IsValid)
            {
                return new ObjectInfo("Invalid");
            }

            return new ObjectInfo(
                preview: FileArtifactPreview(f), 
                properties: Lazy.Create(() => new[]
                {
                    new Property("Path", f.Path.ToString(PathTable)),
                    new Property("Rewrite Count", f.RewriteCount),
                    f.IsOutputFile ? new Property("Producer", PipGraph.GetProducer(f)) : null,
                    new Property("Consumers", PipGraph.GetConsumingPips(f.Path))
                }
                .Where(p => p != null)));
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
                properties: Lazy.Create(() => new[]
                {
                    new Property("Path", d.Path.ToString(PathTable)),
                    new Property("PartialSealId", d.PartialSealId),
                    d.IsOutputDirectory() ? new Property("Producer", PipGraph.GetProducer(d)) : null,
                    new Property("Consumers", PipGraph.GetConsumingPips(d.Path)),
                    d.PartialSealId > 0 ? new Property("Members", PipGraph.ListSealedDirectoryContents(d)) : null
                }
                .Where(p => p != null)));
        }

        private ObjectInfo PipsInfo(PipsScope _)
        {
            return new ObjectInfo(new[]
            {
                new Property("ByType", PipsByType),
                new Property("ByStatus", PipsByStatus),
                new Property("ByExecutionStart", Analyzer.Pip2Perf.OrderBy(kvp => kvp.Value.ExecutionStart).Select(kvp => Analyzer.AsPipReference(kvp.Key))),
                new Property("ByExecutionStop", Analyzer.Pip2Perf.OrderBy(kvp => kvp.Value.ExecutionStop).Select(kvp => Analyzer.AsPipReference(kvp.Key))),
            });
        }

        private ObjectInfo GroupFiles(IEnumerable<FileArtifact> files)
        {
            return new ObjectInfo(properties: Lazy.Create(() => new[]
            {
                new Property("Source Files", GroupByFirstFileNameLetter(files.Where(f => f.IsSourceFile), f => f.Path)),
                new Property("Output Files", GroupByFirstFileNameLetter(files.Where(f => f.IsOutputFile), f => f.Path))
            }));
        }

        private ObjectInfo GroupDirs(IEnumerable<DirectoryArtifact> dirs)
        {
            return new ObjectInfo(properties: Lazy.Create(() => new[]
            {
                new Property("Source Dirs", GroupByFirstFileNameLetter(dirs.Where(d => !d.IsOutputDirectory()), d => d.Path)),
                new Property("Exclusive Opaque Dirs", GroupByFirstFileNameLetter(dirs.Where(d => d.IsOutputDirectory() && !d.IsSharedOpaque), d => d.Path)),
                new Property("Shared Opaque Dirs", GroupByFirstFileNameLetter(dirs.Where(d => d.IsSharedOpaque), d => d.Path))
            }));
        }

        private ObjectInfo GroupByFirstFileNameLetter<T>(IEnumerable<T> elems, Func<T, AbsolutePath> toPath)
        {
            var properties = Lazy.Create(() => elems
                .GroupBy(t => "'" + toPath(t).GetName(PathTable).ToString(StringTable)[0].ToUpperInvariantFast() + "'")
                .OrderBy(grp => grp.Key)
                .Select(grp => new Property(name: grp.Key, value: grp.ToArray())));

            return new ObjectInfo(properties: properties);
        }

        private static CaseMatcher<T, ObjectInfo> Case<T>(Func<T, ObjectInfo> func)
        {
            return Case<T, ObjectInfo>(func);
        }

        private class PipsScope { }
        private class FilesScope { }
        private class AnalyzePath
        {
            internal AbsolutePath Path { get; }
            internal AnalyzePath(AbsolutePath path)
            {
                Path = path;
            }
        }
    }
}
