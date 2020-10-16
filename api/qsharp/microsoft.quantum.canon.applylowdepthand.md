---
uid: Microsoft.Quantum.Canon.ApplyLowDepthAnd
title: ApplyLowDepthAnd operation
ms.date: 10/16/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Canon
qsharp.name: ApplyLowDepthAnd
qsharp.summary: >-
  Inverts a given target qubit if and only if both control qubits are in
  the 1 state, with T-depth 1, using measurement to perform the adjoint
  operation.
---

# ApplyLowDepthAnd operation

Namespace: [Microsoft.Quantum.Canon](xref:Microsoft.Quantum.Canon)

Package: [](https://nuget.org/packages/)


Inverts a given target qubit if and only if both control qubits are inthe 1 state, with T-depth 1, using measurement to perform the adjointoperation.

```Q#
ApplyLowDepthAnd (control1 : Qubit, control2 : Qubit, target : Qubit) : Unit
```


## Description

Inverts `target` if and only if both controls are 1, but assumes that`target` is in state 0.  The operation has T-count 4, T-depth 1 andrequires one helper qubit, and may therefore be preferable to a CCNOToperation, if `target` is known to be 0.  The adjoint of this operationis measurement based and requires no T gates, and no helper qubit.

## Input

### control1 : Qubit

First control qubit


### control2 : Qubit

Second control qubit


### target : Qubit

Target auxiliary qubit; must be in state 0



## References

- Cody Jones: "Novel constructions for the fault-tolerant Toffoli gate",  Phys. Rev. A 87, 022328, 2013  [arXiv:1212.5069](https://arxiv.org/abs/1212.5069)  doi:10.1103/PhysRevA.87.022328- Peter Selinger: "Quantum circuits of T-depth one",  Phys. Rev. A 87, 042302, 2013  [arXiv:1210.0974](https://arxiv.org/abs/1210.0974)  doi:10.1103/PhysRevA.87.042302