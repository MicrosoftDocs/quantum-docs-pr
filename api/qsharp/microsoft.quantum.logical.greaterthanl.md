---
uid: Microsoft.Quantum.Logical.GreaterThanL
title: GreaterThanL function
ms.date: 10/16/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Logical
qsharp.name: GreaterThanL
qsharp.summary: Returns true if and only if a number is greater than another number.
---

# GreaterThanL function

Namespace: [Microsoft.Quantum.Logical](xref:Microsoft.Quantum.Logical)

Package: [](https://nuget.org/packages/)


Returns true if and only if a number is greater than another number.

```Q#
GreaterThanL (a : BigInt, b : BigInt) : Bool
```


## Input

### a : BigInt

The first value to be compared.


### b : BigInt

The second value to be compared.



## Output

`true` if and only if `a` is strictly greater than `b`.

## Remarks

The following are equivalent:```Q#let cond = a > b;let cond = GreaterThanL(a, b);```