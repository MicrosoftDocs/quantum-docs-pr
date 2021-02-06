---
uid: Microsoft.Quantum.Arithmetic.ComputeReciprocalI
title: ComputeReciprocalI operation
ms.date: 2/6/2021 12:00:00 AM
ms.topic: managed-reference
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Arithmetic
qsharp.name: ComputeReciprocalI
qsharp.summary: >-
  Computes the reciprocal 1/x for an unsigned integer x
  using integer division. The result, interpreted as an integer,
  will be `floor(2^(2*n-1) / x)`.
---

# ComputeReciprocalI operation

Namespace: [Microsoft.Quantum.Arithmetic](xref:Microsoft.Quantum.Arithmetic)

Package: [Microsoft.Quantum.Numerics](https://nuget.org/packages/Microsoft.Quantum.Numerics)


Computes the reciprocal 1/x for an unsigned integer xusing integer division. The result, interpreted as an integer,will be `floor(2^(2*n-1) / x)`.

```qsharp
operation ComputeReciprocalI (xs : Microsoft.Quantum.Arithmetic.LittleEndian, result : Microsoft.Quantum.Arithmetic.LittleEndian) : Unit is Adj + Ctl
```


## Input

### xs : [LittleEndian](xref:Microsoft.Quantum.Arithmetic.LittleEndian)

n-bit unsigned integer


### result : [LittleEndian](xref:Microsoft.Quantum.Arithmetic.LittleEndian)

2n-bit output, must be in $\ket{0}$ initially.



## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)



## Remarks

For the input x=0, the output will be all-ones.