---
uid: Microsoft.Quantum.Simulation.EvolutionSchedule
title: EvolutionSchedule user defined type
ms.date: 2/13/2021 12:00:00 AM
ms.topic: managed-reference
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

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Represents a time-dependent dynamical generator.The `Double`parameter is a schedule in $[0, 1]$.

```qsharp

newtype EvolutionSchedule = (Microsoft.Quantum.Simulation.EvolutionSet, (Double -> Microsoft.Quantum.Simulation.GeneratorSystem));
```

