---
title: '%debug (magic command)'
description: Steps through the execution of a given Q# operation or function.
author: rmshaffer
uid: microsoft.quantum.iqsharp.magic-ref.debug
ms.author: ryansha
ms.date: 10/30/2020
ms.topic: article
---

<!--
    NB: This file has been automatically generated from Microsoft.Quantum.IQSharp.Kernel.dll,
        please do not manually edit it.

    [DEBUG] JSON source:
        {"Name": "%debug", "Documentation": {"Summary": "Steps through the execution of a given Q# operation or function.", "Full": null, "Description": "\r\nThis magic command allows for stepping through the execution of a given Q# operation\r\nor function using the QuantumSimulator.\r\n\r\n#### Required parameters\r\n\r\n- Q# operation or function name. This must be the first parameter, and must be a valid Q# operation\r\nor function name that has been defined either in the notebook or in a Q# file in the same folder.\r\n- Arguments for the Q# operation or function must also be specified as `key=value` pairs.\r\n                ", "Remarks": null, "Examples": ["\r\nStep through the execution of a Q# operation defined as `operation MyOperation() : Result`:\r\n```\r\nIn []: %debug MyOperation\r\nOut[]: <interactive HTML for stepping through the operation>\r\n```\r\n                    ", "\r\nStep through the execution of a Q# operation defined as `operation MyOperation(a : Int, b : Int) : Result`:\r\n```\r\nIn []: %debug MyOperation a=5 b=10\r\nOut[]: <interactive HTML for stepping through the operation>\r\n```\r\n                    "], "SeeAlso": null}, "AssemblyName": "Microsoft.Quantum.IQSharp.Kernel"}
-->

# `%debug`

## Summary

Steps through the execution of a given Q# operation or function.

## Description

This magic command allows for stepping through the execution of a given Q# operation
or function using the QuantumSimulator.

#### Required parameters

- Q# operation or function name. This must be the first parameter, and must be a valid Q# operation
or function name that has been defined either in the notebook or in a Q# file in the same folder.
- Arguments for the Q# operation or function must also be specified as `key=value` pairs.

## Examples for `%debug`

### Example 1

Step through the execution of a Q# operation defined as `operation MyOperation() : Result`:
```
In []: %debug MyOperation
Out[]: <interactive HTML for stepping through the operation>
```

### Example 2

Step through the execution of a Q# operation defined as `operation MyOperation(a : Int, b : Int) : Result`:
```
In []: %debug MyOperation a=5 b=10
Out[]: <interactive HTML for stepping through the operation>
```
