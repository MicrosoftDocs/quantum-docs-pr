---
uid: Microsoft.Quantum.Random.BigDiscreteDistribution
title: BigDiscreteDistribution user defined type
ms.date: 11/19/2020 12:00:00 AM
ms.topic: article
qsharp.kind: udt
qsharp.namespace: Microsoft.Quantum.Random
qsharp.name: BigDiscreteDistribution
qsharp.summary: >-
  Represents a univariate probability distribution over integers of
  arbitrary size.
---

# BigDiscreteDistribution user defined type

Namespace: [Microsoft.Quantum.Random](xref:Microsoft.Quantum.Random)

Package: [Microsoft.Quantum.QSharp.Core](https://nuget.org/packages/Microsoft.Quantum.QSharp.Core)


Represents a univariate probability distribution over integers ofarbitrary size.

```qsharp

newtype BigDiscreteDistribution = (Sample : (Unit => BigInt));
```



## Named Items

### Sample : [Unit](xref:microsoft.quantum.lang-ref.unit) => [BigInt](xref:microsoft.quantum.lang-ref.bigint) 



## See Also

- [Microsoft.Quantum.Random.ContinuousDistribution](xref:Microsoft.Quantum.Random.ContinuousDistribution)
- [Microsoft.Quantum.Random.ComplexDistribution](xref:Microsoft.Quantum.Random.ComplexDistribution)
- [Microsoft.Quantum.Random.DiscreteDistribution](xref:Microsoft.Quantum.Random.DiscreteDistribution)