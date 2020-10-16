---
uid: Microsoft.Quantum.Canon.ApplyToFirstQubitC
title: ApplyToFirstQubitC operation
ms.date: 10/16/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Canon
qsharp.name: ApplyToFirstQubitC
qsharp.summary: >-
  Applies operation op to the first qubit in the register.
  The modifier `C` indicates that the operation is controllable.
---

# ApplyToFirstQubitC operation

Namespace: [Microsoft.Quantum.Canon](xref:Microsoft.Quantum.Canon)

Package: [](https://nuget.org/packages/)


Applies operation op to the first qubit in the register.The modifier `C` indicates that the operation is controllable.

```Q#
ApplyToFirstQubitC (op : (Qubit => Unit is Ctl), register : Qubit[]) : Unit
```


## Input

### op : Qubit => Unit Ctl

An operation to be applied to the first qubit


### register : Qubit[]

Qubit array to the first qubit of which the operation is applied



## See Also

- [microsoft.quantum.canon.applytofirstqubit](xref:microsoft.quantum.canon.applytofirstqubit)