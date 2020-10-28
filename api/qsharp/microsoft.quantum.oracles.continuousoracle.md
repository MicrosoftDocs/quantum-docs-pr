---
uid: Microsoft.Quantum.Oracles.ContinuousOracle
title: ContinuousOracle user defined type
ms.date: 10/28/2020 12:00:00 AM
ms.topic: article
qsharp.kind: udt
qsharp.namespace: Microsoft.Quantum.Oracles
qsharp.name: ContinuousOracle
qsharp.summary: >-
  Represents a continuous-time oracle.

  This is an oracle that implements
  $U(\delta t) : \ket{\psi(t)} \mapsto \ket{\psi(t + \delta t)}$
  for all times $t$, where $U$ is a fixed operation, and where
  $\delta t$ is a non-negative real number.
---

# ContinuousOracle user defined type

Namespace: [Microsoft.Quantum.Oracles](xref:Microsoft.Quantum.Oracles)

Package: [](https://nuget.org/packages/)


Represents a continuous-time oracle.This is an oracle that implements$U(\delta t) : \ket{\psi(t)} \mapsto \ket{\psi(t + \delta t)}$for all times $t$, where $U$ is a fixed operation, and where$\delta t$ is a non-negative real number.

```qsharp

newtype ContinuousOracle = (((Double, Qubit[]) => Unit is Adj + Ctl));
```

