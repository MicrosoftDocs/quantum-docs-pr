---
uid: Microsoft.Quantum.Simulation.PauliEvolutionImpl
title: PauliEvolutionImpl operation
ms.date: 11/10/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Simulation
qsharp.name: PauliEvolutionImpl
qsharp.summary: >-
  Represents a dynamical generator as a set of simulatable gates and an
  expansion in the Pauli basis.

  See [Dynamical Generator Modeling](/quantum/libraries/data-structures#dynamical-generator-modeling)
  for more details.
---

# PauliEvolutionImpl operation

Namespace: [Microsoft.Quantum.Simulation](xref:Microsoft.Quantum.Simulation)

Package: [](https://nuget.org/packages/)


Represents a dynamical generator as a set of simulatable gates and anexpansion in the Pauli basis.See [Dynamical Generator Modeling](/quantum/libraries/data-structures#dynamical-generator-modeling)for more details.

```qsharp
operation PauliEvolutionImpl (generatorIndex : Microsoft.Quantum.Simulation.GeneratorIndex, delta : Double, qubits : Qubit[]) : Unit
```


## Input

### generatorIndex : [GeneratorIndex](xref:Microsoft.Quantum.Simulation.GeneratorIndex)

A generator index to be represented as unitary evolution in the Paulibasis.


### delta : [Double](xref:microsoft.quantum.lang-ref.double)

A multiplier on the duration of time-evolution by the term referencedin `generatorIndex`.


### qubits : [Qubit](xref:microsoft.quantum.lang-ref.qubit)[]

Register acted upon by time-evolution operator.



## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)

