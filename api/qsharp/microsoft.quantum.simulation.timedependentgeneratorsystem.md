---
uid: Microsoft.Quantum.Simulation.TimeDependentGeneratorSystem
title: TimeDependentGeneratorSystem user defined type
ms.date: 10/26/2020 12:00:00 AM
ms.topic: article
qsharp.kind: udt
qsharp.namespace: Microsoft.Quantum.Simulation
qsharp.name: TimeDependentGeneratorSystem
qsharp.summary: >-
  Represents a time-dependent dynamical generator as a function
  from time to the value of the dynamical generator at that time.
---

# TimeDependentGeneratorSystem user defined type

Namespace: [Microsoft.Quantum.Simulation](xref:Microsoft.Quantum.Simulation)

Package: [](https://nuget.org/packages/)


Represents a time-dependent dynamical generator as a functionfrom time to the value of the dynamical generator at that time.

```qsharp

newtype TimeDependentGeneratorSystem = ((Double -> Microsoft.Quantum.Simulation.GeneratorSystem));
```

