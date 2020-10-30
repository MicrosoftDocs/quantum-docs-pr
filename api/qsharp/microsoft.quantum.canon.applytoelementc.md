---
uid: Microsoft.Quantum.Canon.ApplyToElementC
title: ApplyToElementC operation
ms.date: 10/29/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Canon
qsharp.name: ApplyToElementC
qsharp.summary: Applies an operation to a given element of an array.
---

# ApplyToElementC operation

Namespace: [Microsoft.Quantum.Canon](xref:Microsoft.Quantum.Canon)

Package: [](https://nuget.org/packages/)


Applies an operation to a given element of an array.

```qsharp
operation ApplyToElementC<'T> (op : ('T => Unit is Ctl), index : Int, targets : 'T[]) : Unit
```


## Description

Given an operation `op`, an index `index`, and an array of targets `targets`,applies `op(targets[index])`.

## Input

### op : 'T => [Unit](xref:microsoft.quantum.lang-ref.unit) Ctl

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
- [Microsoft.Quantum.Canon.ApplyToElementA](xref:Microsoft.Quantum.Canon.ApplyToElementA)
- [Microsoft.Quantum.Canon.ApplyToElementCA](xref:Microsoft.Quantum.Canon.ApplyToElementCA)