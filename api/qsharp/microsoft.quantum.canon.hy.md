---
uid: Microsoft.Quantum.Canon.HY
title: HY operation
ms.date: 2/10/2021 12:00:00 AM
ms.topic: managed-reference
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Canon
qsharp.name: HY
qsharp.summary: >-
  Applies the Y-basis analog to the Hadamard transformation
  that interchanges the Z and Y axes.

  The Y Hadamard transformation $H_Y = S H$ on a single qubit is:

  \begin{align}
  H_Y \mathrel{:=}
  \frac{1}{\sqrt{2}}
  \begin{bmatrix}
  1 & 1 \\\\
  i & -i
  \end{bmatrix}.
  \end{align}
---

# HY operation

Namespace: [Microsoft.Quantum.Canon](xref:Microsoft.Quantum.Canon)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Applies the Y-basis analog to the Hadamard transformationthat interchanges the Z and Y axes.The Y Hadamard transformation $H_Y = S H$ on a single qubit is:\begin{align}H_Y \mathrel{:=}\frac{1}{\sqrt{2}}\begin{bmatrix}1 & 1 \\\\i & -i\end{bmatrix}.\end{align}

```qsharp
operation HY (target : Qubit) : Unit is Adj + Ctl
```


## Input

### target : [Qubit](xref:microsoft.quantum.lang-ref.qubit)

Qubit to which the gate should be applied.



## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)



## See Also

- [Microsoft.Quantum.Intrinsic.H](xref:Microsoft.Quantum.Intrinsic.H)