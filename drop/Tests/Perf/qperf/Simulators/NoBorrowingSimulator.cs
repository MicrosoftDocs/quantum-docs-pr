using Microsoft.Quantum.Simulation.Simulators;
using System;
using System.Collections.Generic;
using System.Text;

namespace qperf.Simulators
{
    public class NoBorrowingSimulator : QuantumSimulator
    {
        public NoBorrowingSimulator() : base(disableBorrowing: true)
        {
        }
    }
}
