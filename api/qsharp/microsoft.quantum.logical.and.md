---
uid: Microsoft.Quantum.Logical.And
title: And function
ms.date: 10/16/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Logical
qsharp.name: And
qsharp.summary: Returns the Boolean conjunction of two values.
---

# And function

Namespace: [Microsoft.Quantum.Logical](xref:Microsoft.Quantum.Logical)

Package: [](https://nuget.org/packages/)


Returns the Boolean conjunction of two values.

```Q#
And (a : Bool, b : Bool) : Bool
```


## Input

### a : Bool

The first value to be considered.


### b : Bool

The second value to be considered.



## Output

`true` if and only if `a` and `b` are both `true`.

## Remarks

Unlike the `and` operator, this function does not short-circuit, such thatboth inputs are fully evaluated.Up to short-circuiting behavior, the following are equivalent:```Q#let x = a and b;let x = And(a, b);```