---
uid: Microsoft.Quantum.Simulation.Unitary
title: Unitary user defined type
ms.date: 1/29/2021 12:00:00 AM
ms.topic: managed-reference
qsharp.kind: udt
qsharp.namespace: Microsoft.Quantum.Simulation
qsharp.name: Unitary
qsharp.summary: Represents evolution under a unitary operator.
---

# Unitary user defined type

Namespace: [Microsoft.Quantum.Simulation](xref:Microsoft.Quantum.Simulation)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Represents evolution under a unitary operator.

```qsharp

newtype Unitary = ((Qubit[] => Unit is Adj + Ctl));
```

