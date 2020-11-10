---
uid: Microsoft.Quantum.Canon.ApplyAnd
title: ApplyAnd operation
ms.date: 11/10/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Canon
qsharp.name: ApplyAnd
qsharp.summary: >-
  Inverts a given target qubit if and only if both control qubits are in the 1 state,
  using measurement to perform the adjoint operation.
---

# ApplyAnd operation

Namespace: [Microsoft.Quantum.Canon](xref:Microsoft.Quantum.Canon)

Package: [](https://nuget.org/packages/)


Inverts a given target qubit if and only if both control qubits are in the 1 state,using measurement to perform the adjoint operation.

```qsharp
operation ApplyAnd (control1 : Qubit, control2 : Qubit, target : Qubit) : Unit
```


## Description

Inverts `target` if and only if both controls are 1, but assumes that`target` is in state 0.  The operation has T-count 4, T-depth 2 andrequires no helper qubit, and may therefore be preferable to a CCNOToperation, if `target` is known to be 0.  The adjoint of this operationis measurement based and requires no T gates.The controlled application of this operation requires no helper qubit,`2^c` `Rz` gates and is not optimized for depth, where `c` is the numberof overall control qubits including the two controls from the `ApplyAnd`operation.  The adjoint controlled application requires `2^c - 1` `Rz`gates (with an angle twice the size of the non-adjoint operation), nohelper qubit and is not optimized for depth.

## Input

### control1 : [Qubit](xref:microsoft.quantum.lang-ref.qubit)

First control qubit


### control2 : [Qubit](xref:microsoft.quantum.lang-ref.qubit)

Second control qubit


### target : [Qubit](xref:microsoft.quantum.lang-ref.qubit)

Target auxiliary qubit; must be in state 0



## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)



## References

- Cody Jones: "Novel constructions for the fault-tolerant Toffoli gate",  Phys. Rev. A 87, 022328, 2013  [arXiv:1212.5069](https://arxiv.org/abs/1212.5069)  doi:10.1103/PhysRevA.87.022328- Craig Gidney: "Halving the cost of quantum addition", Quantum 2, page  74, 2018  [arXiv:1709.06648](https://arxiv.org/abs/1709.06648)  doi:10.1103/PhysRevA.85.044302- Mathias Soeken: "Quantum Oracle Circuits and the Christmas Tree Pattern",  [Blog article from December 19, 2019](https://msoeken.github.io/blog_qac.html)  (note: explains the multiple controlled construction)