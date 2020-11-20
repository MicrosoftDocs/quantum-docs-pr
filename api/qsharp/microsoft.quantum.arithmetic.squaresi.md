---
uid: Microsoft.Quantum.Arithmetic.SquareSI
title: SquareSI operation
ms.date: 11/20/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Arithmetic
qsharp.name: SquareSI
qsharp.summary: >-
  Square signed integer `xs` and store
  the result in `result`, which must be zero initially.
---

# SquareSI operation

Namespace: [Microsoft.Quantum.Arithmetic](xref:Microsoft.Quantum.Arithmetic)

Package: [Microsoft.Quantum.Numerics](https://nuget.org/packages/Microsoft.Quantum.Numerics)


Square signed integer `xs` and storethe result in `result`, which must be zero initially.

```qsharp
operation SquareSI (xs : Microsoft.Quantum.Arithmetic.SignedLittleEndian, result : Microsoft.Quantum.Arithmetic.SignedLittleEndian) : Unit is Adj + Ctl
```


## Input

### xs : [SignedLittleEndian](xref:Microsoft.Quantum.Arithmetic.SignedLittleEndian)

n-bit integer to square (SignedLittleEndian)


### result : [SignedLittleEndian](xref:Microsoft.Quantum.Arithmetic.SignedLittleEndian)

2n-bit result (SignedLittleEndian), must be in state $\ket{0}$initially.



## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)



## Remarks

The implementation relies on IntegerSquare.