---
uid: Microsoft.Quantum.Arithmetic.CopyMostSignificantBit
title: CopyMostSignificantBit operation
ms.date: 10/16/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Arithmetic
qsharp.name: CopyMostSignificantBit
qsharp.summary: >-
  Copies the most significant bit of a qubit register
  `from` representing an unsigned integer into the qubit `target`.
---

# CopyMostSignificantBit operation

Namespace: [Microsoft.Quantum.Arithmetic](xref:Microsoft.Quantum.Arithmetic)

Package: [](https://nuget.org/packages/)


Copies the most significant bit of a qubit register`from` representing an unsigned integer into the qubit `target`.

```Q#
CopyMostSignificantBit (from : Microsoft.Quantum.Arithmetic.LittleEndian, target : Qubit) : Unit
```


## Input

### from : [LittleEndian](xref:Microsoft.Quantum.Arithmetic.LittleEndian)

The unsigned integer from which the highest bit is copied from.the integer is encoded in little-endian format.


### target : Qubit

The qubit in which the highest bit is being copied. The bit encoding isin computational basis.



## See Also

- [Microsoft.Quantum.Arithmetic.LittleEndian](xref:Microsoft.Quantum.Arithmetic.LittleEndian)