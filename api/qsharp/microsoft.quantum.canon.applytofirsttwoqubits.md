---
uid: Microsoft.Quantum.Canon.ApplyToFirstTwoQubits
title: ApplyToFirstTwoQubits operation
ms.date: 10/16/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Canon
qsharp.name: ApplyToFirstTwoQubits
qsharp.summary: Applies an operation to the first two qubits in the register.
---

# ApplyToFirstTwoQubits operation

Namespace: [Microsoft.Quantum.Canon](xref:Microsoft.Quantum.Canon)

Package: [](https://nuget.org/packages/)


Applies an operation to the first two qubits in the register.

```Q#
ApplyToFirstTwoQubits (op : ((Qubit, Qubit) => Unit), register : Qubit[]) : Unit
```


## Input

### op : (Qubit,Qubit) => Unit 

An operation to be applied to the first two qubits


### register : Qubit[]

Qubit array to the first two qubits of which the operation is applied.



## Remarks

This is equivalent to:```qsharpop(register[0], register[1]);```

## See Also

- [microsoft.quantum.canon.applytofirsttwoqubitsa](xref:microsoft.quantum.canon.applytofirsttwoqubitsa)
- [microsoft.quantum.canon.applytofirsttwoqubitsc](xref:microsoft.quantum.canon.applytofirsttwoqubitsc)
- [microsoft.quantum.canon.applytofirsttwoqubitsca](xref:microsoft.quantum.canon.applytofirsttwoqubitsca)