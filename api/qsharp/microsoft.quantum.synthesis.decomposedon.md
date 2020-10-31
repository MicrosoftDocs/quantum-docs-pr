---
uid: Microsoft.Quantum.Synthesis.DecomposedOn
title: DecomposedOn function
ms.date: 10/31/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Synthesis
qsharp.name: DecomposedOn
qsharp.summary: Decomposes a permutation on a variable
---

# DecomposedOn function

Namespace: [Microsoft.Quantum.Synthesis](xref:Microsoft.Quantum.Synthesis)

Package: [](https://nuget.org/packages/)


Decomposes a permutation on a variable

```qsharp
function DecomposedOn (perm : Int[], index : Int) : ((Int[], Int[]), Int[])
```


## Description

Given a permutation $\pi$ (`perm`) and an index $i$ (`index`), this methodreturns three permutations $((\pi_l, \pi_r), \pi')$ such that the imagesof $\pi_l$ and $\pi_r$ do not change bits in their elements at indexes otherthan $i$ and images of $\pi'$ do not change bit $i$ in their elements.

## Input

### perm : [Int](xref:microsoft.quantum.lang-ref.int)[]




### index : [Int](xref:microsoft.quantum.lang-ref.int)





## Output : (([Int](xref:microsoft.quantum.lang-ref.int)[],[Int](xref:microsoft.quantum.lang-ref.int)[]),[Int](xref:microsoft.quantum.lang-ref.int)[])

