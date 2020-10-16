---
uid: Microsoft.Quantum.Chemistry.HTermsToGenSys
title: HTermsToGenSys function
ms.date: 10/16/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Chemistry
qsharp.name: HTermsToGenSys
qsharp.summary: Converts a Hamiltonian in `HTerm[]` data format to a GeneratorSystem.
---

# HTermsToGenSys function

Namespace: [Microsoft.Quantum.Chemistry](xref:Microsoft.Quantum.Chemistry)

Package: [](https://nuget.org/packages/)


Converts a Hamiltonian in `HTerm[]` data format to a GeneratorSystem.

```Q#
HTermsToGenSys (data : Microsoft.Quantum.Chemistry.HTerm[], termType : Int[]) : Microsoft.Quantum.Simulation.GeneratorSystem
```


## Input

### data : [HTerm](xref:Microsoft.Quantum.Chemistry.HTerm)[]

Input data in `HTerm[]` format.


### termType : Int[]

Additional information added to GeneratorIndex.



## Output

A GeneratorSystem representing a Hamiltonian represented by the input `data`.