---
uid: Microsoft.Quantum.Canon.ApplyToFirstTwoQubitsCA
title: ApplyToFirstTwoQubitsCA operation
ms.date: 10/16/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Canon
qsharp.name: ApplyToFirstTwoQubitsCA
qsharp.summary: >-
  Applies an operation to the first two qubits in the register.
  The modifier `CA` indicates that the operation is controllable and adjointable.
---

# ApplyToFirstTwoQubitsCA operation

Namespace: [Microsoft.Quantum.Canon](xref:Microsoft.Quantum.Canon)

Package: [](https://nuget.org/packages/)


Applies an operation to the first two qubits in the register.The modifier `CA` indicates that the operation is controllable and adjointable.

```Q#
ApplyToFirstTwoQubitsCA (op : ((Qubit, Qubit) => Unit is Adj + Ctl), register : Qubit[]) : Unit
```


## Input

### op : (Qubit,Qubit) => Unit Adj + Ctl

An operation to be applied to the first two qubits


### register : Qubit[]

Qubit array to the first two qubits of which the operation is applied.



## Remarks

This is equivalent to:```qsharpop(register[0], register[1]);```

## See Also

- [microsoft.quantum.canon.applytofirsttwoqubits](xref:microsoft.quantum.canon.applytofirsttwoqubits)