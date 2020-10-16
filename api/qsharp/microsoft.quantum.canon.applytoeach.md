---
uid: Microsoft.Quantum.Canon.ApplyToEach
title: ApplyToEach operation
ms.date: 10/16/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Canon
qsharp.name: ApplyToEach
qsharp.summary: Applies a single-qubit operation to each element in a register.
---

# ApplyToEach operation

Namespace: [Microsoft.Quantum.Canon](xref:Microsoft.Quantum.Canon)

Package: [](https://nuget.org/packages/)


Applies a single-qubit operation to each element in a register.

```Q#
ApplyToEach<'T> (singleElementOperation : ('T => Unit), register : 'T[]) : Unit
```


## Input

### singleElementOperation : 'T => Unit 

Operation to apply to each qubit.


### register : 'T[]

Array of qubits on which to apply the given operation.



## Type Parameters

### 'T

The target on which the operation acts.



## See Also

- [Microsoft.Quantum.Canon.ApplyToEachC](xref:Microsoft.Quantum.Canon.ApplyToEachC)
- [Microsoft.Quantum.Canon.ApplyToEachA](xref:Microsoft.Quantum.Canon.ApplyToEachA)
- [Microsoft.Quantum.Canon.ApplyToEachCA](xref:Microsoft.Quantum.Canon.ApplyToEachCA)