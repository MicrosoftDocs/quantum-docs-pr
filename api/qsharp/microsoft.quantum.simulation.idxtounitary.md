---
uid: Microsoft.Quantum.Simulation.IdxToUnitary
title: IdxToUnitary function
ms.date: 10/16/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Simulation
qsharp.name: IdxToUnitary
qsharp.summary: Used in implementation of `PauliBlockEncoding`
---

# IdxToUnitary function

Namespace: [Microsoft.Quantum.Simulation](xref:Microsoft.Quantum.Simulation)

Package: [](https://nuget.org/packages/)


Used in implementation of `PauliBlockEncoding`

```Q#
IdxToUnitary (idx : Int, genFun : (Int -> Microsoft.Quantum.Simulation.GeneratorIndex), genIdxToUnitary : (Microsoft.Quantum.Simulation.GeneratorIndex -> (Qubit[] => Unit is Adj + Ctl))) : (Qubit[] => Unit is Adj + Ctl)
```


## See Also

- [Microsoft.Quantum.Canon.PauliBlockEncoding](xref:Microsoft.Quantum.Canon.PauliBlockEncoding)