---
uid: Microsoft.Quantum.Simulation.MultiplyGeneratorSystem
title: MultiplyGeneratorSystem function
ms.date: 10/26/2020 12:00:00 AM
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

```qsharp
function MultiplyGeneratorSystem (multiplier : Double, generatorSystem : Microsoft.Quantum.Simulation.GeneratorSystem) : Microsoft.Quantum.Simulation.GeneratorSystem
```


## Input

### multiplier : [Double](xref:microsoft.quantum.lang-ref.double)

The multiplier on the coefficient.


### generatorSystem : [GeneratorSystem](xref:Microsoft.Quantum.Simulation.GeneratorSystem)

The `GeneratorSystem` to be multiplied.



## Output : [GeneratorSystem](xref:Microsoft.Quantum.Simulation.GeneratorSystem)

A `GeneratorSystem` representing a system with coefficients a factor`multiplier` larger.

## See Also

- [Microsoft.Quantum.Simulation.GeneratorSystem](xref:Microsoft.Quantum.Simulation.GeneratorSystem)