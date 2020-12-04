---
uid: Microsoft.Quantum.MachineLearning.SequentialModel
title: SequentialModel user defined type
ms.date: 12/4/2020 12:00:00 AM
ms.topic: article
qsharp.kind: udt
qsharp.namespace: Microsoft.Quantum.MachineLearning
qsharp.name: SequentialModel
qsharp.summary: >-
  Describes a quantum classifier model composed of a sequence of
  parameterized and controlled rotations, an assignment of rotation
  angles, and a bias between the two classes recognized by the model.
---

# SequentialModel user defined type

Namespace: [Microsoft.Quantum.MachineLearning](xref:Microsoft.Quantum.MachineLearning)

Package: [Microsoft.Quantum.MachineLearning](https://nuget.org/packages/Microsoft.Quantum.MachineLearning)


Describes a quantum classifier model composed of a sequence ofparameterized and controlled rotations, an assignment of rotationangles, and a bias between the two classes recognized by the model.

```qsharp

newtype SequentialModel = (Structure : Microsoft.Quantum.MachineLearning.ControlledRotation[], Parameters : Double[], Bias : Double);
```



## Named Items

### Structure : [ControlledRotation](xref:Microsoft.Quantum.MachineLearning.ControlledRotation)[]

The sequence of controlled rotations used to classify inputs.
### Parameters : [Double](xref:microsoft.quantum.lang-ref.double)[]

An assignment of rotation angles to the given classification structure.
### Bias : [Double](xref:microsoft.quantum.lang-ref.double)

The bias between the two classes recognized by this classifier.

## References

- [arXiv:1804.00633](https://arxiv.org/abs/1804.00633)