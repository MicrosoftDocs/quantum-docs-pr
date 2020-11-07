---
uid: Microsoft.Quantum.Arrays.Flattened
title: Flattened function
ms.date: 11/7/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Arrays
qsharp.name: Flattened
qsharp.summary: Given an array of arrays, returns the concatenation of all arrays.
---

# Flattened function

Namespace: [Microsoft.Quantum.Arrays](xref:Microsoft.Quantum.Arrays)

Package: [](https://nuget.org/packages/)


Given an array of arrays, returns the concatenation of all arrays.

```qsharp
function Flattened<'T> (arrays : 'T[][]) : 'T[]
```


## Input

### arrays : 'T[][]

Array of arrays.



## Output : 'T[]

Concatenation of all arrays.

## Type Parameters

### 'T

The type of `array` elements.