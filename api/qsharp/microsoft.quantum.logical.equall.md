---
uid: Microsoft.Quantum.Logical.EqualL
title: EqualL function
ms.date: 10/16/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Logical
qsharp.name: EqualL
qsharp.summary: Returns true if and only if two inputs are equal.
---

# EqualL function

Namespace: [Microsoft.Quantum.Logical](xref:Microsoft.Quantum.Logical)

Package: [](https://nuget.org/packages/)


Returns true if and only if two inputs are equal.

```Q#
EqualL (a : BigInt, b : BigInt) : Bool
```


## Input

### a : BigInt

The first value to be compared.


### b : BigInt

The second value to be compared.



## Output

`true` if and only if `a` is equal to `b`.

## Remarks

The following are equivalent:```Q#let cond = a == b;let cond = EqualL(a, b);```