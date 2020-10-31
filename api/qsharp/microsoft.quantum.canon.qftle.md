---
uid: Microsoft.Quantum.Canon.QFTLE
title: QFTLE operation
ms.date: 10/30/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Canon
qsharp.name: QFTLE
qsharp.summary: >-
  Performs the Quantum Fourier Transform on a quantum register containing an
  integer in the little-endian representation.
---

# QFTLE operation

Namespace: [Microsoft.Quantum.Canon](xref:Microsoft.Quantum.Canon)

Package: [](https://nuget.org/packages/)


Performs the Quantum Fourier Transform on a quantum register containing aninteger in the little-endian representation.

```qsharp
operation QFTLE (qs : Microsoft.Quantum.Arithmetic.LittleEndian) : Unit
```


## Input

### qs : [LittleEndian](xref:Microsoft.Quantum.Arithmetic.LittleEndian)

Quantum register to which the Quantum Fourier Transform is applied



## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)



## Remarks

The input and output are assumed to be in little endian encoding.

## See Also

- [Microsoft.Quantum.Canon.QFT](xref:Microsoft.Quantum.Canon.QFT)