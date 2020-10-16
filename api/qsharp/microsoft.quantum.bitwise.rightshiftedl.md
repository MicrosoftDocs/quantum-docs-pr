---
uid: Microsoft.Quantum.Bitwise.RightShiftedL
title: RightShiftedL function
ms.date: 10/16/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Bitwise
qsharp.name: RightShiftedL
qsharp.summary: >-
  Shifts the bitwise representation of a number right by a given number of
  bits.
---

# RightShiftedL function

Namespace: [Microsoft.Quantum.Bitwise](xref:Microsoft.Quantum.Bitwise)

Package: [](https://nuget.org/packages/)


Shifts the bitwise representation of a number right by a given number ofbits.

```Q#
RightShiftedL (value : BigInt, amount : Int) : BigInt
```


## Input

### value : BigInt

The number whose bitwise representation is to be shifted to the right(less significant).


### amount : Int

The number of bits by which `value` is to be shifted to the right.



## Output

The value of `value`, shifted right by `amount` bits.

## Remarks

The following are equivalent:```Q#let c = a >>> b;let c = RightShiftedL(a, b);```