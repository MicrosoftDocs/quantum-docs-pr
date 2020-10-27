---
uid: Microsoft.Quantum.Optimization.LocalUnivariateMinimum
title: LocalUnivariateMinimum function
ms.date: 10/26/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Optimization
qsharp.name: LocalUnivariateMinimum
qsharp.summary: >-
  Returns the local minimum for a univariate function over a bounded interval,
  using a golden interval search.
---

# LocalUnivariateMinimum function

Namespace: [Microsoft.Quantum.Optimization](xref:Microsoft.Quantum.Optimization)

Package: [](https://nuget.org/packages/)


Returns the local minimum for a univariate function over a bounded interval,using a golden interval search.

```qsharp
function LocalUnivariateMinimum (fn : (Double -> Double), bounds : (Double, Double), tolerance : Double) : Microsoft.Quantum.Optimization.UnivariateOptimizationResult
```


## Input

### fn : [Double](xref:microsoft.quantum.lang-ref.double) -> [Double](xref:microsoft.quantum.lang-ref.double)

The univariate function to be minimized.


### bounds : ([Double](xref:microsoft.quantum.lang-ref.double),[Double](xref:microsoft.quantum.lang-ref.double))

The interval in which the local minimum is to be found.


### tolerance : [Double](xref:microsoft.quantum.lang-ref.double)

The accuracy in the function input to be tolerated.The search for local optima will continue until the interval issmaller in width than this tolerance.



## Output : [UnivariateOptimizationResult](xref:Microsoft.Quantum.Optimization.UnivariateOptimizationResult)

A local optima of the given function, located within the given bounds.