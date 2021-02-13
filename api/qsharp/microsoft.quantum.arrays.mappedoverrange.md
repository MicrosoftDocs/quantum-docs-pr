---
uid: Microsoft.Quantum.Arrays.MappedOverRange
title: MappedOverRange function
ms.date: 2/13/2021 12:00:00 AM
ms.topic: managed-reference
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Arrays
qsharp.name: MappedOverRange
qsharp.summary: >-
  Given a range and a function that takes an integer as input,
  returns a new array that consists
  of the images of the range values under the function.
---

# MappedOverRange function

Namespace: [Microsoft.Quantum.Arrays](xref:Microsoft.Quantum.Arrays)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Given a range and a function that takes an integer as input,returns a new array that consistsof the images of the range values under the function.

```qsharp
function MappedOverRange<'T> (mapper : (Int -> 'T), range : Range) : 'T[]
```


## Input

### mapper : [Int](xref:microsoft.quantum.lang-ref.int) -> 'T

A function from `Int` to `'T` that is used to map range values.


### range : [Range](xref:microsoft.quantum.lang-ref.range)

A range of integers.



## Output : 'T[]

An array `'T[]` of elements that are mapped by the `mapper` function.

## Type Parameters

### 'T

The result type of the `mapper` function.

## Example

This example adds 1 to a range of even numbers:```qsharplet numbers = MappedOverRange(PlusI(1, _), 0..2..10);// numbers = [1, 3, 5, 7, 9, 11]```

## Remarks

The function is defined for generic types, i.e., whenever we havea function `mapper: Int -> 'T` we can map the valuesof the range and produce an array of type `'T[]`.

## See Also

- [Microsoft.Quantum.Arrays.Mapped](xref:Microsoft.Quantum.Arrays.Mapped)