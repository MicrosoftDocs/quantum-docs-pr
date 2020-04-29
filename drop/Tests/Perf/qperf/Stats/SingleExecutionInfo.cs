using Microsoft.Quantum.Simulation.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace qperf.Stats
{
    public class SingleExecutionInfo
    {
        public SingleExecutionInfo(RunInfo run, Type quantumMachine, Type gate)
        {
            this.Run = run;
            this.Simulator = quantumMachine.Name;
            this.TopLevelGate = gate.Name;
        }

        public RunInfo Run { get; }

        public string Simulator { get; }

        public string TopLevelGate { get; }

    }
}
