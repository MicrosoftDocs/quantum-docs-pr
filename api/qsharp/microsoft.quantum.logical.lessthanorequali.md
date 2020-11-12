---
uid: Microsoft.Quantum.Logical.LessThanOrEqualI
title: LessThanOrEqualI function
ms.date: 11/12/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Logical
qsharp.name: LessThanOrEqualI
qsharp.summary: >-
  Returns true if and only if a number is less than or equal to another
  number.
---

# LessThanOrEqualI function

Namespace: [Microsoft.Quantum.Logical](xref:Microsoft.Quantum.Logical)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Returns true if and only if a number is less than or equal to anothernumber.

```qsharp
function LessThanOrEqualI (a : Int, b : Int) : Bool
```


## Input

### a : [Int](xref:microsoft.quantum.lang-ref.int)

The first value to be compared.


### b : [Int](xref:microsoft.quantum.lang-ref.int)

The second value to be compared.



## Output : [Bool](xref:microsoft.quantum.lang-ref.bool)

`true` if and only if `a` is less than or equal to `b`.

## Remarks

The following are equivalent:```Q#let cond = a <= b;let cond = LessThanOrEqualI(a, b);```