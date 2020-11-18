---
uid: Microsoft.Quantum.Arrays.All
title: All function
ms.date: 11/18/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Arrays
qsharp.name: All
qsharp.summary: >-
  Given an array and a predicate that is defined
  for the elements of the array, and checks if all elements of the
  array satisfy the predicate.
---

# All function

Namespace: [Microsoft.Quantum.Arrays](xref:Microsoft.Quantum.Arrays)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Given an array and a predicate that is definedfor the elements of the array, and checks if all elements of thearray satisfy the predicate.

```qsharp
function All<'T> (predicate : ('T -> Bool), array : 'T[]) : Bool
```


## Input

### predicate : 'T -> [Bool](xref:microsoft.quantum.lang-ref.bool)

A function from `'T` to `Bool` that is used to check elements.


### array : 'T[]

An array of elements over `'T`.



## Output : [Bool](xref:microsoft.quantum.lang-ref.bool)

A `Bool` value of the AND function of the predicate applied to all elements.

## Type Parameters

### 'T

The type of `array` elements.

## Remarks

The function is defined for generic types, i.e., whenever we havean array `'T[]` and a function `predicate: 'T -> Bool` we can producea `Bool` value that indicates if all elements satisfy `predicate`.