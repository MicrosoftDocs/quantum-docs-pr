---
uid: Microsoft.Quantum.Research.Chemistry._JWOptimized0123Term
title: _JWOptimized0123Term operation
ms.date: 11/11/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Research.Chemistry
qsharp.name: _JWOptimized0123Term
qsharp.summary: Applies time-evolution by a PQRS term described by a `GeneratorIndex`.
---

# _JWOptimized0123Term operation

Namespace: [Microsoft.Quantum.Research.Chemistry](xref:Microsoft.Quantum.Research.Chemistry)

Package: [Microsoft.Quantum.Research.Chemistry](https://nuget.org/packages/Microsoft.Quantum.Research.Chemistry)


Applies time-evolution by a PQRS term described by a `GeneratorIndex`.

```qsharp
operation _JWOptimized0123Term (term : Microsoft.Quantum.Simulation.GeneratorIndex, stepSize : Double, parityQubit : Qubit, qubits : Qubit[]) : Unit is Adj + Ctl
```


## Input

### term : [GeneratorIndex](xref:Microsoft.Quantum.Simulation.GeneratorIndex)

`GeneratorIndex` representing a PQRS term.


### stepSize : [Double](xref:microsoft.quantum.lang-ref.double)

Duration of time-evolution.


### parityQubit : [Qubit](xref:microsoft.quantum.lang-ref.qubit)

Qubit that determines the sign of time-evolution.


### qubits : [Qubit](xref:microsoft.quantum.lang-ref.qubit)[]

Qubits of Hamiltonian.



## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)

