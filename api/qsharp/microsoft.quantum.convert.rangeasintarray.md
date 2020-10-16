---
uid: Microsoft.Quantum.Convert.RangeAsIntArray
title: RangeAsIntArray function
ms.date: 10/16/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Convert
qsharp.name: RangeAsIntArray
qsharp.summary: Creates an array `arr` of integers enumerated by start..step..end.
---

# RangeAsIntArray function

Namespace: [Microsoft.Quantum.Convert](xref:Microsoft.Quantum.Convert)

Package: [](https://nuget.org/packages/)


Creates an array `arr` of integers enumerated by start..step..end.

```Q#
RangeAsIntArray (range : Range) : Int[]
```


## Input

### range : Range

A `Range` of values `start..step..end` to be converted to an array.



## Output

A new array of integers corresponding to values iterated over by `range`.