---
uid: Microsoft.Quantum.Logical.NotEqualR
title: NotEqualR function
ms.date: 10/26/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Logical
qsharp.name: NotEqualR
qsharp.summary: Returns true if and only if two inputs are not equal.
---

# NotEqualR function

Namespace: [Microsoft.Quantum.Logical](xref:Microsoft.Quantum.Logical)

Package: [](https://nuget.org/packages/)


Returns true if and only if two inputs are not equal.

```qsharp
function NotEqualR (a : Result, b : Result) : Bool
```


## Input

### a : __invalid<Result>__

The first value to be compared.


### b : __invalid<Result>__

The second value to be compared.



## Output : [Bool](xref:microsoft.quantum.lang-ref.bool)

`true` if and only if `a` is not equal to `b`.

## Remarks

The following are equivalent:```Q#let cond = a != b;let cond = NotEqualR(a, b);```