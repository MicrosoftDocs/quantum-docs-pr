---
uid: Microsoft.Quantum.Canon.ApplyToFirstQubitC
title: ApplyToFirstQubitC operation
ms.date: 11/11/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Canon
qsharp.name: ApplyToFirstQubitC
qsharp.summary: >-
  Applies operation op to the first qubit in the register.
  The modifier `C` indicates that the operation is controllable.
---

# ApplyToFirstQubitC operation

Namespace: [Microsoft.Quantum.Canon](xref:Microsoft.Quantum.Canon)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Applies operation op to the first qubit in the register.The modifier `C` indicates that the operation is controllable.

```qsharp
operation ApplyToFirstQubitC (op : (Qubit => Unit is Ctl), register : Qubit[]) : Unit is Ctl
```


## Input

### op : [Qubit](xref:microsoft.quantum.lang-ref.qubit) => [Unit](xref:microsoft.quantum.lang-ref.unit)  is Ctl

An operation to be applied to the first qubit


### register : [Qubit](xref:microsoft.quantum.lang-ref.qubit)[]

Qubit array to the first qubit of which the operation is applied



## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)



## See Also

- [Microsoft.Quantum.Canon.ApplyToFirstQubit](xref:Microsoft.Quantum.Canon.ApplyToFirstQubit)