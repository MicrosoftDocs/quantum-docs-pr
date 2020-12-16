---
uid: Microsoft.Quantum.Chemistry.JordanWigner.JordanWignerFermionImpl
title: JordanWignerFermionImpl operation
ms.date: 12/16/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Chemistry.JordanWigner
qsharp.name: JordanWignerFermionImpl
qsharp.summary: >-
  Represents a dynamical generator as a set of simulatable gates and an
  expansion in the JordanWigner basis.

  See [Dynamical Generator Modeling](../libraries/data-structures#dynamical-generator-modeling)
  for more details.
---

# JordanWignerFermionImpl operation

Namespace: [Microsoft.Quantum.Chemistry.JordanWigner](xref:Microsoft.Quantum.Chemistry.JordanWigner)

Package: [Microsoft.Quantum.Chemistry](https://nuget.org/packages/Microsoft.Quantum.Chemistry)


Represents a dynamical generator as a set of simulatable gates and anexpansion in the JordanWigner basis.See [Dynamical Generator Modeling](../libraries/data-structures#dynamical-generator-modeling)for more details.

```qsharp
operation JordanWignerFermionImpl (generatorIndex : Microsoft.Quantum.Simulation.GeneratorIndex, stepSize : Double, qubits : Qubit[]) : Unit is Adj + Ctl
```


## Input

### generatorIndex : [GeneratorIndex](xref:Microsoft.Quantum.Simulation.GeneratorIndex)

A generator index to be represented as unitary evolution in the JordanWigner.


### stepSize : [Double](xref:microsoft.quantum.lang-ref.double)

A multiplier on the duration of time-evolution by the term referencedin `generatorIndex`.


### qubits : [Qubit](xref:microsoft.quantum.lang-ref.qubit)[]

Register acted upon by time-evolution operator.



## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)

