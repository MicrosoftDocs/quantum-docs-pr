---
uid: Microsoft.Quantum.Canon.ApplyToEachCA
title: ApplyToEachCA operation
ms.date: 10/26/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Canon
qsharp.name: ApplyToEachCA
qsharp.summary: >-
  Applies a single-qubit operation to each element in a register.
  The modifier `CA` indicates that the single-qubit operation is controllable
  and adjointable.
---

# ApplyToEachCA operation

Namespace: [Microsoft.Quantum.Canon](xref:Microsoft.Quantum.Canon)

Package: [](https://nuget.org/packages/)


Applies a single-qubit operation to each element in a register.The modifier `CA` indicates that the single-qubit operation is controllableand adjointable.

```qsharp
operation ApplyToEachCA<'T> (singleElementOperation : ('T => Unit is Adj + Ctl), register : 'T[]) : Unit
```


## Input

### singleElementOperation : 'T => [Unit](xref:microsoft.quantum.lang-ref.unit) Adj + Ctl

Operation to apply to each qubit.


### register : 'T[]

Array of qubits on which to apply the given operation.



## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)



## Type Parameters

### 'T

The target on which the operation acts.

## See Also

- [Microsoft.Quantum.Canon.ApplyToEach](xref:Microsoft.Quantum.Canon.ApplyToEach)