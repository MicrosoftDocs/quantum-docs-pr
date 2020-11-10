---
uid: Microsoft.Quantum.ErrorCorrection.FiveQubitCodeRecoveryFn
title: FiveQubitCodeRecoveryFn function
ms.date: 10/26/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.ErrorCorrection
qsharp.name: FiveQubitCodeRecoveryFn
qsharp.summary: >-
  Returns function that maps error syndrome measurements to the
  appropriate error-correcting Pauli operators by table lookup for
  the ⟦5, 1, 3⟧ quantum code.
---

# FiveQubitCodeRecoveryFn function

Namespace: [Microsoft.Quantum.ErrorCorrection](xref:Microsoft.Quantum.ErrorCorrection)

Package: [](https://nuget.org/packages/)


Returns function that maps error syndrome measurements to theappropriate error-correcting Pauli operators by table lookup forthe ⟦5, 1, 3⟧ quantum code.

```qsharp
function FiveQubitCodeRecoveryFn () : Microsoft.Quantum.ErrorCorrection.RecoveryFn
```


## Output : [RecoveryFn](xref:Microsoft.Quantum.ErrorCorrection.RecoveryFn)

Function of type `RecoveryFn` that takes a syndrome measurement`Result[]` and returns the `Pauli[]` operators that corrects thedetected error.

## Remarks

By iterating over all errors of weight $1$, we obtain a total of $3\times 5=15$ possible non-trivial syndromes.Together with the identity, a table of error and corresponding syndrome is built up. For the 5 qubit codethis table is given by: $X\_1: (0,0,0,1); X\_2: (1,0,0,0); X\_3: (1,1,0,0); X\_4: (0,1,1,0); X\_5: (0,0,1,1)$,$Z\_1: (1,0,1,0); Z\_2: (0,1,0,1); Z\_3: (0,0,1,0); Z\_4: (1,0,0,1); Z\_5: (0,1,0,0)$ with $Y_i$ obtained by adding the $X_i$ and $Z_i$ syndromes. Note that theordering in the table lookup recovery is given by converting the bitvectors to integers (using little endian).

## See Also

- [Microsoft.Quantum.ErrorCorrection.RecoveryFn](xref:Microsoft.Quantum.ErrorCorrection.RecoveryFn)