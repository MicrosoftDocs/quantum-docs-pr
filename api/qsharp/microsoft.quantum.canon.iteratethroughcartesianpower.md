---
uid: Microsoft.Quantum.Canon.IterateThroughCartesianPower
title: IterateThroughCartesianPower operation
ms.date: 2/5/2021 12:00:00 AM
ms.topic: managed-reference
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Canon
qsharp.name: IterateThroughCartesianPower
qsharp.summary: >-
  Applies an operation for each index in the Cartesian power of an
  integer range.
---

# IterateThroughCartesianPower operation

Namespace: [Microsoft.Quantum.Canon](xref:Microsoft.Quantum.Canon)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Applies an operation for each index in the Cartesian power of aninteger range.

```qsharp
operation IterateThroughCartesianPower (power : Int, bound : Int, op : (Int[] => Unit)) : Unit
```


## Description

Iteratively applies an operation for each element of a Cartesian powerof the range `0..(bound - 1)`.

## Input

### power : [Int](xref:microsoft.quantum.lang-ref.int)

The Cartesian power to which the range `0..(bound - 1)` should beraised.


### bound : [Int](xref:microsoft.quantum.lang-ref.int)

A specification of the range to be iterated over, given as the lengthof the range.


### op : [Int](xref:microsoft.quantum.lang-ref.int)[] => [Unit](xref:microsoft.quantum.lang-ref.unit) 

An operation to be called for each element of the given Cartesian power.



## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)



## Example

Given an operation `op`, the following two snippets are equivalent:```qsharpIterateThroughCartesianPower(2, 3, op);``````qsharpop([0, 0]);op([1, 0]);op([2, 0]);op([0, 1]);// ..op([2, 2]);```

## See Also

- [Microsoft.Quantum.Canon.IterateThroughCartesianProduct](xref:Microsoft.Quantum.Canon.IterateThroughCartesianProduct)