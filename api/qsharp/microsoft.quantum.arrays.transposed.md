---
uid: Microsoft.Quantum.Arrays.Transposed
title: Transposed function
ms.date: 2/14/2021 12:00:00 AM
ms.topic: managed-reference
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Arrays
qsharp.name: Transposed
qsharp.summary: >-
  Returns the transpose of a matrix represented as an array
  of arrays.
---

# Transposed function

Namespace: [Microsoft.Quantum.Arrays](xref:Microsoft.Quantum.Arrays)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Returns the transpose of a matrix represented as an arrayof arrays.

```qsharp
function Transposed<'T> (matrix : 'T[][]) : 'T[][]
```


## Description

Input as an $r \times c$ matrix with $r$ rows and $c$ columns.  The matrixis row-based, i.e., `matrix[i][j]` accesses the element at row $i$ and column $j$.This function returns the $c \times r$ matrix that is the transpose of theinput matrix.

## Input

### matrix : 'T[][]

Row-based $r \times c$ matrix



## Output : 'T[][]

Transposed $c \times r$ matrix

## Type Parameters

### 'T

The type of each element of `matrix`.

## Example

```qsharp// same as [[1, 4], [2, 5], [3, 6]]let transposed = Transposed([[1, 2, 3], [4, 5, 6]]);```