---
uid: Microsoft.Quantum.Arrays.Diagonal
title: Diagonal function
ms.date: 10/28/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Arrays
qsharp.name: Diagonal
qsharp.summary: Returns an array of diagonal elements of a 2-dimensional array
---

# Diagonal function

Namespace: [Microsoft.Quantum.Arrays](xref:Microsoft.Quantum.Arrays)

Package: [](https://nuget.org/packages/)


Returns an array of diagonal elements of a 2-dimensional array

```qsharp
function Diagonal<'T> (matrix : 'T[][]) : 'T[]
```


## Description

If the 2-dimensional array has not a square shape, the diagonal overthe minimum over the number of rows and columns will be returned.

## Input

### matrix : 'T[][]

2-dimensional matrix in row-wise order



## Output : 'T[]



## Type Parameters

### 'T

The type of each element of `matrix`.

## See Also

- [Microsoft.Quantum.Arrays.Transposed](xref:Microsoft.Quantum.Arrays.Transposed)