---
uid: Microsoft.Quantum.Canon.ApplyToHeadA
title: ApplyToHeadA operation
ms.date: 2/15/2021 12:00:00 AM
ms.topic: managed-reference
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Canon
qsharp.name: ApplyToHeadA
qsharp.summary: Applies an operation to the first element of an array.
---

# ApplyToHeadA operation

Namespace: [Microsoft.Quantum.Canon](xref:Microsoft.Quantum.Canon)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Applies an operation to the first element of an array.

```qsharp
operation ApplyToHeadA<'T> (op : ('T => Unit is Adj), targets : 'T[]) : Unit is Adj
```


## Description

Given an operation `op` and an array of targets `targets`,applies `op(Head(targets))`.

## Input

### op : 'T => [Unit](xref:microsoft.quantum.lang-ref.unit)  is Adj

An operation to be applied.


### targets : 'T[]

An array of targets, of which the first will be applied to `op`.



## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)



## Type Parameters

### 'T

The input type of the operation to be applied.

## See Also

- [Microsoft.Quantum.Canon.ApplyToHead](xref:Microsoft.Quantum.Canon.ApplyToHead)
- [Microsoft.Quantum.Canon.ApplyToHeadC](xref:Microsoft.Quantum.Canon.ApplyToHeadC)
- [Microsoft.Quantum.Canon.ApplyToHeadCA](xref:Microsoft.Quantum.Canon.ApplyToHeadCA)