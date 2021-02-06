---
uid: Microsoft.Quantum.Simulation.GeneratorIndex
title: GeneratorIndex user defined type
ms.date: 2/6/2021 12:00:00 AM
ms.topic: managed-reference
qsharp.kind: udt
qsharp.namespace: Microsoft.Quantum.Simulation
qsharp.name: GeneratorIndex
qsharp.summary: >-
  Represents a single primitive term in the set of all dynamical generators, e.g.
  Hermitian operators, for which there exists a map from that generator
  to time-evolution by that generator, through `EvolutionSet`.

  The first element
  (Int[], Double[]) is indexes that single term -- For instance, the Pauli string
  XXY with coefficient 0.5 would be indexed by ([1,1,2], [0.5]). Alternatively,
  Hamiltonians parameterized by a continuous variable, such as X cos φ + Y sin φ,
  might for instance be represented by ([], [φ]). The second
  element indexes the subsystem on which the generator acts on.
---

# GeneratorIndex user defined type

Namespace: [Microsoft.Quantum.Simulation](xref:Microsoft.Quantum.Simulation)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Represents a single primitive term in the set of all dynamical generators, e.g.Hermitian operators, for which there exists a map from that generatorto time-evolution by that generator, through `EvolutionSet`.The first element(Int[], Double[]) is indexes that single term -- For instance, the Pauli stringXXY with coefficient 0.5 would be indexed by ([1,1,2], [0.5]). Alternatively,Hamiltonians parameterized by a continuous variable, such as X cos φ + Y sin φ,might for instance be represented by ([], [φ]). The secondelement indexes the subsystem on which the generator acts on.

```qsharp

newtype GeneratorIndex = ((Int[], Double[]), Int[]);
```



## Example

Using  <xref:microsoft.quantum.simulation.paulievolutionset>, the operator$\pi X_2 X_5 Y_9$ is represented as:```qsharplet index = GeneratorIndex(([1, 1, 2], [PI()]), [2, 5, 9]);```

## Remarks

> [!WARNING]> The interpretation of an `GeneratorIndex` is not defined except> with reference to a particular set of generators.

## See Also

- [Microsoft.Quantum.Simulation.EvolutionSet](xref:Microsoft.Quantum.Simulation.EvolutionSet)
- [Microsoft.Quantum.Simulation.PauliEvolutionSet](xref:Microsoft.Quantum.Simulation.PauliEvolutionSet)