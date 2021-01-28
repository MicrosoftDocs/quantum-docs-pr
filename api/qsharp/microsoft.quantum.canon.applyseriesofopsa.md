---
uid: Microsoft.Quantum.Canon.ApplySeriesOfOpsA
title: ApplySeriesOfOpsA operation
ms.date: 1/28/2021 12:00:00 AM
ms.topic: managed-reference
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Canon
qsharp.name: ApplySeriesOfOpsA
qsharp.summary: Applies a list of ops and their targets sequentially on an array. (Adjoint)
---

# ApplySeriesOfOpsA operation

Namespace: [Microsoft.Quantum.Canon](xref:Microsoft.Quantum.Canon)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Applies a list of ops and their targets sequentially on an array. (Adjoint)

```qsharp
operation ApplySeriesOfOpsA<'T> (listOfOps : ('T[] => Unit is Adj)[], targets : Int[][], register : 'T[]) : Unit is Adj
```


## Input

### listOfOps : 'T[] => [Unit](xref:microsoft.quantum.lang-ref.unit)  is Adj[]

List of ops, each taking a 'T array, to be applied. They are applied sequentially, lowest index first.Each must have an adjoint functor


### targets : [Int](xref:microsoft.quantum.lang-ref.int)[][]

Nested arrays describing the targets of the op. Each array should contain a list of ints describingthe indices to be used.


### register : 'T[]

Qubit register to be acted upon.



## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)



## Type Parameters

### 'T



## Example

// The following applies Exp([PauliX, PauliY], 0.5) to qubits 0, 1// then X to qubit 2let ops = [Exp([PauliX, PauliY], 0.5, _), ApplyToFirstQubitA(X, _)];let indices = [[0, 1], [2]];ApplySeriesOfOpsA(ops, indices, qubitArray);

## See Also

- [Microsoft.Quantum.Canon.ApplyOpRepeatedlyOver](xref:Microsoft.Quantum.Canon.ApplyOpRepeatedlyOver)