---
uid: Microsoft.Quantum.Measurement.MResetZ
title: MResetZ operation
ms.date: 10/16/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Measurement
qsharp.name: MResetZ
qsharp.summary: >-
  Measures a single qubit in the Z basis,
  and resets it to a fixed initial state
  following the measurement.
---

# MResetZ operation

Namespace: [Microsoft.Quantum.Measurement](xref:Microsoft.Quantum.Measurement)

Package: [](https://nuget.org/packages/)


Measures a single qubit in the Z basis,and resets it to a fixed initial statefollowing the measurement.

```Q#
MResetZ (target : Qubit) : Result
```


## Description

Performs a single-qubit measurement in the $Z$-basis,and ensures that the qubit is returned to $\ket{0}$following the measurement.

## Input

### target : Qubit

A single qubit to be measured.



## Output

The result of measuring `target` in the Pauli $Z$ basis.