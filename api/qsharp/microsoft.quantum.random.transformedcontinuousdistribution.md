---
uid: Microsoft.Quantum.Random.TransformedContinuousDistribution
title: TransformedContinuousDistribution function
ms.date: 11/23/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Random
qsharp.name: TransformedContinuousDistribution
qsharp.summary: >-
  Given a continuous distribution, returns a new distribution that
  transforms the original by a given function.
---

# TransformedContinuousDistribution function

Namespace: [Microsoft.Quantum.Random](xref:Microsoft.Quantum.Random)

Package: [Microsoft.Quantum.QSharp.Core](https://nuget.org/packages/Microsoft.Quantum.QSharp.Core)


Given a continuous distribution, returns a new distribution thattransforms the original by a given function.

```qsharp
function TransformedContinuousDistribution (transform : (Double -> Double), distribution : Microsoft.Quantum.Random.ContinuousDistribution) : Microsoft.Quantum.Random.ContinuousDistribution
```


## Input

### transform : [Double](xref:microsoft.quantum.lang-ref.double) -> [Double](xref:microsoft.quantum.lang-ref.double)

A function that transforms variates of the original distribution to thetransformed distribution.


### distribution : [ContinuousDistribution](xref:Microsoft.Quantum.Random.ContinuousDistribution)

The original distribution to be transformed.



## Output : [ContinuousDistribution](xref:Microsoft.Quantum.Random.ContinuousDistribution)

A new distribution related to `distribution` by the transformation givenby `transform`.