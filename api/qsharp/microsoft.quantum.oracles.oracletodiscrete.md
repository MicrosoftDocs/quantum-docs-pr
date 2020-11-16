---
uid: Microsoft.Quantum.Oracles.OracleToDiscrete
title: OracleToDiscrete function
ms.date: 11/16/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Oracles
qsharp.name: OracleToDiscrete
qsharp.summary: >-
  Given an operation representing a "black-box" oracle, returns a discrete-time oracle
  which represents the "black-box" oracle repeated multiple times.
---

# OracleToDiscrete function

Namespace: [Microsoft.Quantum.Oracles](xref:Microsoft.Quantum.Oracles)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Given an operation representing a "black-box" oracle, returns a discrete-time oraclewhich represents the "black-box" oracle repeated multiple times.

```qsharp
function OracleToDiscrete (blackBoxOracle : (Qubit[] => Unit is Adj + Ctl)) : Microsoft.Quantum.Oracles.DiscreteOracle
```


## Input

### blackBoxOracle : [Qubit](xref:microsoft.quantum.lang-ref.qubit)[] => [Unit](xref:microsoft.quantum.lang-ref.unit)  is Adj + Ctl

The operation to be exponentiated.



## Output : [DiscreteOracle](xref:Microsoft.Quantum.Oracles.DiscreteOracle)

An operation partially applied over the "black-box" oracle representing the discrete-time oracle