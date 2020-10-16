---
uid: Microsoft.Quantum.Arithmetic.IncrementByInteger
title: IncrementByInteger operation
ms.date: 10/16/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Arithmetic
qsharp.name: IncrementByInteger
qsharp.summary: >-
  Increments an unsigned quantum register by a classical integer,
  using phase rotations.
---

# IncrementByInteger operation

Namespace: [Microsoft.Quantum.Arithmetic](xref:Microsoft.Quantum.Arithmetic)

Package: [](https://nuget.org/packages/)


Increments an unsigned quantum register by a classical integer,using phase rotations.

```Q#
IncrementByInteger (increment : Int, target : Microsoft.Quantum.Arithmetic.LittleEndian) : Unit
```


## Description

Suppose that `target` encodes an unsigned integer $x$ in a little-endianencoding and that `increment` is equal to $a$.Then, this operation implements the unitary $\ket{x} \mapsto \ket{x + a}$,where the addition is performedmodulo $2^n$, where $n = \texttt{Length(target!)}$.

## Input

### target : [LittleEndian](xref:Microsoft.Quantum.Arithmetic.LittleEndian)

A quantum register encoding an unsigned integer using little-endianencoding.


### increment : Int

The integer by which the `target` is incremented by.

