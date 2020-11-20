---
uid: Microsoft.Quantum.Simulation.TrotterSimulationAlgorithmImpl
title: TrotterSimulationAlgorithmImpl operation
ms.date: 11/20/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Simulation
qsharp.name: TrotterSimulationAlgorithmImpl
qsharp.summary: >-
  Makes repeated calls to `TrotterStep` to approximate the
  time-evolution operator exp(_-iHt_).
---

# TrotterSimulationAlgorithmImpl operation

Namespace: [Microsoft.Quantum.Simulation](xref:Microsoft.Quantum.Simulation)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Makes repeated calls to `TrotterStep` to approximate thetime-evolution operator exp(_-iHt_).

```qsharp
operation TrotterSimulationAlgorithmImpl (trotterStepSize : Double, trotterOrder : Int, maxTime : Double, evolutionGenerator : Microsoft.Quantum.Simulation.EvolutionGenerator, qubits : Qubit[]) : Unit is Adj + Ctl
```


## Input

### trotterStepSize : [Double](xref:microsoft.quantum.lang-ref.double)

Duration of simulated time-evolution in single Trotter step.


### trotterOrder : [Int](xref:microsoft.quantum.lang-ref.int)

Order of Trotter integrator. This must be either 1 or an even number.


### maxTime : [Double](xref:microsoft.quantum.lang-ref.double)

Total duration of simulation $t$.


### evolutionGenerator : [EvolutionGenerator](xref:Microsoft.Quantum.Simulation.EvolutionGenerator)

A complete description of the system to be simulated.


### qubits : [Qubit](xref:microsoft.quantum.lang-ref.qubit)[]

Qubits acted on by simulation.



## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)

