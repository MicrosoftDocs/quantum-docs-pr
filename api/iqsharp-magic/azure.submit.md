---
title: '%azure.submit (magic command)'
description: Submits a job to an Azure Quantum workspace.
author: rmshaffer
uid: microsoft.quantum.iqsharp.magic-ref.azure.submit
ms.author: ryansha
ms.date: 12/04/2020
ms.topic: article
---

<!--
    NB: This file has been automatically generated from Microsoft.Quantum.IQSharp.AzureClient.dll,
        please do not manually edit it.

    [DEBUG] JSON source:
        {"Name": "%azure.submit", "Documentation": {"Summary": "Submits a job to an Azure Quantum workspace.", "Full": null, "Description": "\r\nThis magic command allows for submitting a Q# operation or function\r\nto be run on the specified target in the current Azure Quantum workspace.\r\nThe command returns immediately after the job is submitted.\r\n\r\nThe Azure Quantum workspace must have been previously initialized\r\nusing the [`%azure.connect` magic command](https://docs.microsoft.com/qsharp/api/iqsharp-magic/azure.connect),\r\nand an execution target for the job must have been specified using the\r\n[`%azure.target` magic command](https://docs.microsoft.com/qsharp/api/iqsharp-magic/azure.target).\r\n\r\n#### Required parameters\r\n\r\n- Q# operation or function name. This must be the first parameter, and must be a valid Q# operation\r\nor function name that has been defined either in the notebook or in a Q# file in the same folder.\r\n- Arguments for the Q# operation or function must also be specified as `key=value` pairs.\r\n\r\n#### Optional parameters\r\n\r\n- `jobName=<string>`: Friendly name to identify this job. If not specified,\r\nthe Q# operation or function name will be used as the job name.\r\n- `shots=<integer>` (default=500): Number of times to repeat execution of the\r\nspecified Q# operation or function.\r\n\r\n#### Possible errors\r\n\r\n- `NotConnected`: Not connected to any Azure Quantum workspace.\r\n- `NoTarget`: No execution target has been configured for Azure Quantum job submission.\r\n- `NoOperationName`: No Q# operation name was specified for Azure Quantum job submission.\r\n- `InvalidTarget`: The specified execution target is not valid for Q# job submission in the current Azure Quantum workspace.\r\n- `UnrecognizedOperationName`: The specified Q# operation name was not recognized.\r\n- `InvalidEntryPoint`: The specified Q# operation cannot be used as an entry point for Azure Quantum job submission.\r\n- `JobSubmissionFailed`: Failed to submit the job to the Azure Quantum workspace.\r\n                    ", "Remarks": null, "Examples": ["\r\nSubmit a Q# operation defined as `operation MyOperation(a : Int, b : Int) : Result`\r\nfor execution on the active target in the current Azure Quantum workspace:\r\n```\r\nIn []: %azure.submit MyOperation a=5 b=10\r\nOut[]: Submitting MyOperation to target provider.qpu...\r\n       Job successfully submitted for 500 shots.\r\n          Job name: MyOperation\r\n          Job ID: <Azure Quantum job ID>\r\n       <detailed properties of submitted job>\r\n```\r\n                        ", "\r\nSubmit a Q# operation defined as `operation MyOperation(a : Int, b : Int) : Result`\r\nfor execution on the active target in the current Azure Quantum workspace,\r\nspecifying a custom job name, number of shots, timeout, and polling interval:\r\n```\r\nIn []: %azure.submit MyOperation a=5 b=10 jobName=\"My job\" shots=100\r\nOut[]: Submitting MyOperation to target provider.qpu...\r\n       Job successfully submitted for 100 shots.\r\n          Job name: My job\r\n          Job ID: <Azure Quantum job ID>\r\n       <detailed properties of submitted job>\r\n```\r\n                        "], "SeeAlso": null}, "AssemblyName": "Microsoft.Quantum.IQSharp.AzureClient"}
-->

# `%azure.submit`

## Summary

Submits a job to an Azure Quantum workspace.

## Description

This magic command allows for submitting a Q# operation or function
to be run on the specified target in the current Azure Quantum workspace.
The command returns immediately after the job is submitted.

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

#### Possible errors

- `NotConnected`: Not connected to any Azure Quantum workspace.
- `NoTarget`: No execution target has been configured for Azure Quantum job submission.
- `NoOperationName`: No Q# operation name was specified for Azure Quantum job submission.
- `InvalidTarget`: The specified execution target is not valid for Q# job submission in the current Azure Quantum workspace.
- `UnrecognizedOperationName`: The specified Q# operation name was not recognized.
- `InvalidEntryPoint`: The specified Q# operation cannot be used as an entry point for Azure Quantum job submission.
- `JobSubmissionFailed`: Failed to submit the job to the Azure Quantum workspace.

## Examples for `%azure.submit`

### Example 1

Submit a Q# operation defined as `operation MyOperation(a : Int, b : Int) : Result`
for execution on the active target in the current Azure Quantum workspace:
```
In []: %azure.submit MyOperation a=5 b=10
Out[]: Submitting MyOperation to target provider.qpu...
       Job successfully submitted for 500 shots.
          Job name: MyOperation
          Job ID: <Azure Quantum job ID>
       <detailed properties of submitted job>
```

### Example 2

Submit a Q# operation defined as `operation MyOperation(a : Int, b : Int) : Result`
for execution on the active target in the current Azure Quantum workspace,
specifying a custom job name, number of shots, timeout, and polling interval:
```
In []: %azure.submit MyOperation a=5 b=10 jobName="My job" shots=100
Out[]: Submitting MyOperation to target provider.qpu...
       Job successfully submitted for 100 shots.
          Job name: My job
          Job ID: <Azure Quantum job ID>
       <detailed properties of submitted job>
```
