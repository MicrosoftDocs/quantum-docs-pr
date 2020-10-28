---
uid: Microsoft.Quantum.Canon.ApplyToFirstTwoQubits
title: ApplyToFirstTwoQubits operation
ms.date: 10/28/2020 12:00:00 AM
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

```qsharp
operation ApplyToFirstTwoQubits (op : ((Qubit, Qubit) => Unit), register : Qubit[]) : Unit
```


## Input

### op : ([Qubit](xref:microsoft.quantum.lang-ref.qubit),[Qubit](xref:microsoft.quantum.lang-ref.qubit)) => [Unit](xref:microsoft.quantum.lang-ref.unit) 

An operation to be applied to the first two qubits


### register : [Qubit](xref:microsoft.quantum.lang-ref.qubit)[]

Qubit array to the first two qubits of which the operation is applied.



## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)



## Remarks

This is equivalent to:```qsharpop(register[0], register[1]);```

## See Also

- [Microsoft.Quantum.Canon.ApplyToFirstTwoQubitsA](xref:Microsoft.Quantum.Canon.ApplyToFirstTwoQubitsA)
- [Microsoft.Quantum.Canon.ApplyToFirstTwoQubitsC](xref:Microsoft.Quantum.Canon.ApplyToFirstTwoQubitsC)
- [Microsoft.Quantum.Canon.ApplyToFirstTwoQubitsCA](xref:Microsoft.Quantum.Canon.ApplyToFirstTwoQubitsCA)