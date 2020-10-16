---
uid: Microsoft.Quantum.Synthesis.DecompositionState
title: DecompositionState user defined type
ms.date: 10/16/2020 12:00:00 AM
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

```Q#

newtype DecompositionState = (Perm : Int[], Lfunctions : (BigInt, Int)[], Rfunctions : (BigInt, Int)[]);
```



## Description

The state holds the current permutation and the currently generated functionsfor controlled gates on the left, and controlled gates on the right.