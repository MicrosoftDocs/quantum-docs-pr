---
uid: Microsoft.Quantum.Arithmetic.ApplyMajorityInPlace
title: ApplyMajorityInPlace operation
ms.date: 11/9/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Arithmetic
qsharp.name: ApplyMajorityInPlace
qsharp.summary: >-
  Applies the three-qubit majority operation in-place on a register of
  qubits.
---

# ApplyMajorityInPlace operation

Namespace: [Microsoft.Quantum.Arithmetic](xref:Microsoft.Quantum.Arithmetic)

Package: [](https://nuget.org/packages/)


Applies the three-qubit majority operation in-place on a register ofqubits.

```qsharp
operation ApplyMajorityInPlace (output : Qubit, input : Qubit[]) : Unit
```


## Description

This operation computes the majority function in-place on 3 qubits.If we denote output qubit as $z$ and input qubits as $x$ and $y$,the operation performs the following transformation:$\ket{xyz} \rightarrow \ket{x \oplus z} \ket{y \oplus z} \ket{\operatorname{MAJ} (x, y, z)}$.

## Input

### output : [Qubit](xref:microsoft.quantum.lang-ref.qubit)

First input qubit. Note that the output is computed in-placeand stored in this qubit.


### input : [Qubit](xref:microsoft.quantum.lang-ref.qubit)[]

Second and third input qubits.



## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)

