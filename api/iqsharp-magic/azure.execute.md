---
title: '%azure.execute (magic command)'
author: rmshaffer
uid: microsoft.quantum.iqsharp.magic-ref.azure.execute
ms.author: rmshaffer
ms.date: 08/21/2020
ms.topic: article
---

<!--
    NB: This file has been automatically generated from Microsoft.Quantum.IQSharp.AzureClient.dll,
        please do not manually edit it.

    [DEBUG] JSON source:
        {"Name": "%azure.execute", "Documentation": {"Summary": "Executes a job in an Azure Quantum workspace.", "Full": null, "Description": "\r\nThis magic command allows for executing a Q# operation or function\r\non the specified target in the current Azure Quantum workspace.\r\nThe command waits a specified amount of time for the job to complete before returning.\r\n\r\nThe Azure Quantum workspace must have been previously initialized\r\nusing the [`%azure.connect` magic command](https://docs.microsoft.com/qsharp/api/iqsharp-magic/azure.connect),\r\nand an execution target for the job must have been specified using the\r\n[`%azure.target` magic command](https://docs.microsoft.com/qsharp/api/iqsharp-magic/azure.target).\r\n\r\n#### Required parameters\r\n\r\n- Q# operation or function name. This must be the first parameter, and must be a valid Q# operation\r\nor function name that has been defined either in the notebook or in a Q# file in the same folder.\r\n- Arguments for the Q# operation or function must also be specified as `key=value` pairs.\r\n\r\n#### Optional parameters\r\n\r\n- `jobName=<string>`: Friendly name to identify this job. If not specified,\r\nthe Q# operation or function name will be used as the job name.\r\n- `shots=<integer>` (default=500): Number of times to repeat execution of the\r\nspecified Q# operation or function.\r\n- `timeout=<integer>` (default=30): Time to wait (in seconds) for job completion\r\nbefore the magic command returns.\r\n- `poll=<integer>` (default=5): Interval (in seconds) to poll for\r\njob status while waiting for job execution to complete.\r\n\r\n#### Possible errors\r\n\r\n- `NotConnected`: Not connected to any Azure Quantum workspace.\r\n- `NoTarget`: No execution target has been configured for Azure Quantum job submission.\r\n- `NoOperationName`: No Q# operation name was specified for Azure Quantum job submission.\r\n- `InvalidTarget`: The specified execution target is not valid for Q# job submission in the current Azure Quantum workspace.\r\n- `UnrecognizedOperationName`: The specified Q# operation name was not recognized.\r\n- `InvalidEntryPoint`: The specified Q# operation cannot be used as an entry point for Azure Quantum job submission.\r\n- `JobSubmissionFailed`: Failed to submit the job to the Azure Quantum workspace.\r\n- `JobNotCompleted`: The specified Azure Quantum job has not yet completed.\r\n- `JobOutputDownloadFailed`: Failed to download results for the specified Azure Quantum job.\r\n                    ", "Remarks": null, "Examples": ["\r\nExecute a Q# operation defined as `operation MyOperation(a : Int, b : Int) : Result`\r\non the active target in the current Azure Quantum workspace:\r\n```\r\nIn []: %azure.execute MyOperation a=5 b=10\r\nOut[]: Submitting MyOperation to target provider.qpu...\r\n       Job successfully submitted for 500 shots.\r\n          Job name: MyOperation\r\n          Job ID: <Azure Quantum job ID>\r\n       Waiting up to 30 seconds for Azure Quantum job to complete...\r\n       [1:23:45 PM] Current job status: Waiting\r\n       [1:23:50 PM] Current job status: Executing\r\n       [1:23:55 PM] Current job status: Succeeded\r\n       <detailed results of completed job>\r\n```\r\n                        ", "\r\nExecute a Q# operation defined as `operation MyOperation(a : Int, b : Int) : Result`\r\non the active target in the current Azure Quantum workspace,\r\nspecifying a custom job name, number of shots, timeout, and polling interval:\r\n```\r\nIn []: %azure.submit MyOperation a=5 b=10 jobName=\"My job\" shots=100 timeout=60 poll=10\r\nOut[]: Submitting MyOperation to target provider.qpu...\r\n       Job successfully submitted for 100 shots.\r\n          Job name: My job\r\n          Job ID: <Azure Quantum job ID>\r\n       Waiting up to 60 seconds for Azure Quantum job to complete...\r\n       [1:23:45 PM] Current job status: Waiting\r\n       [1:23:55 PM] Current job status: Waiting\r\n       [1:24:05 PM] Current job status: Executing\r\n       [1:24:15 PM] Current job status: Succeeded\r\n       <detailed results of completed job>\r\n```\r\n                        "], "SeeAlso": null}, "AssemblyName": "Microsoft.Quantum.IQSharp.AzureClient"}
-->

# `%azure.execute`

## Summary

Executes a job in an Azure Quantum workspace.

## Description

This magic command allows for executing a Q# operation or function
on the specified target in the current Azure Quantum workspace.
The command waits a specified amount of time for the job to complete before returning.

The Azure Quantum workspace must have been previously initialized
using the [`%azure.connect` magic command](https://docs.microsoft.com/qsharp/api/iqsharp-magic/azure.connect),
and an execution target for the job must have been specified using the
[`%azure.target` magic command](https://docs.microsoft.com/qsharp/api/iqsharp-magic/azure.target).

#### Required parameters

- Q# operation or function name. This must be the first parameter, and must be a valid Q# operation
or function name that has been defined either in the notebook or in a Q# file in the same folder.
- Arguments for the Q# operation or function must also be specified as `key=value` pairs.

#### Optional parameters

- `jobName=<string>`: Friendly name to identify this job. If not specified,
the Q# operation or function name will be used as the job name.
- `shots=<integer>` (default=500): Number of times to repeat execution of the
specified Q# operation or function.
- `timeout=<integer>` (default=30): Time to wait (in seconds) for job completion
before the magic command returns.
- `poll=<integer>` (default=5): Interval (in seconds) to poll for
job status while waiting for job execution to complete.

#### Possible errors

- `NotConnected`: Not connected to any Azure Quantum workspace.
- `NoTarget`: No execution target has been configured for Azure Quantum job submission.
- `NoOperationName`: No Q# operation name was specified for Azure Quantum job submission.
- `InvalidTarget`: The specified execution target is not valid for Q# job submission in the current Azure Quantum workspace.
- `UnrecognizedOperationName`: The specified Q# operation name was not recognized.
- `InvalidEntryPoint`: The specified Q# operation cannot be used as an entry point for Azure Quantum job submission.
- `JobSubmissionFailed`: Failed to submit the job to the Azure Quantum workspace.
- `JobNotCompleted`: The specified Azure Quantum job has not yet completed.
- `JobOutputDownloadFailed`: Failed to download results for the specified Azure Quantum job.

## Example

Execute a Q# operation defined as `operation MyOperation(a : Int, b : Int) : Result`
on the active target in the current Azure Quantum workspace:
```
In []: %azure.execute MyOperation a=5 b=10
Out[]: Submitting MyOperation to target provider.qpu...
       Job successfully submitted for 500 shots.
          Job name: MyOperation
          Job ID: <Azure Quantum job ID>
       Waiting up to 30 seconds for Azure Quantum job to complete...
       [1:23:45 PM] Current job status: Waiting
       [1:23:50 PM] Current job status: Executing
       [1:23:55 PM] Current job status: Succeeded
       <detailed results of completed job>
```

## Example

Execute a Q# operation defined as `operation MyOperation(a : Int, b : Int) : Result`
on the active target in the current Azure Quantum workspace,
specifying a custom job name, number of shots, timeout, and polling interval:
```
In []: %azure.submit MyOperation a=5 b=10 jobName="My job" shots=100 timeout=60 poll=10
Out[]: Submitting MyOperation to target provider.qpu...
       Job successfully submitted for 100 shots.
          Job name: My job
          Job ID: <Azure Quantum job ID>
       Waiting up to 60 seconds for Azure Quantum job to complete...
       [1:23:45 PM] Current job status: Waiting
       [1:23:55 PM] Current job status: Waiting
       [1:24:05 PM] Current job status: Executing
       [1:24:15 PM] Current job status: Succeeded
       <detailed results of completed job>
```
