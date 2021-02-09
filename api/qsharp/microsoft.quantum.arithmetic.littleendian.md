---
uid: Microsoft.Quantum.Arithmetic.LittleEndian
title: LittleEndian user defined type
ms.date: 2/9/2021 12:00:00 AM
ms.topic: managed-reference
qsharp.kind: udt
qsharp.namespace: Microsoft.Quantum.Arithmetic
qsharp.name: LittleEndian
qsharp.summary: >-
  Register that encodes an unsigned integer in little-endian order. The
  qubit with index `0` encodes the lowest bit of an unsigned integer.
---

# LittleEndian user defined type

Namespace: [Microsoft.Quantum.Arithmetic](xref:Microsoft.Quantum.Arithmetic)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Register that encodes an unsigned integer in little-endian order. Thequbit with index `0` encodes the lowest bit of an unsigned integer.

```qsharp

newtype LittleEndian = (Qubit[]);
```



## Remarks

We abbreviate `LittleEndian` as `LE` in the documentation.