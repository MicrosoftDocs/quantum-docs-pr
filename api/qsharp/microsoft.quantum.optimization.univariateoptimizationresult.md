---
uid: Microsoft.Quantum.Optimization.UnivariateOptimizationResult
title: UnivariateOptimizationResult user defined type
ms.date: 10/16/2020 12:00:00 AM
ms.topic: article
qsharp.kind: udt
qsharp.namespace: Microsoft.Quantum.Optimization
qsharp.name: UnivariateOptimizationResult
qsharp.summary: Represents the result of optimizing a univariate function.
---

# UnivariateOptimizationResult user defined type

Namespace: [Microsoft.Quantum.Optimization](xref:Microsoft.Quantum.Optimization)

Package: [](https://nuget.org/packages/)


Represents the result of optimizing a univariate function.

```Q#

newtype UnivariateOptimizationResult = (Coordinate : Double, Value : Double);
```



## Named Items

### Coordinate : Double

Input at which an optimum was found.


### Value : Double

Value returned by the function at its optimum.

