---
uid: Microsoft.Quantum.AmplitudeAmplification.AmpAmpObliviousByOraclePhases
title: AmpAmpObliviousByOraclePhases function
ms.date: 10/26/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.AmplitudeAmplification
qsharp.name: AmpAmpObliviousByOraclePhases
qsharp.summary: >+
  > [!WARNING]

  > AmpAmpObliviousByOraclePhases has been deprecated. Please use <xref:Microsoft.Quantum.AmplitudeAmplification.ObliviousAmplitudeAmplificationFromStatePreparation> instead.

  >

  > Please use @"microsoft.quantum.amplitudeamplification.obliviousamplitudeamplificationfromstatepreparation".

---

# AmpAmpObliviousByOraclePhases function

Namespace: [Microsoft.Quantum.AmplitudeAmplification](xref:Microsoft.Quantum.AmplitudeAmplification)

Package: [](https://nuget.org/packages/)


> [!WARNING]
> AmpAmpObliviousByOraclePhases has been deprecated. Please use <xref:Microsoft.Quantum.AmplitudeAmplification.ObliviousAmplitudeAmplificationFromStatePreparation> instead.
>
> Please use @"microsoft.quantum.amplitudeamplification.obliviousamplitudeamplificationfromstatepreparation".



```qsharp
function AmpAmpObliviousByOraclePhases (phases : Microsoft.Quantum.AmplitudeAmplification.ReflectionPhases, startStateOracle : Microsoft.Quantum.Oracles.DeterministicStateOracle, signalOracle : Microsoft.Quantum.Oracles.ObliviousOracle, idxFlagQubit : Int) : ((Qubit[], Qubit[]) => Unit is Adj + Ctl)
```


## Input

### phases : [ReflectionPhases](xref:Microsoft.Quantum.AmplitudeAmplification.ReflectionPhases)




### startStateOracle : [DeterministicStateOracle](xref:Microsoft.Quantum.Oracles.DeterministicStateOracle)




### signalOracle : [ObliviousOracle](xref:Microsoft.Quantum.Oracles.ObliviousOracle)




### idxFlagQubit : [Int](xref:microsoft.quantum.lang-ref.int)





## Output : ([Qubit](xref:microsoft.quantum.lang-ref.qubit)[],[Qubit](xref:microsoft.quantum.lang-ref.qubit)[]) => [Unit](xref:microsoft.quantum.lang-ref.unit) Adj + Ctl

