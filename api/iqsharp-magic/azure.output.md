---
title: '%azure.output (magic command)'
author: rmshaffer
uid: microsoft.quantum.iqsharp.magic-ref.azure.output
ms.author: rmshaffer
ms.date: 07/24/2020
ms.topic: article
---

<!--
    NB: This file has been automatically generated from Microsoft.Quantum.IQSharp.AzureClient.dll,
        please do not manually edit it.

    [DEBUG] JSON source:
        {"Name": "%azure.output", "Documentation": {"Summary": "Displays results for a job in the current Azure Quantum workspace.", "Full": null, "Description": "\r\nThis magic command allows for displaying results for a job in the current \r\nAzure Quantum workspace.\r\nThe job execution must already be completed in order to display\r\nresults.\r\n\r\nThe Azure Quantum workspace must have been previously initialized\r\nusing the [`%azure.connect` magic command](https://docs.microsoft.com/qsharp/api/iqsharp-magic/azure.connect).\r\n\r\n#### Optional parameters\r\n\r\n- The job ID for which to display results. If not specified, the job ID from\r\nthe most recent call to [`%azure.submit`](https://docs.microsoft.com/qsharp/api/iqsharp-magic/azure.submit)\r\nor [`%azure.execute`](https://docs.microsoft.com/qsharp/api/iqsharp-magic/azure.execute) will be used.\r\n\r\n#### Possible errors\r\n\r\n- `NotConnected`: Not connected to any Azure Quantum workspace.\r\n- `JobNotFound`: No job with the given ID was found in the current Azure Quantum workspace.\r\n- `JobNotCompleted`: The specified Azure Quantum job has not yet completed.\r\n- `JobOutputDownloadFailed`: Failed to download results for the specified Azure Quantum job.\r\n                    ", "Remarks": null, "Examples": ["\r\nGet results of a specific job:\r\n```\r\nIn []: %azure.output JOB_ID\r\nOut[]: <detailed results of specified job>\r\n```\r\n                        ", "\r\nGet results of the most recently submitted job:\r\n```\r\nIn []: %azure.output\r\nOut[]: <detailed results of most recently submitted job>\r\n```\r\n                        "], "SeeAlso": null}, "AssemblyName": "Microsoft.Quantum.IQSharp.AzureClient"}
-->

# `%azure.output`

## Summary

Displays results for a job in the current Azure Quantum workspace.

## Description

This magic command allows for displaying results for a job in the current
Azure Quantum workspace.
The job execution must already be completed in order to display
results.

The Azure Quantum workspace must have been previously initialized
using the [`%azure.connect` magic command](https://docs.microsoft.com/qsharp/api/iqsharp-magic/azure.connect).

#### Optional parameters

- The job ID for which to display results. If not specified, the job ID from
the most recent call to [`%azure.submit`](https://docs.microsoft.com/qsharp/api/iqsharp-magic/azure.submit)
or [`%azure.execute`](https://docs.microsoft.com/qsharp/api/iqsharp-magic/azure.execute) will be used.

#### Possible errors

- `NotConnected`: Not connected to any Azure Quantum workspace.
- `JobNotFound`: No job with the given ID was found in the current Azure Quantum workspace.
- `JobNotCompleted`: The specified Azure Quantum job has not yet completed.
- `JobOutputDownloadFailed`: Failed to download results for the specified Azure Quantum job.

## Example

Get results of a specific job:
```
In []: %azure.output JOB_ID
Out[]: <detailed results of specified job>
```

## Example

Get results of the most recently submitted job:
```
In []: %azure.output
Out[]: <detailed results of most recently submitted job>
```
