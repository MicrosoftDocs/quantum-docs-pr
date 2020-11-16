---
uid: Microsoft.Quantum.Simulation.EstimateEnergy
title: EstimateEnergy operation
ms.date: 11/16/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Simulation
qsharp.name: EstimateEnergy
qsharp.summary: >-
  Performs state preparation by applying a
  `statePrepUnitary` on an automatically allocated input state
  phase estimation with respect to `qpeUnitary`on the resulting state
  using a `phaseEstAlgorithm`.
---

# EstimateEnergy operation

Namespace: [Microsoft.Quantum.Simulation](xref:Microsoft.Quantum.Simulation)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Performs state preparation by applying a`statePrepUnitary` on an automatically allocated input statephase estimation with respect to `qpeUnitary`on the resulting stateusing a `phaseEstAlgorithm`.

```qsharp
operation EstimateEnergy (nQubits : Int, statePrepUnitary : (Qubit[] => Unit), qpeUnitary : (Qubit[] => Unit is Adj + Ctl), phaseEstAlgorithm : ((Microsoft.Quantum.Oracles.DiscreteOracle, Qubit[]) => Double)) : Double
```


## Input

### nQubits : [Int](xref:microsoft.quantum.lang-ref.int)

Number of qubits used to perform simulation.


### statePrepUnitary : [Qubit](xref:microsoft.quantum.lang-ref.qubit)[] => [Unit](xref:microsoft.quantum.lang-ref.unit) 

An oracle representing state preparation for the initial dynamicalgenerator.


### qpeUnitary : [Qubit](xref:microsoft.quantum.lang-ref.qubit)[] => [Unit](xref:microsoft.quantum.lang-ref.unit)  is Adj + Ctl

An oracle representing a unitary operator $U$ representing evolutionfor time $\delta t$ under a dynamical generator with ground state$\ket{\phi}$ and ground state energy $E = \phi\\,\delta t$.


### phaseEstAlgorithm : ([DiscreteOracle](xref:Microsoft.Quantum.Oracles.DiscreteOracle),[Qubit](xref:microsoft.quantum.lang-ref.qubit)[]) => [Double](xref:microsoft.quantum.lang-ref.double) 

An operation that performs phase estimation on a given unitary operation.See [iterative phase estimation](/quantum/libraries/characterization#iterative-phase-estimation)for more details.



## Output : [Double](xref:microsoft.quantum.lang-ref.double)

An estimate $\hat{\phi}$ of the ground state energy $\phi$of the ground state energy of the generator represented by $U$.