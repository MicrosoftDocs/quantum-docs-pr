---
uid: Microsoft.Quantum.Arithmetic.ComputeReciprocalFxP
title: ComputeReciprocalFxP operation
ms.date: 1/23/2021 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Arithmetic
qsharp.name: ComputeReciprocalFxP
qsharp.summary: Computes $1/x$ for a fixed-point number $x$.
---

# ComputeReciprocalFxP operation

Namespace: [Microsoft.Quantum.Arithmetic](xref:Microsoft.Quantum.Arithmetic)

Package: [Microsoft.Quantum.Numerics](https://nuget.org/packages/Microsoft.Quantum.Numerics)


Computes $1/x$ for a fixed-point number $x$.

```qsharp
operation ComputeReciprocalFxP (x : Microsoft.Quantum.Arithmetic.FixedPoint, result : Microsoft.Quantum.Arithmetic.FixedPoint) : Unit is Adj + Ctl
```


## Input

### x : [FixedPoint](xref:Microsoft.Quantum.Arithmetic.FixedPoint)

Fixed-point number to be inverted.


### result : [FixedPoint](xref:Microsoft.Quantum.Arithmetic.FixedPoint)

Fixed-point number that will hold the result. Must be initialized to $\ket{0.0}$.



## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)

