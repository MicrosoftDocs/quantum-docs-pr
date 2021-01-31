---
uid: Microsoft.Quantum.Canon.ApplyIfZeroA
title: ApplyIfZeroA operation
ms.date: 1/31/2021 12:00:00 AM
ms.topic: managed-reference
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Canon
qsharp.name: ApplyIfZeroA
qsharp.summary: Applies an adjointable operation conditioned on a classical result value being zero.
---

# ApplyIfZeroA operation

Namespace: [Microsoft.Quantum.Canon](xref:Microsoft.Quantum.Canon)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Applies an adjointable operation conditioned on a classical result value being zero.

```qsharp
operation ApplyIfZeroA<'T> (result : Result, (op : ('T => Unit is Adj), target : 'T)) : Unit is Adj
```


## Description

Given an operation `op` and a result value `result`, applies `op` to the `target`if `result` is `Zero`. If `One`, nothing happens to the `target`.The suffix `A` indicates that the operation to be applied is adjointable.

## Input

### result : __invalid<Result>__

A measurement result that controls whether op is applied or not.


### op : 'T => [Unit](xref:microsoft.quantum.lang-ref.unit)  is Adj

An operation to be conditionally applied.


### target : 'T

The input to which the operation is applied.



## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)



## Type Parameters

### 'T

The input type of the operation to be conditionally applied.

## See Also

- [Microsoft.Quantum.Canon.ApplyIfZeroC](xref:Microsoft.Quantum.Canon.ApplyIfZeroC)
- [Microsoft.Quantum.Canon.ApplyIfZeroA](xref:Microsoft.Quantum.Canon.ApplyIfZeroA)
- [Microsoft.Quantum.Canon.ApplyIfZeroCA](xref:Microsoft.Quantum.Canon.ApplyIfZeroCA)