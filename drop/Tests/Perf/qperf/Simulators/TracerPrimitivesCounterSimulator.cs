using Microsoft.Quantum.Simulation.Core;
using Microsoft.Quantum.Simulation.Simulators.QCTraceSimulators;
using System;
using System.Collections.Generic;
using System.Text;

namespace qperf.Simulators
{
    public class TracerPrimitivesCounterSimulator : QCTraceSimulator
    {
        private static QCTraceSimulatorConfiguration config = new QCTraceSimulatorConfiguration()
        {
            ThrowOnUnconstrainedMeasurement = false,
            UsePrimitiveOperationsCounter = true
        };

        public TracerPrimitivesCounterSimulator() : base(config)
        {
        }
    }
}
