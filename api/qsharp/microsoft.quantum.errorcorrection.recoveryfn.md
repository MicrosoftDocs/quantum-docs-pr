---
uid: Microsoft.Quantum.ErrorCorrection.RecoveryFn
title: RecoveryFn user defined type
ms.date: 11/10/2020 12:00:00 AM
ms.topic: article
qsharp.kind: udt
qsharp.namespace: Microsoft.Quantum.ErrorCorrection
qsharp.name: RecoveryFn
qsharp.summary: >-
  Type for function that maps an error syndrome to a sequence of `Pauli[]`
  operations that correct the detected error.
---

# RecoveryFn user defined type

Namespace: [Microsoft.Quantum.ErrorCorrection](xref:Microsoft.Quantum.ErrorCorrection)

Package: [](https://nuget.org/packages/)


Type for function that maps an error syndrome to a sequence of `Pauli[]`operations that correct the detected error.

```qsharp

newtype RecoveryFn = ((Microsoft.Quantum.ErrorCorrection.Syndrome -> Pauli[]));
```

