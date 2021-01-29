---
uid: Microsoft.Quantum.Oracles.DiscreteOracle
title: DiscreteOracle user defined type
ms.date: 1/29/2021 12:00:00 AM
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

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Represents a discrete-time oracle.This is an oracle that implements $U^m$ for a fixed operation $U$and a non-negative integer $m$.

```qsharp

newtype DiscreteOracle = (((Int, Qubit[]) => Unit is Adj + Ctl));
```

