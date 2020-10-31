---
uid: Microsoft.Quantum.Simulation.SimulationAlgorithm
title: SimulationAlgorithm user defined type
ms.date: 10/31/2020 12:00:00 AM
ms.topic: article
qsharp.kind: udt
qsharp.namespace: Microsoft.Quantum.Simulation
qsharp.name: SimulationAlgorithm
qsharp.summary: >-
  Represents a time-independent simulation algorithm.

  A time-independent simulation technique converts an
  <xref:microsoft.quantum.simulation.evolutiongenerator>
  to unitary time evolution for some time-interval.
---

# SimulationAlgorithm user defined type

Namespace: [Microsoft.Quantum.Simulation](xref:Microsoft.Quantum.Simulation)

Package: [](https://nuget.org/packages/)


Represents a time-independent simulation algorithm.A time-independent simulation technique converts an<xref:microsoft.quantum.simulation.evolutiongenerator>to unitary time evolution for some time-interval.

```qsharp

newtype SimulationAlgorithm = (((Double, Microsoft.Quantum.Simulation.EvolutionGenerator, Qubit[]) => Unit is Adj + Ctl));
```

