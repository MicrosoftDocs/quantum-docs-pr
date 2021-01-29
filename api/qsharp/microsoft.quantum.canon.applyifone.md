---
uid: Microsoft.Quantum.Canon.ApplyIfOne
title: ApplyIfOne operation
ms.date: 1/29/2021 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Canon
qsharp.name: ApplyIfOne
qsharp.summary: Applies an operation conditioned on a classical result value being one.
---

# ApplyIfOne operation

Namespace: [Microsoft.Quantum.Canon](xref:Microsoft.Quantum.Canon)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Applies an operation conditioned on a classical result value being one.

```qsharp
operation ApplyIfOne<'T> (result : Result, (op : ('T => Unit), target : 'T)) : Unit
```


## Description

Given an operation `op` and a result value `result`, applies `op` to the `target`if `result` is `One`. If `Zero`, nothing happens to the `target`.

## Input

### result : __invalid<Result>__

A measurement result that controls whether op is applied or not.


### op : 'T => [Unit](xref:microsoft.quantum.lang-ref.unit) 

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