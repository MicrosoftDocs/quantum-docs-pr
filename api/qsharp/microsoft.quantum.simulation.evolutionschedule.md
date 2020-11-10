---
uid: Microsoft.Quantum.Simulation.EvolutionSchedule
title: EvolutionSchedule user defined type
ms.date: 10/26/2020 12:00:00 AM
ms.topic: article
qsharp.kind: udt
qsharp.namespace: Microsoft.Quantum.Simulation
qsharp.name: EvolutionSchedule
qsharp.summary: >-
  Represents a time-dependent dynamical generator.

  The `Double`
  parameter is a schedule in $[0, 1]$.
---

# EvolutionSchedule user defined type

Namespace: [Microsoft.Quantum.Simulation](xref:Microsoft.Quantum.Simulation)

Package: [](https://nuget.org/packages/)


Represents a time-dependent dynamical generator.The `Double`parameter is a schedule in $[0, 1]$.

```qsharp

newtype EvolutionSchedule = (Microsoft.Quantum.Simulation.EvolutionSet, (Double -> Microsoft.Quantum.Simulation.GeneratorSystem));
```

