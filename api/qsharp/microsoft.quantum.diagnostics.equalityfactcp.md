---
uid: Microsoft.Quantum.Diagnostics.EqualityFactCP
title: EqualityFactCP function
ms.date: 10/16/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Diagnostics
qsharp.name: EqualityFactCP
qsharp.summary: Asserts that a complex number has the expected value.
---

# EqualityFactCP function

Namespace: [Microsoft.Quantum.Diagnostics](xref:Microsoft.Quantum.Diagnostics)

Package: [](https://nuget.org/packages/)


Asserts that a complex number has the expected value.

```Q#
EqualityFactCP (actual : Microsoft.Quantum.Math.ComplexPolar, expected : Microsoft.Quantum.Math.ComplexPolar, message : String) : Unit
```


## Input

### actual : [ComplexPolar](xref:Microsoft.Quantum.Math.ComplexPolar)

The value to be checked.


### expected : [ComplexPolar](xref:Microsoft.Quantum.Math.ComplexPolar)

The expected value.


### message : String

Failure message string to be used when the assertion is triggered.

