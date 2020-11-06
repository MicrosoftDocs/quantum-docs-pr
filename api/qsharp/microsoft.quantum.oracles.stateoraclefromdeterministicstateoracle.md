---
uid: Microsoft.Quantum.Oracles.StateOracleFromDeterministicStateOracle
title: StateOracleFromDeterministicStateOracle function
ms.date: 11/6/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Oracles
qsharp.name: StateOracleFromDeterministicStateOracle
qsharp.summary: Converts an oracle of type `DeterministicStateOracle` to `StateOracle`.
---

# StateOracleFromDeterministicStateOracle function

Namespace: [Microsoft.Quantum.Oracles](xref:Microsoft.Quantum.Oracles)

Package: [](https://nuget.org/packages/)


Converts an oracle of type `DeterministicStateOracle` to `StateOracle`.

```qsharp
function StateOracleFromDeterministicStateOracle (deterministicStateOracle : Microsoft.Quantum.Oracles.DeterministicStateOracle) : Microsoft.Quantum.Oracles.StateOracle
```


## Input

### deterministicStateOracle : [DeterministicStateOracle](xref:Microsoft.Quantum.Oracles.DeterministicStateOracle)

A state preparation oracle $A$ of type `DeterministicStateOracle`.



## Output : [StateOracle](xref:Microsoft.Quantum.Oracles.StateOracle)

The same state preparation oracle $A$, but now of type`StateOracle`. Note that the flag index in this `StateOracle` is adummy variable and has no effect.

## See Also

- [Microsoft.Quantum.Oracles.DeterministicStateOracle](xref:Microsoft.Quantum.Oracles.DeterministicStateOracle)
- [Microsoft.Quantum.Oracles.StateOracle](xref:Microsoft.Quantum.Oracles.StateOracle)