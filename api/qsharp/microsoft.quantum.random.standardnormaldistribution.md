---
uid: Microsoft.Quantum.Random.StandardNormalDistribution
title: StandardNormalDistribution function
ms.date: 1/22/2021 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Random
qsharp.name: StandardNormalDistribution
qsharp.summary: Returns a normal distribution with mean 0 and variance 1.
---

# StandardNormalDistribution function

Namespace: [Microsoft.Quantum.Random](xref:Microsoft.Quantum.Random)

Package: [Microsoft.Quantum.QSharp.Core](https://nuget.org/packages/Microsoft.Quantum.QSharp.Core)


Returns a normal distribution with mean 0 and variance 1.

```qsharp
function StandardNormalDistribution () : Microsoft.Quantum.Random.ContinuousDistribution
```


## Output : [ContinuousDistribution](xref:Microsoft.Quantum.Random.ContinuousDistribution)



## Example

The following draws 10 samples from the standard normal distribution:```Q#let samples = DrawMany((StandardNormalDistribution())::Sample, 10, ());```

## See Also

- [Microsoft.Quantum.Random.NormalDistribution](xref:Microsoft.Quantum.Random.NormalDistribution)