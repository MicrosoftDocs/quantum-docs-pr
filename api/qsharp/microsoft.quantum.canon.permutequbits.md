---
uid: Microsoft.Quantum.Canon.PermuteQubits
title: PermuteQubits operation
ms.date: 1/28/2021 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Canon
qsharp.name: PermuteQubits
qsharp.summary: Permutes qubits by using the SWAP operation.
---

# PermuteQubits operation

Namespace: [Microsoft.Quantum.Canon](xref:Microsoft.Quantum.Canon)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Permutes qubits by using the SWAP operation.

```qsharp
operation PermuteQubits (ordering : Int[], register : Qubit[]) : Unit is Adj + Ctl
```


## Input

### ordering : [Int](xref:microsoft.quantum.lang-ref.int)[]

Describes the new ordering of the qubits, where the qubit at index i will now be at ordering[i].


### register : [Qubit](xref:microsoft.quantum.lang-ref.qubit)[]

Qubit register to be acted upon.



## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)



## Example

Given ordering = [2, 1, 0] and register $\ket{\alpha_0} \ket{\alpha_1} \ket{\alpha_2}$, PermuteQubitschanges the register into $\ket{\alpha_2} \ket{\alpha_1} \ket{\alpha_0}$```qsharp// The following two lines are equivalentPermuteQubits([2, 1, 0], register);SWAP(register[0], register[2]);```