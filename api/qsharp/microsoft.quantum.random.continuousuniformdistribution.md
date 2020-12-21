---
uid: Microsoft.Quantum.Random.ContinuousUniformDistribution
title: ContinuousUniformDistribution function
ms.date: 12/21/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Random
qsharp.name: ContinuousUniformDistribution
qsharp.summary: Returns a uniform distribution over a given inclusive interval.
---

# ContinuousUniformDistribution function

Namespace: [Microsoft.Quantum.Random](xref:Microsoft.Quantum.Random)

Package: [Microsoft.Quantum.QSharp.Core](https://nuget.org/packages/Microsoft.Quantum.QSharp.Core)


Returns a uniform distribution over a given inclusive interval.

```qsharp
function ContinuousUniformDistribution (min : Double, max : Double) : Microsoft.Quantum.Random.ContinuousDistribution
```


## Input

### min : [Double](xref:microsoft.quantum.lang-ref.double)

The smallest real number to be drawn.


### max : [Double](xref:microsoft.quantum.lang-ref.double)

The largest real number to be drawn.



## Output : [ContinuousDistribution](xref:Microsoft.Quantum.Random.ContinuousDistribution)

A distribution whose random variates are real numbers in the inclusiveinterval from `min` to `max` with uniform probability.

## Remarks

Fails if `max <= min`.

## See Also

- [Microsoft.Quantum.DrawRandomDouble](xref:Microsoft.Quantum.DrawRandomDouble)