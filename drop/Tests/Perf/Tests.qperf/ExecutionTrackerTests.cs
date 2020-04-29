using Microsoft.Quantum.Simulation.Simulators;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using qperf.Stats;
using System;
using System.Collections.Generic;
using System.Text;

namespace qperf.Tests
{
    [TestClass]
    public class ExecutionTrackerTests
    {
        [TestMethod]
        public void RunTopLevelGate()
        {
            // Verifies that the RunOne method invokes the gate (exactly) once
            // on the given simulator.
            // It does this by checking that onStart/onEnd are called once 
            // and in the correct order.
            using (var qsim = new QuantumSimulator())
            {
                var starts = 0;
                var ends = 0;

                qsim.OnOperationStart += (op, args) =>
                {
                    Assert.AreEqual("Perf.NoOp", op);
                    Assert.AreEqual(0, starts);
                    Assert.AreEqual(0, ends);
                    starts++;
                };

                qsim.OnOperationEnd += (op, args) =>
                {
                    Assert.AreEqual("Perf.NoOp", op);
                    Assert.AreEqual(1, starts);
                    Assert.AreEqual(0, ends);
                    ends++;
                };

                ExecutionTracker.RunTopLevelGate(qsim, typeof(Perf.NoOp));
            }
        }

        [TestMethod]
        public void Run()
        {
            var info = new RunInfo();
            var run = ExecutionTracker.Run(info, typeof(qperf.Simulators.NoBorrowingSimulator), typeof(Perf.NoOp));

            Assert.IsFalse(run.MainEvent.Watch.IsRunning);
            Assert.AreEqual(info, run.Info.Run);
            Assert.AreEqual("TotalExecution", run.MainEvent.Key);
            Assert.AreEqual(4, run.EventsTotal);       // PerformanceRun,InitSumulator,NoOp(gate),EndSimulator
        }
    }
}
