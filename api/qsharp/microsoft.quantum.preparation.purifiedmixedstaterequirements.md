---
uid: Microsoft.Quantum.Preparation.PurifiedMixedStateRequirements
title: PurifiedMixedStateRequirements function
ms.date: 1/23/2021 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Preparation
qsharp.name: PurifiedMixedStateRequirements
qsharp.summary: >-
  Returns the total number of qubits that must be allocated
  in order to apply the operation returned by
  @"microsoft.quantum.preparation.purifiedmixedstate".
---

# PurifiedMixedStateRequirements function

Namespace: [Microsoft.Quantum.Preparation](xref:Microsoft.Quantum.Preparation)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Returns the total number of qubits that must be allocatedin order to apply the operation returned by@"microsoft.quantum.preparation.purifiedmixedstate".

```qsharp
function PurifiedMixedStateRequirements (targetError : Double, nCoefficients : Int) : Microsoft.Quantum.Preparation.MixedStatePreparationRequirements
```


## Input

### targetError : [Double](xref:microsoft.quantum.lang-ref.double)

The target error $\epsilon$.


### nCoefficients : [Int](xref:microsoft.quantum.lang-ref.int)

The number of coefficients to be specified in preparing a mixed state.



## Output : [MixedStatePreparationRequirements](xref:Microsoft.Quantum.Preparation.MixedStatePreparationRequirements)

A description of how many qubits are required in total, and for each ofthe index and garbage registers used by the@"microsoft.quantum.preparation.purifiedmixedstate" function.

## See Also

- [Microsoft.Quantum.Preparation.PurifiedMixedState](xref:Microsoft.Quantum.Preparation.PurifiedMixedState)