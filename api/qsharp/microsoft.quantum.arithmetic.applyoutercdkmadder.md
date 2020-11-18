---
uid: Microsoft.Quantum.Arithmetic.ApplyOuterCDKMAdder
title: ApplyOuterCDKMAdder operation
ms.date: 11/18/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Arithmetic
qsharp.name: ApplyOuterCDKMAdder
qsharp.summary: >-
  Reversible, in-place ripple-carry operation that is used in the
  integer addition operation RippleCarryAdderCDKM below.
  Given two qubit registers `xs` and `ys` of the same length, the operation
  applies a ripple carry sequence of CNOT and CCNOT gates with qubits
  in `xs` and `ys` as the controls and qubits in `xs` as the targets.
---

# ApplyOuterCDKMAdder operation

Namespace: [Microsoft.Quantum.Arithmetic](xref:Microsoft.Quantum.Arithmetic)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Reversible, in-place ripple-carry operation that is used in theinteger addition operation RippleCarryAdderCDKM below.Given two qubit registers `xs` and `ys` of the same length, the operationapplies a ripple carry sequence of CNOT and CCNOT gates with qubitsin `xs` and `ys` as the controls and qubits in `xs` as the targets.

```qsharp
operation ApplyOuterCDKMAdder (xs : Microsoft.Quantum.Arithmetic.LittleEndian, ys : Microsoft.Quantum.Arithmetic.LittleEndian, ancilla : Qubit) : Unit is Adj + Ctl
```


## Input

### xs : [LittleEndian](xref:Microsoft.Quantum.Arithmetic.LittleEndian)

First qubit register, containing controls and targets.


### ys : [LittleEndian](xref:Microsoft.Quantum.Arithmetic.LittleEndian)

Second qubit register, contributing to the controls.


### ancilla : [Qubit](xref:microsoft.quantum.lang-ref.qubit)

The ancilla qubit used in RippleCarryAdderCDKM passed to this operation.



## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)



## References

- Steven A. Cuccaro, Thomas G. Draper, Samuel A. Kutin, David  Petrie Moulton: "A new quantum ripple-carry addition circuit", 2004.  https://arxiv.org/abs/quant-ph/0410184v1