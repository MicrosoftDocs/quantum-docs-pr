---
uid: Microsoft.Quantum.Canon.ApplySeriesOfOpsA
title: ApplySeriesOfOpsA operation
ms.date: 12/13/2020 12:00:00 AM
ms.topic: article
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



## See Also

- [Microsoft.Quantum.Canon.ApplyOpRepeatedlyOver](xref:Microsoft.Quantum.Canon.ApplyOpRepeatedlyOver)