---
uid: Microsoft.Quantum.Preparation._ApproximatelyUnprepareArbitraryStatePlan
title: _ApproximatelyUnprepareArbitraryStatePlan function
ms.date: 11/1/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Preparation
qsharp.name: _ApproximatelyUnprepareArbitraryStatePlan
qsharp.summary: Implementation step of arbitrary state preparation procedure.
---

# _ApproximatelyUnprepareArbitraryStatePlan function

Namespace: [Microsoft.Quantum.Preparation](xref:Microsoft.Quantum.Preparation)

Package: [](https://nuget.org/packages/)


Implementation step of arbitrary state preparation procedure.

```qsharp
function _ApproximatelyUnprepareArbitraryStatePlan (tolerance : Double, coefficients : Microsoft.Quantum.Math.ComplexPolar[], (rngControl : Range, idxTarget : Int)) : (Qubit[] => Unit is Adj + Ctl)[]
```


## Input

### tolerance : [Double](xref:microsoft.quantum.lang-ref.double)




### coefficients : [ComplexPolar](xref:Microsoft.Quantum.Math.ComplexPolar)[]




### rngControl : [Range](xref:microsoft.quantum.lang-ref.range)




### idxTarget : [Int](xref:microsoft.quantum.lang-ref.int)





## Output : [Qubit](xref:microsoft.quantum.lang-ref.qubit)[] => [Unit](xref:microsoft.quantum.lang-ref.unit) Adj + Ctl[]



## See Also

- [Microsoft.Quantum.Preparation.PrepareArbitraryState](xref:Microsoft.Quantum.Preparation.PrepareArbitraryState)
- [Microsoft.Quantum.Canon.MultiplexPauli](xref:Microsoft.Quantum.Canon.MultiplexPauli)