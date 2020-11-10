---
uid: Microsoft.Quantum.Arrays.SquareArrayFact
title: SquareArrayFact function
ms.date: 10/26/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Arrays
qsharp.name: SquareArrayFact
qsharp.summary: Represents a condition that a 2-dimensional array has a square shape
---

# SquareArrayFact function

Namespace: [Microsoft.Quantum.Arrays](xref:Microsoft.Quantum.Arrays)

Package: [](https://nuget.org/packages/)


Represents a condition that a 2-dimensional array has a square shape

```qsharp
function SquareArrayFact<'T> (array : 'T[][], message : String) : Unit
```


## Description

This function asserts that each row in an array hasas many elements as there are rows (elements) in the array.

## Input

### array : 'T[][]

A 2-dimensional array of elements


### message : [String](xref:microsoft.quantum.lang-ref.string)

A message to be printed if the array is not a square array



## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)



## Type Parameters

### 'T

The type of each element of `array`.

## See Also

- [Microsoft.Quantum.Arrays.RectangularArrayFact](xref:Microsoft.Quantum.Arrays.RectangularArrayFact)