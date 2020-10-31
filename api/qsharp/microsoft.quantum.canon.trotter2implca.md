---
uid: Microsoft.Quantum.Canon.Trotter2ImplCA
title: Trotter2ImplCA operation
ms.date: 10/31/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Canon
qsharp.name: Trotter2ImplCA
qsharp.summary: Implementation of the second-order Trotter–Suzuki integrator.
---

# Trotter2ImplCA operation

Namespace: [Microsoft.Quantum.Canon](xref:Microsoft.Quantum.Canon)

Package: [](https://nuget.org/packages/)


Implementation of the second-order Trotter–Suzuki integrator.

```qsharp
operation Trotter2ImplCA<'T> ((nSteps : Int, op : ((Int, Double, 'T) => Unit is Adj + Ctl)), stepSize : Double, target : 'T) : Unit
```


## Input

### nSteps : [Int](xref:microsoft.quantum.lang-ref.int)

The number of operations to be decomposed into time steps.


### op : ([Int](xref:microsoft.quantum.lang-ref.int),[Double](xref:microsoft.quantum.lang-ref.double),'T) => [Unit](xref:microsoft.quantum.lang-ref.unit) Adj + Ctl

An operation which accepts an index input (type `Int`) and a timeinput (type `Double`) and a quantum register (type `'T`) for decomposition.


### stepSize : [Double](xref:microsoft.quantum.lang-ref.double)

Multiplier on size of each step of the simulation.


### target : 'T

A quantum register on which the operations act.



## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)



## Type Parameters

### 'T

The type which each time step should act upon; typically, either`Qubit[]` or `Qubit`.