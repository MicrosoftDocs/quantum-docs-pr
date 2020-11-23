---
uid: Microsoft.Quantum.Canon.Trotter1ImplCA
title: Trotter1ImplCA operation
ms.date: 11/23/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Canon
qsharp.name: Trotter1ImplCA
qsharp.summary: Implementation of the first-order Trotter–Suzuki integrator.
---

# Trotter1ImplCA operation

Namespace: [Microsoft.Quantum.Canon](xref:Microsoft.Quantum.Canon)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Implementation of the first-order Trotter–Suzuki integrator.

```qsharp
operation Trotter1ImplCA<'T> ((nSteps : Int, op : ((Int, Double, 'T) => Unit is Adj + Ctl)), stepSize : Double, target : 'T) : Unit is Adj + Ctl
```


## Input

### nSteps : [Int](xref:microsoft.quantum.lang-ref.int)

The number of operations to be decomposed into time steps.


### op : ([Int](xref:microsoft.quantum.lang-ref.int),[Double](xref:microsoft.quantum.lang-ref.double),'T) => [Unit](xref:microsoft.quantum.lang-ref.unit)  is Adj + Ctl

An operation which accepts an index input (type `Int`) and a timeinput (type `Double`) and a quantum register (type `'T`) for decomposition.


### stepSize : [Double](xref:microsoft.quantum.lang-ref.double)

Multiplier on size of each step of the simulation.


### target : 'T

A quantum register on which the operations act.



## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)



## Type Parameters

### 'T

The type which each time step should act upon; typically, either`Qubit[]` or `Qubit`.