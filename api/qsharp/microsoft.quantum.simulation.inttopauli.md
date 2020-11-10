---
uid: Microsoft.Quantum.Simulation.IntToPauli
title: IntToPauli function
ms.date: 10/26/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Simulation
qsharp.name: IntToPauli
qsharp.summary: Converts a integer to a single-qubit Pauli operator.
---

# IntToPauli function

Namespace: [Microsoft.Quantum.Simulation](xref:Microsoft.Quantum.Simulation)

Package: [](https://nuget.org/packages/)


Converts a integer to a single-qubit Pauli operator.

```qsharp
function IntToPauli (idx : Int) : Pauli
```


## Input

### idx : [Int](xref:microsoft.quantum.lang-ref.int)

Integer in the range `0..3` to be converted to Pauli operators.



## Output : [Pauli](xref:microsoft.quantum.lang-ref.pauli)

A `Pauli` operator given by `[PauliI, PauliX, PauliY, PauliZ][idx]`.