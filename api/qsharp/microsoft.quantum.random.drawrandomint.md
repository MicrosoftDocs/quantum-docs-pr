---
uid: Microsoft.Quantum.Random.DrawRandomInt
title: DrawRandomInt operation
ms.date: 10/16/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Random
qsharp.name: DrawRandomInt
qsharp.summary: Draws a random integer in a given inclusive range.
---

# DrawRandomInt operation

Namespace: [Microsoft.Quantum.Random](xref:Microsoft.Quantum.Random)

Package: [](https://nuget.org/packages/)


Draws a random integer in a given inclusive range.

```Q#
DrawRandomInt (min : Int, max : Int) : Int
```


## Input

### min : Int

The smallest integer to be drawn.


### max : Int

The largest integer to be drawn.



## Output

An integer in the inclusive range from `min` to `max` with uniformprobability.

## Remarks

Fails if `max <= min`.

## See Also

- [Microsoft.Quantum.DiscreteUniformDistribution](xref:Microsoft.Quantum.DiscreteUniformDistribution)