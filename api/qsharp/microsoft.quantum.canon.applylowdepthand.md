---
uid: Microsoft.Quantum.Canon.ApplyLowDepthAnd
title: ApplyLowDepthAnd operation
ms.date: 2/16/2021 12:00:00 AM
ms.topic: managed-reference
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

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Inverts a given target qubit if and only if both control qubits are inthe 1 state, with T-depth 1, using measurement to perform the adjointoperation.

```qsharp
operation ApplyLowDepthAnd (control1 : Qubit, control2 : Qubit, target : Qubit) : Unit is Adj + Ctl
```


## Description

Inverts `target` if and only if both controls are 1, but assumes that`target` is in state 0.  The operation has T-count 4, T-depth 1 andrequires one helper qubit, and may therefore be preferable to a CCNOToperation, if `target` is known to be 0.  The adjoint of this operationis measurement based and requires no T gates, and no helper qubit.

## Input

### control1 : [Qubit](xref:microsoft.quantum.lang-ref.qubit)

First control qubit


### control2 : [Qubit](xref:microsoft.quantum.lang-ref.qubit)

Second control qubit


### target : [Qubit](xref:microsoft.quantum.lang-ref.qubit)

Target auxiliary qubit; must be in state 0



## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)



## References

- Cody Jones: "Novel constructions for the fault-tolerant Toffoli gate",  Phys. Rev. A 87, 022328, 2013  [arXiv:1212.5069](https://arxiv.org/abs/1212.5069)  doi:10.1103/PhysRevA.87.022328- Peter Selinger: "Quantum circuits of T-depth one",  Phys. Rev. A 87, 042302, 2013  [arXiv:1210.0974](https://arxiv.org/abs/1210.0974)  doi:10.1103/PhysRevA.87.042302