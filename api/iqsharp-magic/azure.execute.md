---
title: '%azure.execute (magic command)'
uid: microsoft.quantum.iqsharp.magic-ref.azure.execute
ms.date: '2020-06-23'
ms.topic: article
---

<!--
    NB: This file has been automatically generated from Microsoft.Quantum.IQSharp.AzureClient.dll,
        please do not manually edit it.

    [DEBUG] JSON source:
        {"Name": "%azure.execute", "Documentation": {"Summary": "Executes a job in an Azure Quantum workspace.", "Full": null, "Description": "\r\nThis magic command allows for executing a job in an Azure Quantum workspace\r\ncorresponding to the Q# operation provided as an argument, and it waits\r\nfor the job to complete before returning.\r\n\r\nThe Azure Quantum workspace must previously have been initialized\r\nusing the %azure.connect magic command.\r\n                    ", "Remarks": null, "Examples": ["\r\nExecute an operation in the current Azure Quantum workspace:\r\n```\r\nIn []: %azure.execute OPERATION_NAME\r\nOut[]: Executing job on target TARGET_NAME...\r\n       <job results displayed here after execution completes>\r\n```\r\n                        "], "SeeAlso": null}, "AssemblyName": "Microsoft.Quantum.IQSharp.AzureClient"}
-->

# `%azure.execute`

## Summary

Executes a job in an Azure Quantum workspace.

## Description

This magic command allows for executing a job in an Azure Quantum workspace
corresponding to the Q# operation provided as an argument, and it waits
for the job to complete before returning.

The Azure Quantum workspace must previously have been initialized
using the %azure.connect magic command.

## Example

Execute an operation in the current Azure Quantum workspace:
```
In []: %azure.execute OPERATION_NAME
Out[]: Executing job on target TARGET_NAME...
       <job results displayed here after execution completes>
```
