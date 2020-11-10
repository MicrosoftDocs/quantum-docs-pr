---
uid: Microsoft.Quantum.Simulation.EvolutionUnitary
title: EvolutionUnitary user defined type
ms.date: 10/26/2020 12:00:00 AM
ms.topic: article
qsharp.kind: udt
qsharp.namespace: Microsoft.Quantum.Simulation
qsharp.name: EvolutionUnitary
qsharp.summary: >-
  Represents a unitary time-evolution operator.

  The first parameter is
  is duration of time-evolution, and the second parameter is the qubit
  register acted upon by the unitary.
---

# EvolutionUnitary user defined type

Namespace: [Microsoft.Quantum.Simulation](xref:Microsoft.Quantum.Simulation)

Package: [](https://nuget.org/packages/)


Represents a unitary time-evolution operator.The first parameter isis duration of time-evolution, and the second parameter is the qubitregister acted upon by the unitary.

```qsharp

newtype EvolutionUnitary = (((Double, Qubit[]) => Unit is Adj + Ctl));
```

