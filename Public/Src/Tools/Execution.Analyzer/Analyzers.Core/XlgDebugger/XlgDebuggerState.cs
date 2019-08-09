﻿// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using BuildXL.Engine;
using BuildXL.Execution.Analyzer.JPath;
using BuildXL.FrontEnd.Script;
using BuildXL.FrontEnd.Script.Debugger;
using BuildXL.Pips;
using BuildXL.Pips.Operations;
using BuildXL.Scheduler.Graph;
using BuildXL.Utilities;
using BuildXL.Utilities.Collections;
using static BuildXL.Execution.Analyzer.JPath.Evaluator;
using static BuildXL.FrontEnd.Script.Debugger.Renderer;

using ProcessMonitoringData = BuildXL.Scheduler.Tracing.ProcessExecutionMonitoringReportedEventData;

namespace BuildXL.Execution.Analyzer
{
    /// <summary>
    /// Global XLG state (where all pips, artifacts, etc. are displayed)
    /// </summary>
    public class XlgDebuggerState : ThreadState, IExpressionEvaluator
    {
        private const string ExeLevelNotCompleted = "NotCompleted";
        private const int XlgThreadId = 1;

        private readonly Evaluator m_evaluator = new Evaluator();

        private DebugLogsAnalyzer Analyzer { get; }

        private CachedGraph CachedGraph => Analyzer.CachedGraph;

        private PipGraph PipGraph => CachedGraph.PipGraph;

        private PathTable PathTable => CachedGraph.Context.PathTable;

        private StringTable StringTable => PathTable.StringTable;

        private ObjectInfo PipsByType { get; }

        private ObjectInfo PipsByStatus { get; }

        private ObjectInfo[] SupportedScopes { get; }

        private Function[] LibraryFunctions { get; }

        private Env RootEnv { get; }

        /// <inheritdoc />
        public override IReadOnlyList<DisplayStackTraceEntry> StackTrace { get; }

        /// <nodoc />
        public XlgDebuggerState(DebugLogsAnalyzer analyzer)
            : base(XlgThreadId)
        {
            Analyzer = analyzer;

            var logFile = Path.Combine(Path.GetDirectoryName(Analyzer.Input.ExecutionLogPath), "BuildXL.log");
            StackTrace = new[]
            {
                new DisplayStackTraceEntry(file: logFile, line: 1, position: 1, functionName: "<main>", entry: null)
            };

            PipsByType = new ObjectInfo(Enum
                .GetValues(typeof(PipType))
                .Cast<PipType>()
                .Except(new[] { PipType.Max })
                .Select(pipType => new Property(pipType.ToString(), () => PipGraph.RetrievePipReferencesOfType(pipType).ToArray())));

            PipsByStatus = new ObjectInfo(Enum
                .GetValues(typeof(PipExecutionLevel))
                .Cast<PipExecutionLevel>()
                .Select(level => level.ToString())
                .Concat(new[] { ExeLevelNotCompleted })
                .Select(levelStr => new Property(levelStr, () => GetPipsForExecutionLevel(levelStr))));

            LibraryFunctions = new[]
            {
                new Function(name: "sum",   minArity: 1, maxArity: 1, func: (args) => args[0].Select(obj => args.Eval.ToInt(obj)).Sum()),
                new Function(name: "count", minArity: 1, maxArity: 1, func: (args) => args[0].Count),
                new Function(name: "uniq",  minArity: 1, maxArity: 1, func: (args) => args[0].GroupBy(obj => args.Eval.PreviewObj(obj)).Select(grp => grp.First()).ToArray()),
                new Function(name: "sort",  minArity: 1, maxArity: 1, func: (args) => args[0].OrderBy(obj => args.Eval.PreviewObj(obj)).ToArray()),
                new Function(name: "grep",  minArity: 2, maxArity: 2, func: (args) => args[1].Select(obj => args.Eval.PreviewObj(obj)).Where(str => args.Eval.Matches(str, args[0])).ToArray()),
                new Function(name: "join",  minArity: 1, maxArity: 1, func: (args) =>
                {
                    return string.Join(Environment.NewLine, args[0].Select(obj => args.Eval.PreviewObj(obj)));
                }),
            };

            SupportedScopes = new[]
            {
                new ObjectInfo(preview: "Global", properties: new[]
                {
                    new Property("Pips",          () => PipGraph.RetrieveAllPips()),
                    new Property("Files",         () => PipGraph.AllFiles),
                    new Property("Directories",   () => PipGraph.AllSealDirectories),
                    //new Property("CriticalPath",  new AnalyzeCricialPath()),
                    new Property("GroupedBy",     new ObjectInfo(new[]
                    {
                        new Property("Pips",          new PipsScope()),
                        new Property("Files",         () => GroupFiles(PipGraph.AllFiles)),
                        new Property("Directories",   () => GroupDirs(PipGraph.AllSealDirectories))
                    }))
                })
            };

            RootEnv = new Env(
                objectResolver: (obj) => Analyzer.Session.Renderer.GetObjectInfo(context: this, obj),
                root: new ObjectInfo(
                    preview: "$", 
                    properties: Concat(
                        SupportedScopes.Select(obj => new Property(obj.Preview, obj)),
                        SupportedScopes.SelectMany(obj => obj.Properties),
                        LibraryFunctions.Select(func => new Property(func.Name, func)))));
        }

        private IEnumerable<T> Concat<T>(params IEnumerable<T>[] list)
        {
            return list.Aggregate((acc, current) => acc != null ? acc.Concat(current) : current);
        }

        private PipReference[] GetPipsForExecutionLevel(string level)
        {
            return PipGraph
                .RetrievePipReferencesOfType(PipType.Process)
                .Where(pipRef => GetPipExecutionLevel(pipRef.PipId) == level)
                .ToArray();
        }

        private string GetPipExecutionLevel(PipId pipId) => GetPipExecutionLevel(Analyzer.TryGetPipExePerf(pipId));

        private string GetPipExecutionLevel(PipExecutionPerformance exePerf)
        {
            return exePerf == null
                ? ExeLevelNotCompleted
                : exePerf.ExecutionLevel.ToString();
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

            
            var maybeResult = JPath.JPath.TryEval(RootEnv, expr, m_evaluator);
            if (maybeResult.Succeeded)
            {
                return new ObjectContext(
                    this, 
                    maybeResult.Result.Count == 1 
                        ? maybeResult.Result.First()
                        : maybeResult.Result.Value.ToArray());
            }
            else
            {
                return maybeResult.Failure;
            }
        }

        #endregion

        /// <inheritdoc />
        public override string ThreadName() => "Full XLG";

        /// <inheritdoc />
        public override IEnumerable<ObjectContext> GetSupportedScopes(int frameIndex)
        {
            return SupportedScopes.Select(obj => new ObjectContext(this, obj));
        }

        /// <nodoc />
        public ObjectInfo Render(Renderer renderer, object ctx, object obj)
        {
            switch (obj)
            {
                case AbsolutePath p:               return new ObjectInfo(p.ToString(PathTable));
                case PipsScope ps:                 return PipsInfo(ps);
                case FileArtifact f:               return FileArtifactInfo(f);
                case DirectoryArtifact d:          return DirectoryArtifactInfo(d);
                case AnalyzePath ap:               return AnalyzePathInfo(ap);
                case AnalyzeCricialPath cp:        return AnalyzeCricialPathInfo();
                case PipId pipId:                  return Render(renderer, ctx, Analyzer.GetPip(pipId)).WithPreview(pipId.ToString());
                case PipReference pipRef:          return Render(renderer, ctx, Analyzer.GetPip(pipRef.PipId));
                case Process proc:                 return ProcessInfo(proc);
                case Pip pip:                      return GenericObjectInfo(pip, preview: PipPreview(pip));
                case FileArtifactWithAttributes f: return GenericObjectInfo(f, preview: FileArtifactPreview(f.ToFileArtifact()));
                case ProcessMonitoringData m:      return ProcessMonitoringInfo(m);
                case string s:                     return new ObjectInfo(s);
                default:
                    return null;
            }
        }

        private ObjectInfo AnalyzeCricialPathInfo()
        {
            return GenericObjectInfo(Analyzer.CriticalPath, preview: "");
        }

        private ObjectInfo ProcessMonitoringInfo(ProcessMonitoringData m)
        {
            return GenericObjectInfo(m, excludeProperties: new[] { "PipId", "Metadata" });
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
            var pipExePerf = Analyzer.TryGetPipExePerf(proc.PipId);
            return new ObjectInfo(preview: PipPreview(proc), properties: new[]
            {
                new Property("PipType", proc.PipType),
                new Property("SemiStableHash", proc.SemiStableHash),
                new Property("Description", proc.GetDescription(PipGraph.Context)),
                new Property("ExecutionLevel", GetPipExecutionLevel(pipExePerf)),
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
                new Property("MonitoringData", () => Analyzer.TryGetProcessMonitoringData(proc.PipId)),
                new Property("GenericInfo", () => GenericObjectInfo(proc, preview: ""))
            });
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
                properties: new[]
                {
                    new Property("Path", f.Path.ToString(PathTable)),
                    new Property("RewriteCount", f.RewriteCount),
                    new Property("FileContentInfo", () => Analyzer.TryGetFileContentInfo(f)),
                    f.IsOutputFile ? new Property("Producer", () => Analyzer.AsPipReference(PipGraph.GetProducer(f))) : null,
                    new Property("Consumers", () => PipGraph.GetConsumingPips(f.Path))
                }
                .Where(p => p != null));
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
                    d.IsOutputDirectory() ? new Property("Producer", () => PipGraph.GetProducer(d)) : null,
                    new Property("Consumers", () => PipGraph.GetConsumingPips(d.Path)),
                    d.PartialSealId > 0 ? new Property("Members", () => PipGraph.ListSealedDirectoryContents(d)) : null
                }
                .Where(p => p != null));
        }

        private ObjectInfo PipsInfo(PipsScope _)
        {
            return new ObjectInfo(new[]
            {
                new Property("ByType", PipsByType),
                new Property("ByStatus", PipsByStatus),
                new Property("ByExecutionStart", () => PipsOrderedBy(exePerf => exePerf.ExecutionStart)),
                new Property("ByExecutionStop", () => PipsOrderedBy(exePerf => exePerf.ExecutionStop))
            });
        }

        private PipReference[] PipsOrderedBy(Func<PipExecutionPerformance, object> selector)
        {
            return Analyzer.Pip2Perf
                .OrderBy(kvp => selector(kvp.Value))
                .Select(kvp => Analyzer.AsPipReference(kvp.Key))
                .ToArray();
        }

        private ObjectInfo GroupFiles(IEnumerable<FileArtifact> files)
        {
            return new ObjectInfo(properties: new[]
            {
                new Property("Source", () => GroupByFirstFileNameLetter(files.Where(f => f.IsSourceFile), f => f.Path)),
                new Property("Output", () => GroupByFirstFileNameLetter(files.Where(f => f.IsOutputFile), f => f.Path))
            });
        }

        private ObjectInfo GroupDirs(IEnumerable<DirectoryArtifact> dirs)
        {
            return new ObjectInfo(properties: new[]
            {
                new Property("Source",          () => GroupByFirstFileNameLetter(dirs.Where(d => !d.IsOutputDirectory()), d => d.Path)),
                new Property("ExclusiveOpaque", () => GroupByFirstFileNameLetter(dirs.Where(d => d.IsOutputDirectory() && !d.IsSharedOpaque), d => d.Path)),
                new Property("SharedOpaque",    () => GroupByFirstFileNameLetter(dirs.Where(d => d.IsSharedOpaque), d => d.Path))
            });
        }

        private ObjectInfo GroupByFirstFileNameLetter<T>(IEnumerable<T> elems, Func<T, AbsolutePath> toPath)
        {
            return new ObjectInfo(elems
                .GroupBy(t => "'" + toPath(t).GetName(PathTable).ToString(StringTable)[0].ToUpperInvariantFast() + "'")
                .OrderBy(grp => grp.Key)
                .Select(grp => new Property(name: grp.Key, value: grp.ToArray())));
        }

        private class PipsScope { }
        private class FilesScope { }
        private class AnalyzeCricialPath { }
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