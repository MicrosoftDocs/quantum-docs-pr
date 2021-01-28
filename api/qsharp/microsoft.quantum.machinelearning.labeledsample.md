---
uid: Microsoft.Quantum.MachineLearning.LabeledSample
title: LabeledSample user defined type
ms.date: 1/27/2021 12:00:00 AM
ms.topic: managed-reference
qsharp.kind: udt
qsharp.namespace: Microsoft.Quantum.MachineLearning
qsharp.name: LabeledSample
qsharp.summary: A sample, labeled with a class to which that sample belongs.
---

# LabeledSample user defined type

Namespace: [Microsoft.Quantum.MachineLearning](xref:Microsoft.Quantum.MachineLearning)

Package: [Microsoft.Quantum.MachineLearning](https://nuget.org/packages/Microsoft.Quantum.MachineLearning)


A sample, labeled with a class to which that sample belongs.

```qsharp

newtype LabeledSample = (Features : Double[], Label : Int);
```



## Named Items

### Features : [Double](xref:microsoft.quantum.lang-ref.double)[]

A vector of features for the given sample.
### Label : [Int](xref:microsoft.quantum.lang-ref.int)

An integer label for the class to which this sample belongs.