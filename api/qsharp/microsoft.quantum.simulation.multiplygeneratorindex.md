---
uid: Microsoft.Quantum.Simulation.MultiplyGeneratorIndex
title: MultiplyGeneratorIndex function
ms.date: 10/16/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Simulation
qsharp.name: MultiplyGeneratorIndex
qsharp.summary: Multiplies the coefficient in a `GeneratorIndex`.
---

# MultiplyGeneratorIndex function

Namespace: [Microsoft.Quantum.Simulation](xref:Microsoft.Quantum.Simulation)

Package: [](https://nuget.org/packages/)


Multiplies the coefficient in a `GeneratorIndex`.

```Q#
MultiplyGeneratorIndex (multiplier : Double, generatorIndex : Microsoft.Quantum.Simulation.GeneratorIndex) : Microsoft.Quantum.Simulation.GeneratorIndex
```


## Input

### multiplier : Double

The multiplier on the coefficient.


### generatorIndex : [GeneratorIndex](xref:Microsoft.Quantum.Simulation.GeneratorIndex)

The `GeneratorIndex` to be multiplied.



## Output

A `GeneratorIndex` representing a term with coefficient a factor`multiplier` larger.

## See Also

- [microsoft.quantum.canon.generatorindex](xref:microsoft.quantum.canon.generatorindex)