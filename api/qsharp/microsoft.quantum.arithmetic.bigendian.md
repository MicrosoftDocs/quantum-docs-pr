---
uid: Microsoft.Quantum.Arithmetic.BigEndian
title: BigEndian user defined type
ms.date: 10/26/2020 12:00:00 AM
ms.topic: article
qsharp.kind: udt
qsharp.namespace: Microsoft.Quantum.Arithmetic
qsharp.name: BigEndian
qsharp.summary: >-
  Register that encodes an unsigned integer in big-endian order. The
  qubit with index `0` encodes the highest bit of an unsigned integer.
---

# BigEndian user defined type

Namespace: [Microsoft.Quantum.Arithmetic](xref:Microsoft.Quantum.Arithmetic)

Package: [](https://nuget.org/packages/)


Register that encodes an unsigned integer in big-endian order. Thequbit with index `0` encodes the highest bit of an unsigned integer.

```qsharp

newtype BigEndian = (Qubit[]);
```



## Remarks

We abbreviate `BigEndian` as `BE` in the documentation.