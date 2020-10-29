---
uid: Microsoft.Quantum.Arithmetic.MultiplyAndAddByModularInteger
title: MultiplyAndAddByModularInteger operation
ms.date: 10/29/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Arithmetic
qsharp.name: MultiplyAndAddByModularInteger
qsharp.summary: Performs a modular multiply-and-add by integer constants on a qubit register.
---

# MultiplyAndAddByModularInteger operation

Namespace: [Microsoft.Quantum.Arithmetic](xref:Microsoft.Quantum.Arithmetic)

Package: [](https://nuget.org/packages/)


Performs a modular multiply-and-add by integer constants on a qubit register.

```qsharp
operation MultiplyAndAddByModularInteger (constMultiplier : Int, modulus : Int, multiplier : Microsoft.Quantum.Arithmetic.LittleEndian, summand : Microsoft.Quantum.Arithmetic.LittleEndian) : Unit
```


## Description

Implements the map$$\begin{align}\ket{x} \ket{b} \mapsto \ket{x} \ket{(b + a \cdot x) \operatorname{mod} N}\end{align}$$for a given modulus $N$, constant multiplier $a$, and summand $y$.

## Input

### constMultiplier : [Int](xref:microsoft.quantum.lang-ref.int)

An integer $a$ to be added to each basis state label.


### modulus : [Int](xref:microsoft.quantum.lang-ref.int)

The modulus $N$ which addition and multiplication is taken with respect to.


### multiplier : [LittleEndian](xref:Microsoft.Quantum.Arithmetic.LittleEndian)

A quantum register representing an unsigned integer whose value is tobe added to each basis state label of `summand`.


### summand : [LittleEndian](xref:Microsoft.Quantum.Arithmetic.LittleEndian)

A quantum register representing an unsigned integer to use as the targetfor this operation.



## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)



## Remarks

- For the circuit diagram and explanation see Figure 6 on [Page 7  of arXiv:quant-ph/0205095v3](https://arxiv.org/pdf/quant-ph/0205095v3.pdf#page=7)- This operation corresponds to CMULT(a)MOD(N) in  [arXiv:quant-ph/0205095v3](https://arxiv.org/pdf/quant-ph/0205095v3.pdf)

## See Also

- [Microsoft.Quantum.Arithmetic.MultiplyAndAddPhaseByModularInteger](xref:Microsoft.Quantum.Arithmetic.MultiplyAndAddPhaseByModularInteger)