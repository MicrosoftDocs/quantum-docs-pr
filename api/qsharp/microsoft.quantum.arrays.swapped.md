---
uid: Microsoft.Quantum.Arrays.Swapped
title: Swapped function
ms.date: 10/26/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Arrays
qsharp.name: Swapped
qsharp.summary: Applies a swap of two elements in an array.
---

# Swapped function

Namespace: [Microsoft.Quantum.Arrays](xref:Microsoft.Quantum.Arrays)

Package: [](https://nuget.org/packages/)


Applies a swap of two elements in an array.

```qsharp
function Swapped<'T> (firstIndex : Int, secondIndex : Int, arr : 'T[]) : 'T[]
```


## Input

### firstIndex : [Int](xref:microsoft.quantum.lang-ref.int)

Index of the first element to be swapped.


### secondIndex : [Int](xref:microsoft.quantum.lang-ref.int)

Index of the second element to be swapped.


### arr : 'T[]

Array with elements to be swapped.



## Output : 'T[]

The array with the in place swap applied.## Example```qsharp// The following returns [0, 3, 2, 1, 4]Swapped(1, 3, [0, 1, 2, 3, 4]);```

## Type Parameters

### 'T

