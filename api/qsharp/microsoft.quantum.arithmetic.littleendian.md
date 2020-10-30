---
uid: Microsoft.Quantum.Arithmetic.LittleEndian
title: LittleEndian user defined type
ms.date: 10/30/2020 12:00:00 AM
ms.topic: article
qsharp.kind: udt
qsharp.namespace: Microsoft.Quantum.Arithmetic
qsharp.name: LittleEndian
qsharp.summary: >-
  Register that encodes an unsigned integer in little-endian order. The
  qubit with index `0` encodes the lowest bit of an unsigned integer.
---

# LittleEndian user defined type

Namespace: [Microsoft.Quantum.Arithmetic](xref:Microsoft.Quantum.Arithmetic)

Package: [](https://nuget.org/packages/)


Register that encodes an unsigned integer in little-endian order. Thequbit with index `0` encodes the lowest bit of an unsigned integer.

```qsharp

newtype LittleEndian = (Qubit[]);
```



## Remarks

We abbreviate `LittleEndian` as `LE` in the documentation.