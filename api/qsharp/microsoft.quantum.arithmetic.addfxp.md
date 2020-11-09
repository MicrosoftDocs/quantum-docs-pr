---
uid: Microsoft.Quantum.Arithmetic.AddFxP
title: AddFxP operation
ms.date: 11/9/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Arithmetic
qsharp.name: AddFxP
qsharp.summary: Adds two fixed-point numbers stored in quantum registers.
---

# AddFxP operation

Namespace: [Microsoft.Quantum.Arithmetic](xref:Microsoft.Quantum.Arithmetic)

Package: [](https://nuget.org/packages/)


Adds two fixed-point numbers stored in quantum registers.

```qsharp
operation AddFxP (fp1 : Microsoft.Quantum.Arithmetic.FixedPoint, fp2 : Microsoft.Quantum.Arithmetic.FixedPoint) : Unit
```


## Description

Given two fixed-point registers respectively in states $\ket{f_1}$ and $\ket{f_2}$,performs the operation $\ket{f_1} \ket{f_2} \mapsto \ket{f_1} \ket{f_1 + f_2}$.

## Input

### fp1 : [FixedPoint](xref:Microsoft.Quantum.Arithmetic.FixedPoint)

First fixed-point number


### fp2 : [FixedPoint](xref:Microsoft.Quantum.Arithmetic.FixedPoint)

Second fixed-point number, will be updated to contain the sum of thetwo inputs.



## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)



## Remarks

The current implementation requires the two fixed-point numbersto have the same point position counting from the least-significantbit, i.e., $n_i$ and $p_i$ must be equal.