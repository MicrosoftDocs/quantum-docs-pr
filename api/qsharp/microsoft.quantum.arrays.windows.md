---
uid: Microsoft.Quantum.Arrays.Windows
title: Windows function
ms.date: 10/26/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Arrays
qsharp.name: Windows
qsharp.summary: Returns all consecutive subarrays of length `size`.
---

# Windows function

Namespace: [Microsoft.Quantum.Arrays](xref:Microsoft.Quantum.Arrays)

Package: [](https://nuget.org/packages/)


Returns all consecutive subarrays of length `size`.

```qsharp
function Windows<'T> (size : Int, array : 'T[]) : 'T[][]
```


## Description

This function returns all `n - size + 1` subarrays of

## Input

### size : [Int](xref:microsoft.quantum.lang-ref.int)

Length of the subarrays.


### array : 'T[]

An array of elements.



## Output : 'T[][]



## Type Parameters

### 'T

The type of `array` elements.