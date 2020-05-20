---
title: '%status (magic command)'
uid: microsoft.quantum.iqsharp.magic-ref.status
ms.date: '2020-05-20'
ms.topic: article
---

<!--
    NB: This file has been automatically generated from Microsoft.Quantum.IQSharp.AzureClient.dll,
        please do not manually edit it.

    [DEBUG] JSON source:
        {"Name": "%status", "Documentation": {"Summary": "Displays status for jobs in the current Azure Quantum workspace.", "Full": null, "Description": "\r\nThis magic command allows for displaying status of jobs in the current \r\nAzure Quantum workspace. If a valid job ID is provided as an argument, the\r\ndetailed status of that job will be displayed; otherwise, a list of all jobs\r\ncreated in the current session will be displayed.\r\n                    ", "Remarks": null, "Examples": ["\r\nPrint status about a specific job:\r\n```\r\nIn []: %status JOB_ID\r\nOut[]: JOB_ID: <job status>\r\n```\r\n                        ", "\r\nPrint status about all jobs created in the current session:\r\n```\r\nIn []: %status\r\nOut[]: <status for each job>\r\n```\r\n                        "], "SeeAlso": null}, "AssemblyName": "Microsoft.Quantum.IQSharp.AzureClient"}
-->

# `%status`

## Summary

Displays status for jobs in the current Azure Quantum workspace.

## Description

This magic command allows for displaying status of jobs in the current
Azure Quantum workspace. If a valid job ID is provided as an argument, the
detailed status of that job will be displayed; otherwise, a list of all jobs
created in the current session will be displayed.

## Example

Print status about a specific job:
```
In []: %status JOB_ID
Out[]: JOB_ID: <job status>
```

## Example

Print status about all jobs created in the current session:
```
In []: %status
Out[]: <status for each job>
```
