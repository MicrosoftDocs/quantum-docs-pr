---
uid: Microsoft.Quantum.Optimization.UnivariateOptimizationResult
title: UnivariateOptimizationResult user defined type
ms.date: 11/16/2020 12:00:00 AM
ms.topic: article
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

newtype UnivariateOptimizationResult = (Coordinate : Double, Value : Double);
```



## Named Items

### Coordinate : [Double](xref:microsoft.quantum.lang-ref.double)

Input at which an optimum was found.
### Value : [Double](xref:microsoft.quantum.lang-ref.double)

Value returned by the function at its optimum.