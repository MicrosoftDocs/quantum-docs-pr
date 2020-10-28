---
uid: Microsoft.Quantum.Logical.Not
title: Not function
ms.date: 10/28/2020 12:00:00 AM
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

```qsharp
function Not (value : Bool) : Bool
```


## Input

### value : [Bool](xref:microsoft.quantum.lang-ref.bool)

The value to be negated.



## Output : [Bool](xref:microsoft.quantum.lang-ref.bool)

`true` if and only if `value` is `false`.

## Remarks

The following are equivalent:```Q#let x = not value;let x = Not(value);```