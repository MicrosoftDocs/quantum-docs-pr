---
title: '%azure.submit (magic command)'
uid: microsoft.quantum.iqsharp.magic-ref.azure.submit
ms.date: '2020-06-25'
ms.topic: article
---

<!--
    NB: This file has been automatically generated from Microsoft.Quantum.IQSharp.AzureClient.dll,
        please do not manually edit it.

    [DEBUG] JSON source:
        {"Name": "%azure.submit", "Documentation": {"Summary": "Submits a job to an Azure Quantum workspace.", "Full": null, "Description": "\r\nThis magic command allows for submitting a job to an Azure Quantum workspace\r\ncorresponding to the Q# operation provided as an argument.\r\n\r\nThe Azure Quantum workspace must previously have been initialized\r\nusing the %azure.connect magic command.\r\n                    ", "Remarks": null, "Examples": ["\r\nSubmit an operation as a new job to the current Azure Quantum workspace:\r\n```\r\nIn []: %azure.submit OPERATION_NAME\r\nOut[]: Submitted job JOB_ID\r\n```\r\n                        "], "SeeAlso": null}, "AssemblyName": "Microsoft.Quantum.IQSharp.AzureClient"}
-->

# `%azure.submit`

## Summary

Submits a job to an Azure Quantum workspace.

## Description

This magic command allows for submitting a job to an Azure Quantum workspace
corresponding to the Q# operation provided as an argument.

The Azure Quantum workspace must previously have been initialized
using the %azure.connect magic command.

## Example

Submit an operation as a new job to the current Azure Quantum workspace:
```
In []: %azure.submit OPERATION_NAME
Out[]: Submitted job JOB_ID
```
