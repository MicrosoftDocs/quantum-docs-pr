---
uid: Microsoft.Quantum.Canon.ApplyToSubregisterA
title: ApplyToSubregisterA operation
ms.date: 10/16/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Canon
qsharp.name: ApplyToSubregisterA
qsharp.summary: >-
  Applies an operation to a subregister of a register, with qubits
  specified by an array of their indices.
  The modifier `A` indicates that the operation is adjointable.
---

# ApplyToSubregisterA operation

Namespace: [Microsoft.Quantum.Canon](xref:Microsoft.Quantum.Canon)

Package: [](https://nuget.org/packages/)


Applies an operation to a subregister of a register, with qubitsspecified by an array of their indices.The modifier `A` indicates that the operation is adjointable.

```Q#
ApplyToSubregisterA (op : (Qubit[] => Unit is Adj), idxs : Int[], target : Qubit[]) : Unit
```


## Input

### op : Qubit[] => Unit Adj

Operation to apply to subregister.


### idxs : Int[]

Array of indices, indicating to which qubits the operation will be applied.


### target : Qubit[]

Register on which the operation acts.



## See Also

- [microsoft.quantum.canon.applytosubregister](xref:microsoft.quantum.canon.applytosubregister)