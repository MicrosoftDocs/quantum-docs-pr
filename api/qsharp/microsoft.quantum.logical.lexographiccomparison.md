---
uid: Microsoft.Quantum.Logical.LexographicComparison
title: LexographicComparison function
ms.date: 11/3/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Logical
qsharp.name: LexographicComparison
qsharp.summary: >-
  Given a comparison function, returns a new function that
  lexographically compares two arrays.
---

# LexographicComparison function

Namespace: [Microsoft.Quantum.Logical](xref:Microsoft.Quantum.Logical)

Package: [](https://nuget.org/packages/)


Given a comparison function, returns a new function thatlexographically compares two arrays.

```qsharp
function LexographicComparison<'T> (elementComparison : (('T, 'T) -> Bool)) : (('T[], 'T[]) -> Bool)
```


## Input

### elementComparison : ('T,'T) -> [Bool](xref:microsoft.quantum.lang-ref.bool)

A function that compares two elements `x` and `y` and returns if`x` is less than or equal to `y`.



## Output : ('T[],'T[]) -> [Bool](xref:microsoft.quantum.lang-ref.bool)

A function that compares two arrays `xs` and `ys` and returns if`xs` occurs before or equal to `ys` in lexographical ordering.

## Type Parameters

### 'T

The type of the elements of the arrays being compared.

## Remarks

The lexographic comparison between two arrays `xs` and `ys` is definedby the following procedure. We say that two elements `x` and `y`are equivalent if `elementComparison(x, y)` and `elementComparison(y, x)`are both true.- Both arrays are compared element-by-element until the first pair of  elements that are not equivalent. The array containing the element  that occurs first according to `elementComparison` is said to occur  first in lexographical ordering.- If no inequivalent elements are found, and one array is longer than  the other, the shorter array is said to occur first.

## See Also

- [Microsoft.Quantum.Arrays.Sorted](xref:Microsoft.Quantum.Arrays.Sorted)