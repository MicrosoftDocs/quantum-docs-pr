---
uid: Microsoft.Quantum.Canon.ApplyToEachA
title: ApplyToEachA operation
ms.date: 10/31/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Canon
qsharp.name: ApplyToEachA
qsharp.summary: >-
  Applies a single-qubit operation to each element in a register.
  The modifier `A` indicates that the single-qubit operation is adjointable.
---

# ApplyToEachA operation

Namespace: [Microsoft.Quantum.Canon](xref:Microsoft.Quantum.Canon)

Package: [](https://nuget.org/packages/)


Applies a single-qubit operation to each element in a register.The modifier `A` indicates that the single-qubit operation is adjointable.

```qsharp
operation ApplyToEachA<'T> (singleElementOperation : ('T => Unit is Adj), register : 'T[]) : Unit
```


## Input

### singleElementOperation : 'T => [Unit](xref:microsoft.quantum.lang-ref.unit) Adj

Operation to apply to each qubit.


### register : 'T[]

Array of qubits on which to apply the given operation.



## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)



## Type Parameters

### 'T

The target on which the operation acts.

## See Also

- [Microsoft.Quantum.Canon.ApplyToEach](xref:Microsoft.Quantum.Canon.ApplyToEach)