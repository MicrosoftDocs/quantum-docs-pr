---
uid: Microsoft.Quantum.Characterization.DiscretePhaseEstimationIteration
title: DiscretePhaseEstimationIteration operation
ms.date: 1/28/2021 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Characterization
qsharp.name: DiscretePhaseEstimationIteration
qsharp.summary: >-
  Performs a single iteration of an iterative (classically-controlled) phase
  estimation algorithm using integer powers of a unitary oracle.
---

# DiscretePhaseEstimationIteration operation

Namespace: [Microsoft.Quantum.Characterization](xref:Microsoft.Quantum.Characterization)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Performs a single iteration of an iterative (classically-controlled) phaseestimation algorithm using integer powers of a unitary oracle.

```qsharp
operation DiscretePhaseEstimationIteration (oracle : Microsoft.Quantum.Oracles.DiscreteOracle, power : Int, theta : Double, targetState : Qubit[], controlQubit : Qubit) : Unit is Adj + Ctl
```


## Input

### oracle : [DiscreteOracle](xref:Microsoft.Quantum.Oracles.DiscreteOracle)

Operation acting on an integer and a register,such that $U^m$ is applied to the given register, where $U$ is the unitarywhose phase is to be estimated, and where $m$ is the integer powergiven to the oracle


### power : [Int](xref:microsoft.quantum.lang-ref.int)

Number of times to apply the given unitary oracle.


### theta : [Double](xref:microsoft.quantum.lang-ref.double)

Angle by which to invert the phase on the control qubit beforeacting on the target state.


### targetState : [Qubit](xref:microsoft.quantum.lang-ref.qubit)[]

Register of state acted upon by the given unitary oracle.


### controlQubit : [Qubit](xref:microsoft.quantum.lang-ref.qubit)

An auxiliary qubit used to control the application of the given oracle.



## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)

