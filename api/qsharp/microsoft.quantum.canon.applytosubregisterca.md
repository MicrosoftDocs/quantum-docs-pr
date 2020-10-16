---
uid: Microsoft.Quantum.Canon.ApplyToSubregisterCA
title: ApplyToSubregisterCA operation
ms.date: 10/16/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Canon
qsharp.name: ApplyToSubregisterCA
qsharp.summary: >-
  Applies an operation to a subregister of a register, with qubits
  specified by an array of their indices.
  The modifier `CA` indicates that the operation is controllable and adjointable.
---

# ApplyToSubregisterCA operation

Namespace: [Microsoft.Quantum.Canon](xref:Microsoft.Quantum.Canon)

Package: [](https://nuget.org/packages/)


Applies an operation to a subregister of a register, with qubitsspecified by an array of their indices.The modifier `CA` indicates that the operation is controllable and adjointable.

```Q#
ApplyToSubregisterCA (op : (Qubit[] => Unit is Ctl + Adj), idxs : Int[], target : Qubit[]) : Unit
```


## Input

### op : Qubit[] => Unit Ctl + Adj

Operation to apply to subregister.


### idxs : Int[]

Array of indices, indicating to which qubits the operation will be applied.


### target : Qubit[]

Register on which the operation acts.



## See Also

- [microsoft.quantum.canon.applytosubregister](xref:microsoft.quantum.canon.applytosubregister)