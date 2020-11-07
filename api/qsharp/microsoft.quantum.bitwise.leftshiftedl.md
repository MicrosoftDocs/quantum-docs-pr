---
uid: Microsoft.Quantum.Bitwise.LeftShiftedL
title: LeftShiftedL function
ms.date: 11/7/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Bitwise
qsharp.name: LeftShiftedL
qsharp.summary: >-
  Shifts the bitwise representation of a number left by a given number of
  bits.
---

# LeftShiftedL function

Namespace: [Microsoft.Quantum.Bitwise](xref:Microsoft.Quantum.Bitwise)

Package: [](https://nuget.org/packages/)


Shifts the bitwise representation of a number left by a given number ofbits.

```qsharp
function LeftShiftedL (value : BigInt, amount : Int) : BigInt
```


## Input

### value : [BigInt](xref:microsoft.quantum.lang-ref.bigint)

The number whose bitwise representation is to be shifted to the left(more significant).


### amount : [Int](xref:microsoft.quantum.lang-ref.int)

The number of bits by which `value` is to be shifted to the left.



## Output : [BigInt](xref:microsoft.quantum.lang-ref.bigint)

The value of `value`, shifted left by `amount` bits.

## Remarks

The following are equivalent:```Q#let c = a <<< b;let c = LeftShiftedL(a, b);```