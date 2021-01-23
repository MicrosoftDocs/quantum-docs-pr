---
uid: Microsoft.Quantum.Arithmetic.MultiplyFxP
title: MultiplyFxP operation
ms.date: 1/23/2021 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Arithmetic
qsharp.name: MultiplyFxP
qsharp.summary: Multiplies two fixed-point numbers in quantum registers.
---

# MultiplyFxP operation

Namespace: [Microsoft.Quantum.Arithmetic](xref:Microsoft.Quantum.Arithmetic)

Package: [Microsoft.Quantum.Numerics](https://nuget.org/packages/Microsoft.Quantum.Numerics)


Multiplies two fixed-point numbers in quantum registers.

```qsharp
operation MultiplyFxP (fp1 : Microsoft.Quantum.Arithmetic.FixedPoint, fp2 : Microsoft.Quantum.Arithmetic.FixedPoint, result : Microsoft.Quantum.Arithmetic.FixedPoint) : Unit is Adj + Ctl
```


## Input

### fp1 : [FixedPoint](xref:Microsoft.Quantum.Arithmetic.FixedPoint)

First fixed-point number.


### fp2 : [FixedPoint](xref:Microsoft.Quantum.Arithmetic.FixedPoint)

Second fixed-point number.


### result : [FixedPoint](xref:Microsoft.Quantum.Arithmetic.FixedPoint)

Result fixed-point number, must be in state $\ket{0}$ initially.



## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)



## Remarks

The current implementation requires the three fixed-point numbersto have the same point position and the same number of qubits.