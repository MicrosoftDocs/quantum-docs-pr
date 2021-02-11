---
uid: Microsoft.Quantum.Canon.ApplyMultiControlledC
title: ApplyMultiControlledC operation
ms.date: 2/11/2021 12:00:00 AM
ms.topic: managed-reference
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Canon
qsharp.name: ApplyMultiControlledC
qsharp.summary: >-
  Applies a multiply controlled version of a singly controlled
  operation.
  The modifier `C` indicates that the single-qubit operation is controllable.
---

# ApplyMultiControlledC operation

Namespace: [Microsoft.Quantum.Canon](xref:Microsoft.Quantum.Canon)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Applies a multiply controlled version of a singly controlledoperation.The modifier `C` indicates that the single-qubit operation is controllable.

```qsharp
operation ApplyMultiControlledC (singlyControlledOp : (Qubit[] => Unit), ccnot : Microsoft.Quantum.Canon.CCNOTop, controls : Qubit[], targets : Qubit[]) : Unit is Ctl
```


## Input

### singlyControlledOp : [Qubit](xref:microsoft.quantum.lang-ref.qubit)[] => [Unit](xref:microsoft.quantum.lang-ref.unit) 

An operation controlled on a single qubit.The first qubit in the argument of the operation isassumed to be a control and the rest are assumed to be target qubits.`ApplyMultiControlled` always calls `singlyControlledOp` with an argument oflength at least 1.


### ccnot : [CCNOTop](xref:Microsoft.Quantum.Canon.CCNOTop)

The controlled-controlled-NOT gate to use for the construction.


### controls : [Qubit](xref:microsoft.quantum.lang-ref.qubit)[]

The qubits that `singlyControlledOp` is to be controlled on.The length of `controls` must be at least 1.


### targets : [Qubit](xref:microsoft.quantum.lang-ref.qubit)[]

The target qubits that `singlyControlledOp` acts upon.



## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)



## Remarks

This operation uses only clean ancilla qubits.For the explanation and circuit diagram see Figure 4.10, Section 4.3 in Nielsen & Chuang

## References

- [ *Michael A. Nielsen , Isaac L. Chuang*,  Quantum Computation and Quantum Information ](http://doi.org/10.1017/CBO9780511976667)

## See Also

- [Microsoft.Quantum.Canon.ApplyMultiControlledCA](xref:Microsoft.Quantum.Canon.ApplyMultiControlledCA)