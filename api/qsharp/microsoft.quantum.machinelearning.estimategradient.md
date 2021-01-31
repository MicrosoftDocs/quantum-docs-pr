---
uid: Microsoft.Quantum.MachineLearning.EstimateGradient
title: EstimateGradient operation
ms.date: 1/31/2021 12:00:00 AM
ms.topic: managed-reference
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.MachineLearning
qsharp.name: EstimateGradient
qsharp.summary: >-
  Estimates the training gradient for a sequential classifier at a
  particular model and for a given encoded input.
---

# EstimateGradient operation

Namespace: [Microsoft.Quantum.MachineLearning](xref:Microsoft.Quantum.MachineLearning)

Package: [Microsoft.Quantum.MachineLearning](https://nuget.org/packages/Microsoft.Quantum.MachineLearning)


Estimates the training gradient for a sequential classifier at aparticular model and for a given encoded input.

```qsharp
operation EstimateGradient (model : Microsoft.Quantum.MachineLearning.SequentialModel, encodedInput : Microsoft.Quantum.MachineLearning.StateGenerator, nMeasurements : Int) : Double[]
```


## Input

### model : [SequentialModel](xref:Microsoft.Quantum.MachineLearning.SequentialModel)

The sequential model whose gradient is to be estimated.


### encodedInput : [StateGenerator](xref:Microsoft.Quantum.MachineLearning.StateGenerator)

An input to the sequential classifier, encoded into a state preparationoperation.


### nMeasurements : [Int](xref:microsoft.quantum.lang-ref.int)

The number of measurements to use in estimating the gradient.



## Output : [Double](xref:microsoft.quantum.lang-ref.double)[]

An estimate of the training gradient at the given input and modelparameters.

## Remarks

This operation uses a Hadamard test and the parameter shift techniquetogether to estimate the gradient.