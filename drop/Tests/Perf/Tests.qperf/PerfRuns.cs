using Microsoft.Quantum.Simulation.Simulators;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using qperf.Simulators;

namespace Performance.Runs
{
    [TestClass]
    public class Runs
    {
        [TestMethod]
        public void H2Simulation()
        {
            qperf.ExecutionTracker.Run(null, typeof(DefaultSimulator), typeof(Perf.H2Simulation));
        }

        [TestMethod]
        public void KDTest()
        {
            qperf.ExecutionTracker.Run(null, typeof(DefaultSimulator), typeof(Perf.KDTest));
        }

        [TestMethod]
        public void NoOp()
        {
            qperf.ExecutionTracker.Run(null, typeof(DefaultSimulator), typeof(Perf.NoOp));
        }

        [TestMethod]
        public void ModularAddProductLETest()
        {
            qperf.ExecutionTracker.Run(null, typeof(DefaultSimulator), typeof(Perf.ModularAddProductLETest));
        }
    }
}
