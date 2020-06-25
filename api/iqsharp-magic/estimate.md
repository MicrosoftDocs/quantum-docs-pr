---
title: '%estimate (magic command)'
uid: microsoft.quantum.iqsharp.magic-ref.estimate
ms.date: '2020-06-25'
ms.topic: article
---

<!--
    NB: This file has been automatically generated from Microsoft.Quantum.IQSharp.Kernel.dll,
        please do not manually edit it.

    [DEBUG] JSON source:
        {"Name": "%estimate", "Documentation": {"Summary": "Runs a given function or operation on the ResourcesEstimator target machine.", "Full": null, "Description": "\r\nThe ResourcesEstimator estimates statistics about how many resources the given\r\noperation needs for execution. The resources it calculates include:\r\n- Counts for each primitive operation\r\n- Depth (maximum number of qubits allocated at any given point)\r\n- Width (total number of gates used for the computation)\r\n\r\n#### Required parameters\r\n\r\n- Q# operation or function name. This must be the first parameter, and must be a valid Q# operation\r\nor function name that has been defined either in the notebook or in a Q# file in the same folder.\r\n- Arguments for the Q# operation or function must also be specified as `key=value` pairs.\r\n                ", "Remarks": null, "Examples": ["\r\nEstimate resources for a Q# operation defined as `operation MyOperation(a : Int, b : Int) : Result`:\r\n```\r\nIn []: %estimate MyOperation a=5 b=10\r\nOut[]: Metric           Sum     \r\n       ---------------- ----\r\n       CNOT             0\r\n       QubitClifford    4\r\n       R                0\r\n       Measure          8\r\n       T                0\r\n       Depth            0\r\n       Width            4\r\n       BorrowedWidth    0\r\n```\r\n                    "], "SeeAlso": null}, "AssemblyName": "Microsoft.Quantum.IQSharp.Kernel"}
-->

# `%estimate`

## Summary

Runs a given function or operation on the ResourcesEstimator target machine.

## Description

The ResourcesEstimator estimates statistics about how many resources the given
operation needs for execution. The resources it calculates include:
- Counts for each primitive operation
- Depth (maximum number of qubits allocated at any given point)
- Width (total number of gates used for the computation)

#### Required parameters

- Q# operation or function name. This must be the first parameter, and must be a valid Q# operation
or function name that has been defined either in the notebook or in a Q# file in the same folder.
- Arguments for the Q# operation or function must also be specified as `key=value` pairs.

## Example

Estimate resources for a Q# operation defined as `operation MyOperation(a : Int, b : Int) : Result`:
```
In []: %estimate MyOperation a=5 b=10
Out[]: Metric           Sum
       ---------------- ----
       CNOT             0
       QubitClifford    4
       R                0
       Measure          8
       T                0
       Depth            0
       Width            4
       BorrowedWidth    0
```
