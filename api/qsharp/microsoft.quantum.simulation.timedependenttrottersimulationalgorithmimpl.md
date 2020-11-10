---
uid: Microsoft.Quantum.Simulation.TimeDependentTrotterSimulationAlgorithmImpl
title: TimeDependentTrotterSimulationAlgorithmImpl operation
ms.date: 10/26/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Simulation
qsharp.name: TimeDependentTrotterSimulationAlgorithmImpl
qsharp.summary: >-
  Implementation of multiple Trotter steps to approximate a unitary
  operator that solves the time-dependent Schrödinger equation.
---

# TimeDependentTrotterSimulationAlgorithmImpl operation

Namespace: [Microsoft.Quantum.Simulation](xref:Microsoft.Quantum.Simulation)

Package: [](https://nuget.org/packages/)


Implementation of multiple Trotter steps to approximate a unitaryoperator that solves the time-dependent Schrödinger equation.

```qsharp
operation TimeDependentTrotterSimulationAlgorithmImpl (trotterStepSize : Double, trotterOrder : Int, maxTime : Double, evolutionSchedule : Microsoft.Quantum.Simulation.EvolutionSchedule, qubits : Qubit[]) : Unit
```


## Input

### trotterStepSize : [Double](xref:microsoft.quantum.lang-ref.double)

Duration of simulated time-evolution in single Trotter step.


### trotterOrder : [Int](xref:microsoft.quantum.lang-ref.int)

Order of Trotter integrator. This must be either 1 or an even number.


### maxTime : [Double](xref:microsoft.quantum.lang-ref.double)

Total duration of simulation $t$.


### evolutionSchedule : [EvolutionSchedule](xref:Microsoft.Quantum.Simulation.EvolutionSchedule)

A complete description of the time-dependent system to be simulated.


### qubits : [Qubit](xref:microsoft.quantum.lang-ref.qubit)[]

Qubits acted on by simulation.



## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)

