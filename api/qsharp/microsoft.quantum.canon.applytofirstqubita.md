---
uid: Microsoft.Quantum.Canon.ApplyToFirstQubitA
title: ApplyToFirstQubitA operation
ms.date: 10/16/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Canon
qsharp.name: ApplyToFirstQubitA
qsharp.summary: >-
  Applies an operation to the first qubit in the register.
  The modifier `A` indicates that the operation is adjointable.
---

# ApplyToFirstQubitA operation

Namespace: [Microsoft.Quantum.Canon](xref:Microsoft.Quantum.Canon)

Package: [](https://nuget.org/packages/)


Applies an operation to the first qubit in the register.The modifier `A` indicates that the operation is adjointable.

```Q#
ApplyToFirstQubitA (op : (Qubit => Unit is Adj), register : Qubit[]) : Unit
```


## Input

### op : Qubit => Unit Adj

An operation to be applied to the first qubit


### register : Qubit[]

Qubit array to the first qubit of which the operation is applied



## See Also

- [microsoft.quantum.canon.applytofirstqubit](xref:microsoft.quantum.canon.applytofirstqubit)