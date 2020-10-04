---
title: '%simulate (magic command)'
author: rmshaffer
uid: microsoft.quantum.iqsharp.magic-ref.simulate
ms.author: rmshaffer
ms.date: 10/04/2020
ms.topic: article
---

<!--
    NB: This file has been automatically generated from Microsoft.Quantum.IQSharp.Kernel.dll,
        please do not manually edit it.

    [DEBUG] JSON source:
        {"Name": "%simulate", "Documentation": {"Summary": "Runs a given function or operation on the QuantumSimulator target machine.", "Full": null, "Description": "\r\nThis magic command allows executing a given function or operation on the QuantumSimulator, \r\nwhich performs a full-state simulation of the given function or operation\r\nand prints the resulting return value.\r\n\r\nSee the [QuantumSimulator user guide](https://docs.microsoft.com/quantum/user-guide/machines/full-state-simulator) to learn more.\r\n\r\n#### Required parameters\r\n\r\n- Q# operation or function name. This must be the first parameter, and must be a valid Q# operation\r\nor function name that has been defined either in the notebook or in a Q# file in the same folder.\r\n- Arguments for the Q# operation or function must also be specified as `key=value` pairs.\r\n                ", "Remarks": null, "Examples": ["\r\nSimulate a Q# operation defined as `operation MyOperation() : Result`:\r\n```\r\nIn []: %simulate MyOperation\r\nOut[]: <return value of the operation>\r\n```\r\n                    ", "\r\nSimulate a Q# operation defined as `operation MyOperation(a : Int, b : Int) : Result`:\r\n```\r\nIn []: %simulate MyOperation a=5 b=10\r\nOut[]: <return value of the operation>\r\n```\r\n                    "], "SeeAlso": null}, "AssemblyName": "Microsoft.Quantum.IQSharp.Kernel"}
-->

# `%simulate`

## Summary

Runs a given function or operation on the QuantumSimulator target machine.

## Description

This magic command allows executing a given function or operation on the QuantumSimulator,
which performs a full-state simulation of the given function or operation
and prints the resulting return value.

See the [QuantumSimulator user guide](https://docs.microsoft.com/quantum/user-guide/machines/full-state-simulator) to learn more.

#### Required parameters

- Q# operation or function name. This must be the first parameter, and must be a valid Q# operation
or function name that has been defined either in the notebook or in a Q# file in the same folder.
- Arguments for the Q# operation or function must also be specified as `key=value` pairs.

## Example

Simulate a Q# operation defined as `operation MyOperation() : Result`:
```
In []: %simulate MyOperation
Out[]: <return value of the operation>
```

## Example

Simulate a Q# operation defined as `operation MyOperation(a : Int, b : Int) : Result`:
```
In []: %simulate MyOperation a=5 b=10
Out[]: <return value of the operation>
```
