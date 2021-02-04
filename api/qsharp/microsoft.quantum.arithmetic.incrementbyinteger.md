---
uid: Microsoft.Quantum.Arithmetic.IncrementByInteger
title: IncrementByInteger operation
ms.date: 2/4/2021 12:00:00 AM
ms.topic: managed-reference
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Arithmetic
qsharp.name: IncrementByInteger
qsharp.summary: >-
  Increments an unsigned quantum register by a classical integer,
  using phase rotations.
---

# IncrementByInteger operation

Namespace: [Microsoft.Quantum.Arithmetic](xref:Microsoft.Quantum.Arithmetic)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Increments an unsigned quantum register by a classical integer,using phase rotations.

```qsharp
operation IncrementByInteger (increment : Int, target : Microsoft.Quantum.Arithmetic.LittleEndian) : Unit is Adj + Ctl
```


## Description

Suppose that `target` encodes an unsigned integer $x$ in a little-endianencoding and that `increment` is equal to $a$.Then, this operation implements the unitary $\ket{x} \mapsto \ket{x + a}$,where the addition is performedmodulo $2^n$, where $n = \texttt{Length(target!)}$.

## Input

### increment : [Int](xref:microsoft.quantum.lang-ref.int)

The integer by which the `target` is incremented by.


### target : [LittleEndian](xref:Microsoft.Quantum.Arithmetic.LittleEndian)

A quantum register encoding an unsigned integer using little-endianencoding.



## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)

