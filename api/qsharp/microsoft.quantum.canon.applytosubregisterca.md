---
uid: Microsoft.Quantum.Canon.ApplyToSubregisterCA
title: ApplyToSubregisterCA operation
ms.date: 1/29/2021 12:00:00 AM
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

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Applies an operation to a subregister of a register, with qubitsspecified by an array of their indices.The modifier `CA` indicates that the operation is controllable and adjointable.

```qsharp
operation ApplyToSubregisterCA (op : (Qubit[] => Unit is Ctl + Adj), idxs : Int[], target : Qubit[]) : Unit is Adj + Ctl
```


## Input

### op : [Qubit](xref:microsoft.quantum.lang-ref.qubit)[] => [Unit](xref:microsoft.quantum.lang-ref.unit)  is Adj + Ctl

Operation to apply to subregister.


### idxs : [Int](xref:microsoft.quantum.lang-ref.int)[]

Array of indices, indicating to which qubits the operation will be applied.


### target : [Qubit](xref:microsoft.quantum.lang-ref.qubit)[]

Register on which the operation acts.



## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)



## See Also

- [Microsoft.Quantum.Canon.ApplyToSubregister](xref:Microsoft.Quantum.Canon.ApplyToSubregister)