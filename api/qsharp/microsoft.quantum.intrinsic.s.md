---
uid: Microsoft.Quantum.Intrinsic.S
title: S operation
ms.date: 1/29/2021 12:00:00 AM
ms.topic: managed-reference
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Intrinsic
qsharp.name: S
qsharp.summary: Applies the π/4 phase gate to a single qubit.
---

# S operation

Namespace: [Microsoft.Quantum.Intrinsic](xref:Microsoft.Quantum.Intrinsic)

Package: [Microsoft.Quantum.QSharp.Core](https://nuget.org/packages/Microsoft.Quantum.QSharp.Core)


Applies the π/4 phase gate to a single qubit.

```qsharp
operation S (qubit : Qubit) : Unit is Adj + Ctl
```


## Description

\begin{align}S \mathrel{:=}\begin{bmatrix}1 & 0 \\\\0 & i\end{bmatrix}.\end{align}

## Input

### qubit : [Qubit](xref:microsoft.quantum.lang-ref.qubit)

Qubit to which the gate should be applied.



## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)

