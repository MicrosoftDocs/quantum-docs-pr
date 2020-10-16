---
uid: Microsoft.Quantum.AmplitudeAmplification.StandardReflectionPhases
title: StandardReflectionPhases function
ms.date: 10/16/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.AmplitudeAmplification
qsharp.name: StandardReflectionPhases
qsharp.summary: >-
  Computes partial reflection phases for standard amplitude
  amplification.
---

# StandardReflectionPhases function

Namespace: [Microsoft.Quantum.AmplitudeAmplification](xref:Microsoft.Quantum.AmplitudeAmplification)

Package: [](https://nuget.org/packages/)


Computes partial reflection phases for standard amplitudeamplification.

```Q#
StandardReflectionPhases (nIterations : Int) : Microsoft.Quantum.AmplitudeAmplification.ReflectionPhases
```


## Input

### nIterations : Int

Number of amplitude amplification iterations to generate partialreflection phases for.



## Output

An operation that implements phases specified as partial reflections

## Remarks

All phases are $\pi$, except for the first reflection about the startstate and the last reflection about the target state, which are $0$.