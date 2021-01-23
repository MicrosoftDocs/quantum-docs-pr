---
uid: Microsoft.Quantum.Preparation.PrepareChoiState
title: PrepareChoiState operation
ms.date: 1/23/2021 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Preparation
qsharp.name: PrepareChoiState
qsharp.summary: >-
  Prepares the Choi–Jamiołkowski state for a given operation onto given reference
  and target registers.
---

# PrepareChoiState operation

Namespace: [Microsoft.Quantum.Preparation](xref:Microsoft.Quantum.Preparation)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Prepares the Choi–Jamiołkowski state for a given operation onto given referenceand target registers.

```qsharp
operation PrepareChoiState (op : (Qubit[] => Unit), reference : Qubit[], target : Qubit[]) : Unit
```


## Input

### op : [Qubit](xref:microsoft.quantum.lang-ref.qubit)[] => [Unit](xref:microsoft.quantum.lang-ref.unit) 

Operation $\Lambda$ whose Choi–Jamiołkowski state $J(\Lambda) / 2^N$is to be prepared, where $N$ is the number of qubits on which`op` acts.


### reference : [Qubit](xref:microsoft.quantum.lang-ref.qubit)[]

A register of qubits starting in the $\ket{00\cdots 0}$ stateto be used as a reference for the action of `op`.


### target : [Qubit](xref:microsoft.quantum.lang-ref.qubit)[]

A register of qubits initially in the $\ket{00\cdots 0}$ stateon which `op` is to be applied.



## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)



## Remarks

The Choi–Jamiłkowski state $J(\Lambda)$ of a quantum process isdefined as$$\begin{align}J(\Lambda) \mathrel{:=} (\boldone \otimes \Lambda)(|\boldone\rangle\!\rangle\langle\!\langle\boldone|),\end{align}$$where $|X\rangle\!\rangle$ is the *vectorization* of a matrix $X$in the column-stacking convention. Learning a classical descriptionof this state provides full information about the effect of $\Lambda$acting on arbitrary input states, and forms the foundation of*quantum process tomography*.

## See Also

- [Microsoft.Quantum.Preparation.PrepareChoiStateA](xref:Microsoft.Quantum.Preparation.PrepareChoiStateA)
- [Microsoft.Quantum.Preparation.PrepareChoiStateC](xref:Microsoft.Quantum.Preparation.PrepareChoiStateC)
- [Microsoft.Quantum.Preparation.PrepareChoiStateCA](xref:Microsoft.Quantum.Preparation.PrepareChoiStateCA)