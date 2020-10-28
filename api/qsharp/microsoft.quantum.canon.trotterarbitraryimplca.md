---
uid: Microsoft.Quantum.Canon.TrotterArbitraryImplCA
title: TrotterArbitraryImplCA operation
ms.date: 10/28/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Canon
qsharp.name: TrotterArbitraryImplCA
qsharp.summary: Recursive implementation of even-order Trotter–Suzuki integrator.
---

# TrotterArbitraryImplCA operation

Namespace: [Microsoft.Quantum.Canon](xref:Microsoft.Quantum.Canon)

Package: [](https://nuget.org/packages/)


Recursive implementation of even-order Trotter–Suzuki integrator.

```qsharp
operation TrotterArbitraryImplCA<'T> (order : Int, (nSteps : Int, op : ((Int, Double, 'T) => Unit is Adj + Ctl)), stepSize : Double, target : 'T) : Unit
```


## Input

### order : [Int](xref:microsoft.quantum.lang-ref.int)

Order of Trotter-Suzuki integrator.


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