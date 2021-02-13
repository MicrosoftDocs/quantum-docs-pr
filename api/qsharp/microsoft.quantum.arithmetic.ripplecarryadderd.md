---
uid: Microsoft.Quantum.Arithmetic.RippleCarryAdderD
title: RippleCarryAdderD operation
ms.date: 2/13/2021 12:00:00 AM
ms.topic: managed-reference
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Arithmetic
qsharp.name: RippleCarryAdderD
qsharp.summary: >-
  Reversible, in-place ripple-carry addition of two integers.
  Given two $n$-bit integers encoded in LittleEndian registers `xs` and `ys`,
  and a qubit carry, the operation computes the sum of the two integers
  where the $n$ least significant bits of the result are held in `ys` and
  the carry out bit is xored to the qubit `carry`.
---

# RippleCarryAdderD operation

Namespace: [Microsoft.Quantum.Arithmetic](xref:Microsoft.Quantum.Arithmetic)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Reversible, in-place ripple-carry addition of two integers.Given two $n$-bit integers encoded in LittleEndian registers `xs` and `ys`,and a qubit carry, the operation computes the sum of the two integerswhere the $n$ least significant bits of the result are held in `ys` andthe carry out bit is xored to the qubit `carry`.

```qsharp
operation RippleCarryAdderD (xs : Microsoft.Quantum.Arithmetic.LittleEndian, ys : Microsoft.Quantum.Arithmetic.LittleEndian, carry : Qubit) : Unit is Adj + Ctl
```


## Input

### xs : [LittleEndian](xref:Microsoft.Quantum.Arithmetic.LittleEndian)

LittleEndian qubit register encoding the first integer summand.


### ys : [LittleEndian](xref:Microsoft.Quantum.Arithmetic.LittleEndian)

LittleEndian qubit register encoding the second integer summand, ismodified to hold the $n$ least significant bits of the sum.


### carry : [Qubit](xref:microsoft.quantum.lang-ref.qubit)

Carry qubit, is xored with the most significant bit of the sum.



## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)



## Remarks

The specified controlled operation makes use of symmetry and mutualcancellation of operations to improve on the default implementationthat adds a control to every operation.

## References

- Thomas G. Draper: "Addition on a Quantum Computer", 2000.  https://arxiv.org/abs/quant-ph/0008033