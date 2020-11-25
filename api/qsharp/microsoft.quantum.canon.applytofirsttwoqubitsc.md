---
uid: Microsoft.Quantum.Canon.ApplyToFirstTwoQubitsC
title: ApplyToFirstTwoQubitsC operation
ms.date: 11/25/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Canon
qsharp.name: ApplyToFirstTwoQubitsC
qsharp.summary: >-
  Applies an operation to the first two qubits in the register.
  The modifier `C` indicates that the operation is controllable.
---

# ApplyToFirstTwoQubitsC operation

Namespace: [Microsoft.Quantum.Canon](xref:Microsoft.Quantum.Canon)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Applies an operation to the first two qubits in the register.The modifier `C` indicates that the operation is controllable.

```qsharp
operation ApplyToFirstTwoQubitsC (op : ((Qubit, Qubit) => Unit is Ctl), register : Qubit[]) : Unit is Ctl
```


## Input

### op : ([Qubit](xref:microsoft.quantum.concepts.the-qubit),[Qubit](xref:microsoft.quantum.concepts.the-qubit)) => [Unit](xref:microsoft.quantum.user-guide.language.types)  is Ctl

An operation to be applied to the first two qubits


### register : [Qubit](xref:microsoft.quantum.concepts.the-qubit)[]

Qubit array to the first two qubits of which the operation is applied.



## Output : [Unit](xref:microsoft.quantum.user-guide.language.types)



## Remarks

This is equivalent to:```qsharpop(register[0], register[1]);```

## See Also

- [Microsoft.Quantum.Canon.ApplyToFirstTwoQubits](xref:Microsoft.Quantum.Canon.ApplyToFirstTwoQubits)