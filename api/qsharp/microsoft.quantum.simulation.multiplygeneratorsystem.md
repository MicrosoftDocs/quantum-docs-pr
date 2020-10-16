---
uid: Microsoft.Quantum.Simulation.MultiplyGeneratorSystem
title: MultiplyGeneratorSystem function
ms.date: 10/16/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Simulation
qsharp.name: MultiplyGeneratorSystem
qsharp.summary: Multiplies the coefficient of all terms in a `GeneratorSystem`.
---

# MultiplyGeneratorSystem function

Namespace: [Microsoft.Quantum.Simulation](xref:Microsoft.Quantum.Simulation)

Package: [](https://nuget.org/packages/)


Multiplies the coefficient of all terms in a `GeneratorSystem`.

```Q#
MultiplyGeneratorSystem (multiplier : Double, generatorSystem : Microsoft.Quantum.Simulation.GeneratorSystem) : Microsoft.Quantum.Simulation.GeneratorSystem
```


## Input

### multiplier : Double

The multiplier on the coefficient.


### generatorSystem : [GeneratorSystem](xref:Microsoft.Quantum.Simulation.GeneratorSystem)

The `GeneratorSystem` to be multiplied.



## Output

A `GeneratorSystem` representing a system with coefficients a factor`multiplier` larger.

## See Also

- [Microsoft.Quantum.Canon.GeneratorSystem](xref:Microsoft.Quantum.Canon.GeneratorSystem)