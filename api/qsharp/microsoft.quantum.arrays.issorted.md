---
uid: Microsoft.Quantum.Arrays.IsSorted
title: IsSorted function
ms.date: 11/10/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Arrays
qsharp.name: IsSorted
qsharp.summary: >-
  Given an array, returns whether that array is sorted as defined by
  a given comparison function.
---

# IsSorted function

Namespace: [Microsoft.Quantum.Arrays](xref:Microsoft.Quantum.Arrays)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Given an array, returns whether that array is sorted as defined bya given comparison function.

```qsharp
function IsSorted<'T> (comparison : (('T, 'T) -> Bool), array : 'T[]) : Bool
```


## Input

### comparison : ('T,'T) -> [Bool](xref:microsoft.quantum.lang-ref.bool)

A function that compares two elements such that `a` is considered tobe less than or equal to `b` if `comparison(a, b)` is `true`.


### array : 'T[]

The array to be checked.



## Output : [Bool](xref:microsoft.quantum.lang-ref.bool)

`true` if and only if for each pair of elements `a` and `b` of`array` occuring in that order, `comparison(a, b)` is `true`.

## Type Parameters

### 'T

The type of each element of `array`.

## Remarks

The function `comparison` is assumed to be transitive, such thatif `comparison(a, b)` and `comparison(b, c)`, then `comparison(a, c)`is assumed. If this property does not hold, then the output of thisfunction may be incorrect.