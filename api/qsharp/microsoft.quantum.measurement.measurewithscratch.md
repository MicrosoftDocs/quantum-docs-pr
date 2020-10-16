---
uid: Microsoft.Quantum.Measurement.MeasureWithScratch
title: MeasureWithScratch operation
ms.date: 10/16/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Measurement
qsharp.name: MeasureWithScratch
qsharp.summary: >-
  Measures the given Pauli operator using an explicit scratch
  qubit to perform the measurement.
---

# MeasureWithScratch operation

Namespace: [Microsoft.Quantum.Measurement](xref:Microsoft.Quantum.Measurement)

Package: [](https://nuget.org/packages/)


Measures the given Pauli operator using an explicit scratchqubit to perform the measurement.

```Q#
MeasureWithScratch (pauli : Pauli[], target : Qubit[]) : Result
```


## Input

### pauli : Pauli[]

A multi-qubit Pauli operator specified as an array ofsingle-qubit Pauli operators.


### target : Qubit[]

Qubit register to be measured.



## Output

The result of measuring the given Pauli operator onthe `target` register.