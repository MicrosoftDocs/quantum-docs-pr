---
uid: Microsoft.Quantum.Canon.ApplyToElementC
title: ApplyToElementC operation
ms.date: 2/14/2021 12:00:00 AM
ms.topic: managed-reference
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Canon
qsharp.name: ApplyToElementC
qsharp.summary: Applies an operation to a given element of an array.
---

# ApplyToElementC operation

Namespace: [Microsoft.Quantum.Canon](xref:Microsoft.Quantum.Canon)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Applies an operation to a given element of an array.

```qsharp
operation ApplyToElementC<'T> (op : ('T => Unit is Ctl), index : Int, targets : 'T[]) : Unit is Ctl
```


## Description

Given an operation `op`, an index `index`, and an array of targets `targets`,applies `op(targets[index])`.

## Input

### op : 'T => [Unit](xref:microsoft.quantum.lang-ref.unit)  is Ctl

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