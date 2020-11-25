---
uid: Microsoft.Quantum.Canon.ApplyToElement
title: ApplyToElement operation
ms.date: 11/25/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Canon
qsharp.name: ApplyToElement
qsharp.summary: Applies an operation to a given element of an array.
---

# ApplyToElement operation

Namespace: [Microsoft.Quantum.Canon](xref:Microsoft.Quantum.Canon)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Applies an operation to a given element of an array.

```qsharp
operation ApplyToElement<'T> (op : ('T => Unit), index : Int, targets : 'T[]) : Unit
```


## Description

Given an operation `op`, an index `index`, and an array of targets `targets`,applies `op(targets[index])`.

## Input

### op : 'T => [Unit](xref:microsoft.quantum.user-guide.language.types) 

An operation to be applied.


### index : [Int](xref:microsoft.quantum.user-guide.language.types)

An index into the array of targets.


### targets : 'T[]

An array of possible targets for `op`.



## Output : [Unit](xref:microsoft.quantum.user-guide.language.types)



## Type Parameters

### 'T

The input type of the operation to be applied.

## See Also

- [Microsoft.Quantum.Canon.ApplyToElementC](xref:Microsoft.Quantum.Canon.ApplyToElementC)
- [Microsoft.Quantum.Canon.ApplyToElementA](xref:Microsoft.Quantum.Canon.ApplyToElementA)
- [Microsoft.Quantum.Canon.ApplyToElementCA](xref:Microsoft.Quantum.Canon.ApplyToElementCA)