---
uid: Microsoft.Quantum.MachineLearning.ApplySequentialClassifier
title: ApplySequentialClassifier operation
ms.date: 10/16/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.MachineLearning
qsharp.name: ApplySequentialClassifier
qsharp.summary: >-
  Given the structure and parameterization of a sequential classifier,
  applies the classifier to a register of qubits.
---

# ApplySequentialClassifier operation

Namespace: [Microsoft.Quantum.MachineLearning](xref:Microsoft.Quantum.MachineLearning)

Package: [](https://nuget.org/packages/)


Given the structure and parameterization of a sequential classifier,applies the classifier to a register of qubits.

```Q#
ApplySequentialClassifier (model : Microsoft.Quantum.MachineLearning.SequentialModel, qubits : Qubit[]) : Unit
```


## Input

### structure

Structure of the given sequential classifier.


### parameters

A parameterization at which the given structure is applied.


### qubits : Qubit[]

A target register to which the classifier should be applied.

