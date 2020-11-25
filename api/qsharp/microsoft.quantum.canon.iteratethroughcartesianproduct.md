---
uid: Microsoft.Quantum.Canon.IterateThroughCartesianProduct
title: IterateThroughCartesianProduct operation
ms.date: 11/25/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Canon
qsharp.name: IterateThroughCartesianProduct
qsharp.summary: >-
  Applies an operation for each index in the Cartesian product of several
  ranges.
---

# IterateThroughCartesianProduct operation

Namespace: [Microsoft.Quantum.Canon](xref:Microsoft.Quantum.Canon)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Applies an operation for each index in the Cartesian product of severalranges.

```qsharp
operation IterateThroughCartesianProduct (bounds : Int[], op : (Int[] => Unit)) : Unit
```


## Description

Iteratively applies an operation for each element of the Cartesian productof `0..(bounds[0] - 1)`, `0..(bounds[1] - 1)`, ..., `0..(bounds[Length(bounds) - 1] - 1)`

## Input

### bounds : [Int](xref:microsoft.quantum.user-guide.language.types)[]

An array specifying the ranges to be iterated over, with each rangebeing specified as an integer length.


### op : [Int](xref:microsoft.quantum.user-guide.language.types)[] => [Unit](xref:microsoft.quantum.user-guide.language.types) 

An operation to be called for each element of the given Cartesian product.



## Output : [Unit](xref:microsoft.quantum.user-guide.language.types)



## See Also

- [Microsoft.Quantum.Canon.IterateThroughCartesianPower](xref:Microsoft.Quantum.Canon.IterateThroughCartesianPower)