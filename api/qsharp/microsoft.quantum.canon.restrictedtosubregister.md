---
uid: Microsoft.Quantum.Canon.RestrictedToSubregister
title: RestrictedToSubregister function
ms.date: 11/25/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Canon
qsharp.name: RestrictedToSubregister
qsharp.summary: Restricts an operation to an array of indices of a register, i.e., a subregister.
---

# RestrictedToSubregister function

Namespace: [Microsoft.Quantum.Canon](xref:Microsoft.Quantum.Canon)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Restricts an operation to an array of indices of a register, i.e., a subregister.

```qsharp
function RestrictedToSubregister (op : (Qubit[] => Unit), idxs : Int[]) : (Qubit[] => Unit)
```


## Input

### op : [Qubit](xref:microsoft.quantum.concepts.the-qubit)[] => [Unit](xref:microsoft.quantum.user-guide.language.types) 

Operation to be restricted to a subregister.


### idxs : [Int](xref:microsoft.quantum.user-guide.language.types)[]

Array of indices, indicating to which qubits the operation will be restricted.



## Output : [Qubit](xref:microsoft.quantum.concepts.the-qubit)[] => [Unit](xref:microsoft.quantum.user-guide.language.types) 



## See Also

- [Microsoft.Quantum.Canon.RestrictedToSubregisterA](xref:Microsoft.Quantum.Canon.RestrictedToSubregisterA)
- [Microsoft.Quantum.Canon.RestrictedToSubregisterC](xref:Microsoft.Quantum.Canon.RestrictedToSubregisterC)
- [Microsoft.Quantum.Canon.RestrictedToSubregisterCA](xref:Microsoft.Quantum.Canon.RestrictedToSubregisterCA)