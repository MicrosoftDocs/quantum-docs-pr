---
uid: Microsoft.Quantum.Canon.ApplyQuantumFourierTransform
title: ApplyQuantumFourierTransform operation
ms.date: 11/9/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Canon
qsharp.name: ApplyQuantumFourierTransform
qsharp.summary: >-
  Performs the Quantum Fourier Transform on a quantum register containing an
  integer in the little-endian representation.
---

# ApplyQuantumFourierTransform operation

Namespace: [Microsoft.Quantum.Canon](xref:Microsoft.Quantum.Canon)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Performs the Quantum Fourier Transform on a quantum register containing aninteger in the little-endian representation.

```qsharp
operation ApplyQuantumFourierTransform (qs : Microsoft.Quantum.Arithmetic.LittleEndian) : Unit is Adj + Ctl
```


## Input

### qs : [LittleEndian](xref:Microsoft.Quantum.Arithmetic.LittleEndian)

Quantum register to which the Quantum Fourier Transform is applied



## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)



## Remarks

The input and output are assumed to be in little endian encoding.

## See Also

- [Microsoft.Quantum.Canon.ApplyQuantumFourierTransformBE](xref:Microsoft.Quantum.Canon.ApplyQuantumFourierTransformBE)