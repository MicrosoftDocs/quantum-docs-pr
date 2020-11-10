---
uid: Microsoft.Quantum.Oracles.DeterministicStateOracleFromStateOracle
title: DeterministicStateOracleFromStateOracle function
ms.date: 10/26/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Oracles
qsharp.name: DeterministicStateOracleFromStateOracle
qsharp.summary: Converts an oracle of type `StateOracle` to `DeterministicStateOracle`.
---

# DeterministicStateOracleFromStateOracle function

Namespace: [Microsoft.Quantum.Oracles](xref:Microsoft.Quantum.Oracles)

Package: [](https://nuget.org/packages/)


Converts an oracle of type `StateOracle` to `DeterministicStateOracle`.

```qsharp
function DeterministicStateOracleFromStateOracle (idxFlagQubit : Int, stateOracle : Microsoft.Quantum.Oracles.StateOracle) : Microsoft.Quantum.Oracles.DeterministicStateOracle
```


## Input

### idxFlagQubit : [Int](xref:microsoft.quantum.lang-ref.int)

The index to the flag qubit of the `stateOracle` $A$,which explicitly acts on two registers: the flag $f$ and the system$s$, e.g. $A\ket{0}\_f\ket{\psi}\_s$.


### stateOracle : [StateOracle](xref:Microsoft.Quantum.Oracles.StateOracle)

A state preparation oracle $A$ of type `StateOracle`.



## Output : [DeterministicStateOracle](xref:Microsoft.Quantum.Oracles.DeterministicStateOracle)

The same state preparation oracle $A$, but now of type`DeterministicStateOracle`, so it acts on a register where $a,s$ nolonger explicitly separate, e.g.  $A\ket{0\psi}\_{as}$.

## See Also

- [Microsoft.Quantum.Oracles.StateOracle](xref:Microsoft.Quantum.Oracles.StateOracle)
- [Microsoft.Quantum.Oracles.DeterministicStateOracle](xref:Microsoft.Quantum.Oracles.DeterministicStateOracle)