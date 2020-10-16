---
uid: Microsoft.Quantum.Canon.ApplyPauli
title: ApplyPauli operation
ms.date: 10/16/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Canon
qsharp.name: ApplyPauli
qsharp.summary: >-
  Given a multi-qubit Pauli operator, applies the corresponding operation to
  a register.
---

# ApplyPauli operation

Namespace: [Microsoft.Quantum.Canon](xref:Microsoft.Quantum.Canon)

Package: [](https://nuget.org/packages/)


Given a multi-qubit Pauli operator, applies the corresponding operation toa register.

```Q#
ApplyPauli (pauli : Pauli[], target : Qubit[]) : Unit
```


## Input

### pauli : Pauli[]

A multi-qubit Pauli operator represented as an array of single-qubit Pauli operators.


### target : Qubit[]

Register to apply the given Pauli operation on.

