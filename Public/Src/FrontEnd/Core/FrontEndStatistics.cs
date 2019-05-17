// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Threading;
using BuildXL.FrontEnd.Sdk;
using BuildXL.FrontEnd.Workspaces;
using BuildXL.Utilities;

#pragma warning disable SA1649 // File name must match first type name

namespace BuildXL.FrontEnd.Core
{
    /// <summary>
    /// Captures statistic information about different stages of the DScript frontend pipeline.
    /// </summary>
    public sealed class FrontEndStatistics : WorkspaceStatistics, IFrontEndStatistics
    {
        private long m_analysisDurationInTicks;

        /// <nodoc />
        public FrontEndStatistics(bool enableSorting = true, EventHandler<WorkspaceProgressEventArgs> workspaceProgressHandler = null)
            : base(enableSorting)
        {
            WorkspaceProgress = workspaceProgressHandler;

            SpecAstConversion       = new Counter(enableSorting);
            SpecAstDeserialization  = new Counter(enableSorting);
            SpecAstSerialization    = new Counter(enableSorting);
            PublicFacadeComputation = new Counter(enableSorting);
            ConfigurationProcessing = new Counter(enableSorting);
            PreludeProcessing       = new Counter(enableSorting);
            CounterWithRootCause    = new CounterWithRootCause(enableSorting);
        }

        /// <inheritdoc />
        public Counter SpecAstConversion { get; }

        /// <inheritdoc />
        public Counter SpecAstDeserialization { get; }

        /// <inheritdoc />
        public Counter SpecAstSerialization { get; }

        /// <inheritdoc />
        public Counter PublicFacadeComputation { get; }

        /// <inheritdoc />
        public CounterWithRootCause CounterWithRootCause { get; }

        /// <inheritdoc />
        public Counter ConfigurationProcessing { get; }

        /// <inheritdoc />
        public Counter PreludeProcessing { get; }

        /// <inheritdoc />
        void IFrontEndStatistics.AnalysisCompleted(AbsolutePath path, TimeSpan duration)
        {
            Interlocked.Add(ref m_analysisDurationInTicks, duration.Ticks);
        }

        /// <inheritdoc />
        TimeSpan IFrontEndStatistics.GetOverallAnalysisDuration()
        {
            return TimeSpan.FromTicks(Interlocked.Read(ref m_analysisDurationInTicks));
        }

        /// <inheritdoc />
        public EventHandler<WorkspaceProgressEventArgs> WorkspaceProgress { get; }

        /// <inheritdoc />
        public INugetStatistics NugetStatistics { get; } = new NugetStatistics();

        /// <inheritdoc />
        public ILoadConfigStatistics LoadConfigStatistics { get; } = new LoadConfigStatistics();
    }
}
