---
uid: Microsoft.Quantum.Canon.ApplyToFirstQubitA
title: ApplyToFirstQubitA operation
ms.date: 11/25/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Canon
qsharp.name: ApplyToFirstQubitA
qsharp.summary: >-
  Applies an operation to the first qubit in the register.
  The modifier `A` indicates that the operation is adjointable.
---

# ApplyToFirstQubitA operation

Namespace: [Microsoft.Quantum.Canon](xref:Microsoft.Quantum.Canon)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Applies an operation to the first qubit in the register.The modifier `A` indicates that the operation is adjointable.

```qsharp
operation ApplyToFirstQubitA (op : (Qubit => Unit is Adj), register : Qubit[]) : Unit is Adj
```


## Input

### op : [Qubit](xref:microsoft.quantum.concepts.the-qubit) => [Unit](xref:microsoft.quantum.user-guide.language.types)  is Adj

An operation to be applied to the first qubit


### register : [Qubit](xref:microsoft.quantum.concepts.the-qubit)[]

Qubit array to the first qubit of which the operation is applied



## Output : [Unit](xref:microsoft.quantum.user-guide.language.types)



## See Also

- [Microsoft.Quantum.Canon.ApplyToFirstQubit](xref:Microsoft.Quantum.Canon.ApplyToFirstQubit)