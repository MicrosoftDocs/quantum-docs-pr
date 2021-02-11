---
uid: Microsoft.Quantum.Intrinsic.Rx
title: Rx operation
ms.date: 2/11/2021 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Intrinsic
qsharp.name: Rx
qsharp.summary: >-
  Applies a rotation about the $x$-axis by a given angle.

  \begin{align}
  R_x(\theta) \mathrel{:=}
  e^{-i \theta \sigma_x / 2} =
  \begin{bmatrix}
  \cos \frac{\theta}{2} & -i\sin \frac{\theta}{2}  \\\\
  -i\sin \frac{\theta}{2} & \cos \frac{\theta}{2}
  \end{bmatrix}.
  \end{align}
---

# Rx operation

Namespace: [Microsoft.Quantum.Intrinsic](xref:Microsoft.Quantum.Intrinsic)

Package: [Microsoft.Quantum.QSharp.Core](https://nuget.org/packages/Microsoft.Quantum.QSharp.Core)


Applies a rotation about the $x$-axis by a given angle.\begin{align}R_x(\theta) \mathrel{:=}e^{-i \theta \sigma_x / 2} =\begin{bmatrix}\cos \frac{\theta}{2} & -i\sin \frac{\theta}{2}  \\\\-i\sin \frac{\theta}{2} & \cos \frac{\theta}{2}\end{bmatrix}.\end{align}

```qsharp
operation Rx (theta : Double, qubit : Qubit) : Unit is Adj + Ctl
```


## Input

### theta : [Double](xref:microsoft.quantum.lang-ref.double)

Angle about which the qubit is to be rotated.


### qubit : [Qubit](xref:microsoft.quantum.lang-ref.qubit)

Qubit to which the gate should be applied.



## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)



## Remarks

Equivalent to:```qsharpR(PauliX, theta, qubit);```