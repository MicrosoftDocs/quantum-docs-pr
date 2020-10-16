---
uid: Microsoft.Quantum.Logical.Not
title: Not function
ms.date: 10/16/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Logical
qsharp.name: Not
qsharp.summary: Returns the Boolean negation of a value.
---

# Not function

Namespace: [Microsoft.Quantum.Logical](xref:Microsoft.Quantum.Logical)

Package: [](https://nuget.org/packages/)


Returns the Boolean negation of a value.

```Q#
Not (value : Bool) : Bool
```


## Input

### value : Bool

The value to be negated.



## Output

`true` if and only if `value` is `false`.

## Remarks

The following are equivalent:```Q#let x = not value;let x = Not(value);```