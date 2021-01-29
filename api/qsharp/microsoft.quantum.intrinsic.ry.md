---
uid: Microsoft.Quantum.Intrinsic.Ry
title: Ry operation
ms.date: 1/29/2021 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Intrinsic
qsharp.name: Ry
qsharp.summary: >-
  Applies a rotation about the $y$-axis by a given angle.

  \begin{align}
  R_y(\theta) \mathrel{:=}
  e^{-i \theta \sigma_y / 2} =
  \begin{bmatrix}
  \cos \frac{\theta}{2} & -\sin \frac{\theta}{2}  \\\\
  \sin \frac{\theta}{2} & \cos \frac{\theta}{2}
  \end{bmatrix}.
  \end{align}
---

# Ry operation

Namespace: [Microsoft.Quantum.Intrinsic](xref:Microsoft.Quantum.Intrinsic)

Package: [Microsoft.Quantum.QSharp.Core](https://nuget.org/packages/Microsoft.Quantum.QSharp.Core)


Applies a rotation about the $y$-axis by a given angle.\begin{align}R_y(\theta) \mathrel{:=}e^{-i \theta \sigma_y / 2} =\begin{bmatrix}\cos \frac{\theta}{2} & -\sin \frac{\theta}{2}  \\\\\sin \frac{\theta}{2} & \cos \frac{\theta}{2}\end{bmatrix}.\end{align}

```qsharp
operation Ry (theta : Double, qubit : Qubit) : Unit is Adj + Ctl
```


## Input

### theta : [Double](xref:microsoft.quantum.lang-ref.double)

Angle about which the qubit is to be rotated.


### qubit : [Qubit](xref:microsoft.quantum.lang-ref.qubit)

Qubit to which the gate should be applied.



## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)



## Remarks

Equivalent to:```qsharpR(PauliY, theta, qubit);```