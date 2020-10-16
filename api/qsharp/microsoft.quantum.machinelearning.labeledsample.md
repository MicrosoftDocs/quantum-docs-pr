---
uid: Microsoft.Quantum.MachineLearning.LabeledSample
title: LabeledSample user defined type
ms.date: 10/16/2020 12:00:00 AM
ms.topic: article
qsharp.kind: udt
qsharp.namespace: Microsoft.Quantum.MachineLearning
qsharp.name: LabeledSample
qsharp.summary: A sample, labeled with a class to which that sample belongs.
---

# LabeledSample user defined type

Namespace: [Microsoft.Quantum.MachineLearning](xref:Microsoft.Quantum.MachineLearning)

Package: [](https://nuget.org/packages/)


A sample, labeled with a class to which that sample belongs.

```Q#

newtype LabeledSample = (Features : Double[], Label : Int);
```



## Named Items

### Features : Double[]

A vector of features for the given sample.


### Label : Int

An integer label for the class to which this sample belongs.

