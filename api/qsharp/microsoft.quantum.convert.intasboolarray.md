---
uid: Microsoft.Quantum.Convert.IntAsBoolArray
title: IntAsBoolArray function
ms.date: 11/19/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Convert
qsharp.name: IntAsBoolArray
qsharp.summary: >-
  Produces a binary representation of a positive integer, using the
  little-endian representation for the returned array.
---

# IntAsBoolArray function

Namespace: [Microsoft.Quantum.Convert](xref:Microsoft.Quantum.Convert)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Produces a binary representation of a positive integer, using thelittle-endian representation for the returned array.

```qsharp
function IntAsBoolArray (number : Int, bits : Int) : Bool[]
```


## Input

### number : [Int](xref:microsoft.quantum.lang-ref.int)

A positive integer to be converted to an array of boolean values.


### bits : [Int](xref:microsoft.quantum.lang-ref.int)

The number of bits in the binary representation of `number`.



## Output : [Bool](xref:microsoft.quantum.lang-ref.bool)[]

An array of boolean values representing `number`.

## Remarks

The input `bits` must be between 0 and 63.The input `number` must be between 0 and $2^{\texttt{bits}} - 1$.