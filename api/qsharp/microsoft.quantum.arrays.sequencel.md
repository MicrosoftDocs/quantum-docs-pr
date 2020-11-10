---
uid: Microsoft.Quantum.Arrays.SequenceL
title: SequenceL function
ms.date: 10/26/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Arrays
qsharp.name: SequenceL
qsharp.summary: Get an array of integers in a given interval.
---

# SequenceL function

Namespace: [Microsoft.Quantum.Arrays](xref:Microsoft.Quantum.Arrays)

Package: [](https://nuget.org/packages/)


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

## Remarks

The difference between `from` and `to` must fit into an `Int` value.