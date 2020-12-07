---
uid: Microsoft.Quantum.Intrinsic.Y
title: Y operation
ms.date: 12/7/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Intrinsic
qsharp.name: Y
qsharp.summary: >-
  Applies the Pauli $Y$ gate.

  \begin{align}
  \sigma_y \mathrel{:=}
  \begin{bmatrix}
  0 & -i \\\\
  i & 0
  \end{bmatrix}.
  \end{align}
---

# Y operation

Namespace: [Microsoft.Quantum.Intrinsic](xref:Microsoft.Quantum.Intrinsic)

Package: [Microsoft.Quantum.QSharp.Core](https://nuget.org/packages/Microsoft.Quantum.QSharp.Core)


Applies the Pauli $Y$ gate.\begin{align}\sigma_y \mathrel{:=}\begin{bmatrix}0 & -i \\\\i & 0\end{bmatrix}.\end{align}

```qsharp
operation Y (qubit : Qubit) : Unit is Adj + Ctl
```


## Input

### qubit : [Qubit](xref:microsoft.quantum.lang-ref.qubit)

Qubit to which the gate should be applied.



## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)

