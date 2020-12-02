---
uid: Microsoft.Quantum.Arithmetic.EvaluateOddPolynomialFxP
title: EvaluateOddPolynomialFxP operation
ms.date: 12/2/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Arithmetic
qsharp.name: EvaluateOddPolynomialFxP
qsharp.summary: Evaluates an odd polynomial in a fixed-point representation.
---

# EvaluateOddPolynomialFxP operation

Namespace: [Microsoft.Quantum.Arithmetic](xref:Microsoft.Quantum.Arithmetic)

Package: [Microsoft.Quantum.Numerics](https://nuget.org/packages/Microsoft.Quantum.Numerics)


Evaluates an odd polynomial in a fixed-point representation.

```qsharp
operation EvaluateOddPolynomialFxP (coefficients : Double[], fpx : Microsoft.Quantum.Arithmetic.FixedPoint, result : Microsoft.Quantum.Arithmetic.FixedPoint) : Unit is Adj + Ctl
```


## Input

### coefficients : [Double](xref:microsoft.quantum.lang-ref.double)[]

Coefficients of the odd polynomial as a double array, i.e., the array$[a_0, a_1, ..., a_k]$ for the odd polynomial$P(x) = a_0 x + a_1 x^3 + \cdots + a_k x^{2k+1}$.


### fpx : [FixedPoint](xref:Microsoft.Quantum.Arithmetic.FixedPoint)

Input fixed-point number for which to evaluate the polynomial.


### result : [FixedPoint](xref:Microsoft.Quantum.Arithmetic.FixedPoint)

Output fixed-point number which will hold P(x). Must be in state$\ket{0}$ initially.



## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)

