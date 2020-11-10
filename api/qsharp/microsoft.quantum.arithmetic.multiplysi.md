---
uid: Microsoft.Quantum.Arithmetic.MultiplySI
title: MultiplySI operation
ms.date: 10/26/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Arithmetic
qsharp.name: MultiplySI
qsharp.summary: >-
  Multiply signed integer `xs` by signed integer `ys` and store
  the result in `result`, which must be zero initially.
---

# MultiplySI operation

Namespace: [Microsoft.Quantum.Arithmetic](xref:Microsoft.Quantum.Arithmetic)

Package: [](https://nuget.org/packages/)


Multiply signed integer `xs` by signed integer `ys` and storethe result in `result`, which must be zero initially.

```qsharp
operation MultiplySI (xs : Microsoft.Quantum.Arithmetic.SignedLittleEndian, ys : Microsoft.Quantum.Arithmetic.SignedLittleEndian, result : Microsoft.Quantum.Arithmetic.SignedLittleEndian) : Unit
```


## Input

### xs : [SignedLittleEndian](xref:Microsoft.Quantum.Arithmetic.SignedLittleEndian)

n-bit multiplicand (SignedLittleEndian)


### ys : [SignedLittleEndian](xref:Microsoft.Quantum.Arithmetic.SignedLittleEndian)

n-bit multiplier (SignedLittleEndian)


### result : [SignedLittleEndian](xref:Microsoft.Quantum.Arithmetic.SignedLittleEndian)

2n-bit result (SignedLittleEndian), must be in state $\ket{0}$initially.



## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)

