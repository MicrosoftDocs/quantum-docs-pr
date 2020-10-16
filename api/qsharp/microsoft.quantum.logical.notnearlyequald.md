---
uid: Microsoft.Quantum.Logical.NotNearlyEqualD
title: NotNearlyEqualD function
ms.date: 10/16/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Logical
qsharp.name: NotNearlyEqualD
qsharp.summary: >-
  Returns true if and only if two inputs are not nearly equal (that is,
  are not within a tolerance of 1e-12).
---

# NotNearlyEqualD function

Namespace: [Microsoft.Quantum.Logical](xref:Microsoft.Quantum.Logical)

Package: [](https://nuget.org/packages/)


Returns true if and only if two inputs are not nearly equal (that is,are not within a tolerance of 1e-12).

```Q#
NotNearlyEqualD (a : Double, b : Double) : Bool
```


## Input

### a : Double

The first value to be compared.


### b : Double

The second value to be compared.



## Output

`true` if and only if `a` is not nearly equal to `b`.

## Remarks

The following are equivalent:```Q#let cond = Microsoft.Quantum.Math.AbsD(a - b) >= 1e-12;let cond = NotNearlyEqualD(a, b);```