---
uid: Microsoft.Quantum.Arithmetic.RippleCarryAdderTTK
title: RippleCarryAdderTTK operation
ms.date: 12/16/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Arithmetic
qsharp.name: RippleCarryAdderTTK
qsharp.summary: >-
  Reversible, in-place ripple-carry addition of two integers.
  Given two $n$-bit integers encoded in LittleEndian registers `xs` and `ys`,
  and a qubit carry, the operation computes the sum of the two integers
  where the $n$ least significant bits of the result are held in `ys` and
  the carry out bit is xored to the qubit `carry`.
---

# RippleCarryAdderTTK operation

Namespace: [Microsoft.Quantum.Arithmetic](xref:Microsoft.Quantum.Arithmetic)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Reversible, in-place ripple-carry addition of two integers.Given two $n$-bit integers encoded in LittleEndian registers `xs` and `ys`,and a qubit carry, the operation computes the sum of the two integerswhere the $n$ least significant bits of the result are held in `ys` andthe carry out bit is xored to the qubit `carry`.

```qsharp
operation RippleCarryAdderTTK (xs : Microsoft.Quantum.Arithmetic.LittleEndian, ys : Microsoft.Quantum.Arithmetic.LittleEndian, carry : Qubit) : Unit is Adj + Ctl
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

This operation has the same functionality as RippleCarryAdderD and,RippleCarryAdderCDKM but does not use any ancilla qubits.

## References

- Yasuhiro Takahashi, Seiichiro Tani, Noboru Kunihiro: "Quantum  Addition Circuits and Unbounded Fan-Out", Quantum Information and  Computation, Vol. 10, 2010.  https://arxiv.org/abs/0910.2530