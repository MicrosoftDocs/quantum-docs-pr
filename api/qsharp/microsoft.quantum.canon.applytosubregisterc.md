---
uid: Microsoft.Quantum.Canon.ApplyToSubregisterC
title: ApplyToSubregisterC operation
ms.date: 10/26/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Canon
qsharp.name: ApplyToSubregisterC
qsharp.summary: >-
  Applies an operation to a subregister of a register, with qubits
  specified by an array of their indices.
  The modifier `C` indicates that the operation is controllable.
---

# ApplyToSubregisterC operation

Namespace: [Microsoft.Quantum.Canon](xref:Microsoft.Quantum.Canon)

Package: [](https://nuget.org/packages/)


Applies an operation to a subregister of a register, with qubitsspecified by an array of their indices.The modifier `C` indicates that the operation is controllable.

```qsharp
operation ApplyToSubregisterC (op : (Qubit[] => Unit is Ctl), idxs : Int[], target : Qubit[]) : Unit
```


## Input

### op : [Qubit](xref:microsoft.quantum.lang-ref.qubit)[] => [Unit](xref:microsoft.quantum.lang-ref.unit) Ctl

Operation to apply to subregister.


### idxs : [Int](xref:microsoft.quantum.lang-ref.int)[]

Array of indices, indicating to which qubits the operation will be applied.


### target : [Qubit](xref:microsoft.quantum.lang-ref.qubit)[]

Register on which the operation acts.



## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)



## See Also

- [Microsoft.Quantum.Canon.ApplyToSubregister](xref:Microsoft.Quantum.Canon.ApplyToSubregister)