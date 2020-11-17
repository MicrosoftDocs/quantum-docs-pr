---
uid: Microsoft.Quantum.Random.ComplexDistribution
title: ComplexDistribution user defined type
ms.date: 11/16/2020 12:00:00 AM
ms.topic: article
qsharp.kind: udt
qsharp.namespace: Microsoft.Quantum.Random
qsharp.name: ComplexDistribution
qsharp.summary: Represents a univariate probability distribution over complex numbers.
---

# ComplexDistribution user defined type

Namespace: [Microsoft.Quantum.Random](xref:Microsoft.Quantum.Random)

Package: [Microsoft.Quantum.QSharp.Core](https://nuget.org/packages/Microsoft.Quantum.QSharp.Core)


Represents a univariate probability distribution over complex numbers.

```qsharp

newtype ComplexDistribution = (Sample : (Unit => Microsoft.Quantum.Math.Complex));
```



## Named Items

### Sample : [Unit](xref:microsoft.quantum.lang-ref.unit) => [Complex](xref:Microsoft.Quantum.Math.Complex) 



## See Also

- [Microsoft.Quantum.Random.ContinuousDistribution](xref:Microsoft.Quantum.Random.ContinuousDistribution)
- [Microsoft.Quantum.Random.DiscreteDistribution](xref:Microsoft.Quantum.Random.DiscreteDistribution)
- [Microsoft.Quantum.Random.BigDiscreteDistribution](xref:Microsoft.Quantum.Random.BigDiscreteDistribution)