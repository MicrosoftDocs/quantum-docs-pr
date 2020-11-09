---
uid: Microsoft.Quantum.Chemistry.JordanWigner.OptimizedBEGeneratorSystem
title: OptimizedBEGeneratorSystem user defined type
ms.date: 11/9/2020 12:00:00 AM
ms.topic: article
qsharp.kind: udt
qsharp.namespace: Microsoft.Quantum.Chemistry.JordanWigner
qsharp.name: OptimizedBEGeneratorSystem
qsharp.summary: >-
  Function that returns `OptimizedBETermIndex` data for term `n` given an
  integer `n`, together with the number of terms in the first `Int` and
  the sum of absolute-values of all term coefficients in the `Double`.
---

# OptimizedBEGeneratorSystem user defined type

Namespace: [Microsoft.Quantum.Chemistry.JordanWigner](xref:Microsoft.Quantum.Chemistry.JordanWigner)

Package: [Microsoft.Quantum.Chemistry](https://nuget.org/packages/Microsoft.Quantum.Chemistry)


Function that returns `OptimizedBETermIndex` data for term `n` given aninteger `n`, together with the number of terms in the first `Int` andthe sum of absolute-values of all term coefficients in the `Double`.

```qsharp

newtype OptimizedBEGeneratorSystem = (Int, Double, (Int -> Microsoft.Quantum.Chemistry.JordanWigner.OptimizedBETermIndex));
```

