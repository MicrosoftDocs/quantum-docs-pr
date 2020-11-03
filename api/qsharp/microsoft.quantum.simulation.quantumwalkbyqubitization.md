---
uid: Microsoft.Quantum.Simulation.QuantumWalkByQubitization
title: QuantumWalkByQubitization function
ms.date: 11/3/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Simulation
qsharp.name: QuantumWalkByQubitization
qsharp.summary: Converts a block-encoding reflection into a quantum walk.
---

# QuantumWalkByQubitization function

Namespace: [Microsoft.Quantum.Simulation](xref:Microsoft.Quantum.Simulation)

Package: [](https://nuget.org/packages/)


Converts a block-encoding reflection into a quantum walk.

```qsharp
function QuantumWalkByQubitization (blockEncoding : Microsoft.Quantum.Simulation.BlockEncodingReflection) : ((Qubit[], Qubit[]) => Unit is Adj + Ctl)
```


## Description

Given a `BlockEncodingReflection` represented by a unitary $U$that encodes some operator $H$ of interest, converts it into a quantumwalk $W$ containing the spectrum of $\pm e^{\pm i\sin^{-1}(H)}$.

## Input

### blockEncoding : [BlockEncodingReflection](xref:Microsoft.Quantum.Simulation.BlockEncodingReflection)

A `BlockEncodingReflection` unitary $U$ to be converted into a Quantumwalk.



## Output : ([Qubit](xref:microsoft.quantum.lang-ref.qubit)[],[Qubit](xref:microsoft.quantum.lang-ref.qubit)[]) => [Unit](xref:microsoft.quantum.lang-ref.unit) Adj + Ctl

A quantum walk $W$ acting jointly on registers `a` and `s` that block-encodes $H$, and contains the spectrum of $\pm e^{\pm i\sin^{-1}(H)}$.

## References

- Hamiltonian Simulation by Qubitization  Guang Hao Low, Isaac L. Chuang  https://arxiv.org/abs/1610.06546

## See Also

- [Microsoft.Quantum.Simulation.BlockEncoding](xref:Microsoft.Quantum.Simulation.BlockEncoding)
- [Microsoft.Quantum.Simulation.BlockEncodingReflection](xref:Microsoft.Quantum.Simulation.BlockEncodingReflection)