---
uid: Microsoft.Quantum.Simulation.IdentityTimeDependentGeneratorSystem
title: IdentityTimeDependentGeneratorSystem function
ms.date: 11/9/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Simulation
qsharp.name: IdentityTimeDependentGeneratorSystem
qsharp.summary: >-
  Returns a time-dependent generator system consistent with the
  Hamiltonian `H(s) = 0`.
---

# IdentityTimeDependentGeneratorSystem function

Namespace: [Microsoft.Quantum.Simulation](xref:Microsoft.Quantum.Simulation)

Package: [](https://nuget.org/packages/)


Returns a time-dependent generator system consistent with theHamiltonian `H(s) = 0`.

```qsharp
function IdentityTimeDependentGeneratorSystem () : Microsoft.Quantum.Simulation.TimeDependentGeneratorSystem
```


## Output : [TimeDependentGeneratorSystem](xref:Microsoft.Quantum.Simulation.TimeDependentGeneratorSystem)

A time dependent generator system representing evolution under the Hamiltonian$H(s) = 0$ for all $s$.