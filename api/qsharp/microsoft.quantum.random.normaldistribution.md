---
uid: Microsoft.Quantum.Random.NormalDistribution
title: NormalDistribution function
ms.date: 1/26/2021 12:00:00 AM
ms.topic: managed-reference
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Random
qsharp.name: NormalDistribution
qsharp.summary: Returns a normal distribution with a given mean and variance.
---

# NormalDistribution function

Namespace: [Microsoft.Quantum.Random](xref:Microsoft.Quantum.Random)

Package: [Microsoft.Quantum.QSharp.Core](https://nuget.org/packages/Microsoft.Quantum.QSharp.Core)


Returns a normal distribution with a given mean and variance.

```qsharp
function NormalDistribution (mean : Double, variance : Double) : Microsoft.Quantum.Random.ContinuousDistribution
```


## Input

### mean : [Double](xref:microsoft.quantum.lang-ref.double)




### variance : [Double](xref:microsoft.quantum.lang-ref.double)





## Output : [ContinuousDistribution](xref:Microsoft.Quantum.Random.ContinuousDistribution)



## Example

The following draws 10 samples from the normal distribution with mean2 and standard deviation 0.1:```Q#let samples = DrawMany(    (NormalDistribution(2.0, PowD(0.1, 2.0)))::Sample,    10, ());```

## See Also

- [Microsoft.Quantum.Random.StandardNormalDistribution](xref:Microsoft.Quantum.Random.StandardNormalDistribution)