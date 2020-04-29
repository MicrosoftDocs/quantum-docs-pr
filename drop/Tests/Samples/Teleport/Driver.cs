using System;
using System.Linq;

using Microsoft.Quantum.Simulation.Core;
using Microsoft.Quantum.Simulation.Simulators;

namespace Quantum.Teleport
{
    class Driver
    {
        static void Main(string[] args)
        {
            using (var qsim = new QuantumSimulator())
            {
                foreach(var i in Enumerable.Range(1, 10)) 
                {                    
                    TeleportCircuit.Run(qsim).Wait();
                    Console.WriteLine();
                }
            }
        }
    }
}