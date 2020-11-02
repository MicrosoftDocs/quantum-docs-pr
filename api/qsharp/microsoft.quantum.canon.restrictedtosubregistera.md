---
uid: Microsoft.Quantum.Canon.RestrictedToSubregisterA
title: RestrictedToSubregisterA function
ms.date: 11/2/2020 12:00:00 AM
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

```qsharp
function RestrictedToSubregisterA (op : (Qubit[] => Unit is Adj), idxs : Int[]) : (Qubit[] => Unit is Adj)
```


## Input

### op : [Qubit](xref:microsoft.quantum.lang-ref.qubit)[] => [Unit](xref:microsoft.quantum.lang-ref.unit) Adj

Operation to be restricted to a subregister.


### idxs : [Int](xref:microsoft.quantum.lang-ref.int)[]

Array of indices, indicating to which qubits the operation will be restricted.



## Output : [Qubit](xref:microsoft.quantum.lang-ref.qubit)[] => [Unit](xref:microsoft.quantum.lang-ref.unit) Adj



## See Also

- [Microsoft.Quantum.Canon.RestrictedToSubregister](xref:Microsoft.Quantum.Canon.RestrictedToSubregister)