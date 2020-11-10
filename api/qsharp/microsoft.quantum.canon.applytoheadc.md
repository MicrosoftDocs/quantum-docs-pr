---
uid: Microsoft.Quantum.Canon.ApplyToHeadC
title: ApplyToHeadC operation
ms.date: 10/26/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Canon
qsharp.name: ApplyToHeadC
qsharp.summary: Applies an operation to the first element of an array.
---

# ApplyToHeadC operation

Namespace: [Microsoft.Quantum.Canon](xref:Microsoft.Quantum.Canon)

Package: [](https://nuget.org/packages/)


Applies an operation to the first element of an array.

```qsharp
operation ApplyToHeadC<'T> (op : ('T => Unit is Ctl), targets : 'T[]) : Unit
```


## Description

Given an operation `op` and an array of targets `targets`,applies `op(Head(targets))`.

## Input

### op : 'T => [Unit](xref:microsoft.quantum.lang-ref.unit) Ctl

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
- [Microsoft.Quantum.Canon.ApplyToHeadCA](xref:Microsoft.Quantum.Canon.ApplyToHeadCA)