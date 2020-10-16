---
uid: Microsoft.Quantum.Canon.ApplyToFirstThreeQubitsC
title: ApplyToFirstThreeQubitsC operation
ms.date: 10/16/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Canon
qsharp.name: ApplyToFirstThreeQubitsC
qsharp.summary: >-
  Applies an operation to the first three qubits in the register.
  The modifier `C` indicates that the operation is controllable.
---

# ApplyToFirstThreeQubitsC operation

Namespace: [Microsoft.Quantum.Canon](xref:Microsoft.Quantum.Canon)

Package: [](https://nuget.org/packages/)


Applies an operation to the first three qubits in the register.The modifier `C` indicates that the operation is controllable.

```Q#
ApplyToFirstThreeQubitsC (op : ((Qubit, Qubit, Qubit) => Unit is Ctl), register : Qubit[]) : Unit
```


## Input

### op : (Qubit,Qubit,Qubit) => Unit Ctl

An operation to be applied to the first three qubits


### register : Qubit[]

Qubit array to the first three qubits of which the operation is applied.



## Remarks

This is equivalent to:```qsharpop(register[0], register[1], register[2]);```

## See Also

- [Microsoft.Quantum.Canon.ApplyToFirstThreeQubits](xref:Microsoft.Quantum.Canon.ApplyToFirstThreeQubits)