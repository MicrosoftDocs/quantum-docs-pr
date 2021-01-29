---
uid: Microsoft.Quantum.Diagnostics.NearEqualityFactD
title: NearEqualityFactD function
ms.date: 1/29/2021 12:00:00 AM
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

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Asserts that a classical floating point value has the expected value up to asmall tolerance of 1e-10.

```qsharp
function NearEqualityFactD (actual : Double, expected : Double) : Unit
```


## Input

### actual : [Double](xref:microsoft.quantum.lang-ref.double)

The number to be checked.


### expected : [Double](xref:microsoft.quantum.lang-ref.double)

The expected value.



## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)



## Remarks

This is equivalent to <xref:microsoft.quantum.diagnostics.equalitywithintolerancefact> withhardcoded tolerance of $10^{-10}$.