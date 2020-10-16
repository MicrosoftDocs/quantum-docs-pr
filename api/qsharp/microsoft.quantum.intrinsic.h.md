---
uid: Microsoft.Quantum.Intrinsic.H
title: H operation
ms.date: 10/16/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Intrinsic
qsharp.name: H
qsharp.summary: >-
  Applies the Hadamard transformation to a single qubit.

  \begin{align}
  H \mathrel{:=}
  \frac{1}{\sqrt{2}}
  \begin{bmatrix}
  1 & 1 \\\\
  1 & -1
  \end{bmatrix}.
  \end{align}
---

# H operation

Namespace: [Microsoft.Quantum.Intrinsic](xref:Microsoft.Quantum.Intrinsic)

Package: [](https://nuget.org/packages/)


Applies the Hadamard transformation to a single qubit.\begin{align}H \mathrel{:=}\frac{1}{\sqrt{2}}\begin{bmatrix}1 & 1 \\\\1 & -1\end{bmatrix}.\end{align}

```Q#
H (qubit : Qubit) : Unit
```


## Input

### qubit : Qubit

Qubit to which the gate should be applied.

