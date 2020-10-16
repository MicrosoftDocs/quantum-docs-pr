---
uid: Microsoft.Quantum.Random.TransformedContinuousDistribution
title: TransformedContinuousDistribution function
ms.date: 10/16/2020 12:00:00 AM
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

Package: [](https://nuget.org/packages/)


Given a continuous distribution, returns a new distribution thattransforms the original by a given function.

```Q#
TransformedContinuousDistribution (transform : (Double -> Double), distribution : Microsoft.Quantum.Random.ContinuousDistribution) : Microsoft.Quantum.Random.ContinuousDistribution
```


## Input

### transform : Double -> Double

A function that transforms variates of the original distribution to thetransformed distribution.


### distribution : [ContinuousDistribution](xref:Microsoft.Quantum.Random.ContinuousDistribution)

The original distribution to be transformed.



## Output

A new distribution related to `distribution` by the transformation givenby `transform`.