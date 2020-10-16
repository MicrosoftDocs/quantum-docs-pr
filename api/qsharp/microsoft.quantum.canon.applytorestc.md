---
uid: Microsoft.Quantum.Canon.ApplyToRestC
title: ApplyToRestC operation
ms.date: 10/16/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Canon
qsharp.name: ApplyToRestC
qsharp.summary: Applies an operation to all but the first element of an array.
---

# ApplyToRestC operation

Namespace: [Microsoft.Quantum.Canon](xref:Microsoft.Quantum.Canon)

Package: [](https://nuget.org/packages/)


Applies an operation to all but the first element of an array.

```Q#
ApplyToRestC<'T> (op : ('T[] => Unit is Ctl), targets : 'T[]) : Unit
```


## Description

Given an operation `op` and an array of targets `targets`,applies `op(Rest(targets))`.

## Input

### op : 'T[] => Unit Ctl

An operation to be applied.


### target

An array of targets, of which all but the first will be applied to `op`.



## Type Parameters

### 'T

The input type of the operation to be applied.



## See Also

- [Microsoft.Quantum.Canon.ApplyToRest](xref:Microsoft.Quantum.Canon.ApplyToRest)
- [Microsoft.Quantum.Canon.ApplyToRestA](xref:Microsoft.Quantum.Canon.ApplyToRestA)
- [Microsoft.Quantum.Canon.ApplyToRestCA](xref:Microsoft.Quantum.Canon.ApplyToRestCA)