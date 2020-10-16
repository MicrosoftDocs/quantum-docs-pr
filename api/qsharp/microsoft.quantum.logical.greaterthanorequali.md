---
uid: Microsoft.Quantum.Logical.GreaterThanOrEqualI
title: GreaterThanOrEqualI function
ms.date: 10/16/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Logical
qsharp.name: GreaterThanOrEqualI
qsharp.summary: >-
  Returns true if and only if a number is greater than or equal to another
  number.
---

# GreaterThanOrEqualI function

Namespace: [Microsoft.Quantum.Logical](xref:Microsoft.Quantum.Logical)

Package: [](https://nuget.org/packages/)


Returns true if and only if a number is greater than or equal to anothernumber.

```Q#
GreaterThanOrEqualI (a : Int, b : Int) : Bool
```


## Input

### a : Int

The first value to be compared.


### b : Int

The second value to be compared.



## Output

`true` if and only if `a` is greater than or is equal to `b`.

## Remarks

The following are equivalent:```Q#let cond = a >= b;let cond = GreaterThanOrEqualI(a, b);```