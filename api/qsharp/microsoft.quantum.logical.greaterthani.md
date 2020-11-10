---
uid: Microsoft.Quantum.Logical.GreaterThanI
title: GreaterThanI function
ms.date: 11/10/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Logical
qsharp.name: GreaterThanI
qsharp.summary: Returns true if and only if a number is greater than another number.
---

# GreaterThanI function

Namespace: [Microsoft.Quantum.Logical](xref:Microsoft.Quantum.Logical)

Package: [](https://nuget.org/packages/)


Returns true if and only if a number is greater than another number.

```qsharp
function GreaterThanI (a : Int, b : Int) : Bool
```


## Input

### a : [Int](xref:microsoft.quantum.lang-ref.int)

The first value to be compared.


### b : [Int](xref:microsoft.quantum.lang-ref.int)

The second value to be compared.



## Output : [Bool](xref:microsoft.quantum.lang-ref.bool)

`true` if and only if `a` is strictly greater than `b`.

## Remarks

The following are equivalent:```Q#let cond = a > b;let cond = GreaterThanI(a, b);```