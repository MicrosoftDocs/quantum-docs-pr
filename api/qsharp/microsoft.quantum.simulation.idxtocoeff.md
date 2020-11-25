---
uid: Microsoft.Quantum.Simulation.IdxToCoeff
title: IdxToCoeff function
ms.date: 11/25/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Simulation
qsharp.name: IdxToCoeff
qsharp.summary: Used in implementation of `PauliBlockEncoding`
---

# IdxToCoeff function

Namespace: [Microsoft.Quantum.Simulation](xref:Microsoft.Quantum.Simulation)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Used in implementation of `PauliBlockEncoding`

```qsharp
function IdxToCoeff (idx : Int, genFun : (Int -> Microsoft.Quantum.Simulation.GeneratorIndex), genIdxToCoeff : (Microsoft.Quantum.Simulation.GeneratorIndex -> Double)) : Double
```


## Input

### idx : [Int](xref:microsoft.quantum.user-guide.language.types)




### genFun : [Int](xref:microsoft.quantum.user-guide.language.types) -> [GeneratorIndex](xref:Microsoft.Quantum.Simulation.GeneratorIndex)




### genIdxToCoeff : [GeneratorIndex](xref:Microsoft.Quantum.Simulation.GeneratorIndex) -> [Double](xref:microsoft.quantum.user-guide.language.types)





## Output : [Double](xref:microsoft.quantum.user-guide.language.types)



## See Also

- [Microsoft.Quantum.Simulation.PauliBlockEncoding](xref:Microsoft.Quantum.Simulation.PauliBlockEncoding)