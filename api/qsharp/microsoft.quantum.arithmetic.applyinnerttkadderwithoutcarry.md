---
uid: Microsoft.Quantum.Arithmetic.ApplyInnerTTKAdderWithoutCarry
title: ApplyInnerTTKAdderWithoutCarry operation
ms.date: 1/29/2021 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Arithmetic
qsharp.name: ApplyInnerTTKAdderWithoutCarry
qsharp.summary: >-
  Implements the inner addition function for the operation
  RippleCarryAdderNoCarryTTK. This is the inner operation that is conjugated
  with the outer operation to construct the full adder.
---

# ApplyInnerTTKAdderWithoutCarry operation

Namespace: [Microsoft.Quantum.Arithmetic](xref:Microsoft.Quantum.Arithmetic)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Implements the inner addition function for the operationRippleCarryAdderNoCarryTTK. This is the inner operation that is conjugatedwith the outer operation to construct the full adder.

```qsharp
operation ApplyInnerTTKAdderWithoutCarry (xs : Microsoft.Quantum.Arithmetic.LittleEndian, ys : Microsoft.Quantum.Arithmetic.LittleEndian) : Unit is Adj + Ctl
```


## Input

### xs : [LittleEndian](xref:Microsoft.Quantum.Arithmetic.LittleEndian)

LittleEndian qubit register encoding the first integer summandinput to RippleCarryAdderNoCarryTTK.


### ys : [LittleEndian](xref:Microsoft.Quantum.Arithmetic.LittleEndian)

LittleEndian qubit register encoding the second integer summandinput to RippleCarryAdderNoCarryTTK.



## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)



## Remarks

The specified controlled operation makes use of symmetry and mutualcancellation of operations to improve on the default implementationthat adds a control to every operation.

## References

- Yasuhiro Takahashi, Seiichiro Tani, Noboru Kunihiro: "Quantum  Addition Circuits and Unbounded Fan-Out", Quantum Information and  Computation, Vol. 10, 2010.  https://arxiv.org/abs/0910.2530