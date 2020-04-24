using System;
using System.Linq;
using Microsoft.Quantum.Simulation.Simulators;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using qperf.Simulators;
using Microsoft.Quantum.Simulation.Simulators.QCTraceSimulators;

namespace qperf.Tests
{
    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void TestSuite()
        {
            var actual = Program.TestSuite().ToArray();

            Assert.AreEqual(4, actual.Length);
            Assert.AreEqual(typeof(Perf.NoOp), actual[0]);
            Assert.AreEqual(typeof(Perf.ModularAddProductLETest), actual[1]);
            Assert.AreEqual(typeof(Perf.H2Simulation), actual[2]);
            Assert.AreEqual(typeof(Perf.KDTest), actual[3]);
        }

        [TestMethod]
        public void SupportedSimulators()
        {
            var actual = Program.SupportedSimulators(typeof(Perf.NoOp)).ToArray();

            Assert.AreEqual(3, actual.Length);
            Assert.AreEqual(typeof(DefaultSimulator), actual[0]);
            Assert.AreEqual(typeof(NoBorrowingSimulator), actual[1]);
            Assert.AreEqual(typeof(QCTraceSimulator), actual[2]);

            actual = Program.SupportedSimulators(typeof(Perf.H2Simulation)).ToArray();
            Assert.AreEqual(2, actual.Length);
            Assert.AreEqual(typeof(DefaultSimulator), actual[0]);
            Assert.AreEqual(typeof(NoBorrowingSimulator), actual[1]);
        }
    }
}
