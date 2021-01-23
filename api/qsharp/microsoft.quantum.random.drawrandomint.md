---
uid: Microsoft.Quantum.Random.DrawRandomInt
title: DrawRandomInt operation
ms.date: 1/23/2021 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Random
qsharp.name: DrawRandomInt
qsharp.summary: Draws a random integer in a given inclusive range.
---

# DrawRandomInt operation

Namespace: [Microsoft.Quantum.Random](xref:Microsoft.Quantum.Random)

Package: [Microsoft.Quantum.QSharp.Core](https://nuget.org/packages/Microsoft.Quantum.QSharp.Core)


Draws a random integer in a given inclusive range.

```qsharp
operation DrawRandomInt (min : Int, max : Int) : Int
```


## Input

### min : [Int](xref:microsoft.quantum.lang-ref.int)

The smallest integer to be drawn.


### max : [Int](xref:microsoft.quantum.lang-ref.int)

The largest integer to be drawn.



## Output : [Int](xref:microsoft.quantum.lang-ref.int)

An integer in the inclusive range from `min` to `max` with uniformprobability.

## Example

The following Q# snippet randomly rolls a six-sided die:```Q#let roll = DrawRandomInt(1, 6);```

## Remarks

Fails if `max <= min`.

## See Also

- [Microsoft.Quantum.DiscreteUniformDistribution](xref:Microsoft.Quantum.DiscreteUniformDistribution)