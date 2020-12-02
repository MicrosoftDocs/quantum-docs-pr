---
uid: Microsoft.Quantum.Diagnostics.EqualityWithinToleranceFact
title: EqualityWithinToleranceFact function
ms.date: 12/2/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Diagnostics
qsharp.name: EqualityWithinToleranceFact
qsharp.summary: >-
  Represents the claim that a classical floating point value has the
  expected value up to a given
  absolute tolerance.
---

# EqualityWithinToleranceFact function

Namespace: [Microsoft.Quantum.Diagnostics](xref:Microsoft.Quantum.Diagnostics)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Represents the claim that a classical floating point value has theexpected value up to a givenabsolute tolerance.

```qsharp
function EqualityWithinToleranceFact (actual : Double, expected : Double, tolerance : Double) : Unit
```


## Input

### actual : [Double](xref:microsoft.quantum.lang-ref.double)

The number to be checked.


### expected : [Double](xref:microsoft.quantum.lang-ref.double)

The expected value.


### tolerance : [Double](xref:microsoft.quantum.lang-ref.double)

Absolute tolerance on the difference between actual and expected.



## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)

