---
uid: Microsoft.Quantum.Canon.ApplyToFirstQubitA
title: ApplyToFirstQubitA operation
ms.date: 10/24/2020 12:00:00 AM
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

Package: [](https://nuget.org/packages/)


Applies an operation to the first qubit in the register.The modifier `A` indicates that the operation is adjointable.

```qsharp
operation ApplyToFirstQubitA (op : (Qubit => Unit is Adj), register : Qubit[]) : Unit
```


## Input

### op : [Qubit](xref:microsoft.quantum.lang-ref.qubit) => [Unit](xref:microsoft.quantum.lang-ref.unit) Adj

An operation to be applied to the first qubit


### register : [Qubit](xref:microsoft.quantum.lang-ref.qubit)[]

Qubit array to the first qubit of which the operation is applied



## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)



## See Also

- [Microsoft.Quantum.Canon.ApplyToFirstQubit](xref:Microsoft.Quantum.Canon.ApplyToFirstQubit)