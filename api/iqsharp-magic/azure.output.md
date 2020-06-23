---
title: '%azure.output (magic command)'
uid: microsoft.quantum.iqsharp.magic-ref.azure.output
ms.date: '2020-06-23'
ms.topic: article
---

<!--
    NB: This file has been automatically generated from Microsoft.Quantum.IQSharp.AzureClient.dll,
        please do not manually edit it.

    [DEBUG] JSON source:
        {"Name": "%azure.output", "Documentation": {"Summary": "Displays results for jobs in the current Azure Quantum workspace.", "Full": null, "Description": "\r\nThis magic command allows for displaying results of jobs in the current \r\nAzure Quantum workspace. If a valid job ID is provided as an argument, and the\r\njob has completed, the output of that job will be displayed. If no job ID is\r\nprovided, the job ID from the most recent call to `%azure.submit` or\r\n`%azure.execute` will be used.\r\n\r\nIf the job has not yet completed, an error message will be displayed.\r\n\r\nThe Azure Quantum workspace must previously have been initialized\r\nusing the %azure.connect magic command.\r\n                    ", "Remarks": null, "Examples": ["\r\nPrint results of a specific job:\r\n```\r\nIn []: %azure.output JOB_ID\r\nOut[]: <job results of specified job>\r\n```\r\n                        ", "\r\nPrint results of the most recently-submitted job:\r\n```\r\nIn []: %azure.output\r\nOut[]: <job results of most recently-submitted job>\r\n```\r\n                        "], "SeeAlso": null}, "AssemblyName": "Microsoft.Quantum.IQSharp.AzureClient"}
-->

# `%azure.output`

## Summary

Displays results for jobs in the current Azure Quantum workspace.

## Description

This magic command allows for displaying results of jobs in the current
Azure Quantum workspace. If a valid job ID is provided as an argument, and the
job has completed, the output of that job will be displayed. If no job ID is
provided, the job ID from the most recent call to `%azure.submit` or
`%azure.execute` will be used.

If the job has not yet completed, an error message will be displayed.

The Azure Quantum workspace must previously have been initialized
using the %azure.connect magic command.

## Example

Print results of a specific job:
```
In []: %azure.output JOB_ID
Out[]: <job results of specified job>
```

## Example

Print results of the most recently-submitted job:
```
In []: %azure.output
Out[]: <job results of most recently-submitted job>
```
