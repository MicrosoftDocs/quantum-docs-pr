---
uid: Microsoft.Quantum.Canon.ApplyToSubregister
title: ApplyToSubregister operation
ms.date: 10/16/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Canon
qsharp.name: ApplyToSubregister
qsharp.summary: >-
  Applies an operation to a subregister of a register, with qubits
  specified by an array of their indices.
---

# ApplyToSubregister operation

Namespace: [Microsoft.Quantum.Canon](xref:Microsoft.Quantum.Canon)

Package: [](https://nuget.org/packages/)


Applies an operation to a subregister of a register, with qubitsspecified by an array of their indices.

```Q#
ApplyToSubregister (op : (Qubit[] => Unit), idxs : Int[], target : Qubit[]) : Unit
```


## Input

### op : Qubit[] => Unit 

Operation to apply to subregister.


### idxs : Int[]

Array of indices, indicating to which qubits the operation will be applied.


### target : Qubit[]

Register on which the operation acts.



## See Also

- [Microsoft.Quantum.Canon.ApplyToSubregisterA](xref:Microsoft.Quantum.Canon.ApplyToSubregisterA)
- [Microsoft.Quantum.Canon.ApplyToSubregisterC](xref:Microsoft.Quantum.Canon.ApplyToSubregisterC)
- [Microsoft.Quantum.Canon.ApplyToSubregisterCA](xref:Microsoft.Quantum.Canon.ApplyToSubregisterCA)