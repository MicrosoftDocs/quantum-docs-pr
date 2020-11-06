---
uid: Microsoft.Quantum.Arithmetic.Invert2sSI
title: Invert2sSI operation
ms.date: 11/6/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Arithmetic
qsharp.name: Invert2sSI
qsharp.summary: Inverts a given integer modulo 2's complement.
---

# Invert2sSI operation

Namespace: [Microsoft.Quantum.Arithmetic](xref:Microsoft.Quantum.Arithmetic)

Package: [Microsoft.Quantum.Numerics](https://nuget.org/packages/Microsoft.Quantum.Numerics)


Inverts a given integer modulo 2's complement.

```qsharp
operation Invert2sSI (xs : Microsoft.Quantum.Arithmetic.SignedLittleEndian) : Unit is Adj + Ctl
```


## Input

### xs : [SignedLittleEndian](xref:Microsoft.Quantum.Arithmetic.SignedLittleEndian)

n-bit signed integer (SignedLittleEndian), will be inverted modulo2's complement.



## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)

