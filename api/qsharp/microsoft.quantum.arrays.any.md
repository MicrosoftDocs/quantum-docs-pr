---
uid: Microsoft.Quantum.Arrays.Any
title: Any function
ms.date: 11/7/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Arrays
qsharp.name: Any
qsharp.summary: >-
  Given an array and a predicate that is defined
  for the elements of the array, checks if at least one element of
  the array satisfies the predicate.
---

# Any function

Namespace: [Microsoft.Quantum.Arrays](xref:Microsoft.Quantum.Arrays)

Package: [](https://nuget.org/packages/)


Given an array and a predicate that is definedfor the elements of the array, checks if at least one element ofthe array satisfies the predicate.

```qsharp
function Any<'T> (predicate : ('T -> Bool), array : 'T[]) : Bool
```


## Input

### predicate : 'T -> [Bool](xref:microsoft.quantum.lang-ref.bool)

A function from `'T` to `Bool` that is used to check elements.


### array : 'T[]

An array of elements over `'T`.



## Output : [Bool](xref:microsoft.quantum.lang-ref.bool)

A `Bool` value of the OR function of the predicate applied to all elements.

## Type Parameters

### 'T

The type of `array` elements.

## Remarks

The function is defined for generic types, i.e., whenever we havean array `'T[]` and a function `predicate: 'T -> Bool` we can producea `Bool` value that indicates if some element satisfies `predicate`.