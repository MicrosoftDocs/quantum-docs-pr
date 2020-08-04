// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Microsoft.Azure.Quantum;
using Microsoft.Azure.Quantum.Storage;
using Microsoft.Quantum.Providers.IonQ.Targets;

namespace Microsoft.Quantum.AzureSamples
{
    class Program
    {
        /// <summary>
        /// This program shows how to programatically submit and fetch results from executing
        /// a Q# operation in AzureQuantum using C#.
        /// </summary>
        /// <param name="subscriptionId">
        ///     Azure subscription to be used in submitting to Azure Quantum.
        /// </param>
        /// <param name="resourceGroup">
        ///     Resource group containing the Azure Quantum workspace to be used.
        /// </param>
        /// <param name="workspaceName">
        ///     Name of the Azure Quantum workspace to submit to.
        /// </param>
        /// <param name="targetId">
        ///     Name of the Azure Quantum target to submit this job to.
        /// </param>
        /// <param name="nQubits">
        ///     The number of qubits to use when running this quantum program.
        /// </param>
        static async Task Main(
                string subscriptionId, string resourceGroup, string workspaceName,
                string targetId = "ionq.simulator",
                long nQubits = 4
        )
        {
            // First create an instance of a Quantum Workspace, where the jobs are executed in Azure:
            var workspace = new Workspace
            (
                subscriptionId: subscriptionId,
                resourceGroupName: resourceGroup,
                workspaceName: workspaceName
            );

            // Create a JobStorageHelper to upload/download data from Azure Storage.
            //    > NOTE: will not be needed in future versions.
            var jobStorageHelper = new JobStorageHelper(
                System.Environment.GetEnvironmentVariable("AZURE_QUANTUM_STORAGE")
            );

            // Create the machine for the Azure Quantum Provider
            // you'll be submitting jobs to:
            var quantumMachine = new IonQQuantumMachine(
                target: targetId,
                jobStorageHelper: jobStorageHelper,
                workspace: workspace
            );

            // Submit a job for each sample Q# application.
            var job = await quantumMachine.SubmitAsync(SampleRandomNumber.Info, nQubits);
                
            // Print the job ids:
            Console.WriteLine($"Job ID: {job.Id}");

            // Wait, sleeping for half a second each time.
            Console.Out.Write("Waiting for results");
            var cloudJob = await workspace.GetJobAsync(job.Id);
            while (cloudJob.InProgress)
            {
                Console.Out.Write(".");
                await Task.Delay(2000);
                cloudJob = await workspace.GetJobAsync(job.Id);
            }
            Console.Out.WriteLine();

            if (cloudJob.Succeeded)
            {
                Console.Write($"Job {cloudJob.Id} ready:\n");
                jobStorageHelper.DownloadJobOutputAsync(cloudJob.Id, Console.OpenStandardOutput()).Wait();
            }
            else
            {
                Console.WriteLine($"Job {cloudJob.Id} status: {cloudJob.Status}\n{cloudJob.Details.ErrorData.Message}");
            }
        }
    }
}
