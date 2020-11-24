---
uid: Microsoft.Quantum.Random.DrawCategorical
title: DrawCategorical operation
ms.date: 11/24/2020 12:00:00 AM
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

Package: [Microsoft.Quantum.QSharp.Core](https://nuget.org/packages/Microsoft.Quantum.QSharp.Core)


Draws a random sample from a categorical distribution specified by alist of probablities.

```qsharp
operation DrawCategorical (probs : Double[]) : Int
```


## Description

The probability of selecting a specific index is proportional to the valueof the array element at that index.Array elements that are equal to zero are ignored and their indices are neverreturned. If any array element is less than zero,or if no array element is greater than zero, then the operation fails.

## Input

### probs : [Double](xref:microsoft.quantum.lang-ref.double)[]

An array of floating-point numbers proportional to the probability ofselecting each index.



## Output : [Int](xref:microsoft.quantum.lang-ref.int)

An integer $i$ with probability $\Pr(i) = p_i / \sum_i p_i$, where $p_i$is the $i$th element of `probs`.

## See Also

- [Microsoft.Quantum.Random.CategoricalDistribution](xref:Microsoft.Quantum.Random.CategoricalDistribution)