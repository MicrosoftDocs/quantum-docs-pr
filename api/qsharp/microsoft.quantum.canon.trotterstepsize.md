---
uid: Microsoft.Quantum.Canon.TrotterStepSize
title: TrotterStepSize function
ms.date: 1/28/2021 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Canon
qsharp.name: TrotterStepSize
qsharp.summary: >-
  Computes Trotter step size in recursive implementation of
  Trotter simulation algorithm.
---

# TrotterStepSize function

Namespace: [Microsoft.Quantum.Canon](xref:Microsoft.Quantum.Canon)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Computes Trotter step size in recursive implementation ofTrotter simulation algorithm.

```qsharp
function TrotterStepSize (order : Int) : Double
```


## Input

### order : [Int](xref:microsoft.quantum.lang-ref.int)





## Output : [Double](xref:microsoft.quantum.lang-ref.double)



## Remarks

This operation uses a different indexing convention than that of[quant-ph/0508139](https://arxiv.org/abs/quant-ph/0508139). Inparticular, `DecomposedIntoTimeStepsCA(_, 4)` corresponds to thescalar $p_2(\lambda)$ in quant-ph/0508139.