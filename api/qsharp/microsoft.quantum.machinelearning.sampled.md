---
uid: Microsoft.Quantum.MachineLearning.Sampled
title: Sampled function
ms.date: 2/6/2021 12:00:00 AM
ms.topic: managed-reference
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.MachineLearning
qsharp.name: Sampled
qsharp.summary: Samples a given array, using the given schedule.
---

# Sampled function

Namespace: [Microsoft.Quantum.MachineLearning](xref:Microsoft.Quantum.MachineLearning)

Package: [Microsoft.Quantum.MachineLearning](https://nuget.org/packages/Microsoft.Quantum.MachineLearning)


Samples a given array, using the given schedule.

```qsharp
function Sampled<'T> (schedule : Microsoft.Quantum.MachineLearning.SamplingSchedule, values : 'T[]) : 'T[]
```


## Input

### schedule : [SamplingSchedule](xref:Microsoft.Quantum.MachineLearning.SamplingSchedule)

A schedule to use in sampling values.


### values : 'T[]

An array of values to be sampled.



## Output : 'T[]

An array of elements from values, following the given schedule.

## Type Parameters

### 'T

