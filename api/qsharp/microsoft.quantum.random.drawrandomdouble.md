---
uid: Microsoft.Quantum.Random.DrawRandomDouble
title: DrawRandomDouble operation
ms.date: 10/28/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Random
qsharp.name: DrawRandomDouble
qsharp.summary: Draws a random real number in a given inclusive interval.
---

# DrawRandomDouble operation

Namespace: [Microsoft.Quantum.Random](xref:Microsoft.Quantum.Random)

Package: [](https://nuget.org/packages/)


Draws a random real number in a given inclusive interval.

```qsharp
operation DrawRandomDouble (min : Double, max : Double) : Double
```


## Input

### min : [Double](xref:microsoft.quantum.lang-ref.double)

The smallest real number to be drawn.


### max : [Double](xref:microsoft.quantum.lang-ref.double)

The largest real number to be drawn.



## Output : [Double](xref:microsoft.quantum.lang-ref.double)

A random real number in the inclusive interval from `min` to `max` withuniform probability.

## Remarks

Fails if `max <= min`.

## See Also

- [Microsoft.Quantum.ContinuousUniformDistribution](xref:Microsoft.Quantum.ContinuousUniformDistribution)