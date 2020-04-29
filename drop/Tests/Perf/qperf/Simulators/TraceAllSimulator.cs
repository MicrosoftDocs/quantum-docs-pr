using Microsoft.Quantum.Simulation.Core;
using Microsoft.Quantum.Simulation.Simulators.QCTraceSimulators;
using System;
using System.Collections.Generic;
using System.Text;

namespace qperf.Simulators
{
    public class TracerAllSimulator : QCTraceSimulator
    {
        private static QCTraceSimulatorConfiguration config = new QCTraceSimulatorConfiguration()
        {
            ThrowOnUnconstrainedMeasurement = false,
            UseDistinctInputsChecker = true,
            UseInvalidatedQubitsUseChecker = true,
            UsePrimitiveOperationsCounter = true,
            UseWidthCounter = true,
            UseDepthCounter = true
        };

        public TracerAllSimulator() : base(config)
        {
        }
    }
}
