---
uid: Microsoft.Quantum.Logical.LessThanOrEqualL
title: LessThanOrEqualL function
ms.date: 10/16/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Logical
qsharp.name: LessThanOrEqualL
qsharp.summary: >-
  Returns true if and only if a number is less than or equal to another
  number.
---

# LessThanOrEqualL function

Namespace: [Microsoft.Quantum.Logical](xref:Microsoft.Quantum.Logical)

Package: [](https://nuget.org/packages/)


Returns true if and only if a number is less than or equal to anothernumber.

```Q#
LessThanOrEqualL (a : BigInt, b : BigInt) : Bool
```


## Input

### a : BigInt

The first value to be compared.


### b : BigInt

The second value to be compared.



## Output

`true` if and only if `a` is less than or equal to `b`.

## Remarks

The following are equivalent:```Q#let cond = a <= b;let cond = LessThanOrEqualL(a, b);```