---
uid: Microsoft.Quantum.Canon.ApplyCNOTChainWithTarget
title: ApplyCNOTChainWithTarget operation
ms.date: 10/16/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Canon
qsharp.name: ApplyCNOTChainWithTarget
qsharp.summary: Computes the parity of an array of qubits into a target qubit.
---

# ApplyCNOTChainWithTarget operation

Namespace: [Microsoft.Quantum.Canon](xref:Microsoft.Quantum.Canon)

Package: [](https://nuget.org/packages/)


Computes the parity of an array of qubits into a target qubit.

```Q#
ApplyCNOTChainWithTarget (qubits : Qubit[], targetQubit : Qubit) : Unit
```


## Description

If the array is initially in the state$\ket{q_0} \ket{q_1} \cdots \ket{q_{\text{target}}}$,the final state is given by$\ket{q_0} \ket{q_1 \oplus q_0} \cdots \ket{q_{n - 1} \oplus \cdots \oplus q_0 \oplus q_{\text{target}}}$.

## Input

### qubits : Qubit[]

Array of qubits on which the parity is computed.


### targetQubit : Qubit

Final qubit into which the parity of 'qubits' is XORed.



## Remarks

The following are equivalent:```qsharpApplyCNOTChainWithTarget(Most(qs), Last(qs));```and```qsharpApplyCNOTChain(qs);```