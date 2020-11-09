---
uid: Microsoft.Quantum.Arrays.Padded
title: Padded function
ms.date: 11/9/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Arrays
qsharp.name: Padded
qsharp.summary: >-
  Returns an array padded at with specified values up to a
  specified length.
---

# Padded function

Namespace: [Microsoft.Quantum.Arrays](xref:Microsoft.Quantum.Arrays)

Package: [](https://nuget.org/packages/)


Returns an array padded at with specified values up to aspecified length.

```qsharp
function Padded<'T> (nElementsTotal : Int, defaultElement : 'T, inputArray : 'T[]) : 'T[]
```


## Input

### nElementsTotal : [Int](xref:microsoft.quantum.lang-ref.int)

The length of the padded array. If this is positive, `inputArray`is padded at the head. If this is negative, `inputArray` is paddedat the tail.


### defaultElement : 'T

Default value to use for padding elements.


### inputArray : 'T[]

Array whose values are at the head of the output array.



## Output : 'T[]

An array `output` that is the `inputArray` padded at the headwith `defaultElement`s until `output` has length `nElementsTotal`

## Type Parameters

### 'T

The type of the array elements.