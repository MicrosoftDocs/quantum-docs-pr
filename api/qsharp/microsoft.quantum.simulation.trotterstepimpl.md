---
uid: Microsoft.Quantum.Simulation.TrotterStepImpl
title: TrotterStepImpl operation
ms.date: 11/24/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Simulation
qsharp.name: TrotterStepImpl
qsharp.summary: Implements time-evolution by a term contained in a `GeneratorSystem`.
---

# TrotterStepImpl operation

Namespace: [Microsoft.Quantum.Simulation](xref:Microsoft.Quantum.Simulation)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Implements time-evolution by a term contained in a `GeneratorSystem`.

```qsharp
operation TrotterStepImpl (evolutionGenerator : Microsoft.Quantum.Simulation.EvolutionGenerator, idx : Int, stepsize : Double, qubits : Qubit[]) : Unit is Adj + Ctl
```


## Input

### evolutionGenerator : [EvolutionGenerator](xref:Microsoft.Quantum.Simulation.EvolutionGenerator)

A complete description of the system to be simulated.


### idx : [Int](xref:microsoft.quantum.lang-ref.int)

Integer index to a term in the described system.


### stepsize : [Double](xref:microsoft.quantum.lang-ref.double)

Multiplier on duration of time-evolution by term indexed by `idx`.


### qubits : [Qubit](xref:microsoft.quantum.lang-ref.qubit)[]

Qubits acted on by simulation.



## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)

