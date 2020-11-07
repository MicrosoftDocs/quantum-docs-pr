---
uid: Microsoft.Quantum.MachineLearning.ApproximateInputEncoder
title: ApproximateInputEncoder function
ms.date: 11/7/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.MachineLearning
qsharp.name: ApproximateInputEncoder
qsharp.summary: >-
  Given a set of coefficients and a tolerance, returns a state preparation
  operation that prepares each coefficient as the corresponding amplitude
  of a computational basis state, up to the given tolerance.
---

# ApproximateInputEncoder function

Namespace: [Microsoft.Quantum.MachineLearning](xref:Microsoft.Quantum.MachineLearning)

Package: [](https://nuget.org/packages/)


Given a set of coefficients and a tolerance, returns a state preparationoperation that prepares each coefficient as the corresponding amplitudeof a computational basis state, up to the given tolerance.

```qsharp
function ApproximateInputEncoder (tolerance : Double, coefficients : Double[]) : Microsoft.Quantum.MachineLearning.StateGenerator
```


## Input

### tolerance : [Double](xref:microsoft.quantum.lang-ref.double)

The approximation tolerance to be used in encoding the givencoefficients into an input state.


### coefficients : [Double](xref:microsoft.quantum.lang-ref.double)[]

The coefficients to be encoded into an input state.



## Output : [StateGenerator](xref:Microsoft.Quantum.MachineLearning.StateGenerator)

A state preparation operation that prepares the given coefficientsas an input state on a given register.