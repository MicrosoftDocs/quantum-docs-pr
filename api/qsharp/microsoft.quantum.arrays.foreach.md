---
uid: Microsoft.Quantum.Arrays.ForEach
title: ForEach operation
ms.date: 11/12/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Arrays
qsharp.name: ForEach
qsharp.summary: >-
  Given an array and an operation that is defined
  for the elements of the array, returns a new array that consists
  of the images of the original array under the operation.
---

# ForEach operation

Namespace: [Microsoft.Quantum.Arrays](xref:Microsoft.Quantum.Arrays)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Given an array and an operation that is definedfor the elements of the array, returns a new array that consistsof the images of the original array under the operation.

```qsharp
operation ForEach<'T, 'U> (action : ('T => 'U), array : 'T[]) : 'U[]
```


## Input

### action : 'T => 'U 

An operation from `'T` to `'U` that is applied to each element.


### array : 'T[]

An array of elements over `'T`.



## Output : 'U[]

An array `'U[]` of elements that are mapped by the `action` operation.

## Type Parameters

### 'T

The type of `array` elements.
### 'U

The result type of the `action` operation.

## Remarks

The operation is defined for generic types, i.e., whenever we havean array `'T[]` and an operation `action : 'T -> 'U` we can map the elementsof the array and produce a new array of type `'U[]`.