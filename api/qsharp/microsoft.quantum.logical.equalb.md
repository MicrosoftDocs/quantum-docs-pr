---
uid: Microsoft.Quantum.Logical.EqualB
title: EqualB function
ms.date: 10/16/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Logical
qsharp.name: EqualB
qsharp.summary: Returns true if and only if two inputs are equal.
---

# EqualB function

Namespace: [Microsoft.Quantum.Logical](xref:Microsoft.Quantum.Logical)

Package: [](https://nuget.org/packages/)


Returns true if and only if two inputs are equal.

```Q#
EqualB (a : Bool, b : Bool) : Bool
```


## Input

### a : Bool

The first value to be compared.


### b : Bool

The second value to be compared.



## Output

`true` if and only if `a` is equal to `b`.

## Remarks

The following are equivalent:```Q#let cond = a == b;let cond = EqualB(a, b);```