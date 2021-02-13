---
uid: Microsoft.Quantum.Chemistry.JordanWigner.VQE._prepareTrialStateWrapper
title: _prepareTrialStateWrapper operation
ms.date: 2/13/2021 12:00:00 AM
ms.topic: managed-reference
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Chemistry.JordanWigner.VQE
qsharp.name: _prepareTrialStateWrapper
qsharp.summary: >-
  Private wrapper around PrepareTrialState to make it compatible with EstimateFrequencyA by defining an adjoint.
  EstimateFrequencyA has built-in emulation feature when targeting the QuantumSimulator, which speeds up its execution.
---

# _prepareTrialStateWrapper operation

Namespace: [Microsoft.Quantum.Chemistry.JordanWigner.VQE](xref:Microsoft.Quantum.Chemistry.JordanWigner.VQE)

Package: [Microsoft.Quantum.Chemistry](https://nuget.org/packages/Microsoft.Quantum.Chemistry)


Private wrapper around PrepareTrialState to make it compatible with EstimateFrequencyA by defining an adjoint.EstimateFrequencyA has built-in emulation feature when targeting the QuantumSimulator, which speeds up its execution.

```qsharp
operation _prepareTrialStateWrapper (inputState : (Int, Microsoft.Quantum.Chemistry.JordanWigner.JordanWignerInputState[]), qubits : Qubit[]) : Unit is Adj
```


## Input

### inputState : ([Int](xref:microsoft.quantum.lang-ref.int),[JordanWignerInputState](xref:Microsoft.Quantum.Chemistry.JordanWigner.JordanWignerInputState)[])

The Jordan-Wigner input required for PrepareTrialState to run.


### qubits : [Qubit](xref:microsoft.quantum.lang-ref.qubit)[]

A qubit register.



## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)

