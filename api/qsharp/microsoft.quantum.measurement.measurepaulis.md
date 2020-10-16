---
uid: Microsoft.Quantum.Measurement.MeasurePaulis
title: MeasurePaulis operation
ms.date: 10/16/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Measurement
qsharp.name: MeasurePaulis
qsharp.summary: >-
  Given an array of multi-qubit Pauli operators, measures each using a specified measurement
  gadget, then returns the array of results.
---

# MeasurePaulis operation

Namespace: [Microsoft.Quantum.Measurement](xref:Microsoft.Quantum.Measurement)

Package: [](https://nuget.org/packages/)


Given an array of multi-qubit Pauli operators, measures each using a specified measurementgadget, then returns the array of results.

```Q#
MeasurePaulis (paulis : Pauli[][], target : Qubit[], gadget : ((Pauli[], Qubit[]) => Result)) : Result[]
```


## Input

### paulis : Pauli[][]

Array of multi-qubit Pauli operators to measure.


### target : Qubit[]

Register on which to measure the given operators.


### gadget : (Pauli[],Qubit[]) => __invalid<Result>__ 

Operation which performs the measurement of a given multi-qubit operator.



## Output

The array of results obtained from measuring each element of `paulis`on `target`.