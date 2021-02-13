---
uid: Microsoft.Quantum.Chemistry.JordanWigner.SelectZ
title: SelectZ operation
ms.date: 2/13/2021 12:00:00 AM
ms.topic: managed-reference
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

Package: [Microsoft.Quantum.Chemistry](https://nuget.org/packages/Microsoft.Quantum.Chemistry)


A unitary $U$ that applies the Pauli $Z$ gate on a qubits $p$ conditionedon an index state $\ket{p}$. That is,$$\begin{align}U\ket{p}\ket{\psi} = \ket{p}Z\_p\ket{\psi}\end{align}$$

```qsharp
operation SelectZ (indexRegister : Microsoft.Quantum.Arithmetic.LittleEndian, targetRegister : Qubit[]) : Unit is Adj + Ctl
```


## Input

### indexRegister : [LittleEndian](xref:Microsoft.Quantum.Arithmetic.LittleEndian)

The state $\ket{p}$ of this register determines the qubit on which $Z$ is applied.


### targetRegister : [Qubit](xref:microsoft.quantum.lang-ref.qubit)[]

Register of qubits on which the Pauli operators are applied.



## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)

