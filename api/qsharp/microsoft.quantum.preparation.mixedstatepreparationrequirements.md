---
uid: Microsoft.Quantum.Preparation.MixedStatePreparationRequirements
title: MixedStatePreparationRequirements user defined type
ms.date: 12/4/2020 12:00:00 AM
ms.topic: article
qsharp.kind: udt
qsharp.namespace: Microsoft.Quantum.Preparation
qsharp.name: MixedStatePreparationRequirements
qsharp.summary: >-
  Represents the number of qubits required in order to prepare a given
  mixed state.
---

# MixedStatePreparationRequirements user defined type

Namespace: [Microsoft.Quantum.Preparation](xref:Microsoft.Quantum.Preparation)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Represents the number of qubits required in order to prepare a givenmixed state.

```qsharp

newtype MixedStatePreparationRequirements = (NTotalQubits : Int, (NIndexQubits : Int, NGarbageQubits : Int));
```



## Named Items

### NTotalQubits : [Int](xref:microsoft.quantum.lang-ref.int)


### NIndexQubits : [Int](xref:microsoft.quantum.lang-ref.int)


### NGarbageQubits : [Int](xref:microsoft.quantum.lang-ref.int)



## See Also

- [Microsoft.Quantum.PurifiedMixedState](xref:Microsoft.Quantum.PurifiedMixedState)