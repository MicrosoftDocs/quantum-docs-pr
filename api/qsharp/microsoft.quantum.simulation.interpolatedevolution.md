---
uid: Microsoft.Quantum.Simulation.InterpolatedEvolution
title: InterpolatedEvolution function
ms.date: 11/4/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Simulation
qsharp.name: InterpolatedEvolution
qsharp.summary: >-
  Interpolates between two generators with a uniform schedule,
  returning an operation that applies simulated evolution under
  the resulting time-dependent generator to a qubit register.
---

# InterpolatedEvolution function

Namespace: [Microsoft.Quantum.Simulation](xref:Microsoft.Quantum.Simulation)

Package: [](https://nuget.org/packages/)


Interpolates between two generators with a uniform schedule,returning an operation that applies simulated evolution underthe resulting time-dependent generator to a qubit register.

```qsharp
function InterpolatedEvolution (interpolationTime : Double, evolutionGeneratorStart : Microsoft.Quantum.Simulation.EvolutionGenerator, evolutionGeneratorEnd : Microsoft.Quantum.Simulation.EvolutionGenerator, timeDependentSimulationAlgorithm : Microsoft.Quantum.Simulation.TimeDependentSimulationAlgorithm) : (Qubit[] => Unit is Adj + Ctl)
```


## Input

### interpolationTime : [Double](xref:microsoft.quantum.lang-ref.double)

Time to perform the interpolation over.


### evolutionGeneratorStart : [EvolutionGenerator](xref:Microsoft.Quantum.Simulation.EvolutionGenerator)

Initial generator to simulate evolution under.


### evolutionGeneratorEnd : [EvolutionGenerator](xref:Microsoft.Quantum.Simulation.EvolutionGenerator)

Final generator to simulate evolution under.


### timeDependentSimulationAlgorithm : [TimeDependentSimulationAlgorithm](xref:Microsoft.Quantum.Simulation.TimeDependentSimulationAlgorithm)

A time-dependent simulation algorithm that will be usedto simulate evolution during the uniform interpolation schedule.



## Output : [Qubit](xref:microsoft.quantum.lang-ref.qubit)[] => [Unit](xref:microsoft.quantum.lang-ref.unit) Adj + Ctl



## Remarks

If the interpolation time is chosen to meet the adiabatic conditions,then this function returns an operation which performs adiabaticstate preparation for the final dynamical generator.