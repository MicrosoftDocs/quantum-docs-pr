---
uid: Microsoft.Quantum.Arrays.RectangularArrayFact
title: RectangularArrayFact function
ms.date: 12/21/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Arrays
qsharp.name: RectangularArrayFact
qsharp.summary: Represents a condition that a 2-dimensional array has a rectangular shape
---

# RectangularArrayFact function

Namespace: [Microsoft.Quantum.Arrays](xref:Microsoft.Quantum.Arrays)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Represents a condition that a 2-dimensional array has a rectangular shape

```qsharp
function RectangularArrayFact<'T> (array : 'T[][], message : String) : Unit
```


## Description

This function asserts that each row in an array has the same length.

## Input

### array : 'T[][]

A 2-dimensional array of elements


### message : [String](xref:microsoft.quantum.lang-ref.string)

A message to be printed if the array is not a rectangular array



## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)



## Type Parameters

### 'T

The type of each element of `array`.

## See Also

- [Microsoft.Quantum.Arrays.SquareArrayFact](xref:Microsoft.Quantum.Arrays.SquareArrayFact)