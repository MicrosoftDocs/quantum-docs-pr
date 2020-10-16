---
uid: Microsoft.Quantum.Canon.ApplyToEachIndexA
title: ApplyToEachIndexA operation
ms.date: 10/16/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Canon
qsharp.name: ApplyToEachIndexA
qsharp.summary: >-
  Applies a single-qubit operation to each indexed element in a register.
  The modifier `A` indicates that the single-qubit operation is adjointable.
---

# ApplyToEachIndexA operation

Namespace: [Microsoft.Quantum.Canon](xref:Microsoft.Quantum.Canon)

Package: [](https://nuget.org/packages/)


Applies a single-qubit operation to each indexed element in a register.The modifier `A` indicates that the single-qubit operation is adjointable.

```Q#
ApplyToEachIndexA<'T> (singleElementOperation : ((Int, 'T) => Unit is Adj), register : 'T[]) : Unit
```


## Input

### singleElementOperation : (Int,'T) => Unit Adj

Operation to apply to each qubit.


### register : 'T[]

Array of qubits on which to apply the given operation.



## Type Parameters

### 'T

The target on which each of the operations acts.



## See Also

- [Microsoft.Quantum.Canon.ApplyToEachIndex](xref:Microsoft.Quantum.Canon.ApplyToEachIndex)