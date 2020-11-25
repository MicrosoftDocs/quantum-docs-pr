---
uid: Microsoft.Quantum.Arrays.IndexRange
title: IndexRange function
ms.date: 11/25/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Arrays
qsharp.name: IndexRange
qsharp.summary: >-
  Given an array, returns a range over the indices of that array, suitable
  for use in a for loop.
---

# IndexRange function

Namespace: [Microsoft.Quantum.Arrays](xref:Microsoft.Quantum.Arrays)

Package: [Microsoft.Quantum.QSharp.Core](https://nuget.org/packages/Microsoft.Quantum.QSharp.Core)


Given an array, returns a range over the indices of that array, suitablefor use in a for loop.

```qsharp
function IndexRange<'TElement> (array : 'TElement[]) : Range
```


## Input

### array : 'TElement[]

An array for which a range of indices should be returned.



## Output : [Range](xref:microsoft.quantum.user-guide.language.types)

A range over all indices of the array.

## Type Parameters

### 'TElement

The type of elements of the array.