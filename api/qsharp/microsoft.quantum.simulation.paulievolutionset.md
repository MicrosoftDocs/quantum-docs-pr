---
uid: Microsoft.Quantum.Simulation.PauliEvolutionSet
title: PauliEvolutionSet function
ms.date: 11/12/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Simulation
qsharp.name: PauliEvolutionSet
qsharp.summary: >-
  Represents a dynamical generator as a set of simulatable gates and an
  expansion in the Pauli basis.
---

# PauliEvolutionSet function

Namespace: [Microsoft.Quantum.Simulation](xref:Microsoft.Quantum.Simulation)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Represents a dynamical generator as a set of simulatable gates and anexpansion in the Pauli basis.

```qsharp
function PauliEvolutionSet () : Microsoft.Quantum.Simulation.EvolutionSet
```


## Output : [EvolutionSet](xref:Microsoft.Quantum.Simulation.EvolutionSet)

An `EvolutionSet` that maps a `GeneratorIndex` for the Pauli basis toan `EvolutionUnitary.

## Remarks

This is obtained by partial application of<xref:microsoft.quantum.simulation.paulievolutionfunction>.