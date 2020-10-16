---
uid: Microsoft.Quantum.Diagnostics.EqualityWithinToleranceFact
title: EqualityWithinToleranceFact function
ms.date: 10/16/2020 12:00:00 AM
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

Package: [](https://nuget.org/packages/)


Represents the claim that a classical floating point value has theexpected value up to a givenabsolute tolerance.

```Q#
EqualityWithinToleranceFact (actual : Double, expected : Double, tolerance : Double) : Unit
```


## Input

### actual : Double

The number to be checked.


### expected : Double

The expected value.


### tolerance : Double

Absolute tolerance on the difference between actual and expected.

