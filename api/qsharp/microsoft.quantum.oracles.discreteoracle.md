---
uid: Microsoft.Quantum.Oracles.DiscreteOracle
title: DiscreteOracle user defined type
ms.date: 10/16/2020 12:00:00 AM
ms.topic: article
qsharp.kind: udt
qsharp.namespace: Microsoft.Quantum.Oracles
qsharp.name: DiscreteOracle
qsharp.summary: >-
  Represents a discrete-time oracle.

  This is an oracle that implements $U^m$ for a fixed operation $U$
  and a non-negative integer $m$.
---

# DiscreteOracle user defined type

Namespace: [Microsoft.Quantum.Oracles](xref:Microsoft.Quantum.Oracles)

Package: [](https://nuget.org/packages/)


Represents a discrete-time oracle.This is an oracle that implements $U^m$ for a fixed operation $U$and a non-negative integer $m$.

```Q#

newtype DiscreteOracle = (((Int, Qubit[]) => Unit is Adj + Ctl));
```

