---
uid: Microsoft.Quantum.Logical.NotEqualI
title: NotEqualI function
ms.date: 10/16/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Logical
qsharp.name: NotEqualI
qsharp.summary: Returns true if and only if two inputs are not equal.
---

# NotEqualI function

Namespace: [Microsoft.Quantum.Logical](xref:Microsoft.Quantum.Logical)

Package: [](https://nuget.org/packages/)


Returns true if and only if two inputs are not equal.

```Q#
NotEqualI (a : Int, b : Int) : Bool
```


## Input

### a : Int

The first value to be compared.


### b : Int

The second value to be compared.



## Output

`true` if and only if `a` is not equal to `b`.

## Remarks

The following are equivalent:```Q#let cond = a != b;let cond = NotEqualI(a, b);```