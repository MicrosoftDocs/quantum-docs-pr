---
uid: Microsoft.Quantum.Convert.RangeAsIntArray
title: RangeAsIntArray function
ms.date: 10/30/2020 12:00:00 AM
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

```qsharp
function RangeAsIntArray (range : Range) : Int[]
```


## Input

### range : [Range](xref:microsoft.quantum.lang-ref.range)

A `Range` of values `start..step..end` to be converted to an array.



## Output : [Int](xref:microsoft.quantum.lang-ref.int)[]

A new array of integers corresponding to values iterated over by `range`.