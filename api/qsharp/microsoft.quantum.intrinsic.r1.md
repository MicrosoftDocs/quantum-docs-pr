---
uid: Microsoft.Quantum.Intrinsic.R1
title: R1 operation
ms.date: 10/16/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Intrinsic
qsharp.name: R1
qsharp.summary: >-
  Applies a rotation about the $\ket{1}$ state by a given angle.

  \begin{align}
  R_1(\theta) \mathrel{:=}
  \operatorname{diag}(1, e^{i\theta}).
  \end{align}
---

# R1 operation

Namespace: [Microsoft.Quantum.Intrinsic](xref:Microsoft.Quantum.Intrinsic)

Package: [](https://nuget.org/packages/)


Applies a rotation about the $\ket{1}$ state by a given angle.\begin{align}R_1(\theta) \mathrel{:=}\operatorname{diag}(1, e^{i\theta}).\end{align}

```Q#
R1 (theta : Double, qubit : Qubit) : Unit
```


## Input

### theta : Double

Angle about which the qubit is to be rotated.


### qubit : Qubit

Qubit to which the gate should be applied.



## Remarks

Equivalent to:```qsharpR(PauliZ, theta, qubit);R(PauliI, -theta, qubit);```