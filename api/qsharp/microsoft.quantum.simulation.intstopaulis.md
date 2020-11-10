---
uid: Microsoft.Quantum.Simulation.IntsToPaulis
title: IntsToPaulis function
ms.date: 10/26/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Simulation
qsharp.name: IntsToPaulis
qsharp.summary: >-
  Converts an array of integers to an array of single-qubit Pauli
  operators.
---

# IntsToPaulis function

Namespace: [Microsoft.Quantum.Simulation](xref:Microsoft.Quantum.Simulation)

Package: [](https://nuget.org/packages/)


Converts an array of integers to an array of single-qubit Paulioperators.

```qsharp
function IntsToPaulis (ints : Int[]) : Pauli[]
```


## Input

### ints : [Int](xref:microsoft.quantum.lang-ref.int)[]

Array of integers in the range `0..3`  to be converted to Paulioperators.



## Output : [Pauli](xref:microsoft.quantum.lang-ref.pauli)[]

An array `paulis` of Pauli operators `Pauli[]` the same length as`ints` such that `paulis[idxPauli]` is equal to the element of`[PauliI, PauliX, PauliY, PauliZ]` given by `ints[idxPauli]`.