---
uid: Microsoft.Quantum.Canon.ApplyToTailCA
title: ApplyToTailCA operation
ms.date: 10/26/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Canon
qsharp.name: ApplyToTailCA
qsharp.summary: Applies an operation to the last element of an array.
---

# ApplyToTailCA operation

Namespace: [Microsoft.Quantum.Canon](xref:Microsoft.Quantum.Canon)

Package: [](https://nuget.org/packages/)


Applies an operation to the last element of an array.

```qsharp
operation ApplyToTailCA<'T> (op : ('T => Unit is Adj + Ctl), targets : 'T[]) : Unit
```


## Description

Given an operation `op` and an array of targets `targets`,applies `op(Tail(targets))`.

## Input

### op : 'T => [Unit](xref:microsoft.quantum.lang-ref.unit) Adj + Ctl

An operation to be applied.


### targets : 'T[]

An array of targets, of which the last will be applied to `op`.



## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)



## Type Parameters

### 'T

The input type of the operation to be applied.

## See Also

- [Microsoft.Quantum.Canon.ApplyToTail](xref:Microsoft.Quantum.Canon.ApplyToTail)
- [Microsoft.Quantum.Canon.ApplyToTailA](xref:Microsoft.Quantum.Canon.ApplyToTailA)
- [Microsoft.Quantum.Canon.ApplyToTailC](xref:Microsoft.Quantum.Canon.ApplyToTailC)