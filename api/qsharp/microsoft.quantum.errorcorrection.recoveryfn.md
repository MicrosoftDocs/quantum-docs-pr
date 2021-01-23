---
uid: Microsoft.Quantum.ErrorCorrection.RecoveryFn
title: RecoveryFn user defined type
ms.date: 1/23/2021 12:00:00 AM
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

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Type for function that maps an error syndrome to a sequence of `Pauli[]`operations that correct the detected error.

```qsharp

newtype RecoveryFn = ((Microsoft.Quantum.ErrorCorrection.Syndrome -> Pauli[]));
```

