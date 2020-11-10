---
uid: Microsoft.Quantum.Canon.ApplyMultiplyControlledAnd
title: ApplyMultiplyControlledAnd operation
ms.date: 10/26/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Canon
qsharp.name: ApplyMultiplyControlledAnd
qsharp.summary: >-
  Implements a multiple-controlled Toffoli gate, assuming that target
  qubit is initialized 0.  The adjoint operation assumes that the target
  qubit will be reset to 0.
---

# ApplyMultiplyControlledAnd operation

Namespace: [Microsoft.Quantum.Canon](xref:Microsoft.Quantum.Canon)

Package: [](https://nuget.org/packages/)


Implements a multiple-controlled Toffoli gate, assuming that targetqubit is initialized 0.  The adjoint operation assumes that the targetqubit will be reset to 0.

```qsharp
operation ApplyMultiplyControlledAnd (controls : Qubit[], target : Qubit) : Unit
```


## Input

### controls : [Qubit](xref:microsoft.quantum.lang-ref.qubit)[]

Control qubits


### target : [Qubit](xref:microsoft.quantum.lang-ref.qubit)

Target qubit



## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)

