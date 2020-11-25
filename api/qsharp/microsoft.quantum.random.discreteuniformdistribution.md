---
uid: Microsoft.Quantum.Random.DiscreteUniformDistribution
title: DiscreteUniformDistribution function
ms.date: 11/25/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Random
qsharp.name: DiscreteUniformDistribution
qsharp.summary: Returns a uniform distribution over a given inclusive range.
---

# DiscreteUniformDistribution function

Namespace: [Microsoft.Quantum.Random](xref:Microsoft.Quantum.Random)

Package: [Microsoft.Quantum.QSharp.Core](https://nuget.org/packages/Microsoft.Quantum.QSharp.Core)


Returns a uniform distribution over a given inclusive range.

```qsharp
function DiscreteUniformDistribution (min : Int, max : Int) : Microsoft.Quantum.Random.DiscreteDistribution
```


## Input

### min : [Int](xref:microsoft.quantum.user-guide.language.types)

The smallest integer to be drawn.


### max : [Int](xref:microsoft.quantum.user-guide.language.types)

The largest integer to be drawn.



## Output : [DiscreteDistribution](xref:Microsoft.Quantum.Random.DiscreteDistribution)

A distribution whose random variates are integers in the inclusiverange from `min` to `max` with uniform probability.

## Remarks

Fails if `max <= min`.

## See Also

- [Microsoft.Quantum.DrawRandomDouble](xref:Microsoft.Quantum.DrawRandomDouble)