---
uid: Microsoft.Quantum.Canon.IterateThroughCartesianProduct
title: IterateThroughCartesianProduct operation
ms.date: 2/15/2021 12:00:00 AM
ms.topic: managed-reference
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

### bounds : [Int](xref:microsoft.quantum.lang-ref.int)[]

An array specifying the ranges to be iterated over, with each rangebeing specified as an integer length.


### op : [Int](xref:microsoft.quantum.lang-ref.int)[] => [Unit](xref:microsoft.quantum.lang-ref.unit) 

An operation to be called for each element of the given Cartesian product.



## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)



## Example

Given an operation `op`, the following two snippets are equivalent:```qsharpIterateThroughCartesianProduct([3, 4, 5], op);``````qsharpop([0, 0, 0]);op([1, 0, 0]);op([2, 0, 0]);op([0, 1, 0]);// ...op([0, 3, 0]);op([0, 0, 1]);//op([2, 3, 4]);```

## See Also

- [Microsoft.Quantum.Canon.IterateThroughCartesianPower](xref:Microsoft.Quantum.Canon.IterateThroughCartesianPower)