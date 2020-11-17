---
uid: Microsoft.Quantum.Synthesis.ApplyPermutationUsingTransformation
title: ApplyPermutationUsingTransformation operation
ms.date: 11/17/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Synthesis
qsharp.name: ApplyPermutationUsingTransformation
qsharp.summary: >-
  Permutes the amplitudes in a quantum state given a permutation
  using transformation-based synthesis.
---

# ApplyPermutationUsingTransformation operation

Namespace: [Microsoft.Quantum.Synthesis](xref:Microsoft.Quantum.Synthesis)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Permutes the amplitudes in a quantum state given a permutationusing transformation-based synthesis.

```qsharp
operation ApplyPermutationUsingTransformation (perm : Int[], qubits : Microsoft.Quantum.Arithmetic.LittleEndian) : Unit is Adj + Ctl
```


## Description

This procedure implements the unidirectional transformation basedsynthesis approach.  Input is a permutation $\pi$ over $2^n$ elements$\{0, \dots, 2^n-1\}$, which represents an $n$-variable reversible Boolean function.The algorithm performs iteratively the following steps:1. Find smallest $x$ such that $x \ne \pi(x) = y$.2. Find multiple-controlled Toffoli operations, which applied to the outputs   make $\pi(x) = x$ and do not change $\pi(x')$ for all $x' < x$

## Input

### perm : [Int](xref:microsoft.quantum.lang-ref.int)[]

A permutation of $2^n$ elements starting from 0.


### qubits : [LittleEndian](xref:Microsoft.Quantum.Arithmetic.LittleEndian)

A list of $n$ qubits to which the permutation is applied to.



## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)



## References

- [*D. Michael Miller*, *Dmitri Maslov*, *Gerhard W. Dueck*,  Proc. DAC 2003, IEEE, pp. 318-323,  2003](https://doi.org/10.1145/775832.775915)- [*Mathias Soeken*, *Gerhard W. Dueck*, *D. Michael Miller*,  Proc. RC 2016, Springer, pp. 307-321,  2016](https://doi.org/10.1007/978-3-319-40578-0_22)

## See Also

- [Microsoft.Quantum.Synthesis.ApplyPermutationUsingDecomposition](xref:Microsoft.Quantum.Synthesis.ApplyPermutationUsingDecomposition)