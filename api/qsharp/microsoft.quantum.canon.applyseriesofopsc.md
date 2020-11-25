---
uid: Microsoft.Quantum.Canon.ApplySeriesOfOpsC
title: ApplySeriesOfOpsC operation
ms.date: 11/25/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Canon
qsharp.name: ApplySeriesOfOpsC
qsharp.summary: Applies a list of ops and their targets sequentially on an array. (Controlled)
---

# ApplySeriesOfOpsC operation

Namespace: [Microsoft.Quantum.Canon](xref:Microsoft.Quantum.Canon)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Applies a list of ops and their targets sequentially on an array. (Controlled)

```qsharp
operation ApplySeriesOfOpsC<'T> (listOfOps : ('T[] => Unit is Ctl)[], targets : Int[][], register : 'T[]) : Unit is Ctl
```


## Input

### listOfOps : 'T[] => [Unit](xref:microsoft.quantum.user-guide.language.types)  is Ctl[]

List of ops, each taking a 'T array, to be applied. They are applied sequentially, lowest index first.Each must have a Controlled functor


### targets : [Int](xref:microsoft.quantum.user-guide.language.types)[][]

Nested arrays describing the targets of the op. Each array should contain a list of ints describingthe indices to be used.


### register : 'T[]

Qubit register to be acted upon.



## Output : [Unit](xref:microsoft.quantum.user-guide.language.types)



## Type Parameters

### 'T



## See Also

- [Microsoft.Quantum.Canon.ApplyOpRepeatedlyOver](xref:Microsoft.Quantum.Canon.ApplyOpRepeatedlyOver)