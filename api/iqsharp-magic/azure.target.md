---
title: '%azure.target (magic command)'
uid: microsoft.quantum.iqsharp.magic-ref.azure.target
ms.date: '2020-06-23'
ms.topic: article
---

<!--
    NB: This file has been automatically generated from Microsoft.Quantum.IQSharp.AzureClient.dll,
        please do not manually edit it.

    [DEBUG] JSON source:
        {"Name": "%azure.target", "Documentation": {"Summary": "Views or sets the target for job submission to an Azure Quantum workspace.", "Full": null, "Description": "\r\nThis magic command allows for specifying a target for job submission\r\nto an Azure Quantum workspace, or viewing the list of all available targets.\r\n\r\nThe Azure Quantum workspace must previously have been initialized\r\nusing the %azure.connect magic command, and the specified target must be\r\navailable in the workspace.   \r\n                    ", "Remarks": null, "Examples": ["\r\nSet the current target for job submission:\r\n```\r\nIn []: %azure.target TARGET_ID\r\nOut[]: Active target is now TARGET_ID\r\n```\r\n                        ", "\r\nView the current target and all available targets in the current Azure Quantum workspace:\r\n```\r\nIn []: %azure.target\r\nOut[]: <current target and list of available targets>\r\n```\r\n                        "], "SeeAlso": null}, "AssemblyName": "Microsoft.Quantum.IQSharp.AzureClient"}
-->

# `%azure.target`

## Summary

Views or sets the target for job submission to an Azure Quantum workspace.

## Description

This magic command allows for specifying a target for job submission
to an Azure Quantum workspace, or viewing the list of all available targets.

The Azure Quantum workspace must previously have been initialized
using the %azure.connect magic command, and the specified target must be
available in the workspace.

## Example

Set the current target for job submission:
```
In []: %azure.target TARGET_ID
Out[]: Active target is now TARGET_ID
```

## Example

View the current target and all available targets in the current Azure Quantum workspace:
```
In []: %azure.target
Out[]: <current target and list of available targets>
```
