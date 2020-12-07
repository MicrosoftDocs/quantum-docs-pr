---
uid: Microsoft.Quantum.MachineLearning.ApplySequentialClassifier
title: ApplySequentialClassifier operation
ms.date: 12/7/2020 12:00:00 AM
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

Package: [Microsoft.Quantum.MachineLearning](https://nuget.org/packages/Microsoft.Quantum.MachineLearning)


Given the structure and parameterization of a sequential classifier,applies the classifier to a register of qubits.

```qsharp
operation ApplySequentialClassifier (model : Microsoft.Quantum.MachineLearning.SequentialModel, qubits : Qubit[]) : Unit is Adj + Ctl
```


## Input

### model : [SequentialModel](xref:Microsoft.Quantum.MachineLearning.SequentialModel)




### qubits : [Qubit](xref:microsoft.quantum.lang-ref.qubit)[]

A target register to which the classifier should be applied.



## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)

