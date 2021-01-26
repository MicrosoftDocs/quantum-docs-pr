---
uid: Microsoft.Quantum.AmplitudeAmplification.ApplyAmplitudeAmplification
title: ApplyAmplitudeAmplification operation
ms.date: 1/26/2021 12:00:00 AM
ms.topic: managed-reference
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.AmplitudeAmplification
qsharp.name: ApplyAmplitudeAmplification
qsharp.summary: >-
  Applies amplitude amplification on a given register, using a given set
  of phases and oracles to reflect about the initial and final states.
---

# ApplyAmplitudeAmplification operation

Namespace: [Microsoft.Quantum.AmplitudeAmplification](xref:Microsoft.Quantum.AmplitudeAmplification)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Applies amplitude amplification on a given register, using a given setof phases and oracles to reflect about the initial and final states.

```qsharp
operation ApplyAmplitudeAmplification (phases : Microsoft.Quantum.AmplitudeAmplification.ReflectionPhases, startStateReflection : Microsoft.Quantum.Oracles.ReflectionOracle, targetStateReflection : Microsoft.Quantum.Oracles.ReflectionOracle, target : Qubit[]) : Unit is Adj + Ctl
```


## Input

### phases : [ReflectionPhases](xref:Microsoft.Quantum.AmplitudeAmplification.ReflectionPhases)

A set of phases describing the partial reflections at each step of theamplitude amplification algorithm. See@"microsoft.quantum.amplitudeamplification.standardreflectionphases"for an example.


### startStateReflection : [ReflectionOracle](xref:Microsoft.Quantum.Oracles.ReflectionOracle)

An oracle that reflects about the initial state.


### targetStateReflection : [ReflectionOracle](xref:Microsoft.Quantum.Oracles.ReflectionOracle)

An oracle that reflects about the desired final state.


### target : [Qubit](xref:microsoft.quantum.lang-ref.qubit)[]

A register to perform amplitude amplification on.



## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)

