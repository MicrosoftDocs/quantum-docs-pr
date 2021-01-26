---
uid: Microsoft.Quantum.Oracles.ReflectionOracle
title: ReflectionOracle user defined type
ms.date: 1/26/2021 12:00:00 AM
ms.topic: managed-reference
qsharp.kind: udt
qsharp.namespace: Microsoft.Quantum.Oracles
qsharp.name: ReflectionOracle
qsharp.summary: >-
  Represents a reflection oracle.

  A reflection oracle, $O$, has inputs:

  - The phase $\phi$ by which to rotate the reflected subspace.
  - The qubit register on which to perform the given reflection.
---

# ReflectionOracle user defined type

Namespace: [Microsoft.Quantum.Oracles](xref:Microsoft.Quantum.Oracles)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Represents a reflection oracle.A reflection oracle, $O$, has inputs:- The phase $\phi$ by which to rotate the reflected subspace.- The qubit register on which to perform the given reflection.

```qsharp

newtype ReflectionOracle = (ApplyReflection : ((Double, Qubit[]) => Unit is Adj + Ctl));
```



## Named Items

### ApplyReflection : ([Double](xref:microsoft.quantum.lang-ref.double),[Qubit](xref:microsoft.quantum.lang-ref.qubit)[]) => [Unit](xref:microsoft.quantum.lang-ref.unit)  is Adj + Ctl



## Remarks

This oracle $O = \boldone - (1 - e^{i \phi}) \ket{\psi}\bra{\psi}$performs a partial reflection by a phase $\phi$ about a single pure state$\ket{\psi}$.