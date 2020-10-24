---
uid: Microsoft.Quantum.Canon.ApplyToEachIndexCA
title: ApplyToEachIndexCA operation
ms.date: 10/24/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Canon
qsharp.name: ApplyToEachIndexCA
qsharp.summary: >-
  Applies a single-qubit operation to each indexed element in a register.
  The modifier `CA` indicates that the single-qubit operation is adjointable
  and controllable.
---

# ApplyToEachIndexCA operation

Namespace: [Microsoft.Quantum.Canon](xref:Microsoft.Quantum.Canon)

Package: [](https://nuget.org/packages/)


Applies a single-qubit operation to each indexed element in a register.The modifier `CA` indicates that the single-qubit operation is adjointableand controllable.

```qsharp
operation ApplyToEachIndexCA<'T> (singleElementOperation : ((Int, 'T) => Unit is Adj + Ctl), register : 'T[]) : Unit
```


## Input

### singleElementOperation : ([Int](xref:microsoft.quantum.lang-ref.int),'T) => [Unit](xref:microsoft.quantum.lang-ref.unit) Adj + Ctl

Operation to apply to each qubit.


### register : 'T[]

Array of qubits on which to apply the given operation.



## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)



## Type Parameters

### 'T

The target on which each of the operations acts.

## See Also

- [Microsoft.Quantum.Canon.ApplyToEachIndex](xref:Microsoft.Quantum.Canon.ApplyToEachIndex)