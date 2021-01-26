---
uid: Microsoft.Quantum.Research.Chemistry.ApplyDeltaParity
title: ApplyDeltaParity operation
ms.date: 1/23/2021 12:00:00 AM
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

Package: [Microsoft.Quantum.Research.Chemistry](https://nuget.org/packages/Microsoft.Quantum.Research.Chemistry)


Computes difference in parity between a previous PQRS... termsand the next PQRS... term. This difference is computed on a auxiliaryqubit.

```qsharp
operation ApplyDeltaParity (prevFermionicTerm : Int[], nextFermionicTerm : Int[], aux : Qubit, qubits : Qubit[]) : Unit is Adj + Ctl
```


## Input

### prevFermionicTerm : [Int](xref:microsoft.quantum.lang-ref.int)[]

List of indices to previous PQRS... terms.


### nextFermionicTerm : [Int](xref:microsoft.quantum.lang-ref.int)[]

List of indices to next PQRS... terms.


### aux : [Qubit](xref:microsoft.quantum.lang-ref.qubit)

Auxiliary qubit onto which parity computation results are stored.


### qubits : [Qubit](xref:microsoft.quantum.lang-ref.qubit)[]

Qubit acted on by all PQRS... terms.



## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)



## Remarks

This assumes that indices of P < Q < R < S < ... for both prevPQ and nextPQ.