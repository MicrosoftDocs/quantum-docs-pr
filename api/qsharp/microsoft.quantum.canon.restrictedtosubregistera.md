---
uid: Microsoft.Quantum.Canon.RestrictedToSubregisterA
title: RestrictedToSubregisterA function
ms.date: 10/16/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Canon
qsharp.name: RestrictedToSubregisterA
qsharp.summary: >-
  Restricts an operation to an array of indices of a register, i.e., a subregister.
  The modifier `A` indicates that the operation is adjointable.
---

# RestrictedToSubregisterA function

Namespace: [Microsoft.Quantum.Canon](xref:Microsoft.Quantum.Canon)

Package: [](https://nuget.org/packages/)


Restricts an operation to an array of indices of a register, i.e., a subregister.The modifier `A` indicates that the operation is adjointable.

```Q#
RestrictedToSubregisterA (op : (Qubit[] => Unit is Adj), idxs : Int[]) : (Qubit[] => Unit is Adj)
```


## Input

### op : Qubit[] => Unit Adj

Operation to be restricted to a subregister.


### idxs : Int[]

Array of indices, indicating to which qubits the operation will be restricted.


### target

Register on which the operation acts.



## See Also

- [Microsoft.Quantum.Canon.RestrictedToSubregister](xref:Microsoft.Quantum.Canon.RestrictedToSubregister)