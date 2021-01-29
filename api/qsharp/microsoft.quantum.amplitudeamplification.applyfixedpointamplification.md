---
uid: Microsoft.Quantum.AmplitudeAmplification.ApplyFixedPointAmplification
title: ApplyFixedPointAmplification operation
ms.date: 1/29/2021 12:00:00 AM
ms.topic: managed-reference
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.AmplitudeAmplification
qsharp.name: ApplyFixedPointAmplification
qsharp.summary: Fixed-Point Amplitude Amplification algorithm
---

# ApplyFixedPointAmplification operation

Namespace: [Microsoft.Quantum.AmplitudeAmplification](xref:Microsoft.Quantum.AmplitudeAmplification)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Fixed-Point Amplitude Amplification algorithm

```qsharp
operation ApplyFixedPointAmplification (statePrepOracle : Microsoft.Quantum.Oracles.StateOracle, startQubits : Qubit[]) : Unit
```


## Input

### statePrepOracle : [StateOracle](xref:Microsoft.Quantum.Oracles.StateOracle)

Unitary oracle that prepares the start state.


### startQubits : [Qubit](xref:microsoft.quantum.lang-ref.qubit)[]

Qubit register



## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)



## Remarks

The startQubits must be in the $\ket{0 \cdots 0}$ state. This operation iterates over a number of queries in powers of $2$ until either a maximal number of queriesis reached, or the target state is found.