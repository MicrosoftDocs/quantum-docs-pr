---
uid: Microsoft.Quantum.MachineLearning.TrainingOptions
title: TrainingOptions user defined type
ms.date: 1/29/2021 12:00:00 AM
ms.topic: managed-reference
qsharp.kind: udt
qsharp.namespace: Microsoft.Quantum.MachineLearning
qsharp.name: TrainingOptions
qsharp.summary: A collection of options to be used in training quantum classifiers.
---

# TrainingOptions user defined type

Namespace: [Microsoft.Quantum.MachineLearning](xref:Microsoft.Quantum.MachineLearning)

Package: [Microsoft.Quantum.MachineLearning](https://nuget.org/packages/Microsoft.Quantum.MachineLearning)


A collection of options to be used in training quantum classifiers.

```qsharp

newtype TrainingOptions = (LearningRate : Double, Tolerance : Double, MinibatchSize : Int, NMeasurements : Int, MaxEpochs : Int, MaxStalls : Int, StochasticRescaleFactor : Double, ScoringPeriod : Int, VerboseMessage : (String -> Unit));
```



## Named Items

### LearningRate : [Double](xref:microsoft.quantum.lang-ref.double)

The learning rate by which gradients should be rescaled when updatingmodel parameters during training steps.
### Tolerance : [Double](xref:microsoft.quantum.lang-ref.double)

The approximation tolerance to use when preparing samples as quantumstates.
### MinibatchSize : [Int](xref:microsoft.quantum.lang-ref.int)

The number of samples to use in each training minibatch.
### NMeasurements : [Int](xref:microsoft.quantum.lang-ref.int)

The number of times to measure each classification result in order toestimate the classification probability.
### MaxEpochs : [Int](xref:microsoft.quantum.lang-ref.int)

The maximum number of epochs to train each model for.
### MaxStalls : [Int](xref:microsoft.quantum.lang-ref.int)

The maximum number of times a training epoch is allowed to stall(approximately zero gradient) before failing.
### StochasticRescaleFactor : [Double](xref:microsoft.quantum.lang-ref.double)

The amount to rescale stalled models by before retrying an update.
### ScoringPeriod : [Int](xref:microsoft.quantum.lang-ref.int)

The number of gradient steps to be taken between scoring points.For best accuracy, set to 1.
### VerboseMessage : [String](xref:microsoft.quantum.lang-ref.string) -> [Unit](xref:microsoft.quantum.lang-ref.unit)

A function that can be used to provide verbose feedback.

## Remarks

This UDT should not be created directly, but rather should be specifiedby calling @"microsoft.quantum.machinelearning.defaulttrainingoptions"and then using the `w/` operator to override different defaults.For example, to use 100,000 measurements and at most 8 trainingepochs:```qsharplet options = DefaultTrainingOptions()              w/ NMeasurements <- 100000              w/ MaxEpochs <- 8;```

## References

- [arXiv:1804.00633](https://arxiv.org/abs/1804.00633)