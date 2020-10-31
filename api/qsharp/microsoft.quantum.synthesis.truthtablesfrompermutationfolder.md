---
uid: Microsoft.Quantum.Synthesis.TruthTablesFromPermutationFolder
title: TruthTablesFromPermutationFolder function
ms.date: 10/31/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Synthesis
qsharp.name: TruthTablesFromPermutationFolder
qsharp.summary: Decomposition logic for a single variable index
---

# TruthTablesFromPermutationFolder function

Namespace: [Microsoft.Quantum.Synthesis](xref:Microsoft.Quantum.Synthesis)

Package: [](https://nuget.org/packages/)


Decomposition logic for a single variable index

```qsharp
function TruthTablesFromPermutationFolder (numVars : Int, state : Microsoft.Quantum.Synthesis.DecompositionState, index : Int) : Microsoft.Quantum.Synthesis.DecompositionState
```


## Description

This takes the current state and generates an updated permutationand possibly adds new functions for controlled gates.

## Input

### numVars : [Int](xref:microsoft.quantum.lang-ref.int)




### state : [DecompositionState](xref:Microsoft.Quantum.Synthesis.DecompositionState)




### index : [Int](xref:microsoft.quantum.lang-ref.int)





## Output : [DecompositionState](xref:Microsoft.Quantum.Synthesis.DecompositionState)

