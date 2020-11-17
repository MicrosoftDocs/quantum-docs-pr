---
uid: Microsoft.Quantum.Simulation.BlockEncoding
title: BlockEncoding user defined type
ms.date: 11/17/2020 12:00:00 AM
ms.topic: article
qsharp.kind: udt
qsharp.namespace: Microsoft.Quantum.Simulation
qsharp.name: BlockEncoding
qsharp.summary: >-
  Represents a unitary where an arbitrary operator of
  interest is encoded in the top-left block.

  That is, a `BlockEncoding` is a unitary $U$ where an arbitrary operator $H$ of
  interest that acts on the system register `s` is encoded in the top-
  left block corresponding to auxiliary state $\ket{0}_a$. That is,

  $$
  \begin{align}
  (\bra{0}_a\otimes I_s)U(\ket{0}_a\otimes I_s) = H
  \end{align}
  $$.
---

# BlockEncoding user defined type

Namespace: [Microsoft.Quantum.Simulation](xref:Microsoft.Quantum.Simulation)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Represents a unitary where an arbitrary operator ofinterest is encoded in the top-left block.That is, a `BlockEncoding` is a unitary $U$ where an arbitrary operator $H$ ofinterest that acts on the system register `s` is encoded in the top-left block corresponding to auxiliary state $\ket{0}_a$. That is,$$\begin{align}(\bra{0}_a\otimes I_s)U(\ket{0}_a\otimes I_s) = H\end{align}$$.

```qsharp

newtype BlockEncoding = (((Qubit[], Qubit[]) => Unit is Adj + Ctl));
```

