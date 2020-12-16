---
uid: Microsoft.Quantum.Chemistry.HTermsToGenSys
title: HTermsToGenSys function
ms.date: 12/16/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Chemistry
qsharp.name: HTermsToGenSys
qsharp.summary: Converts a Hamiltonian in `HTerm[]` data format to a GeneratorSystem.
---

# HTermsToGenSys function

Namespace: [Microsoft.Quantum.Chemistry](xref:Microsoft.Quantum.Chemistry)

Package: [Microsoft.Quantum.Chemistry](https://nuget.org/packages/Microsoft.Quantum.Chemistry)


Converts a Hamiltonian in `HTerm[]` data format to a GeneratorSystem.

```qsharp
function HTermsToGenSys (data : Microsoft.Quantum.Chemistry.HTerm[], termType : Int[]) : Microsoft.Quantum.Simulation.GeneratorSystem
```


## Input

### data : [HTerm](xref:Microsoft.Quantum.Chemistry.HTerm)[]

Input data in `HTerm[]` format.


### termType : [Int](xref:microsoft.quantum.lang-ref.int)[]

Additional information added to GeneratorIndex.



## Output : [GeneratorSystem](xref:Microsoft.Quantum.Simulation.GeneratorSystem)

A GeneratorSystem representing a Hamiltonian represented by the input `data`.