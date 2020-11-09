---
uid: Microsoft.Quantum.Synthesis.IntegerBits
title: IntegerBits function
ms.date: 11/9/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Synthesis
qsharp.name: IntegerBits
qsharp.summary: Returns all positions in which bits of an integer are set.
---

# IntegerBits function

Namespace: [Microsoft.Quantum.Synthesis](xref:Microsoft.Quantum.Synthesis)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Returns all positions in which bits of an integer are set.

```qsharp
function IntegerBits (value : Int, length : Int) : Int[]
```


## Input

### value : [Int](xref:microsoft.quantum.lang-ref.int)

A nonnegative number.


### length : [Int](xref:microsoft.quantum.lang-ref.int)

The number of bits in the binary expansion of `value`.



## Output : [Int](xref:microsoft.quantum.lang-ref.int)[]

An array containing all bit positions (starting from 0) that are 1 inthe binary expansion of `value` considering all bits up to position`length - 1`.  All positions are ordered in the array by position in anincreasing order.