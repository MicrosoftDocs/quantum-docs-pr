---
uid: Microsoft.Quantum.Arithmetic.RippleCarryAdderCDKM
title: RippleCarryAdderCDKM operation
ms.date: 10/26/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Arithmetic
qsharp.name: RippleCarryAdderCDKM
qsharp.summary: Reversible, in-place ripple-carry addition of two integers.
---

# RippleCarryAdderCDKM operation

Namespace: [Microsoft.Quantum.Arithmetic](xref:Microsoft.Quantum.Arithmetic)

Package: [](https://nuget.org/packages/)


Reversible, in-place ripple-carry addition of two integers.

```qsharp
operation RippleCarryAdderCDKM (xs : Microsoft.Quantum.Arithmetic.LittleEndian, ys : Microsoft.Quantum.Arithmetic.LittleEndian, carry : Qubit) : Unit
```


## Description

Given two $n$-bit integers encoded in LittleEndian registers `xs` and `ys`,

## Input

### xs : [LittleEndian](xref:Microsoft.Quantum.Arithmetic.LittleEndian)

LittleEndian qubit register encoding the first integer summand.


### ys : [LittleEndian](xref:Microsoft.Quantum.Arithmetic.LittleEndian)

LittleEndian qubit register encoding the second integer summand, is


### carry : [Qubit](xref:microsoft.quantum.lang-ref.qubit)

Carry qubit, is xored with the most significant bit of the sum.



## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)



## Remarks

This operation has the same functionality as RippleCarryAdderD, but

## References

- Steven A. Cuccaro, Thomas G. Draper, Samuel A. Kutin, David