---
uid: Microsoft.Quantum.Simulation._IdentityTimeDependentGeneratorSystem
title: _IdentityTimeDependentGeneratorSystem function
ms.date: 12/8/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Simulation
qsharp.name: _IdentityTimeDependentGeneratorSystem
qsharp.summary: >-
  Returns a generator system consistent with the
  Hamiltonian `H(s) = 0`, where `s` is a schedule parameter.
---

# _IdentityTimeDependentGeneratorSystem function

Namespace: [Microsoft.Quantum.Simulation](xref:Microsoft.Quantum.Simulation)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Returns a generator system consistent with theHamiltonian `H(s) = 0`, where `s` is a schedule parameter.

```qsharp
function _IdentityTimeDependentGeneratorSystem (schedule : Double) : Microsoft.Quantum.Simulation.GeneratorSystem
```


## Input

### schedule : [Double](xref:microsoft.quantum.lang-ref.double)

This input is ignored, and is defined for consistency with the<xref:microsoft.quantum.canon.timedependentgeneratorsystem> user-defined type.



## Output : [GeneratorSystem](xref:Microsoft.Quantum.Simulation.GeneratorSystem)

A generator system representing evolution under the Hamiltonian$H(s) = 0$ for all $s$.