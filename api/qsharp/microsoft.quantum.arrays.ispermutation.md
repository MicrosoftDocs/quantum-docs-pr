---
uid: Microsoft.Quantum.Arrays.IsPermutation
title: IsPermutation function
ms.date: 10/16/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Arrays
qsharp.name: IsPermutation
qsharp.summary: Outputs true if and only if a given array represents a permutation.
---

# IsPermutation function

Namespace: [Microsoft.Quantum.Arrays](xref:Microsoft.Quantum.Arrays)

Package: [](https://nuget.org/packages/)


Outputs true if and only if a given array represents a permutation.

```Q#
IsPermutation (permuation : Int[]) : Bool
```


## Description

Given an array `array` of length `n`, returns true if and only ifeach integer from `0` to `n - 1` appears exactly once in `array`, suchthat `array` can be interpreted as a permutation on `n` elements.

## Input

### array

An array that may or may not represent a permutation.



## Remarks

An array of length zero is trivially a permutation.