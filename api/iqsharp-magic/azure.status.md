---
title: '%azure.status (magic command)'
description: Displays status for a job in the current Azure Quantum workspace.
author: rmshaffer
uid: microsoft.quantum.iqsharp.magic-ref.azure.status
ms.author: ryansha
ms.date: 11/25/2020
ms.topic: article
---

<!--
    NB: This file has been automatically generated from Microsoft.Quantum.IQSharp.AzureClient.dll,
        please do not manually edit it.

    [DEBUG] JSON source:
        {"Name": "%azure.status", "Documentation": {"Summary": "Displays status for a job in the current Azure Quantum workspace.", "Full": null, "Description": "\r\nThis magic command allows for displaying status for a job in the current \r\nAzure Quantum workspace.\r\n\r\nThe Azure Quantum workspace must have been previously initialized\r\nusing the [`%azure.connect` magic command](https://docs.microsoft.com/qsharp/api/iqsharp-magic/azure.connect).\r\n\r\n#### Optional parameters\r\n\r\n- The job ID for which to display status. If not specified, the job ID from\r\nthe most recent call to [`%azure.submit`](https://docs.microsoft.com/qsharp/api/iqsharp-magic/azure.submit)\r\nor [`%azure.execute`](https://docs.microsoft.com/qsharp/api/iqsharp-magic/azure.execute) will be used.\r\n\r\n#### Possible errors\r\n\r\n- `NotConnected`: Not connected to any Azure Quantum workspace.\r\n- `JobNotFound`: No job with the given ID was found in the current Azure Quantum workspace.\r\n                    ", "Remarks": null, "Examples": ["\r\nGet the status of a specific job:\r\n```\r\nIn []: %azure.status JOB_ID\r\nOut[]: <detailed status of specified job>\r\n```\r\n                        ", "\r\nGet the status of the most recently submitted job:\r\n```\r\nIn []: %azure.status\r\nOut[]: <detailed status of most recently submitted job>\r\n```\r\n                        "], "SeeAlso": null}, "AssemblyName": "Microsoft.Quantum.IQSharp.AzureClient"}
-->

# `%azure.status`

## Summary

Displays status for a job in the current Azure Quantum workspace.

## Description

This magic command allows for displaying status for a job in the current
Azure Quantum workspace.

The Azure Quantum workspace must have been previously initialized
using the [`%azure.connect` magic command](https://docs.microsoft.com/qsharp/api/iqsharp-magic/azure.connect).

#### Optional parameters

- The job ID for which to display status. If not specified, the job ID from
the most recent call to [`%azure.submit`](https://docs.microsoft.com/qsharp/api/iqsharp-magic/azure.submit)
or [`%azure.execute`](https://docs.microsoft.com/qsharp/api/iqsharp-magic/azure.execute) will be used.

#### Possible errors

- `NotConnected`: Not connected to any Azure Quantum workspace.
- `JobNotFound`: No job with the given ID was found in the current Azure Quantum workspace.

## Examples for `%azure.status`

### Example 1

Get the status of a specific job:
```
In []: %azure.status JOB_ID
Out[]: <detailed status of specified job>
```

### Example 2

Get the status of the most recently submitted job:
```
In []: %azure.status
Out[]: <detailed status of most recently submitted job>
```
