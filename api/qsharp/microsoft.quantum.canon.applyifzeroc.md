---
uid: Microsoft.Quantum.Canon.ApplyIfZeroC
title: ApplyIfZeroC operation
ms.date: 11/5/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Canon
qsharp.name: ApplyIfZeroC
qsharp.summary: Applies a controllable operation conditioned on a classical result value being zero.
---

# ApplyIfZeroC operation

Namespace: [Microsoft.Quantum.Canon](xref:Microsoft.Quantum.Canon)

Package: [](https://nuget.org/packages/)


Applies a controllable operation conditioned on a classical result value being zero.

```qsharp
operation ApplyIfZeroC<'T> (result : Result, (op : ('T => Unit is Ctl), target : 'T)) : Unit
```


## Description

Given an operation `op` and a result value `result`, applies `op` to the `target`if `result` is `Zero`. If `One`, nothing happens to the `target`.The suffix `C` indicates that the operation to be applied is controllable.

## Input

### result : __invalid<Result>__

A measurement result that controls whether op is applied or not.


### op : 'T => [Unit](xref:microsoft.quantum.lang-ref.unit) Ctl

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