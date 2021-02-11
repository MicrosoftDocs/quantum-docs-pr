---
uid: Microsoft.Quantum.Arrays.IndexRange
title: IndexRange function
ms.date: 2/11/2021 12:00:00 AM
ms.topic: managed-reference
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Arrays
qsharp.name: IndexRange
qsharp.summary: >-
  Given an array, returns a range over the indices of that array, suitable
  for use in a for loop.
---

# IndexRange function

Namespace: [Microsoft.Quantum.Arrays](xref:Microsoft.Quantum.Arrays)

Package: [Microsoft.Quantum.QSharp.Foundation](https://nuget.org/packages/Microsoft.Quantum.QSharp.Foundation)


Given an array, returns a range over the indices of that array, suitablefor use in a for loop.

```qsharp
function IndexRange<'TElement> (array : 'TElement[]) : Range
```


## Input

### array : 'TElement[]

An array for which a range of indices should be returned.



## Output : [Range](xref:microsoft.quantum.lang-ref.range)

A range over all indices of the array.

## Type Parameters

### 'TElement

The type of elements of the array.

## Example

The following `for` loops are equivalent:```qsharpfor (idx in IndexRange(array)) { ... }for (idx in IndexRange(array)) { ... }```