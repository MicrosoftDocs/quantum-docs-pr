---
uid: Microsoft.Quantum.Intrinsic.Random
title: Random operation
ms.date: 2/13/2021 12:00:00 AM
ms.topic: managed-reference
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Intrinsic
qsharp.name: Random
qsharp.summary: >-
  > [!WARNING]

  > Random has been deprecated. Please use <xref:Microsoft.Quantum.Random.DrawCategorical> instead.


  The random operation takes an array of doubles as input, and returns
  a randomly-selected index into the array as an `Int`.
  The probability of selecting a specific index is proportional to the value
  of the array element at that index.
  Array elements that are equal to zero are ignored and their indices are never
  returned. If any array element is less than zero,
  or if no array element is greater than zero, then the operation fails.
---

# Random operation

Namespace: [Microsoft.Quantum.Intrinsic](xref:Microsoft.Quantum.Intrinsic)

Package: [Microsoft.Quantum.QSharp.Foundation](https://nuget.org/packages/Microsoft.Quantum.QSharp.Foundation)


> [!WARNING]
> Random has been deprecated. Please use <xref:Microsoft.Quantum.Random.DrawCategorical> instead.

The random operation takes an array of doubles as input, and returnsa randomly-selected index into the array as an `Int`.The probability of selecting a specific index is proportional to the valueof the array element at that index.Array elements that are equal to zero are ignored and their indices are neverreturned. If any array element is less than zero,or if no array element is greater than zero, then the operation fails.

```qsharp
operation Random (probs : Double[]) : Int
```


## Input

### probs : [Double](xref:microsoft.quantum.lang-ref.double)[]

An array of floating-point numbers proportional to the probability ofselecting each index.



## Output : [Int](xref:microsoft.quantum.lang-ref.int)

An integer $i$ with probability $\Pr(i) = p_i / \sum_i p_i$, where $p_i$is the $i$th element of `probs`.