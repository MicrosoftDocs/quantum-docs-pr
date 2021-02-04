---
uid: Microsoft.Quantum.Arithmetic.RippleCarryAdderCDKM
title: RippleCarryAdderCDKM operation
ms.date: 2/4/2021 12:00:00 AM
ms.topic: managed-reference
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Arithmetic
qsharp.name: RippleCarryAdderCDKM
qsharp.summary: Reversible, in-place ripple-carry addition of two integers.
---

# RippleCarryAdderCDKM operation

Namespace: [Microsoft.Quantum.Arithmetic](xref:Microsoft.Quantum.Arithmetic)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Reversible, in-place ripple-carry addition of two integers.

```qsharp
operation RippleCarryAdderCDKM (xs : Microsoft.Quantum.Arithmetic.LittleEndian, ys : Microsoft.Quantum.Arithmetic.LittleEndian, carry : Qubit) : Unit is Adj + Ctl
```


## Description

Given two $n$-bit integers encoded in LittleEndian registers `xs` and `ys`,and a qubit carry, the operation computes the sum of the two integerswhere the $n$ least significant bits of the result are held in `ys` andthe carry out bit is xored to the qubit `carry`.

## Input

### xs : [LittleEndian](xref:Microsoft.Quantum.Arithmetic.LittleEndian)

LittleEndian qubit register encoding the first integer summand.


### ys : [LittleEndian](xref:Microsoft.Quantum.Arithmetic.LittleEndian)

LittleEndian qubit register encoding the second integer summand, ismodified to hold the n least significant bits of the sum.


### carry : [Qubit](xref:microsoft.quantum.lang-ref.qubit)

Carry qubit, is xored with the most significant bit of the sum.



## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)



## Remarks

This operation has the same functionality as RippleCarryAdderD, butonly uses one auxiliary qubit instead of $n$.

## References

- Steven A. Cuccaro, Thomas G. Draper, Samuel A. Kutin, David  Petrie Moulton: "A new quantum ripple-carry addition circuit", 2004.  https://arxiv.org/abs/quant-ph/0410184v1