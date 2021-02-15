---
uid: Microsoft.Quantum.Chemistry.HTermsToGenIdx
title: HTermsToGenIdx function
ms.date: 2/15/2021 12:00:00 AM
ms.topic: managed-reference
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Chemistry
qsharp.name: HTermsToGenIdx
qsharp.summary: Converts an index to a Hamiltonian term in `HTerm[]` data format to a GeneratorIndex.
---

# HTermsToGenIdx function

Namespace: [Microsoft.Quantum.Chemistry](xref:Microsoft.Quantum.Chemistry)

Package: [Microsoft.Quantum.Chemistry](https://nuget.org/packages/Microsoft.Quantum.Chemistry)


Converts an index to a Hamiltonian term in `HTerm[]` data format to a GeneratorIndex.

```qsharp
function HTermsToGenIdx (data : Microsoft.Quantum.Chemistry.HTerm[], termType : Int[], idx : Int) : Microsoft.Quantum.Simulation.GeneratorIndex
```


## Input

### data : [HTerm](xref:Microsoft.Quantum.Chemistry.HTerm)[]

Input data in `HTerm[]` format.


### termType : [Int](xref:microsoft.quantum.lang-ref.int)[]

Additional information added to GeneratorIndex.


### idx : [Int](xref:microsoft.quantum.lang-ref.int)

Index to a term of the Hamiltonian



## Output : [GeneratorIndex](xref:Microsoft.Quantum.Simulation.GeneratorIndex)

A GeneratorIndex representing a Hamiltonian term represented by `data[idx]`,together with additional information added by `termType`.