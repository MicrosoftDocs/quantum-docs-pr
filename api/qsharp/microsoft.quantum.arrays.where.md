---
uid: Microsoft.Quantum.Arrays.Where
title: Where function
ms.date: 10/16/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Arrays
qsharp.name: Where
qsharp.summary: >-
  Given a predicate and an array, returns the indices of that
  array where the predicate is true.
---

# Where function

Namespace: [Microsoft.Quantum.Arrays](xref:Microsoft.Quantum.Arrays)

Package: [](https://nuget.org/packages/)


Given a predicate and an array, returns the indices of thatarray where the predicate is true.

```Q#
Where<'T> (predicate : ('T -> Bool), array : 'T[]) : Int[]
```


## Input

### predicate : 'T -> Bool

A function from `'T` to Boolean that is used to filter elements.


### array : 'T[]

An array of elements over `'T`.



## Output

An array of indices where `predicate` is true.

## Type Parameters

### 'T

The type of `array` elements.

