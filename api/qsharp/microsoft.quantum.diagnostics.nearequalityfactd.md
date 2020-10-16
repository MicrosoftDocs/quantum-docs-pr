---
uid: Microsoft.Quantum.Diagnostics.NearEqualityFactD
title: NearEqualityFactD function
ms.date: 10/16/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Diagnostics
qsharp.name: NearEqualityFactD
qsharp.summary: >-
  Asserts that a classical floating point value has the expected value up to a
  small tolerance of 1e-10.
---

# NearEqualityFactD function

Namespace: [Microsoft.Quantum.Diagnostics](xref:Microsoft.Quantum.Diagnostics)

Package: [](https://nuget.org/packages/)


Asserts that a classical floating point value has the expected value up to asmall tolerance of 1e-10.

```Q#
NearEqualityFactD (actual : Double, expected : Double) : Unit
```


## Input

### actual : Double

The number to be checked.


### expected : Double

The expected value.



## Remarks

This is equivalent to <xref:microsoft.quantum.diagnostics.equalitywithintolerancefact> withhardcoded tolerance of $10^{-10}$.