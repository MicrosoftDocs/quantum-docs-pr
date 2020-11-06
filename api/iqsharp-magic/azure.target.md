---
title: '%azure.target (magic command)'
description: Sets or displays the active execution target for Q# job submission in
  an Azure Quantum workspace.
author: rmshaffer
uid: microsoft.quantum.iqsharp.magic-ref.azure.target
ms.author: ryansha
ms.date: 11/06/2020
ms.topic: article
---

<!--
    NB: This file has been automatically generated from Microsoft.Quantum.IQSharp.AzureClient.dll,
        please do not manually edit it.

    [DEBUG] JSON source:
        {"Name": "%azure.target", "Documentation": {"Summary": "Sets or displays the active execution target for Q# job submission in an Azure Quantum workspace.", "Full": null, "Description": "\r\nThis magic command allows for specifying or displaying the execution target for Q# job submission\r\nin an Azure Quantum workspace.\r\n\r\nThe Azure Quantum workspace must have been previously initialized\r\nusing the [`%azure.connect` magic command](https://docs.microsoft.com/qsharp/api/iqsharp-magic/azure.connect)\r\nmagic command. The specified execution target must be available in the workspace and support execution of Q# programs.\r\n\r\n#### Optional parameters\r\n\r\n- The target ID to set as the active execution target for Q# job submission. If not specified,\r\nthe currently active execution target is displayed.\r\n\r\n#### Possible errors\r\n\r\n- `NotConnected`: Not connected to any Azure Quantum workspace.\r\n- `InvalidTarget`: The specified execution target is not valid for Q# job submission in the current Azure Quantum workspace.\r\n- `NoTarget`: No execution target has been configured for Azure Quantum job submission.\r\n                    ", "Remarks": null, "Examples": ["\r\nSet the current target for Q# job submission to `provider.qpu`:\r\n```\r\nIn []: %azure.target provider.qpu\r\nOut[]: Loading package Microsoft.Quantum.Providers.Provider and dependencies...\r\n       Active target is now provider.qpu\r\n       <detailed properties of active execution target>\r\n```\r\n                        ", "\r\nDisplay the current target and all available targets in the current Azure Quantum workspace:\r\n```\r\nIn []: %azure.target\r\nOut[]: Current execution target: provider.qpu\r\n       Available execution targets: provider.qpu, provider.simulator\r\n       <detailed properties of active execution target>\r\n```\r\n                        "], "SeeAlso": null}, "AssemblyName": "Microsoft.Quantum.IQSharp.AzureClient"}
-->

# `%azure.target`

## Summary

Sets or displays the active execution target for Q# job submission in an Azure Quantum workspace.

## Description

This magic command allows for specifying or displaying the execution target for Q# job submission
in an Azure Quantum workspace.

The Azure Quantum workspace must have been previously initialized
using the [`%azure.connect` magic command](https://docs.microsoft.com/qsharp/api/iqsharp-magic/azure.connect)
magic command. The specified execution target must be available in the workspace and support execution of Q# programs.

#### Optional parameters

- The target ID to set as the active execution target for Q# job submission. If not specified,
the currently active execution target is displayed.

#### Possible errors

- `NotConnected`: Not connected to any Azure Quantum workspace.
- `InvalidTarget`: The specified execution target is not valid for Q# job submission in the current Azure Quantum workspace.
- `NoTarget`: No execution target has been configured for Azure Quantum job submission.

## Examples for `%azure.target`

### Example 1

Set the current target for Q# job submission to `provider.qpu`:
```
In []: %azure.target provider.qpu
Out[]: Loading package Microsoft.Quantum.Providers.Provider and dependencies...
       Active target is now provider.qpu
       <detailed properties of active execution target>
```

### Example 2

Display the current target and all available targets in the current Azure Quantum workspace:
```
In []: %azure.target
Out[]: Current execution target: provider.qpu
       Available execution targets: provider.qpu, provider.simulator
       <detailed properties of active execution target>
```
