---
uid: Microsoft.Quantum.Random.CategoricalDistribution
title: CategoricalDistribution function
ms.date: 1/23/2021 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Random
qsharp.name: CategoricalDistribution
qsharp.summary: >-
  Returns a discrete categorical distribution, in which the probability
  for each of a finite list of given outcomes is explicitly specified.
---

# CategoricalDistribution function

Namespace: [Microsoft.Quantum.Random](xref:Microsoft.Quantum.Random)

Package: [Microsoft.Quantum.QSharp.Core](https://nuget.org/packages/Microsoft.Quantum.QSharp.Core)


Returns a discrete categorical distribution, in which the probabilityfor each of a finite list of given outcomes is explicitly specified.

```qsharp
function CategoricalDistribution (probs : Double[]) : Microsoft.Quantum.Random.DiscreteDistribution
```


## Input

### probs : [Double](xref:microsoft.quantum.lang-ref.double)[]

The probabilities for each outcome from the categorical distribution.These probabilities may not be normalized, but must all be non-negative.



## Output : [DiscreteDistribution](xref:Microsoft.Quantum.Random.DiscreteDistribution)

The index `i` with probability `probs[i] / sum`, where `sum` is the sumof `probs` given by `Fold(PlusD, 0.0, probs)`.

## Example

The following Q# code will display 0 with probability 30% and 1 withprobability 70%:```Q#let dist = CategoricalDistribution([0.3, 0.7]);Message($"Got sample: {dist::Sample()}");```