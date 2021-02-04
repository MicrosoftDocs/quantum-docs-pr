---
uid: Microsoft.Quantum.MachineLearning.DefaultTrainingOptions
title: DefaultTrainingOptions function
ms.date: 2/4/2021 12:00:00 AM
ms.topic: managed-reference
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.MachineLearning
qsharp.name: DefaultTrainingOptions
qsharp.summary: Returns a default set of options for training classifiers.
---

# DefaultTrainingOptions function

Namespace: [Microsoft.Quantum.MachineLearning](xref:Microsoft.Quantum.MachineLearning)

Package: [Microsoft.Quantum.MachineLearning](https://nuget.org/packages/Microsoft.Quantum.MachineLearning)


Returns a default set of options for training classifiers.

```qsharp
function DefaultTrainingOptions () : Microsoft.Quantum.MachineLearning.TrainingOptions
```


## Output : [TrainingOptions](xref:Microsoft.Quantum.MachineLearning.TrainingOptions)

A reasonable set of default training options for use when trainingclassifiers.

## Example

To use the default options, but with additional measurements, use the`w/` operator:```qsharplet options = DefaultTrainingOptions()    w/ NMeasurements <- 1000000;```