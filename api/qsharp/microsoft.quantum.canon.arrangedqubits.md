---
uid: Microsoft.Quantum.Canon.ArrangedQubits
title: ArrangedQubits function
ms.date: 12/9/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Canon
qsharp.name: ArrangedQubits
qsharp.summary: Arrange control, target, and helper qubits according to an index
---

# ArrangedQubits function

Namespace: [Microsoft.Quantum.Canon](xref:Microsoft.Quantum.Canon)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Arrange control, target, and helper qubits according to an index

```qsharp
function ArrangedQubits (controls : Qubit[], target : Qubit, helper : Qubit[]) : Qubit[]
```


## Description

Returns a Qubit array with target at index 0, and control i at index2^i.  The helper qubits are inserted to all other positions in thearray.

## Input

### controls : [Qubit](xref:microsoft.quantum.lang-ref.qubit)[]




### target : [Qubit](xref:microsoft.quantum.lang-ref.qubit)




### helper : [Qubit](xref:microsoft.quantum.lang-ref.qubit)[]





## Output : [Qubit](xref:microsoft.quantum.lang-ref.qubit)[]

