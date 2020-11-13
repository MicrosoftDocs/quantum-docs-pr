---
uid: Microsoft.Quantum.Intrinsic.ResetAll
title: ResetAll operation
ms.date: 11/13/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Intrinsic
qsharp.name: ResetAll
qsharp.summary: >-
  Given an array of qubits, measure them and ensure they are in the |0⟩ state
  such that they can be safely released.
---

# ResetAll operation

Namespace: [Microsoft.Quantum.Intrinsic](xref:Microsoft.Quantum.Intrinsic)

Package: [Microsoft.Quantum.QSharp.Core](https://nuget.org/packages/Microsoft.Quantum.QSharp.Core)


Given an array of qubits, measure them and ensure they are in the |0⟩ statesuch that they can be safely released.

```qsharp
operation ResetAll (qubits : Qubit[]) : Unit
```


## Input

### qubits : [Qubit](xref:microsoft.quantum.lang-ref.qubit)[]

An array of qubits whose states are to be reset to $\ket{0}$.



## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)

