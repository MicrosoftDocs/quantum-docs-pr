---
uid: Microsoft.Quantum.Chemistry.JordanWigner.PrepareSparseMultiConfigurationalState
title: PrepareSparseMultiConfigurationalState operation
ms.date: 10/16/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Chemistry.JordanWigner
qsharp.name: PrepareSparseMultiConfigurationalState
qsharp.summary: >-
  Sparse multi-configurational state preparation of trial state by adding excitations
  to initial trial state.
---

# PrepareSparseMultiConfigurationalState operation

Namespace: [Microsoft.Quantum.Chemistry.JordanWigner](xref:Microsoft.Quantum.Chemistry.JordanWigner)

Package: [](https://nuget.org/packages/)


Sparse multi-configurational state preparation of trial state by adding excitationsto initial trial state.

```Q#
PrepareSparseMultiConfigurationalState (initialStatePreparation : (Qubit[] => Unit), excitations : Microsoft.Quantum.Chemistry.JordanWigner.JordanWignerInputState[], qubits : Qubit[]) : Unit
```


## Input

### initialStatePreparation : Qubit[] => Unit 

Unitary to prepare initial trial state.


### excitations : [JordanWignerInputState](xref:Microsoft.Quantum.Chemistry.JordanWigner.JordanWignerInputState)[]

Excitations of initial trial state represented bythe amplitude of the excitation and the qubit indicesthe excitation acts on.


### qubits : Qubit[]

Qubits of Hamiltonian.

