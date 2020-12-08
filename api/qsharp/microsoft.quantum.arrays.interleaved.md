---
uid: Microsoft.Quantum.Arrays.Interleaved
title: Interleaved function
ms.date: 12/8/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Arrays
qsharp.name: Interleaved
qsharp.summary: Interleaves two arrays of (almost) same size.
---

# Interleaved function

Namespace: [Microsoft.Quantum.Arrays](xref:Microsoft.Quantum.Arrays)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Interleaves two arrays of (almost) same size.

```qsharp
function Interleaved<'T> (first : 'T[], second : 'T[]) : 'T[]
```


## Description

This function returns the interleaving of two arrays, startingwith the first element from the first array, then the firstelement from the second array, and so on.The first array must either beof the same length as the second one, or can have one more element.

## Input

### first : 'T[]

The first array to be interleaved.


### second : 'T[]

The second array to be interleaved.



## Output : 'T[]

Interleaved array

## Type Parameters

### 'T

The type of each element of `first` and `second`.