---
uid: Microsoft.Quantum.Logical.NotEqualD
title: NotEqualD function
ms.date: 10/16/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Logical
qsharp.name: NotEqualD
qsharp.summary: Returns true if and only if two inputs are not equal.
---

# NotEqualD function

Namespace: [Microsoft.Quantum.Logical](xref:Microsoft.Quantum.Logical)

Package: [](https://nuget.org/packages/)


Returns true if and only if two inputs are not equal.

```Q#
NotEqualD (a : Double, b : Double) : Bool
```


## Input

### a : Double

The first value to be compared.


### b : Double

The second value to be compared.



## Output

`true` if and only if `a` is not equal to `b`.

## Remarks

The following are equivalent:```Q#let cond = a != b;let cond = NotEqualD(a, b);```