---
uid: Microsoft.Quantum.Arrays.Mapped
title: Mapped function
ms.date: 10/29/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Arrays
qsharp.name: Mapped
qsharp.summary: >-
  Given an array and a function that is defined
  for the elements of the array, returns a new array that consists
  of the images of the original array under the function.
---

# Mapped function

Namespace: [Microsoft.Quantum.Arrays](xref:Microsoft.Quantum.Arrays)

Package: [](https://nuget.org/packages/)


Given an array and a function that is definedfor the elements of the array, returns a new array that consistsof the images of the original array under the function.

```qsharp
function Mapped<'T, 'U> (mapper : ('T -> 'U), array : 'T[]) : 'U[]
```


## Input

### mapper : 'T -> 'U

A function from `'T` to `'U` that is used to map elements.


### array : 'T[]

An array of elements over `'T`.



## Output : 'U[]

An array `'U[]` of elements that are mapped by the `mapper` function.

## Type Parameters

### 'T

The type of `array` elements.
### 'U

The result type of the `mapper` function.

## Remarks

The function is defined for generic types, i.e., whenever we havean array `'T[]` and a function `mapper: 'T -> 'U` we can map the elementsof the array and produce a new array of type `'U[]`.