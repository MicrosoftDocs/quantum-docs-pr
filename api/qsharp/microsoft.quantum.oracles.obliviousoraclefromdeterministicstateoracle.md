---
uid: Microsoft.Quantum.Oracles.ObliviousOracleFromDeterministicStateOracle
title: ObliviousOracleFromDeterministicStateOracle function
ms.date: 12/4/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Oracles
qsharp.name: ObliviousOracleFromDeterministicStateOracle
qsharp.summary: Combines the oracles `DeterministicStateOracle` and `ObliviousOracle`.
---

# ObliviousOracleFromDeterministicStateOracle function

Namespace: [Microsoft.Quantum.Oracles](xref:Microsoft.Quantum.Oracles)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Combines the oracles `DeterministicStateOracle` and `ObliviousOracle`.

```qsharp
function ObliviousOracleFromDeterministicStateOracle (ancillaOracle : Microsoft.Quantum.Oracles.DeterministicStateOracle, signalOracle : Microsoft.Quantum.Oracles.ObliviousOracle) : Microsoft.Quantum.Oracles.ObliviousOracle
```


## Input

### ancillaOracle : [DeterministicStateOracle](xref:Microsoft.Quantum.Oracles.DeterministicStateOracle)

A state preparation oracle $A$ of type `DeterministicStateOracle` acting on register $a$.


### signalOracle : [ObliviousOracle](xref:Microsoft.Quantum.Oracles.ObliviousOracle)

A oracle $U$ of type `ObliviousOracle` acting jointly on register $a,s$.



## Output : [ObliviousOracle](xref:Microsoft.Quantum.Oracles.ObliviousOracle)

An oracle $O=UA$ of type `ObliviousOracle`.

## See Also

- [Microsoft.Quantum.Oracles.DeterministicStateOracle](xref:Microsoft.Quantum.Oracles.DeterministicStateOracle)
- [Microsoft.Quantum.Oracles.ObliviousOracle](xref:Microsoft.Quantum.Oracles.ObliviousOracle)