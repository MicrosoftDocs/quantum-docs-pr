---
uid: Microsoft.Quantum.Characterization.DiscretePhaseEstimationIteration
title: DiscretePhaseEstimationIteration operation
ms.date: 10/16/2020 12:00:00 AM
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

Package: [](https://nuget.org/packages/)


Performs a single iteration of an iterative (classically-controlled) phaseestimation algorithm using integer powers of a unitary oracle.

```Q#
DiscretePhaseEstimationIteration (oracle : Microsoft.Quantum.Oracles.DiscreteOracle, power : Int, theta : Double, targetState : Qubit[], controlQubit : Qubit) : Unit
```


## Input

### oracle : [DiscreteOracle](xref:Microsoft.Quantum.Oracles.DiscreteOracle)

Operation acting on an integer and a register,such that $U^m$ is applied to the given register, where $U$ is the unitarywhose phase is to be estimated, and where $m$ is the integer powergiven to the oracle


### power : Int

Number of times to apply the given unitary oracle.


### theta : Double

Angle by which to invert the phase on the control qubit beforeacting on the target state.


### targetState : Qubit[]

Register of state acted upon by the given unitary oracle.


### controlQubit : Qubit

An auxiliary qubit used to control the application of the given oracle.

