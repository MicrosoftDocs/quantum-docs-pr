using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Quantum.Simulation.QCTraceSimulatorRuntime;
using qperf.Stats;

using Microsoft.Azure.Documents.Client;
using Newtonsoft.Json.Linq;
using System.Dynamic;
using System.Threading.Tasks;
using Microsoft.Azure.Documents;
using System.Linq;
using System.IO;

namespace qperf
{
    public class Uploader
    {
        public class AzureRecord
        {
            public string Run;
            public DateTime Start;
            public string QDK;
            public string HostName;
            public string SourceVersion;
            public string BuildBranch;
            public string Simulator;
            public string TopLevelGate;
            public string Event;
            public long Count;
            public double Average;
            public double SecondMoment;
            public double Min;
            public double Max;
        }

        static Uri endpoint = new Uri("https://solid-perf.documents.azure.com:443/");

        public static DocumentClient CreateClient(string token)
        {
            if (string.IsNullOrWhiteSpace(token))
            {
                Console.WriteLine("Empty Azure token. Skipping regression check/uploading.");
                return null;
            }

            return new DocumentClient(endpoint, token);
        }

        public static void Upload(DocumentClient client, ExecutionTracker[] allExecutions)
        {
            if (client == null)
            {
                return;
            }

            UploadAll(client, allExecutions);
        }

        public static bool ValidateAll(DocumentClient client, ExecutionTracker[] allExecutions)
        {
            if (client == null)
            {
                return true;
            }

            bool allValid = true;

            Console.WriteLine($"##[info] Calculating trends... ");
            var path = Path.GetFullPath("perf-results.md");
            using (var summary = File.CreateText(path))
            {
                summary.WriteLine("# Performance results.\n");
                summary.WriteLine($"| {"Simulator",-36} | {"TopLevelGate",-33} | {"TotalExecution (ms)",24} | {"Average",19} | {"StdDev",19} | {"Diff",30} |   Result   |");
                summary.WriteLine($"|{":--------",-36}  |{":-----------",-33}  |  {"------------------:",24}|  {"------:",19}|  {"-----:",19}|  {"---:",30}|:-----------|");

                foreach (var one in allExecutions)
                {
                    allValid &= ValidateOne(client, one, summary);
                }

            }

            Console.WriteLine($"##vso[task.uploadsummary]{path}");
            Console.Write(File.ReadAllText(path));

            return allValid;
        }

        public static bool ValidateOne(string token, ExecutionTracker execution, TextWriter log)
        {
            if (string.IsNullOrWhiteSpace(token))
            {
                return true;
            }

            using (var client = new DocumentClient(endpoint, token))
            {
                return ValidateOne(client, execution, log);
            }
        }

        /// <summary>
        /// Validates that the given execution has not regressed in performance.
        /// It compares results from at least 5 and at most 15 latest runs 
        /// and checks if the time has regressed more than 2 * stddev.
        /// </summary>
        public static bool ValidateOne(DocumentClient client, ExecutionTracker execution, TextWriter log)
        {
            var collection = UriFactory.CreateDocumentCollectionUri("Perf", "Records");

            var previous = client.CreateDocumentQuery<AzureRecord>(collection)
                .Where(r =>
                   r.HostName == execution.Info.Run.HostName &&
                   r.TopLevelGate == execution.Info.TopLevelGate &&
                   r.Simulator == execution.Info.Simulator &&
                   r.BuildBranch == "master" &&
                   r.Event == "TotalExecution"
                )
                .OrderByDescending(r => r.Start)
                .Take(15)
                .ToArray();

            //Console.WriteLine(string.Join('\n',previous.Select(r => r.TopLevelGate + ":" + r.HostName + ":" + r.Start + r.Simulator)));

            // Make sure we have at least 5 samples before validating:
            if (previous.Length < 5)
            {
                log.WriteLine($"| {execution.Info.Simulator,-36} | {execution.Info.TopLevelGate,-33} | Not enough runs found from this host to calculate a trend... ||");
                return true;
            }

            var (avg, stdDev) = CalculateTrend(previous);
            var totalExec = execution.Stats.Data.Where(evt => evt.Key.Key == "TotalExecution").First().Value.GetVariableStatistics(0)[0];
            var diff = totalExec - avg;
            var isOk = 
                (totalExec <= 100 && avg <= 100) ||
                ((diff / avg) <= 0.05);

            string Bold(string msg) => isOk ? msg : $"**{msg}**";
            string BoldD(double msg) => isOk ? $"{msg:F2}" : $"**{msg:F2}**";

            log.WriteLine($"| {Bold(execution.Info.Simulator),-36} | {Bold(execution.Info.TopLevelGate),-33} | {BoldD(totalExec),24} | {BoldD(avg),19} | {BoldD(stdDev),19} | {BoldD(diff), 19} ({(diff/avg),8:P2}) | {(isOk ? "OK        " : "**ERROR!**")} |");

            return isOk;
        }

        private static ValueTuple<double, double> CalculateTrend(AzureRecord[] previous)
        {
            var count = previous.Length;

            var avg = 0.0;
            for(var i = 0; i < count; i++)
            {
                avg += previous[i].Average;
            }

            avg = avg / (double)count;

            var stdDev = 0.0;
            for (var i = 0; i < count; i++)
            {
                stdDev += (previous[i].Average - avg) * (previous[i].Average - avg);
            }

            stdDev = Math.Sqrt(stdDev / (double)count);

            return (avg, stdDev);
        }


        public static void UploadAll(DocumentClient client, ExecutionTracker[] allExecutions)
        {
            foreach (var one in allExecutions)
            {
                UploadOne(client, one);
            }
        }


        public static void UploadOne(DocumentClient client, ExecutionTracker execution)
        {
            Console.Write($"Uploading results for {execution.Info.TopLevelGate} on simulator {execution.Info.Simulator}  to Azure... ");

            var stats = execution.Stats;

            var collection = UriFactory.CreateDocumentCollectionUri("Perf", "Records");
            var statistics = stats.GetStatisticsNamesCopy();
            List<Task<ResourceResponse<Document>>> tasks = new List<Task<ResourceResponse<Document>>>();

            foreach (var d in stats.Data)
            {
                var r = CreateAzureRecord(statistics, d.Key, d.Value);
                tasks.Add(client.CreateDocumentAsync(collection, r));
            }

            var timeout = 60000;
            Task.WaitAll(tasks.ToArray(), timeout);

            Console.WriteLine("done.");
        }

        public static AzureRecord CreateAzureRecord(string[] statisticsNames, Record d, MultivariableRecord data)
        {
            var info = d.ExecutionInfo;
            var values = data.GetVariableStatistics(0);

            var record = new AzureRecord
            {
                Run = info.Run.Id,
                Start = info.Run.Start,
                QDK = info.Run.QDKVersion,
                HostName = info.Run.HostName,
                SourceVersion = info.Run.SourceVersion,
                BuildBranch = info.Run.BuildBranch,
                Simulator = info.Simulator,
                TopLevelGate = info.TopLevelGate,
                Event = d.Key,
                Count = data.NumberOfSamples,
                Average = values[0],
                SecondMoment = values[1],
                Min = values[2],
                Max = values[3]
            };

            return record;
        }
    }
}
