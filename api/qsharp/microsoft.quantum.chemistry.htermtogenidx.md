---
uid: Microsoft.Quantum.Chemistry.HTermToGenIdx
title: HTermToGenIdx function
ms.date: 10/28/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Chemistry
qsharp.name: HTermToGenIdx
qsharp.summary: Converts a Hamiltonian term in `HTerm` data format to a GeneratorIndex.
---

# HTermToGenIdx function

Namespace: [Microsoft.Quantum.Chemistry](xref:Microsoft.Quantum.Chemistry)

Package: [](https://nuget.org/packages/)


Converts a Hamiltonian term in `HTerm` data format to a GeneratorIndex.

```qsharp
function HTermToGenIdx (term : Microsoft.Quantum.Chemistry.HTerm, termType : Int[]) : Microsoft.Quantum.Simulation.GeneratorIndex
```


## Input

### term : [HTerm](xref:Microsoft.Quantum.Chemistry.HTerm)

Input data in `HTerm` format.


### termType : [Int](xref:microsoft.quantum.lang-ref.int)[]

Additional information added to GeneratorIndex.



## Output : [GeneratorIndex](xref:Microsoft.Quantum.Simulation.GeneratorIndex)

A GeneratorIndex representing a Hamiltonian term represented by `term`,together with additional information added by `termType`.