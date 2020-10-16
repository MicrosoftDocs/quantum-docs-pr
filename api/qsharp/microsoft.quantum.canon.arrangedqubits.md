---
uid: Microsoft.Quantum.Canon.ArrangedQubits
title: ArrangedQubits function
ms.date: 10/16/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Canon
qsharp.name: ArrangedQubits
qsharp.summary: Arrange control, target, and helper qubits according to an index
---

# ArrangedQubits function

Namespace: [Microsoft.Quantum.Canon](xref:Microsoft.Quantum.Canon)

Package: [](https://nuget.org/packages/)


Arrange control, target, and helper qubits according to an index

```Q#
ArrangedQubits (controls : Qubit[], target : Qubit, helper : Qubit[]) : Qubit[]
```


## Description

Returns a Qubit array with target at index 0, and control i at index2^i.  The helper qubits are inserted to all other positions in thearray.