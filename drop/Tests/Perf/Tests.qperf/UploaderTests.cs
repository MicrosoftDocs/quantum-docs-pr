using System;
using System.Linq;
using Microsoft.Quantum.Simulation.Simulators;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using qperf.Simulators;
using qperf.Stats;
using Newtonsoft.Json;

namespace qperf.Tests
{
    [TestClass]
    public class UploaderTests
    {
        [TestMethod]
        public void CreateSerializableRecord()
        {
            var runInfo = new RunInfo();
            var tracker = qperf.ExecutionTracker.Run(runInfo, typeof(DefaultSimulator), typeof(Perf.NoOp));

            var data = tracker.Stats.Data.First();
            var names = tracker.Stats.GetStatisticsNamesCopy();

            var actual = Uploader.CreateAzureRecord(names, data.Key, data.Value);

            Assert.AreEqual(runInfo.Id, actual.Run);
            Assert.AreEqual(runInfo.Start, actual.Start);
            Assert.AreEqual(runInfo.QDKVersion, actual.QDK);
            Assert.AreEqual(runInfo.HostName, actual.HostName);
            Assert.AreEqual(data.Key.ExecutionInfo.Simulator, actual.Simulator);
            Assert.AreEqual(data.Key.ExecutionInfo.TopLevelGate, actual.TopLevelGate);
            Assert.AreEqual(data.Value.NumberOfSamples, actual.Count);
            Assert.AreEqual(data.Value.GetVariableStatistics(0)[0], actual.Average);

            Assert.IsTrue(JsonConvert.SerializeObject(actual).StartsWith($"{{\"Run\":\"{runInfo.Id}\""));
        }
    }
}