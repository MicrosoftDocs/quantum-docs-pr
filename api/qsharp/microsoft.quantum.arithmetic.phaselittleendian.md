---
uid: Microsoft.Quantum.Arithmetic.PhaseLittleEndian
title: PhaseLittleEndian user defined type
ms.date: 11/9/2020 12:00:00 AM
ms.topic: article
qsharp.kind: udt
qsharp.namespace: Microsoft.Quantum.Arithmetic
qsharp.name: PhaseLittleEndian
qsharp.summary: >-
  Little-endian unsigned integers in QFT basis.

  For example, if $\ket{x}$ is the little-endian encoding of the integer
  $x$ in the computational basis,
  then $\operatorname{QFTLE} \ket{x}$ is the encoding of $x$ in the QFT
  basis.
---

# PhaseLittleEndian user defined type

Namespace: [Microsoft.Quantum.Arithmetic](xref:Microsoft.Quantum.Arithmetic)

Package: [](https://nuget.org/packages/)


Little-endian unsigned integers in QFT basis.For example, if $\ket{x}$ is the little-endian encoding of the integer$x$ in the computational basis,then $\operatorname{QFTLE} \ket{x}$ is the encoding of $x$ in the QFTbasis.

```qsharp

newtype PhaseLittleEndian = (Qubit[]);
```



## Remarks

We abbreviate `PhaseLittleEndian` as `PhaseLE` in the documentation.

## See Also

- [Microsoft.Quantum.Canon.QFT](xref:Microsoft.Quantum.Canon.QFT)
- [Microsoft.Quantum.Canon.QFTLE](xref:Microsoft.Quantum.Canon.QFTLE)