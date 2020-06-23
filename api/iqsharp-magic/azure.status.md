---
title: '%azure.status (magic command)'
uid: microsoft.quantum.iqsharp.magic-ref.azure.status
ms.date: '2020-06-23'
ms.topic: article
---

<!--
    NB: This file has been automatically generated from Microsoft.Quantum.IQSharp.AzureClient.dll,
        please do not manually edit it.

    [DEBUG] JSON source:
        {"Name": "%azure.status", "Documentation": {"Summary": "Displays status for jobs in the current Azure Quantum workspace.", "Full": null, "Description": "\r\nThis magic command allows for displaying status of jobs in the current \r\nAzure Quantum workspace. If a valid job ID is provided as an argument, the\r\ndetailed status of that job will be displayed. If no job ID is\r\nprovided, the job ID from the most recent call to `%azure.submit` or\r\n`%azure.execute` will be used.\r\n\r\nThe Azure Quantum workspace must previously have been initialized\r\nusing the %azure.connect magic command.\r\n                    ", "Remarks": null, "Examples": ["\r\nPrint status of a specific job:\r\n```\r\nIn []: %azure.status JOB_ID\r\nOut[]: <job status of specified job>\r\n```\r\n                        ", "\r\nPrint status of the most recently-submitted job:\r\n```\r\nIn []: %azure.status\r\nOut[]: <job status of most recently-submitted job>\r\n```\r\n                        "], "SeeAlso": null}, "AssemblyName": "Microsoft.Quantum.IQSharp.AzureClient"}
-->

# `%azure.status`

## Summary

Displays status for jobs in the current Azure Quantum workspace.

## Description

This magic command allows for displaying status of jobs in the current
Azure Quantum workspace. If a valid job ID is provided as an argument, the
detailed status of that job will be displayed. If no job ID is
provided, the job ID from the most recent call to `%azure.submit` or
`%azure.execute` will be used.

The Azure Quantum workspace must previously have been initialized
using the %azure.connect magic command.

## Example

Print status of a specific job:
```
In []: %azure.status JOB_ID
Out[]: <job status of specified job>
```

## Example

Print status of the most recently-submitted job:
```
In []: %azure.status
Out[]: <job status of most recently-submitted job>
```
