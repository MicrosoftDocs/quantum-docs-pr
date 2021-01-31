---
uid: Microsoft.Quantum.Arithmetic.MAJ
title: MAJ operation
ms.date: 1/31/2021 12:00:00 AM
ms.topic: managed-reference
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Arithmetic
qsharp.name: MAJ
qsharp.summary: This applies the in-place majority operation to 3 qubits.
---

# MAJ operation

Namespace: [Microsoft.Quantum.Arithmetic](xref:Microsoft.Quantum.Arithmetic)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


This applies the in-place majority operation to 3 qubits.

```qsharp
operation MAJ (input0 : Qubit, input1 : Qubit, target : Qubit) : Unit is Adj + Ctl
```


## Description

If we denote the state of the target qubit as $\ket{z}$, and input states ofthe input qubits as $\ket{x}$ and $\ket{y}$, thenthis operation performs the following transformation:$\ket{xyz} \rightarrow \ket{x \oplus z} \ket{y \oplus z} \ket{\operatorname{MAJ} (x, y, z)}$.

## Input

### input0 : [Qubit](xref:microsoft.quantum.lang-ref.qubit)

The first input qubit.


### input1 : [Qubit](xref:microsoft.quantum.lang-ref.qubit)

The second input qubit.


### target : [Qubit](xref:microsoft.quantum.lang-ref.qubit)

A qubit onto which the majority function will be applied.



## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)

