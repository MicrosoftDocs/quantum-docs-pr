---
uid: Microsoft.Quantum.Simulation.SumGeneratorSystems
title: SumGeneratorSystems function
ms.date: 10/16/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Simulation
qsharp.name: SumGeneratorSystems
qsharp.summary: Adds multiple `GeneratorSystem`s to create a new GeneratorSystem.
---

# SumGeneratorSystems function

Namespace: [Microsoft.Quantum.Simulation](xref:Microsoft.Quantum.Simulation)

Package: [](https://nuget.org/packages/)


Adds multiple `GeneratorSystem`s to create a new GeneratorSystem.

```Q#
SumGeneratorSystems (generatorSystems : Microsoft.Quantum.Simulation.GeneratorSystem[]) : Microsoft.Quantum.Simulation.GeneratorSystem
```


## Input

### generatorSystems : [GeneratorSystem](xref:Microsoft.Quantum.Simulation.GeneratorSystem)[]

An array of type `GeneratorSystem[]`.



## Output

A `GeneratorSystem` representing a system that is the sum of theinput generator systems.

## See Also

- [Microsoft.Quantum.Canon.GeneratorSystem](xref:Microsoft.Quantum.Canon.GeneratorSystem)