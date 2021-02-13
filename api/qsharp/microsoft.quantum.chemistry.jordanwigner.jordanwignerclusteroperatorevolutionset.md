---
uid: Microsoft.Quantum.Chemistry.JordanWigner.JordanWignerClusterOperatorEvolutionSet
title: JordanWignerClusterOperatorEvolutionSet function
ms.date: 2/13/2021 12:00:00 AM
ms.topic: managed-reference
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Chemistry.JordanWigner
qsharp.name: JordanWignerClusterOperatorEvolutionSet
qsharp.summary: >-
  Represents a dynamical generator as a set of simulatable gates and an
  expansion in the JordanWigner basis.
---

# JordanWignerClusterOperatorEvolutionSet function

Namespace: [Microsoft.Quantum.Chemistry.JordanWigner](xref:Microsoft.Quantum.Chemistry.JordanWigner)

Package: [Microsoft.Quantum.Chemistry](https://nuget.org/packages/Microsoft.Quantum.Chemistry)


Represents a dynamical generator as a set of simulatable gates and anexpansion in the JordanWigner basis.

```qsharp
function JordanWignerClusterOperatorEvolutionSet () : Microsoft.Quantum.Simulation.EvolutionSet
```


## Output : [EvolutionSet](xref:Microsoft.Quantum.Simulation.EvolutionSet)

An `EvolutionSet` that maps a `GeneratorIndex` for the JordanWigner basis toan `EvolutionUnitary.