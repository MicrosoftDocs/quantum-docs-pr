---
uid: Microsoft.Quantum.ErrorCorrection.BitFlipRecoveryFn
title: BitFlipRecoveryFn function
ms.date: 11/7/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.ErrorCorrection
qsharp.name: BitFlipRecoveryFn
qsharp.summary: >-
  Function for recovery Pauli operations for given syndrome measurement
  by table lookup for the ⟦3, 1, 1⟧ bit flip code.
---

# BitFlipRecoveryFn function

Namespace: [Microsoft.Quantum.ErrorCorrection](xref:Microsoft.Quantum.ErrorCorrection)

Package: [](https://nuget.org/packages/)


Function for recovery Pauli operations for given syndrome measurementby table lookup for the ⟦3, 1, 1⟧ bit flip code.

```qsharp
function BitFlipRecoveryFn () : Microsoft.Quantum.ErrorCorrection.RecoveryFn
```


## Output : [RecoveryFn](xref:Microsoft.Quantum.ErrorCorrection.RecoveryFn)

Function of type `RecoveryFn` that takes a syndrome measurement`Result[]` and returns the `Pauli[]` operations that corrects thedetected error.

## See Also

- [Microsoft.Quantum.ErrorCorrection.RecoveryFn](xref:Microsoft.Quantum.ErrorCorrection.RecoveryFn)