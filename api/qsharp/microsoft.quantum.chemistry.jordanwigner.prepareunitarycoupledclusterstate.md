---
uid: Microsoft.Quantum.Chemistry.JordanWigner.PrepareUnitaryCoupledClusterState
title: PrepareUnitaryCoupledClusterState operation
ms.date: 11/25/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Chemistry.JordanWigner
qsharp.name: PrepareUnitaryCoupledClusterState
qsharp.summary: Unitary coupled-cluster state preparation of trial state
---

# PrepareUnitaryCoupledClusterState operation

Namespace: [Microsoft.Quantum.Chemistry.JordanWigner](xref:Microsoft.Quantum.Chemistry.JordanWigner)

Package: [Microsoft.Quantum.Chemistry](https://nuget.org/packages/Microsoft.Quantum.Chemistry)


Unitary coupled-cluster state preparation of trial state

```qsharp
operation PrepareUnitaryCoupledClusterState (initialStatePreparation : (Qubit[] => Unit), clusterOperator : Microsoft.Quantum.Chemistry.JordanWigner.JordanWignerInputState[], trotterStepSize : Double, qubits : Qubit[]) : Unit
```


## Input

### initialStatePreparation : [Qubit](xref:microsoft.quantum.concepts.the-qubit)[] => [Unit](xref:microsoft.quantum.user-guide.language.types) 

Unitary to prepare initial trial state.


### clusterOperator : [JordanWignerInputState](xref:Microsoft.Quantum.Chemistry.JordanWigner.JordanWignerInputState)[]




### trotterStepSize : [Double](xref:microsoft.quantum.user-guide.language.types)




### qubits : [Qubit](xref:microsoft.quantum.concepts.the-qubit)[]

Qubits of Hamiltonian.



## Output : [Unit](xref:microsoft.quantum.user-guide.language.types)

