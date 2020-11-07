---
uid: Microsoft.Quantum.Canon.ApplyToMostCA
title: ApplyToMostCA operation
ms.date: 11/7/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Canon
qsharp.name: ApplyToMostCA
qsharp.summary: Applies an operation to all but the last element of an array.
---

# ApplyToMostCA operation

Namespace: [Microsoft.Quantum.Canon](xref:Microsoft.Quantum.Canon)

Package: [](https://nuget.org/packages/)


Applies an operation to all but the last element of an array.

```qsharp
operation ApplyToMostCA<'T> (op : ('T[] => Unit is Adj + Ctl), targets : 'T[]) : Unit
```


## Description

Given an operation `op` and an array of targets `targets`,applies `op(Most(targets))`.

## Input

### op : 'T[] => [Unit](xref:microsoft.quantum.lang-ref.unit) Adj + Ctl

An operation to be applied.


### targets : 'T[]

An array of targets, of which all but the last will be applied to `op`.



## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)



## Type Parameters

### 'T

The input type of the operation to be applied.

## See Also

- [Microsoft.Quantum.Canon.ApplyToMost](xref:Microsoft.Quantum.Canon.ApplyToMost)
- [Microsoft.Quantum.Canon.ApplyToMostA](xref:Microsoft.Quantum.Canon.ApplyToMostA)
- [Microsoft.Quantum.Canon.ApplyToMostC](xref:Microsoft.Quantum.Canon.ApplyToMostC)