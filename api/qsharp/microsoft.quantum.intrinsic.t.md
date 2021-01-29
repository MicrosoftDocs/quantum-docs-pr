---
uid: Microsoft.Quantum.Intrinsic.T
title: T operation
ms.date: 1/29/2021 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Intrinsic
qsharp.name: T
qsharp.summary: Applies the T gate to a single qubit.
---

# T operation

Namespace: [Microsoft.Quantum.Intrinsic](xref:Microsoft.Quantum.Intrinsic)

Package: [Microsoft.Quantum.QSharp.Core](https://nuget.org/packages/Microsoft.Quantum.QSharp.Core)


Applies the T gate to a single qubit.

```qsharp
operation T (qubit : Qubit) : Unit is Adj + Ctl
```


## Description

This operation can be simulated by the unitary matrix\begin{align}T \mathrel{:=}\begin{bmatrix}1 & 0 \\\\0 & e^{i \pi / 4}\end{bmatrix}.\end{align}

## Input

### qubit : [Qubit](xref:microsoft.quantum.lang-ref.qubit)

Qubit to which the gate should be applied.



## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)

