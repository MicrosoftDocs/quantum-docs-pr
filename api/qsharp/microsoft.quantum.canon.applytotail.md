---
uid: Microsoft.Quantum.Canon.ApplyToTail
title: ApplyToTail operation
ms.date: 10/26/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Canon
qsharp.name: ApplyToTail
qsharp.summary: Applies an operation to the last element of an array.
---

# ApplyToTail operation

Namespace: [Microsoft.Quantum.Canon](xref:Microsoft.Quantum.Canon)

Package: [](https://nuget.org/packages/)


Applies an operation to the last element of an array.

```qsharp
operation ApplyToTail<'T> (op : ('T => Unit), targets : 'T[]) : Unit
```


## Description

Given an operation `op` and an array of targets `targets`,applies `op(Tail(targets))`.

## Input

### op : 'T => [Unit](xref:microsoft.quantum.lang-ref.unit) 

An operation to be applied.


### targets : 'T[]

An array of targets, of which the last will be applied to `op`.



## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)



## Type Parameters

### 'T

The input type of the operation to be applied.

## See Also

- [Microsoft.Quantum.Canon.ApplyToTailA](xref:Microsoft.Quantum.Canon.ApplyToTailA)
- [Microsoft.Quantum.Canon.ApplyToTailC](xref:Microsoft.Quantum.Canon.ApplyToTailC)
- [Microsoft.Quantum.Canon.ApplyToTailCA](xref:Microsoft.Quantum.Canon.ApplyToTailCA)