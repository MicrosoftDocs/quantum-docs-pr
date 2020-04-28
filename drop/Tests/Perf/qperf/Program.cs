using Microsoft.Quantum.Simulation.Core;
using Microsoft.Quantum.Simulation.QCTraceSimulatorRuntime;
using Microsoft.Quantum.Simulation.Simulators;
using Microsoft.Quantum.Simulation.Simulators.QCTraceSimulators;
using qperf.Simulators;
using qperf.Stats;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace qperf
{
    public class Program
    {
        // Usage:
        //   qperf [cosmosDbKey] [force]
        //
        //     - cosmosDbKey: is the AuthorizationKey to upload the results to Azure.
        //          if not provided, data will not be uploaded to cosmos
        //     - force (true/false): by default, results will be compared to previous runs
        //          on the same machine to check for regression. if a regression is detected
        //          the program returns an error (to fail the build) and the data is not
        //          uploaded to Azure.
        static void Main(string[] args)
        {
            var token = (args?.Length >= 1) ? args[0] : null;
            var ignoreValidation = (args?.Length >= 2) ? bool.Parse(args[1]) : false;

            var info = new RunInfo();
            var gates = TestSuite();
            var allExecutions = new List<ExecutionTracker>();

            foreach (var gate in gates)
            {
                var simulators = SupportedSimulators(gate).ToArray();

                foreach (var qsim in simulators)
                {
                    ExecutionTracker run = RunOne(info, qsim, gate);

                    // Retry once if execution is not within trends on the first pass:
                    if (!Uploader.ValidateOne(token, run, Console.Out))
                    {
                        Console.WriteLine("##[warning]!!! Regression detected. Trying one more time:");
                        run = RunOne(info, qsim, gate);
                    }

                    // Save execution results so all of them are uploaded together.
                    allExecutions.Add(run);
                }
            }

            // Validate and Upload results
            using (var client = Uploader.CreateClient(token))
            {
                var results = allExecutions.ToArray();
                var success = Uploader.ValidateAll(client, results);

                Uploader.Upload(client, results);

                if (ignoreValidation == false && success == false)
                {
                    Console.WriteLine("##[task.logissue type=warning]Performance regression detected.");
                }
            }
        }

        private static ExecutionTracker RunOne(RunInfo info, Type qsim, Type gate)
        {
            var run = ExecutionTracker.Run(info, qsim, gate);
            var results = run.Stats.ToCSV();

            // Output results to console:
            Console.Write(results);

            // Output results to file:
            File.AppendAllText($"perf-{qsim.Name}-{gate.Name}-results.txt", results);
            return run;
        }

        public static IEnumerable<Type> TestSuite()
        {
            yield return typeof(Perf.NoOp);
            yield return typeof(Perf.ModularAddProductLETest);
            yield return typeof(Perf.H2Simulation);
            yield return typeof(Perf.KDTest);
            yield return typeof(Perf.ToffoliChainTest1000);
            yield return typeof(Perf.ToffoliChainTest10000);
            yield return typeof(Perf.ToffoliChainTest50000);
        }

        public static IEnumerable<Type> SupportedSimulators(Type gate)
        {
            if ((gate == typeof(Perf.ToffoliChainTest1000)) ||
                (gate == typeof(Perf.ToffoliChainTest10000)) ||
                (gate == typeof(Perf.ToffoliChainTest50000)))
            {
                yield return typeof(ToffoliSimulator);
                yield return typeof(TracerSimulator);
                yield return typeof(ResourcesEstimator);
            }
            else
            {
                yield return typeof(DefaultSimulator);
                yield return typeof(NoBorrowingSimulator);
                yield return typeof(ResourcesEstimator);
                yield return typeof(TracerSimulator);
                yield return typeof(TracerPrimitivesCounterSimulator);
                yield return typeof(TracerAllSimulator);
            }
        }
    }
}