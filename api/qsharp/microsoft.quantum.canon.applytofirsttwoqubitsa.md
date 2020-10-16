---
uid: Microsoft.Quantum.Canon.ApplyToFirstTwoQubitsA
title: ApplyToFirstTwoQubitsA operation
ms.date: 10/16/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Canon
qsharp.name: ApplyToFirstTwoQubitsA
qsharp.summary: >-
  Applies an operation to the first two qubits in the register.
  The modifier `A` indicates that the operation is adjointable.
---

# ApplyToFirstTwoQubitsA operation

Namespace: [Microsoft.Quantum.Canon](xref:Microsoft.Quantum.Canon)

Package: [](https://nuget.org/packages/)


Applies an operation to the first two qubits in the register.The modifier `A` indicates that the operation is adjointable.

```Q#
ApplyToFirstTwoQubitsA (op : ((Qubit, Qubit) => Unit is Adj), register : Qubit[]) : Unit
```


## Input

### op : (Qubit,Qubit) => Unit Adj

An operation to be applied to the first two qubits


### register : Qubit[]

Qubit array to the first two qubits of which the operation is applied.



## Remarks

This is equivalent to:```qsharpop(register[0], register[1]);```

## See Also

- [microsoft.quantum.canon.applytofirsttwoqubits](xref:microsoft.quantum.canon.applytofirsttwoqubits)