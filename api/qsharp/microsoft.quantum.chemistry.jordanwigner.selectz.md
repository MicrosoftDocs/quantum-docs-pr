---
uid: Microsoft.Quantum.Chemistry.JordanWigner.SelectZ
title: SelectZ operation
ms.date: 10/16/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Chemistry.JordanWigner
qsharp.name: SelectZ
qsharp.summary: >-
  A unitary $U$ that applies the Pauli $Z$ gate on a qubits $p$ conditioned
  on an index state $\ket{p}$. That is,
  $$
  \begin{align}
  U\ket{p}\ket{\psi} = \ket{p}Z\_p\ket{\psi}
  \end{align}
  $$
---

# SelectZ operation

Namespace: [Microsoft.Quantum.Chemistry.JordanWigner](xref:Microsoft.Quantum.Chemistry.JordanWigner)

Package: [](https://nuget.org/packages/)


A unitary $U$ that applies the Pauli $Z$ gate on a qubits $p$ conditionedon an index state $\ket{p}$. That is,$$\begin{align}U\ket{p}\ket{\psi} = \ket{p}Z\_p\ket{\psi}\end{align}$$

```Q#
SelectZ (indexRegister : Microsoft.Quantum.Arithmetic.LittleEndian, targetRegister : Qubit[]) : Unit
```


## Input

### indexRegister : [LittleEndian](xref:Microsoft.Quantum.Arithmetic.LittleEndian)

The state $\ket{p}$ of this register determines the qubit on which $Z$ is applied.


### targetRegister : Qubit[]

Register of qubits on which the Pauli operators are applied.

