---
uid: Microsoft.Quantum.MachineLearning.InferredLabels
title: InferredLabels function
ms.date: 11/6/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.MachineLearning
qsharp.name: InferredLabels
qsharp.summary: >-
  Given an array of classification probabilities and a bias, returns the
  label inferred from each probability.
---

# InferredLabels function

Namespace: [Microsoft.Quantum.MachineLearning](xref:Microsoft.Quantum.MachineLearning)

Package: [Microsoft.Quantum.MachineLearning](https://nuget.org/packages/Microsoft.Quantum.MachineLearning)


Given an array of classification probabilities and a bias, returns thelabel inferred from each probability.

```qsharp
function InferredLabels (bias : Double, probabilities : Double[]) : Int[]
```


## Input

### bias : [Double](xref:microsoft.quantum.lang-ref.double)

The bias between two classes, typically the result of training aclassifier.


### probabilities : [Double](xref:microsoft.quantum.lang-ref.double)[]

An array of classification probabilities for a set of samples, typicallyresulting from estimating classification frequencies.



## Output : [Int](xref:microsoft.quantum.lang-ref.int)[]

The label inferred from each classification probability.