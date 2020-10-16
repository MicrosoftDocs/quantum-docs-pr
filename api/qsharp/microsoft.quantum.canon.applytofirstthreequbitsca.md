---
uid: Microsoft.Quantum.Canon.ApplyToFirstThreeQubitsCA
title: ApplyToFirstThreeQubitsCA operation
ms.date: 10/16/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Canon
qsharp.name: ApplyToFirstThreeQubitsCA
qsharp.summary: >-
  Applies an operation to the first three qubits in the register.
  The modifier `CA` indicates that the operation is controllable and adjointable.
---

# ApplyToFirstThreeQubitsCA operation

Namespace: [Microsoft.Quantum.Canon](xref:Microsoft.Quantum.Canon)

Package: [](https://nuget.org/packages/)


Applies an operation to the first three qubits in the register.The modifier `CA` indicates that the operation is controllable and adjointable.

```Q#
ApplyToFirstThreeQubitsCA (op : ((Qubit, Qubit, Qubit) => Unit is Adj + Ctl), register : Qubit[]) : Unit
```


## Input

### op : (Qubit,Qubit,Qubit) => Unit Adj + Ctl

An operation to be applied to the first three qubits


### register : Qubit[]

Qubit array to the first three qubits of which the operation is applied.



## Remarks

This is equivalent to:```qsharpop(register[0], register[1], register[2]);```

## See Also

- [Microsoft.Quantum.Canon.ApplyToFirstThreeQubits](xref:Microsoft.Quantum.Canon.ApplyToFirstThreeQubits)