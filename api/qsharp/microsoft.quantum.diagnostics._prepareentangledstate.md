---
uid: Microsoft.Quantum.Diagnostics._prepareEntangledState
title: _prepareEntangledState operation
ms.date: 11/9/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Diagnostics
qsharp.name: _prepareEntangledState
qsharp.summary: >-
  Given two registers, prepares the maximally entangled state
  between each pair of qubits on the respective registers.
  All qubits must start in the |0⟩ state.

  The result is that corresponding pairs of qubits from each register are in the
  $\bra{\beta_{00}}\ket{\beta_{00}}$.
---

# _prepareEntangledState operation

Namespace: [Microsoft.Quantum.Diagnostics](xref:Microsoft.Quantum.Diagnostics)

Package: [Microsoft.Quantum.QSharp.Core](https://nuget.org/packages/Microsoft.Quantum.QSharp.Core)


Given two registers, prepares the maximally entangled statebetween each pair of qubits on the respective registers.All qubits must start in the |0⟩ state.The result is that corresponding pairs of qubits from each register are in the$\bra{\beta_{00}}\ket{\beta_{00}}$.

```qsharp
operation _prepareEntangledState (left : Qubit[], right : Qubit[]) : Unit is Adj + Ctl
```


## Input

### left : [Qubit](xref:microsoft.quantum.lang-ref.qubit)[]

A qubit array in the $\ket{0\cdots 0}$ state


### right : [Qubit](xref:microsoft.quantum.lang-ref.qubit)[]

A qubit array in the $\ket{0\cdots 0}$ state



## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)

