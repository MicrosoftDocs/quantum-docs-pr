---
uid: Microsoft.Quantum.Simulation.GetGeneratorSystemFunction
title: GetGeneratorSystemFunction function
ms.date: 10/16/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Simulation
qsharp.name: GetGeneratorSystemFunction
qsharp.summary: Retrieves the `GeneratorIndex` function in a `GeneratorSystem`.
---

# GetGeneratorSystemFunction function

Namespace: [Microsoft.Quantum.Simulation](xref:Microsoft.Quantum.Simulation)

Package: [](https://nuget.org/packages/)


Retrieves the `GeneratorIndex` function in a `GeneratorSystem`.

```Q#
GetGeneratorSystemFunction (generatorSystem : Microsoft.Quantum.Simulation.GeneratorSystem) : (Int -> Microsoft.Quantum.Simulation.GeneratorIndex)
```


## Input

### generatorSystem : [GeneratorSystem](xref:Microsoft.Quantum.Simulation.GeneratorSystem)

The `GeneratorSystem` of interest.



## Output

An function that indexes each `GeneratorIndex` term in a Hamiltonian.

## See Also

- [microsoft.quantum.canon.generatorindex](xref:microsoft.quantum.canon.generatorindex)
- [microsoft.quantum.canon.generatorsystem](xref:microsoft.quantum.canon.generatorsystem)