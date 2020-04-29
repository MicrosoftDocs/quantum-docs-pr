using Microsoft.Quantum.Simulation.Core;
using Microsoft.Quantum.Simulation.QCTraceSimulatorRuntime;
using System;
using System.Collections.Generic;
using System.Text;

namespace qperf.Stats
{
    public class Record : ICSVColumns
    {
        public Record() : this(null)
        {
        }

        public Record(EventTracker evt)
        {
            this.ExecutionInfo = evt?.Tracker.Info;
            this.Key = evt?.Key;
        }

        public string Key { get; }

        public SingleExecutionInfo ExecutionInfo { get; }

        public int Count => 1;

        public string[] GetColumnNames()
        {
            return new string[]
            {
                "Run",
                "Time",
                "QDK",
                "HostName",
                "SourceVersion",
                "BuildBranch",
                "Simulator",
                "TopLevelGate",
                "Event"
            };
        }

        public string[] GetRow()
        {
            return new string[]
            {
                this.ExecutionInfo?.Run?.Id,
                this.ExecutionInfo?.Run?.Start.ToString(),
                this.ExecutionInfo?.Run?.QDKVersion,
                this.ExecutionInfo?.Run?.HostName,
                this.ExecutionInfo?.Run?.SourceVersion,
                this.ExecutionInfo?.Run?.BuildBranch,
                this.ExecutionInfo?.Simulator,
                this.ExecutionInfo?.TopLevelGate,
                this.Key
            };
        }

        public override bool Equals(object obj)
        {
            var edge = obj as Record;
            return edge != null &&
                this.Key == edge.Key;
        }

        public override int GetHashCode()
        {
            return this.Key.GetHashCode();
        }
    }
}
