---
uid: Microsoft.Quantum.Canon.ApplyToFirstThreeQubitsC
title: ApplyToFirstThreeQubitsC operation
ms.date: 11/25/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Canon
qsharp.name: ApplyToFirstThreeQubitsC
qsharp.summary: >-
  Applies an operation to the first three qubits in the register.
  The modifier `C` indicates that the operation is controllable.
---

# ApplyToFirstThreeQubitsC operation

Namespace: [Microsoft.Quantum.Canon](xref:Microsoft.Quantum.Canon)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Applies an operation to the first three qubits in the register.The modifier `C` indicates that the operation is controllable.

```qsharp
operation ApplyToFirstThreeQubitsC (op : ((Qubit, Qubit, Qubit) => Unit is Ctl), register : Qubit[]) : Unit is Ctl
```


## Input

### op : ([Qubit](xref:microsoft.quantum.concepts.the-qubit),[Qubit](xref:microsoft.quantum.concepts.the-qubit),[Qubit](xref:microsoft.quantum.concepts.the-qubit)) => [Unit](xref:microsoft.quantum.user-guide.language.types)  is Ctl

An operation to be applied to the first three qubits


### register : [Qubit](xref:microsoft.quantum.concepts.the-qubit)[]

Qubit array to the first three qubits of which the operation is applied.



## Output : [Unit](xref:microsoft.quantum.user-guide.language.types)



## Remarks

This is equivalent to:```qsharpop(register[0], register[1], register[2]);```

## See Also

- [Microsoft.Quantum.Canon.ApplyToFirstThreeQubits](xref:Microsoft.Quantum.Canon.ApplyToFirstThreeQubits)