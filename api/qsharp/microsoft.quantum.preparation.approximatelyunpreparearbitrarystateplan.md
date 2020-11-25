---
uid: Microsoft.Quantum.Preparation.ApproximatelyUnprepareArbitraryStatePlan
title: ApproximatelyUnprepareArbitraryStatePlan function
ms.date: 11/25/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Preparation
qsharp.name: ApproximatelyUnprepareArbitraryStatePlan
qsharp.summary: Implementation step of arbitrary state preparation procedure.
---

# ApproximatelyUnprepareArbitraryStatePlan function

Namespace: [Microsoft.Quantum.Preparation](xref:Microsoft.Quantum.Preparation)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Implementation step of arbitrary state preparation procedure.

```qsharp
function ApproximatelyUnprepareArbitraryStatePlan (tolerance : Double, coefficients : Microsoft.Quantum.Math.ComplexPolar[], (rngControl : Range, idxTarget : Int)) : (Qubit[] => Unit is Adj + Ctl)[]
```


## Input

### tolerance : [Double](xref:microsoft.quantum.user-guide.language.types)




### coefficients : [ComplexPolar](xref:Microsoft.Quantum.Math.ComplexPolar)[]




### rngControl : [Range](xref:microsoft.quantum.user-guide.language.types)




### idxTarget : [Int](xref:microsoft.quantum.user-guide.language.types)





## Output : [Qubit](xref:microsoft.quantum.concepts.the-qubit)[] => [Unit](xref:microsoft.quantum.user-guide.language.types)  is Adj + Ctl[]



## See Also

- [Microsoft.Quantum.Preparation.PrepareArbitraryState](xref:Microsoft.Quantum.Preparation.PrepareArbitraryState)
- [Microsoft.Quantum.Canon.MultiplexPauli](xref:Microsoft.Quantum.Canon.MultiplexPauli)