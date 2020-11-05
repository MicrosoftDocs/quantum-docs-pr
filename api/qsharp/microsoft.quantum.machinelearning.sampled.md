---
uid: Microsoft.Quantum.MachineLearning.Sampled
title: Sampled function
ms.date: 11/5/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.MachineLearning
qsharp.name: Sampled
qsharp.summary: Samples a given array, using the given schedule.
---

# Sampled function

Namespace: [Microsoft.Quantum.MachineLearning](xref:Microsoft.Quantum.MachineLearning)

Package: [](https://nuget.org/packages/)


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

