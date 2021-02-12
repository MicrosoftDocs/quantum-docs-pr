---
uid: Microsoft.Quantum.Preparation.MixedStatePreparation
title: MixedStatePreparation user defined type
ms.date: 2/11/2021 12:00:00 AM
ms.topic: managed-reference
qsharp.kind: udt
qsharp.namespace: Microsoft.Quantum.Preparation
qsharp.name: MixedStatePreparation
qsharp.summary: >-
  Represents a particular mixed state that can be prepared on an index
  and a garbage register.
---

# MixedStatePreparation user defined type

Namespace: [Microsoft.Quantum.Preparation](xref:Microsoft.Quantum.Preparation)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Represents a particular mixed state that can be prepared on an indexand a garbage register.

```qsharp

newtype MixedStatePreparation = (Requirements : Microsoft.Quantum.Preparation.MixedStatePreparationRequirements, Norm : Double, Prepare : ((Microsoft.Quantum.Arithmetic.LittleEndian, Qubit[], Qubit[]) => Unit is Adj + Ctl));
```



## Named Items

### Requirements : [MixedStatePreparationRequirements](xref:Microsoft.Quantum.Preparation.MixedStatePreparationRequirements)


### Norm : [Double](xref:microsoft.quantum.lang-ref.double)


### Prepare : ([LittleEndian](xref:Microsoft.Quantum.Arithmetic.LittleEndian),[Qubit](xref:microsoft.quantum.lang-ref.qubit)[],[Qubit](xref:microsoft.quantum.lang-ref.qubit)[]) => [Unit](xref:microsoft.quantum.lang-ref.unit)  is Adj + Ctl



## See Also

- [Microsoft.Quantum.PurifiedMixedState](xref:Microsoft.Quantum.PurifiedMixedState)