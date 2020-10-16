---
uid: Microsoft.Quantum.Oracles.ObliviousOracleFromDeterministicStateOracle
title: ObliviousOracleFromDeterministicStateOracle function
ms.date: 10/16/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Oracles
qsharp.name: ObliviousOracleFromDeterministicStateOracle
qsharp.summary: Combines the oracles `DeterministicStateOracle` and `ObliviousOracle`.
---

# ObliviousOracleFromDeterministicStateOracle function

Namespace: [Microsoft.Quantum.Oracles](xref:Microsoft.Quantum.Oracles)

Package: [](https://nuget.org/packages/)


Combines the oracles `DeterministicStateOracle` and `ObliviousOracle`.

```Q#
ObliviousOracleFromDeterministicStateOracle (ancillaOracle : Microsoft.Quantum.Oracles.DeterministicStateOracle, signalOracle : Microsoft.Quantum.Oracles.ObliviousOracle) : Microsoft.Quantum.Oracles.ObliviousOracle
```


## Input

### ancillaOracle : [DeterministicStateOracle](xref:Microsoft.Quantum.Oracles.DeterministicStateOracle)

A state preparation oracle $A$ of type `DeterministicStateOracle` acting on register $a$.


### signalOracle : [ObliviousOracle](xref:Microsoft.Quantum.Oracles.ObliviousOracle)

A oracle $U$ of type `ObliviousOracle` acting jointly on register $a,s$.



## Output

An oracle $O=UA$ of type `ObliviousOracle`.

## See Also

- [Microsoft.Quantum.Canon.DeterministicStateOracle](xref:Microsoft.Quantum.Canon.DeterministicStateOracle)
- [Microsoft.Quantum.Canon.ObliviousOracle](xref:Microsoft.Quantum.Canon.ObliviousOracle)