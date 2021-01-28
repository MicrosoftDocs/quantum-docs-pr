---
uid: Microsoft.Quantum.AmplitudeAmplification.StandardReflectionPhases
title: StandardReflectionPhases function
ms.date: 1/27/2021 12:00:00 AM
ms.topic: managed-reference
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.AmplitudeAmplification
qsharp.name: StandardReflectionPhases
qsharp.summary: >-
  Computes partial reflection phases for standard amplitude
  amplification.
---

# StandardReflectionPhases function

Namespace: [Microsoft.Quantum.AmplitudeAmplification](xref:Microsoft.Quantum.AmplitudeAmplification)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Computes partial reflection phases for standard amplitudeamplification.

```qsharp
function StandardReflectionPhases (nIterations : Int) : Microsoft.Quantum.AmplitudeAmplification.ReflectionPhases
```


## Input

### nIterations : [Int](xref:microsoft.quantum.lang-ref.int)

Number of amplitude amplification iterations to generate partialreflection phases for.



## Output : [ReflectionPhases](xref:Microsoft.Quantum.AmplitudeAmplification.ReflectionPhases)

An operation that implements phases specified as partial reflections

## Remarks

All phases are $\pi$, except for the first reflection about the startstate and the last reflection about the target state, which are $0$.