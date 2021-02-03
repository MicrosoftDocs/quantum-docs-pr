---
uid: Microsoft.Quantum.Arrays.Sorted
title: Sorted function
ms.date: 2/3/2021 12:00:00 AM
ms.topic: managed-reference
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Arrays
qsharp.name: Sorted
qsharp.summary: >-
  Given an array, returns the elements of that array sorted by a given
  comparison function.
---

# Sorted function

Namespace: [Microsoft.Quantum.Arrays](xref:Microsoft.Quantum.Arrays)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Given an array, returns the elements of that array sorted by a givencomparison function.

```qsharp
function Sorted<'T> (comparison : (('T, 'T) -> Bool), array : 'T[]) : 'T[]
```


## Input

### comparison : ('T,'T) -> [Bool](xref:microsoft.quantum.lang-ref.bool)

A function that compares two elements such that `a` is considered tobe less than or equal to `b` if `comparison(a, b)` is `true`.


### array : 'T[]

The array to be sorted.



## Output : 'T[]



## Type Parameters

### 'T

The type of each element of `array`.

## Example

The following snippet sorts an array of integers to occur in ascendingorder:```qsharplet sortedArray = Sorted(LessThanOrEqualI, [3, 17, 11, -201, -11]);```

## Remarks

The function `comparison` is assumed to be transitive, such thatif `comparison(a, b)` and `comparison(b, c)`, then `comparison(a, c)`is assumed. If this property does not hold, then the output of thisfunction may be incorrect.As this is a function, the results are completely determinstic, evenwhen two elements are considered equal under `comparison`;that is, when `comparison(a, b)` and `comparison(b, a)` are both `true`.In particular, the sort performed by this function is guaranteed to bestable, so that if two elements `a` and `b` occur in that order within`array` and are considered equal under `comparison`, then `a` will alsoappear before `b` in the output.For example:```qsharpfunction LastDigitLessThanOrEqual(left : Int, right : Int) : Bool {    return LessThanOrEqualI(        left % 10, right % 10    );}function SortedByLastDigit() : Int[] {    return Sorted(LastDigitLessThanOrEqual, [3, 37, 11, 17]);}// returns [11, 3, 37, 17].```