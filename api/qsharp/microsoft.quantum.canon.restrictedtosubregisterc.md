---
uid: Microsoft.Quantum.Canon.RestrictedToSubregisterC
title: RestrictedToSubregisterC function
ms.date: 10/16/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Canon
qsharp.name: RestrictedToSubregisterC
qsharp.summary: >-
  Restricts an operation to an array of indices of a register, i.e., a subregister.
  The modifier `C` indicates that the operation is controllable.
---

# RestrictedToSubregisterC function

Namespace: [Microsoft.Quantum.Canon](xref:Microsoft.Quantum.Canon)

Package: [](https://nuget.org/packages/)


Restricts an operation to an array of indices of a register, i.e., a subregister.The modifier `C` indicates that the operation is controllable.

```Q#
RestrictedToSubregisterC (op : (Qubit[] => Unit is Ctl), idxs : Int[]) : (Qubit[] => Unit is Ctl)
```


## Input

### op : Qubit[] => Unit Ctl

Operation to be restricted to a subregister.


### idxs : Int[]

Array of indices, indicating to which qubits the operation will be restricted.


### target

Register on which the operation acts.



## See Also

- [Microsoft.Quantum.Canon.RestrictedToSubregister](xref:Microsoft.Quantum.Canon.RestrictedToSubregister)