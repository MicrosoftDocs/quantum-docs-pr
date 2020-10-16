---
uid: Microsoft.Quantum.Arithmetic.PhaseLittleEndian
title: PhaseLittleEndian user defined type
ms.date: 10/16/2020 12:00:00 AM
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

```Q#

newtype PhaseLittleEndian = (Qubit[]);
```



## Remarks

We abbreviate `PhaseLittleEndian` as `PhaseLE` in the documentation.

## See Also

- [Microsoft.Quantum.Arithmetic.QFT](xref:Microsoft.Quantum.Arithmetic.QFT)
- [Microsoft.Quantum.Arithmetic.QFTLE](xref:Microsoft.Quantum.Arithmetic.QFTLE)