---
uid: Microsoft.Quantum.Arrays.EqualA
title: EqualA function
ms.date: 10/26/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Arrays
qsharp.name: EqualA
qsharp.summary: >-
  Given two arrays of the same type and a predicate that is defined
  for pairs of elements of the arrays, checks whether the arrays are equal.
---

# EqualA function

Namespace: [Microsoft.Quantum.Arrays](xref:Microsoft.Quantum.Arrays)

Package: [](https://nuget.org/packages/)


Given two arrays of the same type and a predicate that is definedfor pairs of elements of the arrays, checks whether the arrays are equal.

```qsharp
function EqualA<'T> (equal : (('T, 'T) -> Bool), array1 : 'T[], array2 : 'T[]) : Bool
```


## Input

### equal : ('T,'T) -> [Bool](xref:microsoft.quantum.lang-ref.bool)

A function from tuple `('T, 'T)` to `Bool` that is used to check whether two elements of arrays are equal.


### array1 : 'T[]

The first array to be compared.


### array2 : 'T[]

The second array to be compared.



## Output : [Bool](xref:microsoft.quantum.lang-ref.bool)

The value `true` if and only if `array1` and `array2` are equal.That is, if both arrays have the same length, and all elements are equalas defined by `equal`.

## Type Parameters

### 'T

The type of each array's elements.

## Remarks

This function is defined for generic types; i.e., whenever we havetwo arrays `'T[]` and a function `equal: ('T, 'T) -> Bool`, this function returnsa `Bool` value that indicates whether the arrays are equal.For two arrays to be considered equal, they have to have equal lengthand the elements in the same positions in the arrays have to be equal.