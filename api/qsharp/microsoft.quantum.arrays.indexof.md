---
uid: Microsoft.Quantum.Arrays.IndexOf
title: IndexOf function
ms.date: 11/26/2020 12:00:00 AM
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

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Returns the first index of the first element in an array that satisfiesa given predicate. If no such element exists, returns -1.

```qsharp
function IndexOf<'T> (predicate : ('T -> Bool), arr : 'T[]) : Int
```


## Input

### predicate : 'T -> [Bool](xref:microsoft.quantum.lang-ref.bool)

A predicate function acting on elements of the array.


### arr : 'T[]

An array to be searched using the given predicate.



## Output : [Int](xref:microsoft.quantum.lang-ref.int)

Either the smallest index `idx` such that `predicate(arr[idx])` is true,or -1 if no such element exists.

## Type Parameters

### 'T

