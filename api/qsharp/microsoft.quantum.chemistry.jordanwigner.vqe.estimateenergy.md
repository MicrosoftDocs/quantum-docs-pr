---
uid: Microsoft.Quantum.Chemistry.JordanWigner.VQE.EstimateEnergy
title: EstimateEnergy operation
ms.date: 10/26/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Chemistry.JordanWigner.VQE
qsharp.name: EstimateEnergy
qsharp.summary: Estimates the energy of the molecule by summing the energy contributed by the individual Jordan-Wigner terms.
---

# EstimateEnergy operation

Namespace: [Microsoft.Quantum.Chemistry.JordanWigner.VQE](xref:Microsoft.Quantum.Chemistry.JordanWigner.VQE)

Package: [](https://nuget.org/packages/)


Estimates the energy of the molecule by summing the energy contributed by the individual Jordan-Wigner terms.

```qsharp
operation EstimateEnergy (jwHamiltonian : Microsoft.Quantum.Chemistry.JordanWigner.JordanWignerEncodingData, nSamples : Int) : Double
```


## Description

This operation implicitly relies on the spin up-down indexing convention.

## Input

### jwHamiltonian : [JordanWignerEncodingData](xref:Microsoft.Quantum.Chemistry.JordanWigner.JordanWignerEncodingData)

The Jordan-Wigner Hamiltonian.


### nSamples : [Int](xref:microsoft.quantum.lang-ref.int)

The number of samples to use for the estimation of the term expectations.



## Output : [Double](xref:microsoft.quantum.lang-ref.double)

The estimated energy of the molecule