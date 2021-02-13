---
uid: Microsoft.Quantum.MachineLearning.ValidateSequentialClassifier
title: ValidateSequentialClassifier operation
ms.date: 2/13/2021 12:00:00 AM
ms.topic: managed-reference
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.MachineLearning
qsharp.name: ValidateSequentialClassifier
qsharp.summary: >-
  Validates a given sequential classifier against a given set of
  pre-labeled samples.
---

# ValidateSequentialClassifier operation

Namespace: [Microsoft.Quantum.MachineLearning](xref:Microsoft.Quantum.MachineLearning)

Package: [Microsoft.Quantum.MachineLearning](https://nuget.org/packages/Microsoft.Quantum.MachineLearning)


Validates a given sequential classifier against a given set ofpre-labeled samples.

```qsharp
operation ValidateSequentialClassifier (model : Microsoft.Quantum.MachineLearning.SequentialModel, samples : Microsoft.Quantum.MachineLearning.LabeledSample[], tolerance : Double, nMeasurements : Int, validationSchedule : Microsoft.Quantum.MachineLearning.SamplingSchedule) : Microsoft.Quantum.MachineLearning.ValidationResults
```


## Input

### model : [SequentialModel](xref:Microsoft.Quantum.MachineLearning.SequentialModel)

The sequential model to be validated.


### samples : [LabeledSample](xref:Microsoft.Quantum.MachineLearning.LabeledSample)[]

The samples to be used to validate the given model.


### tolerance : [Double](xref:microsoft.quantum.lang-ref.double)

The approximation tolerance to use in encoding each sample as an inputto the sequential classifier.


### nMeasurements : [Int](xref:microsoft.quantum.lang-ref.int)

The number of measurements to use in classifying each sample.


### validationSchedule : [SamplingSchedule](xref:Microsoft.Quantum.MachineLearning.SamplingSchedule)

The schedule by which samples should be drawn from the validation set.



## Output : [ValidationResults](xref:Microsoft.Quantum.MachineLearning.ValidationResults)

The results of the given validation.