---
uid: Microsoft.Quantum.Measurement.MResetY
title: MResetY operation
ms.date: 10/16/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Measurement
qsharp.name: MResetY
qsharp.summary: >-
  Measures a single qubit in the Y basis,
  and resets it to a fixed initial state
  following the measurement.
---

# MResetY operation

Namespace: [Microsoft.Quantum.Measurement](xref:Microsoft.Quantum.Measurement)

Package: [](https://nuget.org/packages/)


Measures a single qubit in the Y basis,and resets it to a fixed initial statefollowing the measurement.

```Q#
MResetY (target : Qubit) : Result
```


## Description

Performs a single-qubit measurement in the $Y$-basis,and ensures that the qubit is returned to $\ket{0}$following the measurement.

## Input

### target : Qubit

A single qubit to be measured.



## Output

The result of measuring `target` in the Pauli $Y$ basis.