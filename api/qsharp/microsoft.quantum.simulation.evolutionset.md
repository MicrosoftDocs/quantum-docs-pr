---
uid: Microsoft.Quantum.Simulation.EvolutionSet
title: EvolutionSet user defined type
ms.date: 2/12/2021 12:00:00 AM
ms.topic: managed-reference
qsharp.kind: udt
qsharp.namespace: Microsoft.Quantum.Simulation
qsharp.name: EvolutionSet
qsharp.summary: >-
  Represents a set of gates that can be readily implemented and used
  to implement simulation algorithms.

  Elements in the set are indexed
  by a  <xref:microsoft.quantum.simulation.generatorindex>,
  and each set is described by a function
  from `GeneratorIndex` to  <xref:microsoft.quantum.simulation.evolutionunitary>,
  which are operations
  parameterized by a real number representing time
---

# EvolutionSet user defined type

Namespace: [Microsoft.Quantum.Simulation](xref:Microsoft.Quantum.Simulation)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Represents a set of gates that can be readily implemented and usedto implement simulation algorithms.Elements in the set are indexedby a  <xref:microsoft.quantum.simulation.generatorindex>,and each set is described by a functionfrom `GeneratorIndex` to  <xref:microsoft.quantum.simulation.evolutionunitary>,which are operationsparameterized by a real number representing time

```qsharp

newtype EvolutionSet = ((Microsoft.Quantum.Simulation.GeneratorIndex -> Microsoft.Quantum.Simulation.EvolutionUnitary));
```

