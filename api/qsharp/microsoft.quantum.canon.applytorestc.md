---
uid: Microsoft.Quantum.Canon.ApplyToRestC
title: ApplyToRestC operation
ms.date: 10/26/2020 12:00:00 AM
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

```qsharp
operation ApplyToRestC<'T> (op : ('T[] => Unit is Ctl), targets : 'T[]) : Unit
```


## Description

Given an operation `op` and an array of targets `targets`,

## Input

### op : 'T[] => [Unit](xref:microsoft.quantum.lang-ref.unit) Ctl

An operation to be applied.


### targets : 'T[]

An array of targets, of which all but the first will be applied to `op`.



## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)



## Type Parameters

### 'T

The input type of the operation to be applied.

## See Also

- [Microsoft.Quantum.Canon.ApplyToRest](xref:Microsoft.Quantum.Canon.ApplyToRest)
- [Microsoft.Quantum.Canon.ApplyToRestA](xref:Microsoft.Quantum.Canon.ApplyToRestA)
- [Microsoft.Quantum.Canon.ApplyToRestCA](xref:Microsoft.Quantum.Canon.ApplyToRestCA)