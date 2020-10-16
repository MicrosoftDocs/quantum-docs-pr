---
uid: Microsoft.Quantum.Logical.EqualD
title: EqualD function
ms.date: 10/16/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Logical
qsharp.name: EqualD
qsharp.summary: Returns true if and only if two inputs are equal.
---

# EqualD function

Namespace: [Microsoft.Quantum.Logical](xref:Microsoft.Quantum.Logical)

Package: [](https://nuget.org/packages/)


Returns true if and only if two inputs are equal.

```Q#
EqualD (a : Double, b : Double) : Bool
```


## Input

### a : Double

The first value to be compared.


### b : Double

The second value to be compared.



## Output

`true` if and only if `a` is equal to `b`.

## Remarks

The following are equivalent:```Q#let cond = a == b;let cond = EqualD(a, b);```