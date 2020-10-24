---
uid: Microsoft.Quantum.Arithmetic.IncrementPhaseByModularInteger
title: IncrementPhaseByModularInteger operation
ms.date: 10/24/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Arithmetic
qsharp.name: IncrementPhaseByModularInteger
qsharp.summary: Performs a modular increment of a qubit register by an integer constant.
---

# IncrementPhaseByModularInteger operation

Namespace: [Microsoft.Quantum.Arithmetic](xref:Microsoft.Quantum.Arithmetic)

Package: [](https://nuget.org/packages/)


Performs a modular increment of a qubit register by an integer constant.

```qsharp
operation IncrementPhaseByModularInteger (increment : Int, modulus : Int, target : Microsoft.Quantum.Arithmetic.PhaseLittleEndian) : Unit
```


## Description

Let us denote `increment` by $a$, `modulus` by $N$ and integer encoded in `target` by $y$.Then the operation performs the following transformation:\begin{align}\ket{y} \mapsto \ket{(y + a) \operatorname{mod} N}\end{align}Integers are encoded in little-endian format in QFT basis.

## Input

### increment : [Int](xref:microsoft.quantum.lang-ref.int)

Integer increment $a$ to be added to $y$.


### modulus : [Int](xref:microsoft.quantum.lang-ref.int)

Integer $N$ that mods $y + a$.


### target : [PhaseLittleEndian](xref:Microsoft.Quantum.Arithmetic.PhaseLittleEndian)

Integer $y$ in phase-encoded little-endian format that `increment` $a$ is added to.



## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)



## Remarks

Assumes that `target` has the highest bit set to 0.Also assumes that the value of target is less than $N$.For the circuit diagram and explanation see Figure 5 on [Page 5of arXiv:quant-ph/0205095v3](https://arxiv.org/pdf/quant-ph/0205095v3.pdf#page=5).

## See Also

- [Microsoft.Quantum.Arithmetic.IncrementByModularInteger](xref:Microsoft.Quantum.Arithmetic.IncrementByModularInteger)