---
uid: Microsoft.Quantum.Logical.LessThanOrEqualD
title: LessThanOrEqualD function
ms.date: 2/4/2021 12:00:00 AM
ms.topic: managed-reference
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Logical
qsharp.name: LessThanOrEqualD
qsharp.summary: >-
  Returns true if and only if a number is less than or equal to another
  number.
---

# LessThanOrEqualD function

Namespace: [Microsoft.Quantum.Logical](xref:Microsoft.Quantum.Logical)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


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

The following are equivalent:```qsharplet cond = a <= b;let cond = LessThanOrEqualD(a, b);```