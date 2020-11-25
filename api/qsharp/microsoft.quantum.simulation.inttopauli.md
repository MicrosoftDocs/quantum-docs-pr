---
uid: Microsoft.Quantum.Simulation.IntToPauli
title: IntToPauli function
ms.date: 11/25/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Simulation
qsharp.name: IntToPauli
qsharp.summary: Converts a integer to a single-qubit Pauli operator.
---

# IntToPauli function

Namespace: [Microsoft.Quantum.Simulation](xref:Microsoft.Quantum.Simulation)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Converts a integer to a single-qubit Pauli operator.

```qsharp
function IntToPauli (idx : Int) : Pauli
```


## Input

### idx : [Int](xref:microsoft.quantum.user-guide.language.types)

Integer in the range `0..3` to be converted to Pauli operators.



## Output : [Pauli](xref:microsoft.quantum.user-guide.language.types)

A `Pauli` operator given by `[PauliI, PauliX, PauliY, PauliZ][idx]`.