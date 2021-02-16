---
uid: Microsoft.Quantum.MachineLearning.NQubitsRequired
title: NQubitsRequired function
ms.date: 2/16/2021 12:00:00 AM
ms.topic: managed-reference
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.MachineLearning
qsharp.name: NQubitsRequired
qsharp.summary: >-
  Returns the number of qubits required to apply a given sequential
  classifier.
---

# NQubitsRequired function

Namespace: [Microsoft.Quantum.MachineLearning](xref:Microsoft.Quantum.MachineLearning)

Package: [Microsoft.Quantum.MachineLearning](https://nuget.org/packages/Microsoft.Quantum.MachineLearning)


Returns the number of qubits required to apply a given sequentialclassifier.

```qsharp
function NQubitsRequired (model : Microsoft.Quantum.MachineLearning.SequentialModel) : Int
```


## Input

### model : [SequentialModel](xref:Microsoft.Quantum.MachineLearning.SequentialModel)





## Output : [Int](xref:microsoft.quantum.lang-ref.int)

The minimum size of a register on which the sequential classifiermay be applied.