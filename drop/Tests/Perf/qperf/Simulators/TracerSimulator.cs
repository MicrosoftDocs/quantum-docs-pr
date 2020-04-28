using Microsoft.Quantum.Simulation.Core;
using Microsoft.Quantum.Simulation.Simulators.QCTraceSimulators;
using System;
using System.Collections.Generic;
using System.Text;

namespace qperf.Simulators
{
    public class TracerSimulator : QCTraceSimulator
    {
        public TracerSimulator()
            : base(new QCTraceSimulatorConfiguration() { ThrowOnUnconstrainedMeasurement = false })
        {
        }
    }
}
