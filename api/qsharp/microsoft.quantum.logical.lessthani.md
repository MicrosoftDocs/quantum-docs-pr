---
uid: Microsoft.Quantum.Logical.LessThanI
title: LessThanI function
ms.date: 10/16/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Logical
qsharp.name: LessThanI
qsharp.summary: Returns true if and only if a number is less than another number.
---

# LessThanI function

Namespace: [Microsoft.Quantum.Logical](xref:Microsoft.Quantum.Logical)

Package: [](https://nuget.org/packages/)


Returns true if and only if a number is less than another number.

```Q#
LessThanI (a : Int, b : Int) : Bool
```


## Input

### a : Int

The first value to be compared.


### b : Int

The second value to be compared.



## Output

`true` if and only if `a` is strictly less than `b`.

## Remarks

The following are equivalent:```Q#let cond = a < b;let cond = LessThanI(a, b);```