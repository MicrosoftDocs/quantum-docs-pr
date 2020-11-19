---
uid: Microsoft.Quantum.Intrinsic.X
title: X operation
ms.date: 11/19/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Intrinsic
qsharp.name: X
qsharp.summary: >-
  Applies the Pauli $X$ gate.

  \begin{align}
  \sigma_x \mathrel{:=}
  \begin{bmatrix}
  0 & 1 \\\\
  1 & 0
  \end{bmatrix}.
  \end{align}
---

# X operation

Namespace: [Microsoft.Quantum.Intrinsic](xref:Microsoft.Quantum.Intrinsic)

Package: [Microsoft.Quantum.QSharp.Core](https://nuget.org/packages/Microsoft.Quantum.QSharp.Core)


Applies the Pauli $X$ gate.\begin{align}\sigma_x \mathrel{:=}\begin{bmatrix}0 & 1 \\\\1 & 0\end{bmatrix}.\end{align}

```qsharp
operation X (qubit : Qubit) : Unit is Adj + Ctl
```


## Input

### qubit : [Qubit](xref:microsoft.quantum.lang-ref.qubit)

Qubit to which the gate should be applied.



## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)

