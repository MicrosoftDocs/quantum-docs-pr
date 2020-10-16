---
uid: Microsoft.Quantum.Logical.GreaterThanOrEqualL
title: GreaterThanOrEqualL function
ms.date: 10/16/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Logical
qsharp.name: GreaterThanOrEqualL
qsharp.summary: >-
  Returns true if and only if a number is greater than or equal to another
  number.
---

# GreaterThanOrEqualL function

Namespace: [Microsoft.Quantum.Logical](xref:Microsoft.Quantum.Logical)

Package: [](https://nuget.org/packages/)


Returns true if and only if a number is greater than or equal to anothernumber.

```Q#
GreaterThanOrEqualL (a : BigInt, b : BigInt) : Bool
```


## Input

### a : BigInt

The first value to be compared.


### b : BigInt

The second value to be compared.



## Output

`true` if and only if `a` is greater than or is equal to `b`.

## Remarks

The following are equivalent:```Q#let cond = a >= b;let cond = GreaterThanOrEqualL(a, b);```