---
uid: Microsoft.Quantum.Research.Chemistry.ApplyDeltaParity
title: ApplyDeltaParity operation
ms.date: 10/16/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Research.Chemistry
qsharp.name: ApplyDeltaParity
qsharp.summary: >-
  Computes difference in parity between a previous PQRS... terms
  and the next PQRS... term. This difference is computed on a auxiliary
  qubit.
---

# ApplyDeltaParity operation

Namespace: [Microsoft.Quantum.Research.Chemistry](xref:Microsoft.Quantum.Research.Chemistry)

Package: [](https://nuget.org/packages/)


Computes difference in parity between a previous PQRS... termsand the next PQRS... term. This difference is computed on a auxiliaryqubit.

```Q#
ApplyDeltaParity (prevFermionicTerm : Int[], nextFermionicTerm : Int[], aux : Qubit, qubits : Qubit[]) : Unit
```


## Input

### prevFermionicTerm : Int[]

List of indices to previous PQRS... terms.


### nextFermionicTerm : Int[]

List of indices to next PQRS... terms.


### aux : Qubit

Auxiliary qubit onto which parity computation results are stored.


### qubits : Qubit[]

Qubit acted on by all PQRS... terms.



## Remarks

This assumes that indices of P < Q < R < S < ... for both prevPQ and nextPQ.