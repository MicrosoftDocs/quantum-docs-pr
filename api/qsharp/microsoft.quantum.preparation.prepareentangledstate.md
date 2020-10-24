---
uid: Microsoft.Quantum.Preparation.PrepareEntangledState
title: PrepareEntangledState operation
ms.date: 10/24/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Preparation
qsharp.name: PrepareEntangledState
qsharp.summary: >-
  Pairwise entangles two qubit registers.

  That is, given two registers, prepares the maximally entangled state
  $\frac{1}{\sqrt{2}} \left(\ket{00} + \ket{11} \right)$ between each pair of qubits on the respective registers,
  assuming that each register starts in the $\ket{0\cdots 0}$ state.
---

# PrepareEntangledState operation

Namespace: [Microsoft.Quantum.Preparation](xref:Microsoft.Quantum.Preparation)

Package: [](https://nuget.org/packages/)


Pairwise entangles two qubit registers.That is, given two registers, prepares the maximally entangled state$\frac{1}{\sqrt{2}} \left(\ket{00} + \ket{11} \right)$ between each pair of qubits on the respective registers,assuming that each register starts in the $\ket{0\cdots 0}$ state.

```qsharp
operation PrepareEntangledState (left : Qubit[], right : Qubit[]) : Unit
```


## Input

### left : [Qubit](xref:microsoft.quantum.lang-ref.qubit)[]

A qubit array in the $\ket{0\cdots 0}$ state


### right : [Qubit](xref:microsoft.quantum.lang-ref.qubit)[]

A qubit array in the $\ket{0\cdots 0}$ state



## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)

