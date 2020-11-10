---
uid: Microsoft.Quantum.Arithmetic.IncrementPhaseByInteger
title: IncrementPhaseByInteger operation
ms.date: 11/10/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Arithmetic
qsharp.name: IncrementPhaseByInteger
qsharp.summary: >-
  Increments an unsigned quantum register by a classical integer,
  using phase rotations.
---

# IncrementPhaseByInteger operation

Namespace: [Microsoft.Quantum.Arithmetic](xref:Microsoft.Quantum.Arithmetic)

Package: [](https://nuget.org/packages/)


Increments an unsigned quantum register by a classical integer,using phase rotations.

```qsharp
operation IncrementPhaseByInteger (increment : Int, target : Microsoft.Quantum.Arithmetic.PhaseLittleEndian) : Unit
```


## Description

Suppose that `target` encodes an unsigned integer $x$ in a little-endianencoding and that `increment` is equal to $a$.Then, this operation implements the unitary $\ket{x} \mapsto \ket{x + a}$,where the addition is performedmodulo $2^n$, where $n = \texttt{Length(target!)}$.

## Input

### increment : [Int](xref:microsoft.quantum.lang-ref.int)

The integer by which the `target` is incremented by.


### target : [PhaseLittleEndian](xref:Microsoft.Quantum.Arithmetic.PhaseLittleEndian)

A quantum register encoding an unsigned integer using little-endianencoding in the dual (QFT) basis.



## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)



## Remarks

Note that we have simplified the circuit because the increment is aclassical constant, not a quantum register.See the figure on[ Page 6 of arXiv:quant-ph/0008033v1 ](https://arxiv.org/pdf/quant-ph/0008033.pdf#page=6)for the circuit diagram and explanation.

## References

- [ *Thomas G. Draper*,  arXiv:quant-ph/0008033](https://arxiv.org/pdf/quant-ph/0008033v1.pdf)

## See Also

- [Microsoft.Quantum.Arithmetic.IncrementByInteger](xref:Microsoft.Quantum.Arithmetic.IncrementByInteger)