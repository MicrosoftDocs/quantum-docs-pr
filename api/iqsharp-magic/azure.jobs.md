---
title: '%azure.jobs (magic command)'
uid: microsoft.quantum.iqsharp.magic-ref.azure.jobs
ms.date: '2020-06-23'
ms.topic: article
---

<!--
    NB: This file has been automatically generated from Microsoft.Quantum.IQSharp.AzureClient.dll,
        please do not manually edit it.

    [DEBUG] JSON source:
        {"Name": "%azure.jobs", "Documentation": {"Summary": "Displays a list of jobs in the current Azure Quantum workspace.", "Full": null, "Description": "\r\nThis magic command allows for displaying the list of jobs in the current \r\nAzure Quantum workspace, optionally filtering the list to jobs which\r\nhave an ID, name, or target containing the provided filter parameter.\r\n\r\nThe Azure Quantum workspace must previously have been initialized\r\nusing the %azure.connect magic command.\r\n                    ", "Remarks": null, "Examples": ["\r\nPrint the list of jobs:\r\n```\r\nIn []: %azure.jobs\r\nOut[]: <list of jobs in the workspace>\r\n```\r\n                        ", "\r\nPrint the list of jobs whose ID, name, or target contains \"MyJob\":\r\n```\r\nIn []: %azure.jobs \"MyJob\"\r\nOut[]: <list of matching jobs>\r\n```\r\n                        "], "SeeAlso": null}, "AssemblyName": "Microsoft.Quantum.IQSharp.AzureClient"}
-->

# `%azure.jobs`

## Summary

Displays a list of jobs in the current Azure Quantum workspace.

## Description

This magic command allows for displaying the list of jobs in the current
Azure Quantum workspace, optionally filtering the list to jobs which
have an ID, name, or target containing the provided filter parameter.

The Azure Quantum workspace must previously have been initialized
using the %azure.connect magic command.

## Example

Print the list of jobs:
```
In []: %azure.jobs
Out[]: <list of jobs in the workspace>
```

## Example

Print the list of jobs whose ID, name, or target contains "MyJob":
```
In []: %azure.jobs "MyJob"
Out[]: <list of matching jobs>
```
