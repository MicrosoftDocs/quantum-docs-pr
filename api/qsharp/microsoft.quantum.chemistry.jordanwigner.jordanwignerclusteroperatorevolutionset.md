---
uid: Microsoft.Quantum.Chemistry.JordanWigner.JordanWignerClusterOperatorEvolutionSet
title: JordanWignerClusterOperatorEvolutionSet function
ms.date: 10/16/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Chemistry.JordanWigner
qsharp.name: JordanWignerClusterOperatorEvolutionSet
qsharp.summary: >-
  Represents a dynamical generator as a set of simulatable gates and an
  expansion in the JordanWigner basis.
---

# JordanWignerClusterOperatorEvolutionSet function

Namespace: [Microsoft.Quantum.Chemistry.JordanWigner](xref:Microsoft.Quantum.Chemistry.JordanWigner)

Package: [](https://nuget.org/packages/)


Represents a dynamical generator as a set of simulatable gates and anexpansion in the JordanWigner basis.

```Q#
JordanWignerClusterOperatorEvolutionSet () : Microsoft.Quantum.Simulation.EvolutionSet
```


## Output

An `EvolutionSet` that maps a `GeneratorIndex` for the JordanWigner basis toan `EvolutionUnitary.