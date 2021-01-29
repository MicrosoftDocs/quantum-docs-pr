---
uid: Microsoft.Quantum.Arrays.SequenceL
title: SequenceL function
ms.date: 1/29/2021 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Arrays
qsharp.name: SequenceL
qsharp.summary: Get an array of integers in a given interval.
---

# SequenceL function

Namespace: [Microsoft.Quantum.Arrays](xref:Microsoft.Quantum.Arrays)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Get an array of integers in a given interval.

```qsharp
function SequenceL (from : BigInt, to : BigInt) : BigInt[]
```


## Input

### from : [BigInt](xref:microsoft.quantum.lang-ref.bigint)

An inclusive start index of the interval.


### to : [BigInt](xref:microsoft.quantum.lang-ref.bigint)

An inclusive end index of the interval that is not smaller than `from`.



## Output : [BigInt](xref:microsoft.quantum.lang-ref.bigint)[]

An array containing the sequence of numbers `from`, `from + 1`, ...,`to`.

## Example

```qsharplet arr1 = SequenceL(0L, 3L); // [0L, 1L, 2L, 3L]let arr2 = SequenceL(23L, 29L); // [23L, 24L, 25L, 26L, 27L, 28L, 29L]let arr3 = SequenceL(-5L, -2L); // [-5L, -4L, -3L, -2L]```

## Remarks

The difference between `from` and `to` must fit into an `Int` value.