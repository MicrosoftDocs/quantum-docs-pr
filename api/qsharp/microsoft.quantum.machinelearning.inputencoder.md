---
uid: Microsoft.Quantum.MachineLearning.InputEncoder
title: InputEncoder function
ms.date: 1/27/2021 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.MachineLearning
qsharp.name: InputEncoder
qsharp.summary: >-
  Given a set of coefficients and a tolerance, returns a state preparation
  operation that prepares each coefficient as the corresponding amplitude
  of a computational basis state.
---

# InputEncoder function

Namespace: [Microsoft.Quantum.MachineLearning](xref:Microsoft.Quantum.MachineLearning)

Package: [Microsoft.Quantum.MachineLearning](https://nuget.org/packages/Microsoft.Quantum.MachineLearning)


Given a set of coefficients and a tolerance, returns a state preparationoperation that prepares each coefficient as the corresponding amplitudeof a computational basis state.

```qsharp
function InputEncoder (coefficients : Double[]) : Microsoft.Quantum.MachineLearning.StateGenerator
```


## Input

### coefficients : [Double](xref:microsoft.quantum.lang-ref.double)[]

The coefficients to be encoded into an input state.



## Output : [StateGenerator](xref:Microsoft.Quantum.MachineLearning.StateGenerator)

A state preparation operation that prepares the given coefficientsas an input state on a given register.