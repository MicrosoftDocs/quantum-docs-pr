---
uid: Microsoft.Quantum.Research.Chemistry._JWOptimizedPQandPQQRTerm
title: _JWOptimizedPQandPQQRTerm operation
ms.date: 12/15/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Research.Chemistry
qsharp.name: _JWOptimizedPQandPQQRTerm
qsharp.summary: Applies time-evolution by a PQ or PQQR term described by a `GeneratorIndex`.
---

# _JWOptimizedPQandPQQRTerm operation

Namespace: [Microsoft.Quantum.Research.Chemistry](xref:Microsoft.Quantum.Research.Chemistry)

Package: [Microsoft.Quantum.Research.Chemistry](https://nuget.org/packages/Microsoft.Quantum.Research.Chemistry)


Applies time-evolution by a PQ or PQQR term described by a `GeneratorIndex`.

```qsharp
operation _JWOptimizedPQandPQQRTerm (term : Microsoft.Quantum.Simulation.GeneratorIndex, stepSize : Double, parityQubit : Qubit, qubits : Qubit[]) : Unit is Adj + Ctl
```


## Input

### term : [GeneratorIndex](xref:Microsoft.Quantum.Simulation.GeneratorIndex)

`GeneratorIndex` representing a PQ or PQQr term.


### stepSize : [Double](xref:microsoft.quantum.lang-ref.double)

Duration of time-evolution.


### parityQubit : [Qubit](xref:microsoft.quantum.lang-ref.qubit)

Qubit that determines the sign of time-evolution.


### qubits : [Qubit](xref:microsoft.quantum.lang-ref.qubit)[]

Qubits of Hamiltonian.



## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)

