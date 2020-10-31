---
uid: Microsoft.Quantum.Synthesis.DecompositionState
title: DecompositionState user defined type
ms.date: 10/31/2020 12:00:00 AM
ms.topic: article
qsharp.kind: udt
qsharp.namespace: Microsoft.Quantum.Synthesis
qsharp.name: DecompositionState
qsharp.summary: State during decomposition based on variable indexes
---

# DecompositionState user defined type

Namespace: [Microsoft.Quantum.Synthesis](xref:Microsoft.Quantum.Synthesis)

Package: [](https://nuget.org/packages/)


State during decomposition based on variable indexes

```qsharp

newtype DecompositionState = (Perm : Int[], Lfunctions : (BigInt, Int)[], Rfunctions : (BigInt, Int)[]);
```



## Named Items

### Perm : [Int](xref:microsoft.quantum.lang-ref.int)[]


### Lfunctions : ([BigInt](xref:microsoft.quantum.lang-ref.bigint),[Int](xref:microsoft.quantum.lang-ref.int))[]


### Rfunctions : ([BigInt](xref:microsoft.quantum.lang-ref.bigint),[Int](xref:microsoft.quantum.lang-ref.int))[]



## Description

The state holds the current permutation and the currently generated functionsfor controlled gates on the left, and controlled gates on the right.