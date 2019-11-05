// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.ContractsLight;
using BuildXL.Interop.MacOS;
using BuildXL.Pips;
using BuildXL.Utilities;
using static BuildXL.Utilities.FormattableStringEx;

namespace BuildXL.Scheduler
{
    /// <summary>
    /// This class stores historic performance averages of process pips
    /// </summary>
    public readonly struct PipHistoricPerfData : IEquatable<PipHistoricPerfData>
    {
        private const string PLATFORM_OSX = "PLATFORM_OSX";

        /// <summary>
        /// Default time to live
        /// </summary>
        public const byte DefaultTimeToLive = 255; // more than 2 weeks with 20 builds a day.

        private readonly byte m_entryTimeToLive;

        /// <summary>
        /// Processor used in % (150 means one processor fully used and the other half used)
        /// </summary>
        public readonly ushort ProcessorsInPercents;

        /// <summary>
        /// The average run duration
        /// </summary>
        public readonly uint DurationInMs;

        /// <summary>
        /// Peak memory used (in KB)
        /// </summary>
        public readonly uint PeakMemoryInKB;

        /// <summary>
        /// The amount of kilobytes read/written
        /// </summary>
        public readonly uint DiskIOInKB;

        /// <summary>
        /// Kext stats
        /// </summary>
        public readonly Sandbox.PipKextStats KextStats;

        /// <summary>
        /// Check if the structure was recently generated
        /// </summary>
        public bool IsFresh => m_entryTimeToLive == DefaultTimeToLive;

        #region Constructors

        /// <summary>
        /// Construct a new runtime data based on collected performance data
        /// </summary>
        public PipHistoricPerfData(ProcessPipExecutionPerformance executionPerformance)
        {
            Contract.Requires(executionPerformance.ExecutionLevel == PipExecutionLevel.Executed);

            m_entryTimeToLive = DefaultTimeToLive;
            DurationInMs = (uint)Math.Min(uint.MaxValue, Math.Max(1, executionPerformance.ProcessExecutionTime.TotalMilliseconds));
            // For historical ram usage, we record the peak working set instead of the virtual memory due to the precision.
            PeakMemoryInKB = (uint)Math.Min(uint.MaxValue, executionPerformance.MemoryCounters.PeakWorkingSet / 1024);
            DiskIOInKB = (uint)Math.Min(uint.MaxValue, executionPerformance.IO.GetAggregateIO().TransferCount / 1024);
            ProcessorsInPercents = executionPerformance.ProcessorsInPercents;
            KextStats = executionPerformance.KextStats;
        }

        private PipHistoricPerfData(byte timeToLive, uint durationInMs, uint peakMemoryInKB, ushort processorsInPercents, uint diskIOInKB, Sandbox.PipKextStats kextStats)
        {
            m_entryTimeToLive = timeToLive;
            DurationInMs = durationInMs;
            PeakMemoryInKB = peakMemoryInKB;
            ProcessorsInPercents = processorsInPercents;
            DiskIOInKB = diskIOInKB;
            KextStats = kextStats;
        }

        #endregion

        #region Serialization

        /// <summary>
        /// Save the data to a file
        /// </summary>
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters")]
        public void Serialize(BuildXLWriter writer)
        {
            Contract.Requires(writer != null);
            writer.Write(m_entryTimeToLive);
            writer.Write(DurationInMs);
            writer.Write(PeakMemoryInKB);
            writer.Write(ProcessorsInPercents);
            writer.Write(DiskIOInKB);
            KextStats.Serialize(writer);
        }

        /// <summary>
        /// Read the data from a file
        /// </summary>
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters")]
        public static bool Deserialize(BuildXLReader reader, out PipHistoricPerfData result)
        {
            Contract.Requires(reader != null);
            byte timeToLive = reader.ReadByte();
            byte newTimeToLive = (byte)(timeToLive - 1);
            result = new PipHistoricPerfData(
                newTimeToLive, 
                reader.ReadUInt32(),
                reader.ReadUInt32(),
                reader.ReadUInt16(),
                reader.ReadUInt32(),
                Sandbox.PipKextStats.Deserialize(reader));
            return newTimeToLive > 0;
        }

        #endregion

        #region Equality/hash

        /// <inherit />
        public override int GetHashCode()
        {
            unchecked
            {
                return HashCodeHelper.Combine(
                    (int)m_entryTimeToLive,
                    (int)DurationInMs,
                    (int)PeakMemoryInKB,
                    (int)ProcessorsInPercents,
                    (int)DiskIOInKB,
                    KextStats.GetHashCode());
            }
        }

        /// <inherit />
        public bool Equals(PipHistoricPerfData other)
        {
            return m_entryTimeToLive == other.m_entryTimeToLive &&
                DurationInMs == other.DurationInMs &&
                PeakMemoryInKB == other.PeakMemoryInKB &&
                ProcessorsInPercents == other.ProcessorsInPercents &&
                DiskIOInKB == other.DiskIOInKB &&
                KextStats == other.KextStats;
        }

        /// <inherit />
        public override bool Equals(object obj)
        {
            return StructUtilities.Equals(this, obj);
        }

        /// <summary>
        /// Checks whether two PipHistoricPerfData structures are the same.
        /// </summary>
        public static bool operator ==(PipHistoricPerfData left, PipHistoricPerfData right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Checks whether two PipHistoricPerfData structures are different.
        /// </summary>
        public static bool operator !=(PipHistoricPerfData left, PipHistoricPerfData right)
        {
            return !left.Equals(right);
        }

        #endregion

        /// <summary>
        /// Reset the time-to-live counter to the fresh state.
        /// </summary>
        public PipHistoricPerfData MakeFresh()
        {
            return new PipHistoricPerfData(
                DefaultTimeToLive, 
                DurationInMs, 
                PeakMemoryInKB, 
                ProcessorsInPercents, 
                DiskIOInKB, 
                new Sandbox.PipKextStats());
        }

        /// <summary>
        /// Merge the old and new results using asymmetric exponential moving average.
        /// See http://en.wikipedia.org/wiki/Moving_average#Exponential_moving_average
        /// </summary>
        public PipHistoricPerfData Merge(PipHistoricPerfData other)
        {
            var durationResult = GetMergeResult(DurationInMs, other.DurationInMs);
            var peakMemoryResult = GetMergeResult(PeakMemoryInKB, other.PeakMemoryInKB);
            var processorInPercentResult = GetMergeResult(ProcessorsInPercents, other.ProcessorsInPercents);
            var diskIOResult = GetMergeResult(DiskIOInKB, other.DiskIOInKB);

            return new PipHistoricPerfData(
                DefaultTimeToLive,
                durationResult,
                peakMemoryResult, 
                (ushort)processorInPercentResult,
                diskIOResult,
                KextStats.Merge(other.KextStats, GetMergeResult));
        }

        private Sandbox.PipKextStats Merge(Sandbox.PipKextStats oldData, Sandbox.PipKextStats newData)
        {
            return oldData.Merge(newData, GetMergeResult);
        }

        private static uint GetMergeResult(uint oldData, uint newData)
        {
            try
            {
                // An asymmetric merge that goes up fast but decreases slowly.
                if (newData > oldData)
                {
                    return (uint) ( (((ulong)newData) / 2) + (((ulong)oldData) / 2) );
                }

                return (uint) ( (((ulong)oldData) * 9 / 10) + (((ulong)newData) / 10) );
            }
            catch (OverflowException ex)
            {
                throw new BuildXLException(I($"Failed to merge historic perf data result with old '{oldData} and new {newData}' data values!"), ex);
            }
        }
    }
}
