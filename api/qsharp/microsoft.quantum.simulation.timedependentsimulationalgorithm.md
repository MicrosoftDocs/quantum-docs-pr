---
uid: Microsoft.Quantum.Simulation.TimeDependentSimulationAlgorithm
title: TimeDependentSimulationAlgorithm user defined type
ms.date: 10/30/2020 12:00:00 AM
ms.topic: article
qsharp.kind: udt
qsharp.namespace: Microsoft.Quantum.Simulation
qsharp.name: TimeDependentSimulationAlgorithm
qsharp.summary: >-
  Represents a time-dependent simulation algorithm.

  A time-dependent simulation technique converts an
  <xref:microsoft.quantum.simulation.evolutionschedule>
  to unitary time-evolution for some time-interval.
---

# TimeDependentSimulationAlgorithm user defined type

Namespace: [Microsoft.Quantum.Simulation](xref:Microsoft.Quantum.Simulation)

Package: [](https://nuget.org/packages/)


Represents a time-dependent simulation algorithm.A time-dependent simulation technique converts an<xref:microsoft.quantum.simulation.evolutionschedule>to unitary time-evolution for some time-interval.

```qsharp

newtype TimeDependentSimulationAlgorithm = (((Double, Microsoft.Quantum.Simulation.EvolutionSchedule, Qubit[]) => Unit is Adj + Ctl));
```

