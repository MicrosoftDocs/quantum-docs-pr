---
uid: Microsoft.Quantum.Simulation.TrotterStep
title: TrotterStep function
ms.date: 10/30/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Simulation
qsharp.name: TrotterStep
qsharp.summary: >-
  Implements a single time-step of time-evolution by the system
  described in an `EvolutionGenerator` using a Trotter–Suzuki
  decomposition.
---

# TrotterStep function

Namespace: [Microsoft.Quantum.Simulation](xref:Microsoft.Quantum.Simulation)

Package: [](https://nuget.org/packages/)


Implements a single time-step of time-evolution by the systemdescribed in an `EvolutionGenerator` using a Trotter–Suzukidecomposition.

```qsharp
function TrotterStep (evolutionGenerator : Microsoft.Quantum.Simulation.EvolutionGenerator, trotterOrder : Int, trotterStepSize : Double) : (Qubit[] => Unit is Adj + Ctl)
```


## Input

### evolutionGenerator : [EvolutionGenerator](xref:Microsoft.Quantum.Simulation.EvolutionGenerator)

A complete description of the system to be simulated.


### trotterOrder : [Int](xref:microsoft.quantum.lang-ref.int)

Order of Trotter integrator. This must be either 1 or an even number.


### trotterStepSize : [Double](xref:microsoft.quantum.lang-ref.double)

Duration of simulated time-evolution in single Trotter step.



## Output : [Qubit](xref:microsoft.quantum.lang-ref.qubit)[] => [Unit](xref:microsoft.quantum.lang-ref.unit) Adj + Ctl

Unitary operation that approximates a single step of time-evolutionfor duration `trotterStepSize`.

## Remarks

For more on the Trotter–Suzuki decomposition, see[Time-Ordered Composition](/quantum/libraries/control-flow#time-ordered-composition).