---
uid: Microsoft.Quantum.Canon.ApplyToEach
title: ApplyToEach operation
ms.date: 2/16/2021 12:00:00 AM
ms.topic: managed-reference
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Canon
qsharp.name: ApplyToEach
qsharp.summary: Applies a single-qubit operation to each element in a register.
---

# ApplyToEach operation

Namespace: [Microsoft.Quantum.Canon](xref:Microsoft.Quantum.Canon)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Applies a single-qubit operation to each element in a register.

```qsharp
operation ApplyToEach<'T> (singleElementOperation : ('T => Unit), register : 'T[]) : Unit
```


## Input

### singleElementOperation : 'T => [Unit](xref:microsoft.quantum.lang-ref.unit) 

Operation to apply to each qubit.


### register : 'T[]

Array of qubits on which to apply the given operation.



## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)



## Type Parameters

### 'T

The target on which the operation acts.

## Example

Prepare a three-qubit $\ket{+}$ state:```qsharpusing (register = Qubit[3]) {    ApplyToEach(H, register);}```

## See Also

- [Microsoft.Quantum.Canon.ApplyToEachC](xref:Microsoft.Quantum.Canon.ApplyToEachC)
- [Microsoft.Quantum.Canon.ApplyToEachA](xref:Microsoft.Quantum.Canon.ApplyToEachA)
- [Microsoft.Quantum.Canon.ApplyToEachCA](xref:Microsoft.Quantum.Canon.ApplyToEachCA)