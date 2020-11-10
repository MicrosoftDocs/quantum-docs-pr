---
uid: Microsoft.Quantum.Arrays.Filtered
title: Filtered function
ms.date: 10/26/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Arrays
qsharp.name: Filtered
qsharp.summary: >-
  Given an array and a predicate that is defined
  for the elements of the array, returns an array that consists of
  those elements that satisfy the predicate.
---

# Filtered function

Namespace: [Microsoft.Quantum.Arrays](xref:Microsoft.Quantum.Arrays)

Package: [](https://nuget.org/packages/)


Given an array and a predicate that is definedfor the elements of the array, returns an array that consists ofthose elements that satisfy the predicate.

```qsharp
function Filtered<'T> (predicate : ('T -> Bool), array : 'T[]) : 'T[]
```


## Input

### predicate : 'T -> [Bool](xref:microsoft.quantum.lang-ref.bool)

A function from `'T` to Boolean that is used to filter elements.


### array : 'T[]

An array of elements over `'T`.



## Output : 'T[]

An array `'T[]` of elements that satisfy the predicate.

## Type Parameters

### 'T

The type of `array` elements.

## Remarks

The function is defined for generic types, i.e., whenever we havean array `'T[]` and a predicate `'T -> Bool` we can filter elements.