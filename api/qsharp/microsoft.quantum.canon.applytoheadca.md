---
uid: Microsoft.Quantum.Canon.ApplyToHeadCA
title: ApplyToHeadCA operation
ms.date: 10/26/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Canon
qsharp.name: ApplyToHeadCA
qsharp.summary: Applies an operation to the first element of an array.
---

# ApplyToHeadCA operation

Namespace: [Microsoft.Quantum.Canon](xref:Microsoft.Quantum.Canon)

Package: [](https://nuget.org/packages/)


Applies an operation to the first element of an array.

```qsharp
operation ApplyToHeadCA<'T> (op : ('T => Unit is Adj + Ctl), targets : 'T[]) : Unit
```


## Description

Given an operation `op` and an array of targets `targets`,applies `op(Head(targets))`.

## Input

### op : 'T => [Unit](xref:microsoft.quantum.lang-ref.unit) Adj + Ctl

An operation to be applied.


### targets : 'T[]

An array of targets, of which the first will be applied to `op`.



## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)



## Type Parameters

### 'T

The input type of the operation to be applied.

## See Also

- [Microsoft.Quantum.Canon.ApplyToHead](xref:Microsoft.Quantum.Canon.ApplyToHead)
- [Microsoft.Quantum.Canon.ApplyToHeadA](xref:Microsoft.Quantum.Canon.ApplyToHeadA)
- [Microsoft.Quantum.Canon.ApplyToHeadC](xref:Microsoft.Quantum.Canon.ApplyToHeadC)