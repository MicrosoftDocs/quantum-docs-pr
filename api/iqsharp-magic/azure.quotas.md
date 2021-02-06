---
title: '%azure.quotas (magic command)'
description: Displays a list of quotas for the current Azure Quantum workspace.
author: rmshaffer
uid: microsoft.quantum.iqsharp.magic-ref.azure.quotas
ms.author: ryansha
ms.date: 02/06/2021
ms.topic: managed-reference
---

<!--
    NB: This file has been automatically generated from Microsoft.Quantum.IQSharp.AzureClient.dll,
        please do not manually edit it.

    [DEBUG] JSON source:
        {"Name": "%azure.quotas", "Documentation": {"Summary": "Displays a list of quotas for the current Azure Quantum workspace.", "Full": null, "Description": "\r\nThis magic command allows for displaying quota information for the current \r\nAzure Quantum workspace.\r\n\r\nThe Azure Quantum workspace must have been previously initialized\r\nusing the [`%azure.connect` magic command](https://docs.microsoft.com/qsharp/api/iqsharp-magic/azure.connect).\r\n                        \r\n#### Possible errors\r\n\r\n- `NotConnected`: Not connected to any Azure Quantum workspace.\r\n                    ", "Remarks": null, "Examples": ["\r\nGet the list of quotas:\r\n```\r\nIn []: %azure.quotas\r\nOut[]: <quota information for the workspace>\r\n```\r\n                        "], "SeeAlso": null}, "AssemblyName": "Microsoft.Quantum.IQSharp.AzureClient"}
-->

# `%azure.quotas`

## Summary

Displays a list of quotas for the current Azure Quantum workspace.

## Description

This magic command allows for displaying quota information for the current
Azure Quantum workspace.

The Azure Quantum workspace must have been previously initialized
using the [`%azure.connect` magic command](https://docs.microsoft.com/qsharp/api/iqsharp-magic/azure.connect).

#### Possible errors

- `NotConnected`: Not connected to any Azure Quantum workspace.

## Examples for `%azure.quotas`

### Example 1

Get the list of quotas:
```
In []: %azure.quotas
Out[]: <quota information for the workspace>
```
