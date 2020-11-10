---
uid: Microsoft.Quantum.Canon.ApplyToElementCA
title: ApplyToElementCA operation
ms.date: 10/26/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Canon
qsharp.name: ApplyToElementCA
qsharp.summary: Applies an operation to a given element of an array.
---

# ApplyToElementCA operation

Namespace: [Microsoft.Quantum.Canon](xref:Microsoft.Quantum.Canon)

Package: [](https://nuget.org/packages/)


Applies an operation to a given element of an array.

```qsharp
operation ApplyToElementCA<'T> (op : ('T => Unit is Adj + Ctl), index : Int, targets : 'T[]) : Unit
```


## Description

Given an operation `op`, an index `index`, and an array of targets `targets`,applies `op(targets[index])`.

## Input

### op : 'T => [Unit](xref:microsoft.quantum.lang-ref.unit) Adj + Ctl

An operation to be applied.


### index : [Int](xref:microsoft.quantum.lang-ref.int)

An index into the array of targets.


### targets : 'T[]

An array of possible targets for `op`.



## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)



## Type Parameters

### 'T

The input type of the operation to be applied.

## See Also

- [Microsoft.Quantum.Canon.ApplyToElement](xref:Microsoft.Quantum.Canon.ApplyToElement)
- [Microsoft.Quantum.Canon.ApplyToElementC](xref:Microsoft.Quantum.Canon.ApplyToElementC)
- [Microsoft.Quantum.Canon.ApplyToElementA](xref:Microsoft.Quantum.Canon.ApplyToElementA)