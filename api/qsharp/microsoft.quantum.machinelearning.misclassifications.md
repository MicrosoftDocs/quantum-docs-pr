---
uid: Microsoft.Quantum.MachineLearning.Misclassifications
title: Misclassifications function
ms.date: 2/16/2021 12:00:00 AM
ms.topic: managed-reference
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.MachineLearning
qsharp.name: Misclassifications
qsharp.summary: >-
  Given a set of inferred labels and a set of correct labels, returns
  indices for where each set of labels differs.
---

# Misclassifications function

Namespace: [Microsoft.Quantum.MachineLearning](xref:Microsoft.Quantum.MachineLearning)

Package: [Microsoft.Quantum.MachineLearning](https://nuget.org/packages/Microsoft.Quantum.MachineLearning)


Given a set of inferred labels and a set of correct labels, returnsindices for where each set of labels differs.

```qsharp
function Misclassifications (inferredLabels : Int[], actualLabels : Int[]) : Int[]
```


## Input

### inferredLabels : [Int](xref:microsoft.quantum.lang-ref.int)[]

The labels inferred for a given training or validation set.


### actualLabels : [Int](xref:microsoft.quantum.lang-ref.int)[]

The true labels for a given training or validation set.



## Output : [Int](xref:microsoft.quantum.lang-ref.int)[]

An array of indices `idx` such that`inferredLabels[idx] != actualLabels[idx]`.

## Example

```qsharplet misclassifications = Misclassifications([0, 1, 0, 0], [0, 1, 1, 0]);Message($"{misclassifications}"); // Will print [2].```