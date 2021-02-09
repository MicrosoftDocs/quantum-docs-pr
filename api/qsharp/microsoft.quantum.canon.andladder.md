---
uid: Microsoft.Quantum.Canon.AndLadder
title: AndLadder operation
ms.date: 2/9/2021 12:00:00 AM
ms.topic: managed-reference
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Canon
qsharp.name: AndLadder
qsharp.summary: Performs a controlled "AND ladder" on a register of target qubits.
---

# AndLadder operation

Namespace: [Microsoft.Quantum.Canon](xref:Microsoft.Quantum.Canon)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Performs a controlled "AND ladder" on a register of target qubits.

```qsharp
operation AndLadder (ccnot : Microsoft.Quantum.Canon.CCNOTop, controls : Qubit[], targets : Qubit[]) : Unit is Adj
```


## Description

This operation applies a transformation described by the followingmapping of the computational basis,$$\begin{align}\ket{x\_1, \dots, x\_n} \ket{y\_1, \dots, y\_{n - 1}} \mapsto\ket{x\_1, \dots, x\_n} \ket{y\_1 \oplus (x\_1 \land x\_2), \dots, y\_{n - 1} \oplus (x\_1 \land x\_2 \land \cdots \land x\_{n - 1}},\end{align}$$where $\ket{x\_1, \dots, x\_n}$ refers to the computational basisstates of `controls`, and where $\ket{y\_1, \dots, y\_{n - 1}}$refers to the computational basis states of `targets`.

## Input

### ccnot : [CCNOTop](xref:Microsoft.Quantum.Canon.CCNOTop)

The CCNOT gate to use for the construction.


### controls : [Qubit](xref:microsoft.quantum.lang-ref.qubit)[]

A register of qubits to be used as controls for the and ladder.This operation leaves computational basis states of `controls`invariant.The length of `controls` must be at least 2, and mustbe equal to one plus the length of `targets`.


### targets : [Qubit](xref:microsoft.quantum.lang-ref.qubit)[]

The length of `targets` must be at least 1 and equal to the lengthof `controls` minus one.



## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)



## Remarks

- Used as a part of <xref:microsoft.quantum.canon.applymulticontrolledc>  and <xref:microsoft.quantum.canon.applymulticontrolledca>.- For the explanation and circuit diagram see Figure 4.10, Section 4.3 in Nielsen & Chuang.

## References

- [ *Michael A. Nielsen , Isaac L. Chuang*,  Quantum Computation and Quantum Information ](http://doi.org/10.1017/CBO9780511976667)