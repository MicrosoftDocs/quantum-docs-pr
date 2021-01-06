---
uid: Microsoft.Quantum.Oracles.ReflectionOracleFromDeterministicStateOracle
title: ReflectionOracleFromDeterministicStateOracle function
ms.date: 1/5/2021 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Oracles
qsharp.name: ReflectionOracleFromDeterministicStateOracle
qsharp.summary: Constructs reflection about a given state from an oracle.
---

# ReflectionOracleFromDeterministicStateOracle function

Namespace: [Microsoft.Quantum.Oracles](xref:Microsoft.Quantum.Oracles)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Constructs reflection about a given state from an oracle.

```qsharp
function ReflectionOracleFromDeterministicStateOracle (oracle : Microsoft.Quantum.Oracles.DeterministicStateOracle) : Microsoft.Quantum.Oracles.ReflectionOracle
```


## Description

Given a deterministic state preparation oracle represented by a unitarymatrix $O$,the result of this function is an oracle that applies a reflectionaround the state $\ket{\psi}$ prepared by the oracle $O$; that is,the state $\ket{\psi}$ such that $O\ket{0} = \ket{\psi}$.

## Input

### oracle : [DeterministicStateOracle](xref:Microsoft.Quantum.Oracles.DeterministicStateOracle)

An oracle that prepares copies of the state $\ket{\psi}$.



## Output : [ReflectionOracle](xref:Microsoft.Quantum.Oracles.ReflectionOracle)

An oracle that reflects about the state $\ket{\psi}$.

## See Also

- [Microsoft.Quantum.Oracles.DeterministicStateOracle](xref:Microsoft.Quantum.Oracles.DeterministicStateOracle)
- [Microsoft.Quantum.Oracles.ReflectionOracle](xref:Microsoft.Quantum.Oracles.ReflectionOracle)