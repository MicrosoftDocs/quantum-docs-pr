---
uid: Microsoft.Quantum.Research.Chemistry.JWOptimizedFermionEvolutionFunction
title: JWOptimizedFermionEvolutionFunction function
ms.date: 10/16/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Research.Chemistry
qsharp.name: JWOptimizedFermionEvolutionFunction
qsharp.summary: >-
  Represents a dynamical generator as a set of simulatable gates and an
  expansion in the JWOptimized basis.
---

# JWOptimizedFermionEvolutionFunction function

Namespace: [Microsoft.Quantum.Research.Chemistry](xref:Microsoft.Quantum.Research.Chemistry)

Package: [](https://nuget.org/packages/)


Represents a dynamical generator as a set of simulatable gates and anexpansion in the JWOptimized basis.

```Q#
JWOptimizedFermionEvolutionFunction (generatorIndex : Microsoft.Quantum.Simulation.GeneratorIndex, parityQubit : Qubit) : Microsoft.Quantum.Simulation.EvolutionUnitary
```


## Input

### generatorIndex : [GeneratorIndex](xref:Microsoft.Quantum.Simulation.GeneratorIndex)

A generator index to be represented as unitary evolution in the JWOptimizedbasis.


### parityQubit : Qubit

Qubit that determines the sign of time-evolution.



## Output

An `EvolutionUnitary` representing time-evolution by the termreferenced in `generatorIndex.