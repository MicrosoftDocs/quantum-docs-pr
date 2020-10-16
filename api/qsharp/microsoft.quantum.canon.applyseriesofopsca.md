---
uid: Microsoft.Quantum.Canon.ApplySeriesOfOpsCA
title: ApplySeriesOfOpsCA operation
ms.date: 10/16/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Canon
qsharp.name: ApplySeriesOfOpsCA
qsharp.summary: Applies a list of ops and their targets sequentially on an array. (Adjoint + Controlled)
---

# ApplySeriesOfOpsCA operation

Namespace: [Microsoft.Quantum.Canon](xref:Microsoft.Quantum.Canon)

Package: [](https://nuget.org/packages/)


Applies a list of ops and their targets sequentially on an array. (Adjoint + Controlled)

```Q#
ApplySeriesOfOpsCA<'T> (listOfOps : ('T[] => Unit is Adj + Ctl)[], targets : Int[][], register : 'T[]) : Unit
```


## Input

### listOfOps : 'T[] => Unit Adj + Ctl[]

List of ops, each taking a 'T array, to be applied. They are applied sequentially, lowest index first.Each must have both an Adjoint and Controlled functor.


### targets : Int[][]

Nested arrays describing the targets of the op. Each array should contain a list of ints describingthe indices to be used.


### register : 'T[]

Qubit register to be acted upon.


### Example

// The following applies Exp([PauliX, PauliY], 0.5) to qubits 0, 1// then X to qubit 2let ops = [Exp([PauliX, PauliY], 0.5, _), ApplyToFirstQubitCA(X, _)];let indices = [[0, 1], [2]];ApplySeriesOfOpsCA(ops, indices, qubitArray);



## See Also

- [Microsoft.Quantum.Canon.ApplyOpRepeatedlyOver](xref:Microsoft.Quantum.Canon.ApplyOpRepeatedlyOver)