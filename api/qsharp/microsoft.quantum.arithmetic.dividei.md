---
uid: Microsoft.Quantum.Arithmetic.DivideI
title: DivideI operation
ms.date: 2/5/2021 12:00:00 AM
ms.topic: managed-reference
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Arithmetic
qsharp.name: DivideI
qsharp.summary: Divides two quantum integers.
---

# DivideI operation

Namespace: [Microsoft.Quantum.Arithmetic](xref:Microsoft.Quantum.Arithmetic)

Package: [Microsoft.Quantum.Numerics](https://nuget.org/packages/Microsoft.Quantum.Numerics)


Divides two quantum integers.

```qsharp
operation DivideI (xs : Microsoft.Quantum.Arithmetic.LittleEndian, ys : Microsoft.Quantum.Arithmetic.LittleEndian, result : Microsoft.Quantum.Arithmetic.LittleEndian) : Unit is Adj + Ctl
```


## Description

`xs` will hold theremainder `xs - floor(xs/ys) * ys` and `result` will hold`floor(xs/ys)`.

## Input

### xs : [LittleEndian](xref:Microsoft.Quantum.Arithmetic.LittleEndian)

$n$-bit dividend, will be replaced by the remainder.


### ys : [LittleEndian](xref:Microsoft.Quantum.Arithmetic.LittleEndian)

$n$-bit divisor


### result : [LittleEndian](xref:Microsoft.Quantum.Arithmetic.LittleEndian)

$n$-bit result, must be in state $\ket{0}$ initiallyand will be replaced by the result of the integer division.



## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)



## Remarks

Uses a standard shift-and-subtract approach to implement the division.The controlled version is specialized such the subtraction does notrequire additional controls.