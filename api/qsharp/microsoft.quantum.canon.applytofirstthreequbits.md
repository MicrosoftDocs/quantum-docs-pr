---
uid: Microsoft.Quantum.Canon.ApplyToFirstThreeQubits
title: ApplyToFirstThreeQubits operation
ms.date: 11/25/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Canon
qsharp.name: ApplyToFirstThreeQubits
qsharp.summary: Applies an operation to the first three qubits in the register.
---

# ApplyToFirstThreeQubits operation

Namespace: [Microsoft.Quantum.Canon](xref:Microsoft.Quantum.Canon)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Applies an operation to the first three qubits in the register.

```qsharp
operation ApplyToFirstThreeQubits (op : ((Qubit, Qubit, Qubit) => Unit), register : Qubit[]) : Unit
```


## Input

### op : ([Qubit](xref:microsoft.quantum.concepts.the-qubit),[Qubit](xref:microsoft.quantum.concepts.the-qubit),[Qubit](xref:microsoft.quantum.concepts.the-qubit)) => [Unit](xref:microsoft.quantum.user-guide.language.types) 

An operation to be applied to the first three qubits


### register : [Qubit](xref:microsoft.quantum.concepts.the-qubit)[]

Qubit array to the first three qubits of which the operation is applied.



## Output : [Unit](xref:microsoft.quantum.user-guide.language.types)



## Remarks

This is equivalent to:```qsharpop(register[0], register[1], register[2]);```

## See Also

- [Microsoft.Quantum.Canon.ApplyToFirstThreeQubitsC](xref:Microsoft.Quantum.Canon.ApplyToFirstThreeQubitsC)
- [Microsoft.Quantum.Canon.ApplyToFirstThreeQubitsA](xref:Microsoft.Quantum.Canon.ApplyToFirstThreeQubitsA)
- [Microsoft.Quantum.Canon.ApplyToFirstThreeQubitsCA](xref:Microsoft.Quantum.Canon.ApplyToFirstThreeQubitsCA)