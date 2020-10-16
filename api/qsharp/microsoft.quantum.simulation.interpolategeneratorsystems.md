---
uid: Microsoft.Quantum.Simulation.InterpolateGeneratorSystems
title: InterpolateGeneratorSystems function
ms.date: 10/16/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Simulation
qsharp.name: InterpolateGeneratorSystems
qsharp.summary: >-
  Returns a `TimeDependentGeneratorSystem` representing the linear
  interpolation between two `GeneratorSystem`s.
---

# InterpolateGeneratorSystems function

Namespace: [Microsoft.Quantum.Simulation](xref:Microsoft.Quantum.Simulation)

Package: [](https://nuget.org/packages/)


Returns a `TimeDependentGeneratorSystem` representing the linearinterpolation between two `GeneratorSystem`s.

```Q#
InterpolateGeneratorSystems (generatorSystemStart : Microsoft.Quantum.Simulation.GeneratorSystem, generatorSystemEnd : Microsoft.Quantum.Simulation.GeneratorSystem) : Microsoft.Quantum.Simulation.TimeDependentGeneratorSystem
```


## Input

### generatorSystemStart : [GeneratorSystem](xref:Microsoft.Quantum.Simulation.GeneratorSystem)

The start `GeneratorSystem`.


### generatorSystemEnd : [GeneratorSystem](xref:Microsoft.Quantum.Simulation.GeneratorSystem)

The end `GeneratorSystem`.



## Output

A `TimeDependentGeneratorSystem` representing a system that is thesum of the input generator systems, with weight $(1-s)$ on`generatorSystemStart` and weight $s$ on `generatorSystemEnd`.

## See Also

- [Microsoft.Quantum.Canon.GeneratorSystem](xref:Microsoft.Quantum.Canon.GeneratorSystem)
- [Microsoft.Quantum.Canon.TimeDependentGeneratorSystem](xref:Microsoft.Quantum.Canon.TimeDependentGeneratorSystem)