---
uid: Microsoft.Quantum.Logical.LessThanOrEqualD
title: LessThanOrEqualD function
ms.date: 10/26/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Logical
qsharp.name: LessThanOrEqualD
qsharp.summary: >-
  Returns true if and only if a number is less than or equal to another
  number.
---

# LessThanOrEqualD function

Namespace: [Microsoft.Quantum.Logical](xref:Microsoft.Quantum.Logical)

Package: [](https://nuget.org/packages/)


Returns true if and only if a number is less than or equal to anothernumber.

```qsharp
function LessThanOrEqualD (a : Double, b : Double) : Bool
```


## Input

### a : [Double](xref:microsoft.quantum.lang-ref.double)

The first value to be compared.


### b : [Double](xref:microsoft.quantum.lang-ref.double)

The second value to be compared.



## Output : [Bool](xref:microsoft.quantum.lang-ref.bool)

`true` if and only if `a` is less than or equal to `b`.

## Remarks

The following are equivalent:```Q#let cond = a <= b;let cond = LessThanOrEqualD(a, b);```