---
uid: Microsoft.Quantum.Canon.ApplyToMostA
title: ApplyToMostA operation
ms.date: 12/9/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Canon
qsharp.name: ApplyToMostA
qsharp.summary: Applies an operation to all but the last element of an array.
---

# ApplyToMostA operation

Namespace: [Microsoft.Quantum.Canon](xref:Microsoft.Quantum.Canon)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Applies an operation to all but the last element of an array.

```qsharp
operation ApplyToMostA<'T> (op : ('T[] => Unit is Adj), targets : 'T[]) : Unit is Adj
```


## Description

Given an operation `op` and an array of targets `targets`,applies `op(Most(targets))`.

## Input

### op : 'T[] => [Unit](xref:microsoft.quantum.lang-ref.unit)  is Adj

An operation to be applied.


### targets : 'T[]

An array of targets, of which all but the last will be applied to `op`.



## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)



## Type Parameters

### 'T

The input type of the operation to be applied.

## See Also

- [Microsoft.Quantum.Canon.ApplyToMost](xref:Microsoft.Quantum.Canon.ApplyToMost)
- [Microsoft.Quantum.Canon.ApplyToMostC](xref:Microsoft.Quantum.Canon.ApplyToMostC)
- [Microsoft.Quantum.Canon.ApplyToMostCA](xref:Microsoft.Quantum.Canon.ApplyToMostCA)