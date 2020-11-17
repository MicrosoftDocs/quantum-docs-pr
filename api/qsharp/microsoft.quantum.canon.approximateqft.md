---
uid: Microsoft.Quantum.Canon.ApproximateQFT
title: ApproximateQFT operation
ms.date: 11/16/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Canon
qsharp.name: ApproximateQFT
qsharp.summary: Apply the Approximate Quantum Fourier Transform (AQFT) to a quantum register.
---

# ApproximateQFT operation

Namespace: [Microsoft.Quantum.Canon](xref:Microsoft.Quantum.Canon)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Apply the Approximate Quantum Fourier Transform (AQFT) to a quantum register.

```qsharp
operation ApproximateQFT (a : Int, qs : Microsoft.Quantum.Arithmetic.BigEndian) : Unit is Adj + Ctl
```


## Input

### a : [Int](xref:microsoft.quantum.lang-ref.int)

approximation parameter which determines at which level the controlled Z-rotations thatoccur in the QFT circuit are pruned.The approximation parameter a determines the pruning level of the Z-rotations, i.e.,a ∈ {0..n} and all Z-rotations 2π/2ᵏ where k>a areremoved from the QFT circuit. It is known that for k >= log₂(n)+log₂(1/ε)+3one can bound ||QFT-AQFT||<ε.


### qs : [BigEndian](xref:Microsoft.Quantum.Arithmetic.BigEndian)

quantum register of n qubits to which the Approximate Quantum Fourier Transform is applied.



## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)



## Remarks

AQFT requires Z-rotation gates of the form 2π/2ᵏ and Hadamard gates.The input and output are assumed to be encoded in big endian encoding.

## References

- [ *M. Roetteler, Th. Beth*,  Appl. Algebra Eng. Commun. Comput.  19(3): 177-193 (2008) ](http://doi.org/10.1007/s00200-008-0072-2)- [ *D. Coppersmith* arXiv:quant-ph/0201067v1 ](https://arxiv.org/abs/quant-ph/0201067)