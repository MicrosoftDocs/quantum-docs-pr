---
title: '%azure.jobs (magic command)'
author: rmshaffer
uid: microsoft.quantum.iqsharp.magic-ref.azure.jobs
ms.author: rmshaffer
ms.date: 08/01/2020
ms.topic: article
---

<!--
    NB: This file has been automatically generated from Microsoft.Quantum.IQSharp.AzureClient.dll,
        please do not manually edit it.

    [DEBUG] JSON source:
        {"Name": "%azure.jobs", "Documentation": {"Summary": "Displays a list of jobs in the current Azure Quantum workspace.", "Full": null, "Description": "\r\nThis magic command allows for displaying the list of jobs in the current \r\nAzure Quantum workspace, optionally filtering the list to jobs which\r\nhave an ID, name, or target containing the provided filter parameter.\r\n\r\nThe Azure Quantum workspace must have been previously initialized\r\nusing the [`%azure.connect` magic command](https://docs.microsoft.com/qsharp/api/iqsharp-magic/azure.connect).\r\n\r\n#### Optional parameters\r\n\r\n- A string to filter the list of jobs. Jobs which have an ID, name, or target\r\ncontaining the provided filter parameter will be displayed. If not specified,\r\nall recent jobs are displayed.\r\n\r\n#### Possible errors\r\n\r\n- `NotConnected`: Not connected to any Azure Quantum workspace.\r\n                    ", "Remarks": null, "Examples": ["\r\nGet the list of jobs:\r\n```\r\nIn []: %azure.jobs\r\nOut[]: <detailed status of all recent jobs in the workspace>\r\n```\r\n                        ", "\r\nGet the list of jobs whose ID, name, or target contains \"My job\":\r\n```\r\nIn []: %azure.jobs \"My job\"\r\nOut[]: <detailed status of matching jobs in the workspace>\r\n```\r\n                        "], "SeeAlso": null}, "AssemblyName": "Microsoft.Quantum.IQSharp.AzureClient"}
-->

# `%azure.jobs`

## Summary

Displays a list of jobs in the current Azure Quantum workspace.

## Description

This magic command allows for displaying the list of jobs in the current
Azure Quantum workspace, optionally filtering the list to jobs which
have an ID, name, or target containing the provided filter parameter.

The Azure Quantum workspace must have been previously initialized
using the [`%azure.connect` magic command](https://docs.microsoft.com/qsharp/api/iqsharp-magic/azure.connect).

#### Optional parameters

- A string to filter the list of jobs. Jobs which have an ID, name, or target
containing the provided filter parameter will be displayed. If not specified,
all recent jobs are displayed.

#### Possible errors

- `NotConnected`: Not connected to any Azure Quantum workspace.

## Example

Get the list of jobs:
```
In []: %azure.jobs
Out[]: <detailed status of all recent jobs in the workspace>
```

## Example

Get the list of jobs whose ID, name, or target contains "My job":
```
In []: %azure.jobs "My job"
Out[]: <detailed status of matching jobs in the workspace>
```
