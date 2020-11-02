---
title: '%toffoli (magic command)'
description: Runs a given function or operation on the ToffoliSimulator target machine.
author: rmshaffer
uid: microsoft.quantum.iqsharp.magic-ref.toffoli
ms.author: ryansha
ms.date: 11/02/2020
ms.topic: article
---

<!--
    NB: This file has been automatically generated from Microsoft.Quantum.IQSharp.Kernel.dll,
        please do not manually edit it.

    [DEBUG] JSON source:
        {"Name": "%toffoli", "Documentation": {"Summary": "Runs a given function or operation on the ToffoliSimulator target machine.", "Full": null, "Description": "\r\nThis magic command allows executing a given function or operation on the ToffoliSimulator, \r\nwhich performs a simulation of the given function or operation in which the state is always\r\na simple product state in the computational basis, and prints the resulting return value.\r\n\r\nSee the [ToffoliSimulator user guide](https://docs.microsoft.com/quantum/user-guide/machines/toffoli-simulator) to learn more.\r\n\r\n#### Required parameters\r\n\r\n- Q# operation or function name. This must be the first parameter, and must be a valid Q# operation\r\nor function name that has been defined either in the notebook or in a Q# file in the same folder.\r\n- Arguments for the Q# operation or function must also be specified as `key=value` pairs.\r\n                ", "Remarks": null, "Examples": ["\r\nUse the ToffoliSimulator to simulate a Q# operation\r\ndefined as `operation MyOperation() : Result`:\r\n```\r\nIn []: %toffoli MyOperation\r\nOut[]: <return value of the operation>\r\n```\r\n                    ", "\r\nUse the ToffoliSimulator to simulate a Q# operation\r\ndefined as `operation MyOperation(a : Int, b : Int) : Result`:\r\n```\r\nIn []: %toffoli MyOperation a=5 b=10\r\nOut[]: <return value of the operation>\r\n```\r\n                    "], "SeeAlso": null}, "AssemblyName": "Microsoft.Quantum.IQSharp.Kernel"}
-->

# `%toffoli`

## Summary

Runs a given function or operation on the ToffoliSimulator target machine.

## Description

This magic command allows executing a given function or operation on the ToffoliSimulator,
which performs a simulation of the given function or operation in which the state is always
a simple product state in the computational basis, and prints the resulting return value.

See the [ToffoliSimulator user guide](https://docs.microsoft.com/quantum/user-guide/machines/toffoli-simulator) to learn more.

#### Required parameters

- Q# operation or function name. This must be the first parameter, and must be a valid Q# operation
or function name that has been defined either in the notebook or in a Q# file in the same folder.
- Arguments for the Q# operation or function must also be specified as `key=value` pairs.

## Examples for `%toffoli`

### Example 1

Use the ToffoliSimulator to simulate a Q# operation
defined as `operation MyOperation() : Result`:
```
In []: %toffoli MyOperation
Out[]: <return value of the operation>
```

### Example 2

Use the ToffoliSimulator to simulate a Q# operation
defined as `operation MyOperation(a : Int, b : Int) : Result`:
```
In []: %toffoli MyOperation a=5 b=10
Out[]: <return value of the operation>
```
