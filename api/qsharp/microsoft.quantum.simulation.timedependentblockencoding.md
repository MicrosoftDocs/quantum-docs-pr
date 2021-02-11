---
uid: Microsoft.Quantum.Simulation.TimeDependentBlockEncoding
title: TimeDependentBlockEncoding user defined type
ms.date: 2/11/2021 12:00:00 AM
ms.topic: article
qsharp.kind: udt
qsharp.namespace: Microsoft.Quantum.Simulation
qsharp.name: TimeDependentBlockEncoding
qsharp.summary: >-
  Represents a `BlockEncoding` that is controlled by a clock register.

  That is, a `TimeDependentBlockEncoding` is a unitary $U$ controlled by a state
  $\ket{k}_d$ in clock register `d` such that an arbitrary operator $H_k$ of
  interest that acts on the system register `s` is encoded in the top-
  left block corresponding to auxiliary state $\ket{0}_a$. That is,

  $$
  \begin{align}
  (\bra{0}\_a\otimes I_{ds})U(\ket{0}\_a\otimes I_{ds}) = \sum_{k}\ket{k}\bra{k}\_d\otimes H_k.
  \end{align}
  $$.
---

# TimeDependentBlockEncoding user defined type

Namespace: [Microsoft.Quantum.Simulation](xref:Microsoft.Quantum.Simulation)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Represents a `BlockEncoding` that is controlled by a clock register.That is, a `TimeDependentBlockEncoding` is a unitary $U$ controlled by a state$\ket{k}_d$ in clock register `d` such that an arbitrary operator $H_k$ ofinterest that acts on the system register `s` is encoded in the top-left block corresponding to auxiliary state $\ket{0}_a$. That is,$$\begin{align}(\bra{0}\_a\otimes I_{ds})U(\ket{0}\_a\otimes I_{ds}) = \sum_{k}\ket{k}\bra{k}\_d\otimes H_k.\end{align}$$.

```qsharp

newtype TimeDependentBlockEncoding = (((Qubit[], Qubit[], Qubit[]) => Unit is Adj + Ctl));
```

