---
uid: Microsoft.Quantum.Optimization.UnivariateOptimizationResult
title: UnivariateOptimizationResult user defined type
ms.date: 2/12/2021 12:00:00 AM
ms.topic: managed-reference
qsharp.kind: udt
qsharp.namespace: Microsoft.Quantum.Optimization
qsharp.name: UnivariateOptimizationResult
qsharp.summary: Represents the result of optimizing a univariate function.
---

# UnivariateOptimizationResult user defined type

Namespace: [Microsoft.Quantum.Optimization](xref:Microsoft.Quantum.Optimization)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Represents the result of optimizing a univariate function.

```qsharp

newtype UnivariateOptimizationResult = (Coordinate : Double, Value : Double, NQueries : Int);
```



## Named Items

### Coordinate : [Double](xref:microsoft.quantum.lang-ref.double)

Input at which an optimum was found.
### Value : [Double](xref:microsoft.quantum.lang-ref.double)

Value returned by the function at its optimum.
### NQueries : [Int](xref:microsoft.quantum.lang-ref.int)

The amount of times the function was called.