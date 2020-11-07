---
uid: Microsoft.Quantum.Intrinsic.Rz
title: Rz operation
ms.date: 11/7/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Intrinsic
qsharp.name: Rz
qsharp.summary: >-
  Applies a rotation about the $z$-axis by a given angle.

  \begin{align}
  R_z(\theta) \mathrel{:=}
  e^{-i \theta \sigma_z / 2} =
  \begin{bmatrix}
  e^{-i \theta / 2} & 0 \\\\
  0 & e^{i \theta / 2}
  \end{bmatrix}.
  \end{align}
---

# Rz operation

Namespace: [Microsoft.Quantum.Intrinsic](xref:Microsoft.Quantum.Intrinsic)

Package: [](https://nuget.org/packages/)


Applies a rotation about the $z$-axis by a given angle.\begin{align}R_z(\theta) \mathrel{:=}e^{-i \theta \sigma_z / 2} =\begin{bmatrix}e^{-i \theta / 2} & 0 \\\\0 & e^{i \theta / 2}\end{bmatrix}.\end{align}

```qsharp
operation Rz (theta : Double, qubit : Qubit) : Unit
```


## Input

### theta : [Double](xref:microsoft.quantum.lang-ref.double)

Angle about which the qubit is to be rotated.


### qubit : [Qubit](xref:microsoft.quantum.lang-ref.qubit)

Qubit to which the gate should be applied.



## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)



## Remarks

Equivalent to:```qsharpR(PauliZ, theta, qubit);```