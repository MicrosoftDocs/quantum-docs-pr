---
uid: Microsoft.Quantum.Research.Chemistry.JordanWignerOptimizedFermionEvolutionSet
title: JordanWignerOptimizedFermionEvolutionSet function
ms.date: 10/16/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Research.Chemistry
qsharp.name: JordanWignerOptimizedFermionEvolutionSet
qsharp.summary: >-
  Represents a dynamical generator as a set of simulatable gates and an
  expansion in the Pauli basis.
---

# JordanWignerOptimizedFermionEvolutionSet function

Namespace: [Microsoft.Quantum.Research.Chemistry](xref:Microsoft.Quantum.Research.Chemistry)

Package: [](https://nuget.org/packages/)


Represents a dynamical generator as a set of simulatable gates and anexpansion in the Pauli basis.

```Q#
JordanWignerOptimizedFermionEvolutionSet (parityQubit : Qubit) : Microsoft.Quantum.Simulation.EvolutionSet
```


## Input

### parityQubit : Qubit

Qubit that determines the sign of time-evolution.



## Output

An `EvolutionSet` that maps a `GeneratorIndex` for the JWOptimized basis toan `EvolutionUnitary.