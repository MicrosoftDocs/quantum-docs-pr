---
uid: Microsoft.Quantum.Intrinsic.Exp
title: Exp operation
ms.date: 10/16/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Intrinsic
qsharp.name: Exp
qsharp.summary: >-
  Applies the exponential of a multi-qubit Pauli operator.

  \begin{align}
  e^{i \theta [P_0 \otimes P_1 \cdots P_{N-1}]},
  \end{align}
  where $P_i$ is the $i$th element of `paulis`, and where
  $N = $`Length(paulis)`.
---

# Exp operation

Namespace: [Microsoft.Quantum.Intrinsic](xref:Microsoft.Quantum.Intrinsic)

Package: [](https://nuget.org/packages/)


Applies the exponential of a multi-qubit Pauli operator.\begin{align}e^{i \theta [P_0 \otimes P_1 \cdots P_{N-1}]},\end{align}where $P_i$ is the $i$th element of `paulis`, and where$N = $`Length(paulis)`.

```Q#
Exp (paulis : Pauli[], theta : Double, qubits : Qubit[]) : Unit
```


## Input

### paulis : Pauli[]

Array of single-qubit Pauli values indicating the tensor productfactors on each qubit.


### theta : Double

Angle about the given multi-qubit Pauli operator by which thetarget register is to be rotated.


### qubits : Qubit[]

Register to apply the given rotation to.

