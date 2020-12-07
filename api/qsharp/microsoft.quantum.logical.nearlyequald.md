---
uid: Microsoft.Quantum.Logical.NearlyEqualD
title: NearlyEqualD function
ms.date: 12/7/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Logical
qsharp.name: NearlyEqualD
qsharp.summary: >-
  Returns true if and only if two inputs are nearly equal (that is, within
  a tolerance of 1e-12).
---

# NearlyEqualD function

Namespace: [Microsoft.Quantum.Logical](xref:Microsoft.Quantum.Logical)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Returns true if and only if two inputs are nearly equal (that is, withina tolerance of 1e-12).

```qsharp
function NearlyEqualD (a : Double, b : Double) : Bool
```


## Input

### a : [Double](xref:microsoft.quantum.lang-ref.double)

The first value to be compared.


### b : [Double](xref:microsoft.quantum.lang-ref.double)

The second value to be compared.



## Output : [Bool](xref:microsoft.quantum.lang-ref.bool)

`true` if and only if `a` is nearly equal to `b`.

## Remarks

The following are equivalent:```Q#let cond = Microsoft.Quantum.Math.AbsD(a - b) < 1e-12;let cond = NearlyEqualD(a, b);```