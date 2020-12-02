---
uid: Microsoft.Quantum.Preparation._PrepareAmplitudesFromZeroState
title: _PrepareAmplitudesFromZeroState operation
ms.date: 12/2/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Preparation
qsharp.name: _PrepareAmplitudesFromZeroState
qsharp.summary: >-
  Given a set of coefficients and a little-endian encoded quantum register
  of unentangled qubits, all of which are in zero state, prepares a state
  on that register described by the given coefficients. Uses state emulation
  if supported by the target.
---

# _PrepareAmplitudesFromZeroState operation

Namespace: [Microsoft.Quantum.Preparation](xref:Microsoft.Quantum.Preparation)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Given a set of coefficients and a little-endian encoded quantum registerof unentangled qubits, all of which are in zero state, prepares a stateon that register described by the given coefficients. Uses state emulationif supported by the target.

```qsharp
operation _PrepareAmplitudesFromZeroState (coefficients : Microsoft.Quantum.Math.ComplexPolar[], qubits : Microsoft.Quantum.Arithmetic.LittleEndian) : Unit
```


## Input

### coefficients : [ComplexPolar](xref:Microsoft.Quantum.Math.ComplexPolar)[]




### qubits : [LittleEndian](xref:Microsoft.Quantum.Arithmetic.LittleEndian)





## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)

