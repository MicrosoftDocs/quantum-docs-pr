---
uid: Microsoft.Quantum.Arithmetic.EvaluatePolynomialFxP
title: EvaluatePolynomialFxP operation
ms.date: 10/26/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Arithmetic
qsharp.name: EvaluatePolynomialFxP
qsharp.summary: Evaluates a polynomial in a fixed-point representation.
---

# EvaluatePolynomialFxP operation

Namespace: [Microsoft.Quantum.Arithmetic](xref:Microsoft.Quantum.Arithmetic)

Package: [](https://nuget.org/packages/)


Evaluates a polynomial in a fixed-point representation.

```qsharp
operation EvaluatePolynomialFxP (coefficients : Double[], fpx : Microsoft.Quantum.Arithmetic.FixedPoint, result : Microsoft.Quantum.Arithmetic.FixedPoint) : Unit
```


## Input

### coefficients : [Double](xref:microsoft.quantum.lang-ref.double)[]

Coefficients of the polynomial as a double array, i.e., the array$[a_0, a_1, ..., a_d]$ for the polynomial$P(x) = a_0 + a_1 x + \cdots + a_d x^d$.


### fpx : [FixedPoint](xref:Microsoft.Quantum.Arithmetic.FixedPoint)

Input fixed-point number for which to evaluate the polynomial.


### result : [FixedPoint](xref:Microsoft.Quantum.Arithmetic.FixedPoint)

Output fixed-point number which will hold $P(x)$. Must be in state$\ket{0}$ initially.



## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)

