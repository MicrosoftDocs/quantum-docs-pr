---
uid: Microsoft.Quantum.Simulation.TrotterSimulationAlgorithm
title: TrotterSimulationAlgorithm function
ms.date: 10/16/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Simulation
qsharp.name: TrotterSimulationAlgorithm
qsharp.summary: >-
  `SimulationAlgorithm` function that uses a Trotter–Suzuki
  decomposition to approximate the time-evolution operator _exp(-iHt)_.
---

# TrotterSimulationAlgorithm function

Namespace: [Microsoft.Quantum.Simulation](xref:Microsoft.Quantum.Simulation)

Package: [](https://nuget.org/packages/)


`SimulationAlgorithm` function that uses a Trotter–Suzukidecomposition to approximate the time-evolution operator _exp(-iHt)_.

```Q#
TrotterSimulationAlgorithm (trotterStepSize : Double, trotterOrder : Int) : Microsoft.Quantum.Simulation.SimulationAlgorithm
```


## Input

### trotterStepSize : Double

Duration of simulated time-evolution in single Trotter step.


### trotterOrder : Int

Order of Trotter integrator. This must be either 1 or an even number.



## Output

A `SimulationAlgorithm` type.