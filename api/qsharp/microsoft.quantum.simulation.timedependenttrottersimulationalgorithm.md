---
uid: Microsoft.Quantum.Simulation.TimeDependentTrotterSimulationAlgorithm
title: TimeDependentTrotterSimulationAlgorithm function
ms.date: 10/16/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Simulation
qsharp.name: TimeDependentTrotterSimulationAlgorithm
qsharp.summary: >-
  `TimeDependentSimulationAlgorithm` function that uses a Trotter–Suzuki
  decomposition to approximate a unitary operator that solves the
  time-dependent Schrodinger equation.
---

# TimeDependentTrotterSimulationAlgorithm function

Namespace: [Microsoft.Quantum.Simulation](xref:Microsoft.Quantum.Simulation)

Package: [](https://nuget.org/packages/)


`TimeDependentSimulationAlgorithm` function that uses a Trotter–Suzukidecomposition to approximate a unitary operator that solves thetime-dependent Schrodinger equation.

```Q#
TimeDependentTrotterSimulationAlgorithm (trotterStepSize : Double, trotterOrder : Int) : Microsoft.Quantum.Simulation.TimeDependentSimulationAlgorithm
```


## Input

### trotterStepSize : Double

Duration of simulated time-evolution in single Trotter step.


### trotterOrder : Int

Order of Trotter integrator. This must be either 1 or an even number.



## Output

A `TimeDependentSimulationAlgorithm` type.