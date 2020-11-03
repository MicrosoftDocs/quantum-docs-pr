---
uid: Microsoft.Quantum.Canon.ApplyIfOneA
title: ApplyIfOneA operation
ms.date: 11/3/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Canon
qsharp.name: ApplyIfOneA
qsharp.summary: Applies an adjointable operation conditioned on a classical result value being one.
---

# ApplyIfOneA operation

Namespace: [Microsoft.Quantum.Canon](xref:Microsoft.Quantum.Canon)

Package: [](https://nuget.org/packages/)


Applies an adjointable operation conditioned on a classical result value being one.

```qsharp
operation ApplyIfOneA<'T> (result : Result, (op : ('T => Unit is Adj), target : 'T)) : Unit
```


## Description

Given an operation `op` and a result value `result`, applies `op` to the `target`if `result` is `One`. If `Zero`, nothing happens to the `target`.The suffix `A` indicates that the operation to be applied is adjointable.

## Input

### result : __invalid<Result>__

A measurement result that controls whether op is applied or not.


### op : 'T => [Unit](xref:microsoft.quantum.lang-ref.unit) Adj

An operation to be conditionally applied.


### target : 'T

The input to which the operation is applied.



## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)



## Type Parameters

### 'T

The input type of the operation to be conditionally applied.

## See Also

- [Microsoft.Quantum.Canon.ApplyIfOneC](xref:Microsoft.Quantum.Canon.ApplyIfOneC)
- [Microsoft.Quantum.Canon.ApplyIfOneA](xref:Microsoft.Quantum.Canon.ApplyIfOneA)
- [Microsoft.Quantum.Canon.ApplyIfOneCA](xref:Microsoft.Quantum.Canon.ApplyIfOneCA)