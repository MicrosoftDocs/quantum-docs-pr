---
uid: Microsoft.Quantum.Simulation.TrotterStepImpl
title: TrotterStepImpl operation
ms.date: 10/16/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Simulation
qsharp.name: TrotterStepImpl
qsharp.summary: Implements time-evolution by a term contained in a `GeneratorSystem`.
---

# TrotterStepImpl operation

Namespace: [Microsoft.Quantum.Simulation](xref:Microsoft.Quantum.Simulation)

Package: [](https://nuget.org/packages/)


Implements time-evolution by a term contained in a `GeneratorSystem`.

```Q#
TrotterStepImpl (evolutionGenerator : Microsoft.Quantum.Simulation.EvolutionGenerator, idx : Int, stepsize : Double, qubits : Qubit[]) : Unit
```


## Input

### evolutionGenerator : [EvolutionGenerator](xref:Microsoft.Quantum.Simulation.EvolutionGenerator)

A complete description of the system to be simulated.


### idx : Int

Integer index to a term in the described system.


### stepsize : Double

Multiplier on duration of time-evolution by term indexed by `idx`.


### qubits : Qubit[]

Qubits acted on by simulation.

