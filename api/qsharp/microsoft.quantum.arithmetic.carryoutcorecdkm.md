---
uid: Microsoft.Quantum.Arithmetic.CarryOutCoreCDKM
title: CarryOutCoreCDKM operation
ms.date: 11/9/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Arithmetic
qsharp.name: CarryOutCoreCDKM
qsharp.summary: >-
  The core operation in the RippleCarryAdderCDKM, used with the above
  ApplyOuterCDKMAdder operation, i.e. conjugated with this operation to obtain
  the inner operation of the RippleCarryAdderCDKM. This operation computes
  the carry out qubit and applies a sequence of NOT gates on part of the input `ys`.
---

# CarryOutCoreCDKM operation

Namespace: [Microsoft.Quantum.Arithmetic](xref:Microsoft.Quantum.Arithmetic)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


The core operation in the RippleCarryAdderCDKM, used with the aboveApplyOuterCDKMAdder operation, i.e. conjugated with this operation to obtainthe inner operation of the RippleCarryAdderCDKM. This operation computesthe carry out qubit and applies a sequence of NOT gates on part of the input `ys`.

```qsharp
operation CarryOutCoreCDKM (xs : Microsoft.Quantum.Arithmetic.LittleEndian, ys : Microsoft.Quantum.Arithmetic.LittleEndian, ancilla : Qubit, carry : Qubit) : Unit is Adj + Ctl
```


## Input

### xs : [LittleEndian](xref:Microsoft.Quantum.Arithmetic.LittleEndian)

First qubit register.


### ys : [LittleEndian](xref:Microsoft.Quantum.Arithmetic.LittleEndian)

Second qubit register.


### ancilla : [Qubit](xref:microsoft.quantum.lang-ref.qubit)

The ancilla qubit used in RippleCarryAdderCDKM passed to this operation.


### carry : [Qubit](xref:microsoft.quantum.lang-ref.qubit)

Carry out qubit in the RippleCarryAdderCDKM operation.



## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)



## References

- Steven A. Cuccaro, Thomas G. Draper, Samuel A. Kutin, David  Petrie Moulton: "A new quantum ripple-carry addition circuit", 2004.  https://arxiv.org/abs/quant-ph/0410184v1