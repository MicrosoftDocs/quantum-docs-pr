---
uid: Microsoft.Quantum.MachineLearning.NQubitsRequired
title: NQubitsRequired function
ms.date: 10/16/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.MachineLearning
qsharp.name: NQubitsRequired
qsharp.summary: >-
  Returns the number of qubits required to apply a given sequential
  classifier.
---

# NQubitsRequired function

Namespace: [Microsoft.Quantum.MachineLearning](xref:Microsoft.Quantum.MachineLearning)

Package: [](https://nuget.org/packages/)


Returns the number of qubits required to apply a given sequentialclassifier.

```Q#
NQubitsRequired (model : Microsoft.Quantum.MachineLearning.SequentialModel) : Int
```


## Input

### structure

The structure of a given sequential classifier.



## Output

The minimum size of a register on which the sequential classifiermay be applied.