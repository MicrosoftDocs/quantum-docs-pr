---
uid: Microsoft.Quantum.Synthesis.DecomposedOn
title: DecomposedOn function
ms.date: 1/28/2021 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Synthesis
qsharp.name: DecomposedOn
qsharp.summary: Decomposes a permutation on a variable
---

# DecomposedOn function

Namespace: [Microsoft.Quantum.Synthesis](xref:Microsoft.Quantum.Synthesis)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


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



## Example

Assume that the input is perm = [0, 2, 3, 5, 7, 1, 4, 6] and index = 0,then this function computes three permutations based on the followingtable, which lists the permutation `perm` in binary notation with elementsin group A and images in group D.  The columns list the bit indices.|   A   |   B   |   C   |   D   || 2 1 0 | 2 1 0 | 2 1 0 | 2 1 0 ||-------|-------|-------|-------|| 0 0 0 |       |       | 0 0 0 | 0| 0 0 1 |       |       | 0 1 0 | 2| 0 1 0 |       |       | 0 1 1 | 3| 0 1 1 |       |       | 1 0 1 | 5| 1 0 0 |       |       | 1 1 1 | 7| 1 0 1 |       |       | 0 0 1 | 1| 1 1 0 |       |       | 1 0 0 | 4| 1 1 1 |       |       | 1 1 0 | 6All values for indices not equal to 0 (= index) are copied from A to Band from D to C.|   A   |   B   |   C   |   D   || 2 1 0 | 2 1 0 | 2 1 0 | 2 1 0 ||-------|-------|-------|-------|| 0 0 0 | 0 0   | 0 0   | 0 0 0 || 0 0 1 | 0 0   | 0 1   | 0 1 0 || 0 1 0 | 0 1   | 0 1   | 0 1 1 || 0 1 1 | 0 1   | 1 0   | 1 0 1 || 1 0 0 | 1 0   | 1 1   | 1 1 1 || 1 0 1 | 1 0   | 0 0   | 0 0 1 || 1 1 0 | 1 1   | 1 0   | 1 0 0 || 1 1 1 | 1 1   | 1 1   | 1 1 0 |Next a 0 is placed for the first element with an empty index at column 0in block B and then a 1 is placed in B where the prefix matches (in thefirst case the other row with indices 0 0).Afterwards, a 1 is added in the same row in block C, and then a 0 for thecorresponding prefix in block C.  This process is repeated, until allindices have been placed in column 0 in blocks B and C.|   A   |   B   |   C   |   D   || 2 1 0 | 2 1 0 | 2 1 0 | 2 1 0 ||-------|-------|-------|-------|| 0 0 0 | 0 0 0 | 0 0 0 | 0 0 0 || 0 0 1 | 0 0 1 | 0 1 1 | 0 1 0 || 0 1 0 | 0 1 0 | 0 1 0 | 0 1 1 || 0 1 1 | 0 1 1 | 1 0 1 | 1 0 1 || 1 0 0 | 1 0 0 | 1 1 0 | 1 1 1 || 1 0 1 | 1 0 1 | 0 0 1 | 0 0 1 || 1 1 0 | 1 1 0 | 1 0 0 | 1 0 0 || 1 1 1 | 1 1 1 | 1 1 1 | 1 1 0 |We can read three new permutations from the table:- $\pi_l$ with elements in A, images in B (left)- $\pi_r$ with elements in D, images in C (right)- $\pi'$  with elements in B, images in C (remainder)Note that by design bit values do not change in $\pi_l$ and $\pi_r$ forindices 1 and 2, and bit values do not change for in $\pi_'$ forindex 0.  Also note that $\pi_l$ and $\pi_r$ must be self-inverse.The derived and returned permutations are:left      = [0, 1, 2, 3, 4, 5, 6, 7]right     = [0, 1, 3, 2, 4, 5, 7, 6]remainder = [0, 3, 2, 5, 6, 1, 4, 7]