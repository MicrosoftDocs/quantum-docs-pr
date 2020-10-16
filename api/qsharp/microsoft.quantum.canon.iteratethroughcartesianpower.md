---
uid: Microsoft.Quantum.Canon.IterateThroughCartesianPower
title: IterateThroughCartesianPower operation
ms.date: 10/16/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Canon
qsharp.name: IterateThroughCartesianPower
qsharp.summary: >-
  Applies an operation for each index in the Cartesian power of an
  integer range.
---

# IterateThroughCartesianPower operation

Namespace: [Microsoft.Quantum.Canon](xref:Microsoft.Quantum.Canon)

Package: [](https://nuget.org/packages/)


Applies an operation for each index in the Cartesian power of aninteger range.

```Q#
IterateThroughCartesianPower (power : Int, bound : Int, op : (Int[] => Unit)) : Unit
```


## Description

Iteratively applies an operation for each element of a Cartesian powerof the range `0..(bound - 1)`.

## Input

### power : Int

The Cartesian power to which the range `0..(bound - 1)` should beraised.


### bound : Int

A specification of the range to be iterated over, given as the lengthof the range.


### op : Int[] => Unit 

An operation to be called for each element of the given Cartesian power.



## See Also

- [Microsoft.Quantum.Canon.IterateThroughCartesianProduct](xref:Microsoft.Quantum.Canon.IterateThroughCartesianProduct)