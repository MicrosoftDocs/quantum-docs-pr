---
uid: Microsoft.Quantum.Arrays.Unique
title: Unique function
ms.date: 1/29/2021 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Arrays
qsharp.name: Unique
qsharp.summary: Returns a new array that has no equal adjacent elements.
---

# Unique function

Namespace: [Microsoft.Quantum.Arrays](xref:Microsoft.Quantum.Arrays)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Returns a new array that has no equal adjacent elements.

```qsharp
function Unique<'T> (equal : (('T, 'T) -> Bool), array : 'T[]) : 'T[]
```


## Description

Given some array of elements and a function to test equality, thisfunction returns a new array in which the relative order of elementsis kept, but all adjacent elements which are equal are filtered tojust a single element.

## Input

### equal : ('T,'T) -> [Bool](xref:microsoft.quantum.lang-ref.bool)

A function that compares two elements such that `a` is considered tobe equal to `b` if `equal(a, b)` is `true`.


### array : 'T[]

The array to be filtered for unique elements.



## Output : 'T[]

Array with no equal adjacent elements.

## Type Parameters

### 'T

The type of each element of `array`.

## Example

```Q#let unique1 = Unique(EqualI, [1, 1, 3, 3, 2, 5, 5, 5, 7]);// same as [1, 3, 2, 5, 7]let unique2 = Unique(EqualI, [2, 2, 1, 1, 2, 2, 1, 1]);// same as [2, 1, 2, 1];let unique3 = Unique(EqualI, Sorted(LessThanOrEqualI, [2, 2, 1, 1, 2, 2, 1, 1]));// same as [1, 2];```

## Remarks

If there are multiple elements that are equal but not next to each other,there will be multiple occurrences in the output array.  Use this functiontogether with `Sorted` to get an array with overall unique elements.