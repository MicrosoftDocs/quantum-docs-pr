---
uid: Microsoft.Quantum.Simulation.PauliBlockEncoding
title: PauliBlockEncoding function
ms.date: 2/4/2021 12:00:00 AM
ms.topic: managed-reference
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Simulation
qsharp.name: PauliBlockEncoding
qsharp.summary: >-
  Creates a block-encoding unitary for a Hamiltonian.

  The Hamiltonian $H=\sum_{j}\alpha_j P_j$ is described by a
  sum of Pauli terms $P_j$, each with real coefficient $\alpha_j$.
---

# PauliBlockEncoding function

Namespace: [Microsoft.Quantum.Simulation](xref:Microsoft.Quantum.Simulation)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Creates a block-encoding unitary for a Hamiltonian.The Hamiltonian $H=\sum_{j}\alpha_j P_j$ is described by asum of Pauli terms $P_j$, each with real coefficient $\alpha_j$.

```qsharp
function PauliBlockEncoding (generatorSystem : Microsoft.Quantum.Simulation.GeneratorSystem) : (Double, Microsoft.Quantum.Simulation.BlockEncodingReflection)
```


## Input

### generatorSystem : [GeneratorSystem](xref:Microsoft.Quantum.Simulation.GeneratorSystem)

A `GeneratorSystem` that describes $H$ as a sum of Pauli terms



## Output : ([Double](xref:microsoft.quantum.lang-ref.double),[BlockEncodingReflection](xref:Microsoft.Quantum.Simulation.BlockEncodingReflection))

## First parameterThe one-norm of coefficients $\alpha=\sum_{j}|\alpha_j|$.## Second parameterA `BlockEncodingReflection` unitary $U$ of the Hamiltonian $H$. As this unitarysatisfies $U^2 = I$, it is also a reflection.

## Remarks

This is obtained by preparing and unpreparing the state $\sum_{j}\sqrt{\alpha_j/\alpha}\ket{j}$,and constructing a multiply-controlled unitary<xref:microsoft.quantum.preparation.statepreparationpositivecoefficients> and<xref:microsoft.quantum.canon.multiplexoperationsfromgenerator>.