---
uid: Microsoft.Quantum.Canon.ApplyToRest
title: ApplyToRest operation
ms.date: 10/16/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Canon
qsharp.name: ApplyToRest
qsharp.summary: Applies an operation to all but the first element of an array.
---

# ApplyToRest operation

Namespace: [Microsoft.Quantum.Canon](xref:Microsoft.Quantum.Canon)

Package: [](https://nuget.org/packages/)


Applies an operation to all but the first element of an array.

```Q#
ApplyToRest<'T> (op : ('T[] => Unit), targets : 'T[]) : Unit
```


## Description

Given an operation `op` and an array of targets `targets`,applies `op(Rest(targets))`.

## Input

### op : 'T[] => Unit 

An operation to be applied.


### target

An array of targets, of which all but the first will be applied to `op`.



## Type Parameters

### 'T

The input type of the operation to be applied.



## See Also

- [Microsoft.Quantum.Canon.ApplyToRestA](xref:Microsoft.Quantum.Canon.ApplyToRestA)
- [Microsoft.Quantum.Canon.ApplyToRestC](xref:Microsoft.Quantum.Canon.ApplyToRestC)
- [Microsoft.Quantum.Canon.ApplyToRestCA](xref:Microsoft.Quantum.Canon.ApplyToRestCA)