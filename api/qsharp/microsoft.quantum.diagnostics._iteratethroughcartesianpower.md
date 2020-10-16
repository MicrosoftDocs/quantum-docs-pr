---
uid: Microsoft.Quantum.Diagnostics._iterateThroughCartesianPower
title: _iterateThroughCartesianPower operation
ms.date: 10/16/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Diagnostics
qsharp.name: _iterateThroughCartesianPower
qsharp.summary: >-
  Iterates a variable through a Cartesian product
  [ 0, bounds[0]-1 ] × [ 0, bounds[1]-1 ] × [ 0, bounds[Length(bounds)-1]-1 ]
  and calls op(arr) for every element of the Cartesian product
---

# _iterateThroughCartesianPower operation

Namespace: [Microsoft.Quantum.Diagnostics](xref:Microsoft.Quantum.Diagnostics)

Package: [](https://nuget.org/packages/)


Iterates a variable through a Cartesian product[ 0, bounds[0]-1 ] × [ 0, bounds[1]-1 ] × [ 0, bounds[Length(bounds)-1]-1 ]and calls op(arr) for every element of the Cartesian product

```Q#
_iterateThroughCartesianPower (length : Int, value : Int, op : (Int[] => Unit)) : Unit
```
