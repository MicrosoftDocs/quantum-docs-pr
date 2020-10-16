---
uid: Microsoft.Quantum.Intrinsic.T
title: T operation
ms.date: 10/16/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Intrinsic
qsharp.name: T
qsharp.summary: Applies the T gate to a single qubit.
---

# T operation

Namespace: [Microsoft.Quantum.Intrinsic](xref:Microsoft.Quantum.Intrinsic)

Package: [](https://nuget.org/packages/)


Applies the T gate to a single qubit.

```Q#
T (qubit : Qubit) : Unit
```


## Description

This operation can be simulated by the unitary matrix\begin{align}T \mathrel{:=}\begin{bmatrix}1 & 0 \\\\0 & e^{i \pi / 4}\end{bmatrix}.\end{align}

## Input

### qubit : Qubit

Qubit to which the gate should be applied.

