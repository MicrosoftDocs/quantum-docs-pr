---
uid: Microsoft.Quantum.Arithmetic.ApplyInnerTTKAdder
title: ApplyInnerTTKAdder operation
ms.date: 12/21/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Arithmetic
qsharp.name: ApplyInnerTTKAdder
qsharp.summary: >-
  Implements the inner addition function for the operation
  RippleCarryAdderTTK. This is the inner operation that is conjugated
  with the outer operation to construct the full adder.
---

# ApplyInnerTTKAdder operation

Namespace: [Microsoft.Quantum.Arithmetic](xref:Microsoft.Quantum.Arithmetic)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Implements the inner addition function for the operationRippleCarryAdderTTK. This is the inner operation that is conjugatedwith the outer operation to construct the full adder.

```qsharp
operation ApplyInnerTTKAdder (xs : Microsoft.Quantum.Arithmetic.LittleEndian, ys : Microsoft.Quantum.Arithmetic.LittleEndian, carry : Qubit) : Unit is Adj + Ctl
```


## Input

### xs : [LittleEndian](xref:Microsoft.Quantum.Arithmetic.LittleEndian)

LittleEndian qubit register encoding the first integer summandinput to RippleCarryAdderTTK.


### ys : [LittleEndian](xref:Microsoft.Quantum.Arithmetic.LittleEndian)

LittleEndian qubit register encoding the second integer summandinput to RippleCarryAdderTTK.


### carry : [Qubit](xref:microsoft.quantum.lang-ref.qubit)

Carry qubit, is xored with the most significant bit of the sum.



## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)



## Remarks

The specified controlled operation makes use of symmetry and mutualcancellation of operations to improve on the default implementationthat adds a control to every operation.

## References

- Yasuhiro Takahashi, Seiichiro Tani, Noboru Kunihiro: "Quantum  Addition Circuits and Unbounded Fan-Out", Quantum Information and  Computation, Vol. 10, 2010.  https://arxiv.org/abs/0910.2530