---
uid: Microsoft.Quantum.Arithmetic.SquareI
title: SquareI operation
ms.date: 12/16/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Arithmetic
qsharp.name: SquareI
qsharp.summary: >-
  Computes the square of the integer `xs` into `result`,
  which must be zero initially.
---

# SquareI operation

Namespace: [Microsoft.Quantum.Arithmetic](xref:Microsoft.Quantum.Arithmetic)

Package: [Microsoft.Quantum.Numerics](https://nuget.org/packages/Microsoft.Quantum.Numerics)


Computes the square of the integer `xs` into `result`,which must be zero initially.

```qsharp
operation SquareI (xs : Microsoft.Quantum.Arithmetic.LittleEndian, result : Microsoft.Quantum.Arithmetic.LittleEndian) : Unit is Adj + Ctl
```


## Input

### xs : [LittleEndian](xref:Microsoft.Quantum.Arithmetic.LittleEndian)

$n$-bit number to square (LittleEndian)


### result : [LittleEndian](xref:Microsoft.Quantum.Arithmetic.LittleEndian)

$2n$-bit result (LittleEndian), must be in state $\ket{0}$ initially.



## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)



## Remarks

Uses a standard shift-and-add approach to compute the square. Saves$n-1$ qubits compared to the straight-forward solution which firstcopies out xs before applying a regular multiplier and then undoingthe copy operation.