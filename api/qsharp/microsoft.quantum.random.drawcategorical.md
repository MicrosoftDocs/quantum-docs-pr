---
uid: Microsoft.Quantum.Random.DrawCategorical
title: DrawCategorical operation
ms.date: 10/26/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Random
qsharp.name: DrawCategorical
qsharp.summary: >-
  Draws a random sample from a categorical distribution specified by a
  list of probablities.
---

# DrawCategorical operation

Namespace: [Microsoft.Quantum.Random](xref:Microsoft.Quantum.Random)

Package: [](https://nuget.org/packages/)


Draws a random sample from a categorical distribution specified by a

```qsharp
operation DrawCategorical (probs : Double[]) : Int
```


## Description

The probability of selecting a specific index is proportional to the value

## Input

### probs : [Double](xref:microsoft.quantum.lang-ref.double)[]

An array of floating-point numbers proportional to the probability of



## Output : [Int](xref:microsoft.quantum.lang-ref.int)

An integer $i$ with probability $\Pr(i) = p_i / \sum_i p_i$, where $p_i$

## See Also

- [Microsoft.Quantum.Random.CategoricalDistribution](xref:Microsoft.Quantum.Random.CategoricalDistribution)