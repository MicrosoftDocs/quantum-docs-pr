---
uid: Microsoft.Quantum.Canon.ApplyCCNOTChain
title: ApplyCCNOTChain operation
ms.date: 12/2/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Canon
qsharp.name: ApplyCCNOTChain
qsharp.summary: >-
  Implements a cascade of CCNOT gates controlled on corresponding bits of two
  qubit registers, acting on the next qubit of one of the registers.
  Starting from the qubits at position 0 in both registers as controls, CCNOT is
  applied to the qubit at position 1 of the target register, then controlled by
  the qubits at position 1 acting on the qubit at position 2 in the target register,
  etc., ending with an action on the target qubit in position `Length(nQubits)-1`.
---

# ApplyCCNOTChain operation

Namespace: [Microsoft.Quantum.Canon](xref:Microsoft.Quantum.Canon)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Implements a cascade of CCNOT gates controlled on corresponding bits of twoqubit registers, acting on the next qubit of one of the registers.Starting from the qubits at position 0 in both registers as controls, CCNOT isapplied to the qubit at position 1 of the target register, then controlled bythe qubits at position 1 acting on the qubit at position 2 in the target register,etc., ending with an action on the target qubit in position `Length(nQubits)-1`.

```qsharp
operation ApplyCCNOTChain (register : Qubit[], targets : Qubit[]) : Unit is Adj + Ctl
```


## Input

### register : [Qubit](xref:microsoft.quantum.lang-ref.qubit)[]

Qubit register, only used for controls.


### targets : [Qubit](xref:microsoft.quantum.lang-ref.qubit)[]

Qubit register, used for controls and as target.



## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)



## Remarks

The target qubit register must have one qubit more than the other register.