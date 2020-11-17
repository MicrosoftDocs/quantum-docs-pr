---
uid: Microsoft.Quantum.Intrinsic.R
title: R operation
ms.date: 11/17/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Intrinsic
qsharp.name: R
qsharp.summary: >-
  Applies a rotation about the given Pauli axis.

  \begin{align}
  R_{\mu}(\theta) \mathrel{:=}
  e^{-i \theta \sigma_{\mu} / 2},
  \end{align}
  where $\mu \in \{I, X, Y, Z\}$.
---

# R operation

Namespace: [Microsoft.Quantum.Intrinsic](xref:Microsoft.Quantum.Intrinsic)

Package: [Microsoft.Quantum.QSharp.Core](https://nuget.org/packages/Microsoft.Quantum.QSharp.Core)


Applies a rotation about the given Pauli axis.\begin{align}R_{\mu}(\theta) \mathrel{:=}e^{-i \theta \sigma_{\mu} / 2},\end{align}where $\mu \in \{I, X, Y, Z\}$.

```qsharp
operation R (pauli : Pauli, theta : Double, qubit : Qubit) : Unit is Adj + Ctl
```


## Input

### pauli : [Pauli](xref:microsoft.quantum.lang-ref.pauli)

Pauli operator ($\mu$) to be exponentiated to form the rotation.


### theta : [Double](xref:microsoft.quantum.lang-ref.double)

Angle about which the qubit is to be rotated.


### qubit : [Qubit](xref:microsoft.quantum.lang-ref.qubit)

Qubit to which the gate should be applied.



## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)



## Remarks

When called with `pauli = PauliI`, this operation appliesa *global phase*. This phase can be significantwhen used with the `Controlled` functor.