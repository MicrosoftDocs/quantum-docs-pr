---
uid: Microsoft.Quantum.Chemistry.JordanWigner._ApplyJordanWignerPQTerm_
title: _ApplyJordanWignerPQTerm_ operation
ms.date: 10/26/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Chemistry.JordanWigner
qsharp.name: _ApplyJordanWignerPQTerm_
qsharp.summary: Applies time-evolution by a PQ term described by a `GeneratorIndex`.
---

# _ApplyJordanWignerPQTerm_ operation

Namespace: [Microsoft.Quantum.Chemistry.JordanWigner](xref:Microsoft.Quantum.Chemistry.JordanWigner)

Package: [](https://nuget.org/packages/)


Applies time-evolution by a PQ term described by a `GeneratorIndex`.

```qsharp
operation _ApplyJordanWignerPQTerm_ (term : Microsoft.Quantum.Simulation.GeneratorIndex, stepSize : Double, extraParityQubits : Qubit[], qubits : Qubit[]) : Unit
```


## Input

### term : [GeneratorIndex](xref:Microsoft.Quantum.Simulation.GeneratorIndex)

`GeneratorIndex` representing a PQ term.


### stepSize : [Double](xref:microsoft.quantum.lang-ref.double)

Duration of time-evolution.


### extraParityQubits : [Qubit](xref:microsoft.quantum.lang-ref.qubit)[]

Optional parity qubits that flip the sign of time-evolution.


### qubits : [Qubit](xref:microsoft.quantum.lang-ref.qubit)[]

Qubits of Hamiltonian.



## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)

