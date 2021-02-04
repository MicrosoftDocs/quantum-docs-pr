---
uid: Microsoft.Quantum.Random.TransformedContinuousDistribution
title: TransformedContinuousDistribution function
ms.date: 2/4/2021 12:00:00 AM
ms.topic: managed-reference
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Random
qsharp.name: TransformedContinuousDistribution
qsharp.summary: >-
  Given a continuous distribution, returns a new distribution that
  transforms the original by a given function.
---

# TransformedContinuousDistribution function

Namespace: [Microsoft.Quantum.Random](xref:Microsoft.Quantum.Random)

Package: [Microsoft.Quantum.QSharp.Foundation](https://nuget.org/packages/Microsoft.Quantum.QSharp.Foundation)


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

## Example

The following two distributions are identical:```qsharplet dist1 = ContinuousUniformDistribution(1.0, 2.0);let dist2 = TransformedContinuousDistribution(    PlusD(1.0, _),    ContinuousUniformDistribution(0.0, 1.0));```