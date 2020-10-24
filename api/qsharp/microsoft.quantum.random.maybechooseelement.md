---
uid: Microsoft.Quantum.Random.MaybeChooseElement
title: MaybeChooseElement operation
ms.date: 10/24/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Random
qsharp.name: MaybeChooseElement
qsharp.summary: >-
  Given an array of data and an a distribution over its indices,
  attempts to choose an element at random.
---

# MaybeChooseElement operation

Namespace: [Microsoft.Quantum.Random](xref:Microsoft.Quantum.Random)

Package: [](https://nuget.org/packages/)


Given an array of data and an a distribution over its indices,attempts to choose an element at random.

```qsharp
operation MaybeChooseElement<'T> (data : 'T[], indexDistribution : Microsoft.Quantum.Random.DiscreteDistribution) : (Bool, 'T)
```


## Input

### data : 'T[]

The array from which an element should be chosen.


### indexDistribution : [DiscreteDistribution](xref:Microsoft.Quantum.Random.DiscreteDistribution)

A distribution over the indices of `data`.



## Output : ([Bool](xref:microsoft.quantum.lang-ref.bool),'T)



## Type Parameters

### 'T

