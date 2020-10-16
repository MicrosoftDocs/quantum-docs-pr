---
uid: Microsoft.Quantum.Canon.ApplyIfOneCA
title: ApplyIfOneCA operation
ms.date: 10/16/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Canon
qsharp.name: ApplyIfOneCA
qsharp.summary: Applies a unitary operation conditioned on a classical result value being one.
---

# ApplyIfOneCA operation

Namespace: [Microsoft.Quantum.Canon](xref:Microsoft.Quantum.Canon)

Package: [](https://nuget.org/packages/)


Applies a unitary operation conditioned on a classical result value being one.

```Q#
ApplyIfOneCA<'T> (result : Result, (op : ('T => Unit is Adj + Ctl), target : 'T)) : Unit
```


## Description

Given an operation `op` and a result value `result`, applies `op` to the `target`if `result` is `One`. If `Zero`, nothing happens to the `target`.The suffix `CA` indicates that the operation to be applied is unitary(controllable and adjointable).

## Input

### op : 'T => Unit Adj + Ctl

An operation to be conditionally applied.


### result : __invalid<Result>__

A measurement result that controls whether op is applied or not.


### target : 'T

The input to which the operation is applied.



## Type Parameters

### 'T

The input type of the operation to be conditionally applied.



## See Also

- [Microsoft.Quantum.Canon.ApplyIfOneC](xref:Microsoft.Quantum.Canon.ApplyIfOneC)
- [Microsoft.Quantum.Canon.ApplyIfOneA](xref:Microsoft.Quantum.Canon.ApplyIfOneA)
- [Microsoft.Quantum.Canon.ApplyIfOneCA](xref:Microsoft.Quantum.Canon.ApplyIfOneCA)