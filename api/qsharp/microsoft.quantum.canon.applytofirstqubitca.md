---
uid: Microsoft.Quantum.Canon.ApplyToFirstQubitCA
title: ApplyToFirstQubitCA operation
ms.date: 10/16/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Canon
qsharp.name: ApplyToFirstQubitCA
qsharp.summary: >-
  Applies operation op to the first qubit in the register.
  The modifier `CA` indicates that the operation is controllable and adjointable.
---

# ApplyToFirstQubitCA operation

Namespace: [Microsoft.Quantum.Canon](xref:Microsoft.Quantum.Canon)

Package: [](https://nuget.org/packages/)


Applies operation op to the first qubit in the register.The modifier `CA` indicates that the operation is controllable and adjointable.

```Q#
ApplyToFirstQubitCA (op : (Qubit => Unit is Adj + Ctl), register : Qubit[]) : Unit
```


## Input

### op : Qubit => Unit Adj + Ctl

An operation to be applied to the first qubit


### register : Qubit[]

Qubit array to the first qubit of which the operation is applied



## See Also

- [microsoft.quantum.canon.applytofirstqubit](xref:microsoft.quantum.canon.applytofirstqubit)