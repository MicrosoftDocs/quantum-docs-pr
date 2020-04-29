using Microsoft.Quantum.Simulation.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace qperf.Stats
{
    public class RunInfo
    {
        public RunInfo()
        {
            this.Id = Guid.NewGuid().ToString();
            this.BuildBranch = Environment.GetEnvironmentVariable("BUILD_SOURCEBRANCHNAME");
            this.HostName = Environment.MachineName;
            this.QDKVersion = typeof(Qubit).Assembly.GetName().Version.ToString();
            this.Start = DateTime.Now;
            this.SourceVersion = Environment.GetEnvironmentVariable("BUILD_SOURCEVERSION");
        }

        public string Id { get; }

        public string BuildBranch { get; }

        public string HostName { get; }

        public string QDKVersion { get; }

        public string SourceVersion { get; }

        public DateTime Start { get; }
    }
}
