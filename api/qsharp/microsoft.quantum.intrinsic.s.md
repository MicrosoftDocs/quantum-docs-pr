---
uid: Microsoft.Quantum.Intrinsic.S
title: S operation
ms.date: 11/9/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Intrinsic
qsharp.name: S
qsharp.summary: Applies the S gate to a single qubit.
---

# S operation

Namespace: [Microsoft.Quantum.Intrinsic](xref:Microsoft.Quantum.Intrinsic)

Package: [Microsoft.Quantum.QSharp.Core](https://nuget.org/packages/Microsoft.Quantum.QSharp.Core)


Applies the S gate to a single qubit.

```qsharp
operation S (qubit : Qubit) : Unit is Adj + Ctl
```


## Description

This operation can be simulated by the unitary matrix\begin{align}S \mathrel{:=}\begin{bmatrix}1 & 0 \\\\0 & i\end{bmatrix}.\end{align}

## Input

### qubit : [Qubit](xref:microsoft.quantum.lang-ref.qubit)

Qubit to which the gate should be applied.



## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)

