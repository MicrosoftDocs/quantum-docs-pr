---
uid: Microsoft.Quantum.Canon.PermuteQubits
title: PermuteQubits operation
ms.date: 10/26/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Canon
qsharp.name: PermuteQubits
qsharp.summary: Permutes qubits by using the SWAP operation.
---

# PermuteQubits operation

Namespace: [Microsoft.Quantum.Canon](xref:Microsoft.Quantum.Canon)

Package: [](https://nuget.org/packages/)


Permutes qubits by using the SWAP operation.

```qsharp
operation PermuteQubits (ordering : Int[], register : Qubit[]) : Unit
```


## Input

### ordering : [Int](xref:microsoft.quantum.lang-ref.int)[]

Describes the new ordering of the qubits, where the qubit at index i will now be at ordering[i].


### register : [Qubit](xref:microsoft.quantum.lang-ref.qubit)[]

Qubit register to be acted upon.



## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)

