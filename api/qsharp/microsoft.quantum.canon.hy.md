---
uid: Microsoft.Quantum.Canon.HY
title: HY operation
ms.date: 10/26/2020 12:00:00 AM
ms.topic: article
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

Package: [](https://nuget.org/packages/)


Applies the Y-basis analog to the Hadamard transformationthat interchanges the Z and Y axes.The Y Hadamard transformation $H_Y = S H$ on a single qubit is:\begin{align}H_Y \mathrel{:=}\frac{1}{\sqrt{2}}\begin{bmatrix}1 & 1 \\\\i & -i\end{bmatrix}.\end{align}

```qsharp
operation HY (target : Qubit) : Unit
```


## Input

### target : [Qubit](xref:microsoft.quantum.lang-ref.qubit)

Qubit to which the gate should be applied.



## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)



## See Also

- [Microsoft.Quantum.Intrinsic.H](xref:Microsoft.Quantum.Intrinsic.H)