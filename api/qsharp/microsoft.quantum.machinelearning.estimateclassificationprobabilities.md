---
uid: Microsoft.Quantum.MachineLearning.EstimateClassificationProbabilities
title: EstimateClassificationProbabilities operation
ms.date: 10/16/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.MachineLearning
qsharp.name: EstimateClassificationProbabilities
qsharp.summary: >-
  Given a set of samples and a sequential classifier, estimates the
  classification probability for those samples by repeatedly measuring
  the output of the classifier on each sample.
---

# EstimateClassificationProbabilities operation

Namespace: [Microsoft.Quantum.MachineLearning](xref:Microsoft.Quantum.MachineLearning)

Package: [](https://nuget.org/packages/)


Given a set of samples and a sequential classifier, estimates theclassification probability for those samples by repeatedly measuringthe output of the classifier on each sample.

```Q#
EstimateClassificationProbabilities (tolerance : Double, model : Microsoft.Quantum.MachineLearning.SequentialModel, samples : Double[][], nMeasurements : Int) : Double[]
```


## Input

### tolerance : Double

The tolerance to allow in encoding the sample into a state preparationoperation.


### model : [SequentialModel](xref:Microsoft.Quantum.MachineLearning.SequentialModel)

The sequential model to be used to estimate the classificationprobabilities for the given samples.


### samples : Double[][]

An array of feature vectors for each sample to be classified.


### nMeasurements : Int

The number of measurements to use in estimating the classificationprobability.



## Output

An array of estimates of the classification probability for each givensample.