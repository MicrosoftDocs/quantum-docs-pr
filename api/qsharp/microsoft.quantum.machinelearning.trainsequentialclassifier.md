---
uid: Microsoft.Quantum.MachineLearning.TrainSequentialClassifier
title: TrainSequentialClassifier operation
ms.date: 2/3/2021 12:00:00 AM
ms.topic: managed-reference
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.MachineLearning
qsharp.name: TrainSequentialClassifier
qsharp.summary: >-
  Given the structure of a sequential classifier, trains the classifier
  on a given labeled training set.
---

# TrainSequentialClassifier operation

Namespace: [Microsoft.Quantum.MachineLearning](xref:Microsoft.Quantum.MachineLearning)

Package: [Microsoft.Quantum.MachineLearning](https://nuget.org/packages/Microsoft.Quantum.MachineLearning)


Given the structure of a sequential classifier, trains the classifieron a given labeled training set.

```qsharp
operation TrainSequentialClassifier (models : Microsoft.Quantum.MachineLearning.SequentialModel[], samples : Microsoft.Quantum.MachineLearning.LabeledSample[], options : Microsoft.Quantum.MachineLearning.TrainingOptions, trainingSchedule : Microsoft.Quantum.MachineLearning.SamplingSchedule, validationSchedule : Microsoft.Quantum.MachineLearning.SamplingSchedule) : (Microsoft.Quantum.MachineLearning.SequentialModel, Int)
```


## Input

### models : [SequentialModel](xref:Microsoft.Quantum.MachineLearning.SequentialModel)[]

An array of models to be used as starting points during training.


### samples : [LabeledSample](xref:Microsoft.Quantum.MachineLearning.LabeledSample)[]

A set of labeled training data that will be used to perform training.


### options : [TrainingOptions](xref:Microsoft.Quantum.MachineLearning.TrainingOptions)

Configuration to be used when training; see@"microsoft.quantum.machinelearning.trainingoptions" and@"microsoft.quantum.machinelearning.defaulttrainingoptions" for moredetails.


### trainingSchedule : [SamplingSchedule](xref:Microsoft.Quantum.MachineLearning.SamplingSchedule)

A sampling schedule to use when selecting samples from the trainingdata during training steps.


### validationSchedule : [SamplingSchedule](xref:Microsoft.Quantum.MachineLearning.SamplingSchedule)

A sampling schedule to use when selecting samples from the trainingdata when selecting which start point resulted in the best classifierscore.



## Output : ([SequentialModel](xref:Microsoft.Quantum.MachineLearning.SequentialModel),[Int](xref:microsoft.quantum.lang-ref.int))

- A parameterization of the given classifier and a bias between the two  classes, together corresponding to the best result from each of the  given start points.- The number of misses observed at the best classifier model.

## See Also

- [Microsoft.Quantum.MachineLearning.TrainSequentialClassifierAtModel](xref:Microsoft.Quantum.MachineLearning.TrainSequentialClassifierAtModel)
- [Microsoft.Quantum.MachineLearning.ValidateSequentialClassifier](xref:Microsoft.Quantum.MachineLearning.ValidateSequentialClassifier)