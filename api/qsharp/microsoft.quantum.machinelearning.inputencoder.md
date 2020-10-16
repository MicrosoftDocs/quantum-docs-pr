---
uid: Microsoft.Quantum.MachineLearning.InputEncoder
title: InputEncoder function
ms.date: 10/16/2020 12:00:00 AM
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

Package: [](https://nuget.org/packages/)


Given a set of coefficients and a tolerance, returns a state preparationoperation that prepares each coefficient as the corresponding amplitudeof a computational basis state.

```Q#
InputEncoder (coefficients : Double[]) : Microsoft.Quantum.MachineLearning.StateGenerator
```


## Input

### coefficients : Double[]

The coefficients to be encoded into an input state.



## Output

A state preparation operation that prepares the given coefficientsas an input state on a given register.