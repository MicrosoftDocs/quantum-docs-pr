---
uid: Microsoft.Quantum.Arrays.IndexOf
title: IndexOf function
ms.date: 10/16/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Arrays
qsharp.name: IndexOf
qsharp.summary: >-
  Returns the first index of the first element in an array that satisfies
  a given predicate. If no such element exists, returns -1.
---

# IndexOf function

Namespace: [Microsoft.Quantum.Arrays](xref:Microsoft.Quantum.Arrays)

Package: [](https://nuget.org/packages/)


Returns the first index of the first element in an array that satisfiesa given predicate. If no such element exists, returns -1.

```Q#
IndexOf<'T> (predicate : ('T -> Bool), arr : 'T[]) : Int
```


## Input

### predicate : 'T -> Bool

A predicate function acting on elements of the array.


### arr : 'T[]

An array to be searched using the given predicate.



## Output

Either the smallest index `idx` such that `predicate(arr[idx])` is true,or -1 if no such element exists.