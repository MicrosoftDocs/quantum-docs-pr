---
uid: Microsoft.Quantum.Logical.Or
title: Or function
ms.date: 10/16/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Logical
qsharp.name: Or
qsharp.summary: Returns the Boolean disjunction of two values.
---

# Or function

Namespace: [Microsoft.Quantum.Logical](xref:Microsoft.Quantum.Logical)

Package: [](https://nuget.org/packages/)


Returns the Boolean disjunction of two values.

```Q#
Or (a : Bool, b : Bool) : Bool
```


## Input

### a : Bool

The first value to be considered.


### b : Bool

The second value to be considered.



## Output

`true` if and only if either `a` or `b` are `true`.

## Remarks

Unlike the `or` operator, this function does not short-circuit, such thatboth inputs are fully evaluated.Up to short-circuiting behavior, the following are equivalent:```Q#let x = a or b;let x = Or(a, b);```