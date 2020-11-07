---
uid: Microsoft.Quantum.Arrays.MappedByIndex
title: MappedByIndex function
ms.date: 11/7/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Arrays
qsharp.name: MappedByIndex
qsharp.summary: >-
  Given an array and a function that is defined
  for the indexed elements of the array, returns a new array that consists
  of the images of the original array under the function.
---

# MappedByIndex function

Namespace: [Microsoft.Quantum.Arrays](xref:Microsoft.Quantum.Arrays)

Package: [](https://nuget.org/packages/)


Given an array and a function that is definedfor the indexed elements of the array, returns a new array that consistsof the images of the original array under the function.

```qsharp
function MappedByIndex<'T, 'U> (mapper : ((Int, 'T) -> 'U), array : 'T[]) : 'U[]
```


## Input

### mapper : ([Int](xref:microsoft.quantum.lang-ref.int),'T) -> 'U

A function from `(Int, 'T)` to `'U` that is used to map elementsand their indices.


### array : 'T[]

An array of elements over `'T`.



## Output : 'U[]

An array `'U[]` of elements that are mapped by the `mapper` function.

## Type Parameters

### 'T

The type of `array` elements.
### 'U

The result type of the `mapper` function.

## See Also

- [Microsoft.Quantum.Arrays.Mapped](xref:Microsoft.Quantum.Arrays.Mapped)