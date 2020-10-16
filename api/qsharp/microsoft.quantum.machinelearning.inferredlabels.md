---
uid: Microsoft.Quantum.MachineLearning.InferredLabels
title: InferredLabels function
ms.date: 10/16/2020 12:00:00 AM
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

Package: [](https://nuget.org/packages/)


Given an array of classification probabilities and a bias, returns thelabel inferred from each probability.

```Q#
InferredLabels (bias : Double, probabilities : Double[]) : Int[]
```


## Input

### bias : Double

The bias between two classes, typically the result of training aclassifier.


### probabilities : Double[]

An array of classification probabilities for a set of samples, typicallyresulting from estimating classification frequencies.



## Output

The label inferred from each classification probability.