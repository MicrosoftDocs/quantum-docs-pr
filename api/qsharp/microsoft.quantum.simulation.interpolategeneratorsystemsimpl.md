---
uid: Microsoft.Quantum.Simulation.InterpolateGeneratorSystemsImpl
title: InterpolateGeneratorSystemsImpl function
ms.date: 2/10/2021 12:00:00 AM
ms.topic: managed-reference
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Simulation
qsharp.name: InterpolateGeneratorSystemsImpl
qsharp.summary: >-
  Linearly interpolates between two `GeneratorSystems` according to a
  schedule parameter `s` between 0 and 1 (inclusive).
---

# InterpolateGeneratorSystemsImpl function

Namespace: [Microsoft.Quantum.Simulation](xref:Microsoft.Quantum.Simulation)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Linearly interpolates between two `GeneratorSystems` according to aschedule parameter `s` between 0 and 1 (inclusive).

```qsharp
function InterpolateGeneratorSystemsImpl (schedule : Double, generatorSystemStart : Microsoft.Quantum.Simulation.GeneratorSystem, generatorSystemEnd : Microsoft.Quantum.Simulation.GeneratorSystem) : Microsoft.Quantum.Simulation.GeneratorSystem
```


## Input

### schedule : [Double](xref:microsoft.quantum.lang-ref.double)

A schedule parameter $s\in[0,1]$.


### generatorSystemStart : [GeneratorSystem](xref:Microsoft.Quantum.Simulation.GeneratorSystem)

The start `GeneratorSystem`.


### generatorSystemEnd : [GeneratorSystem](xref:Microsoft.Quantum.Simulation.GeneratorSystem)

The end `GeneratorSystem`.



## Output : [GeneratorSystem](xref:Microsoft.Quantum.Simulation.GeneratorSystem)

A `GeneratorSystem` representing a system that is the sum of theinput generator systems, with weight $(1-s)$ on `generatorSystemStart`and weight $s$ on `generatorSystemEnd`.

## See Also

- [Microsoft.Quantum.Simulation.GeneratorSystem](xref:Microsoft.Quantum.Simulation.GeneratorSystem)