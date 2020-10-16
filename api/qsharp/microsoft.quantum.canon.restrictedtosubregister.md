---
uid: Microsoft.Quantum.Canon.RestrictedToSubregister
title: RestrictedToSubregister function
ms.date: 10/16/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Canon
qsharp.name: RestrictedToSubregister
qsharp.summary: Restricts an operation to an array of indices of a register, i.e., a subregister.
---

# RestrictedToSubregister function

Namespace: [Microsoft.Quantum.Canon](xref:Microsoft.Quantum.Canon)

Package: [](https://nuget.org/packages/)


Restricts an operation to an array of indices of a register, i.e., a subregister.

```Q#
RestrictedToSubregister (op : (Qubit[] => Unit), idxs : Int[]) : (Qubit[] => Unit)
```


## Input

### op : Qubit[] => Unit 

Operation to be restricted to a subregister.


### idxs : Int[]

Array of indices, indicating to which qubits the operation will be restricted.


### target

Register on which the operation acts.



## See Also

- [Microsoft.Quantum.Canon.RestrictedToSubregisterA](xref:Microsoft.Quantum.Canon.RestrictedToSubregisterA)
- [Microsoft.Quantum.Canon.RestrictedToSubregisterC](xref:Microsoft.Quantum.Canon.RestrictedToSubregisterC)
- [Microsoft.Quantum.Canon.RestrictedToSubregisterCA](xref:Microsoft.Quantum.Canon.RestrictedToSubregisterCA)