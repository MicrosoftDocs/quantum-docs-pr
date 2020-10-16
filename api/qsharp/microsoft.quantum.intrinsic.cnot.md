---
uid: Microsoft.Quantum.Intrinsic.CNOT
title: CNOT operation
ms.date: 10/16/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Intrinsic
qsharp.name: CNOT
qsharp.summary: >-
  Applies the controlled-NOT (CNOT) gate to a pair of qubits.

  \begin{align}
  \operatorname{CNOT} \mathrel{:=}
  \begin{bmatrix}
  1 & 0 & 0 & 0 \\\\
  0 & 1 & 0 & 0 \\\\
  0 & 0 & 0 & 1 \\\\
  0 & 0 & 1 & 0
  \end{bmatrix},
  \end{align}

  where rows and columns are ordered as in the quantum concepts guide.
---

# CNOT operation

Namespace: [Microsoft.Quantum.Intrinsic](xref:Microsoft.Quantum.Intrinsic)

Package: [](https://nuget.org/packages/)


Applies the controlled-NOT (CNOT) gate to a pair of qubits.\begin{align}\operatorname{CNOT} \mathrel{:=}\begin{bmatrix}1 & 0 & 0 & 0 \\\\0 & 1 & 0 & 0 \\\\0 & 0 & 0 & 1 \\\\0 & 0 & 1 & 0\end{bmatrix},\end{align}where rows and columns are ordered as in the quantum concepts guide.

```Q#
CNOT (control : Qubit, target : Qubit) : Unit
```


## Input

### control : Qubit

Control qubit for the CNOT gate.


### target : Qubit

Target qubit for the CNOT gate.



## Remarks

Equivalent to:```qsharpControlled X([control], target);```