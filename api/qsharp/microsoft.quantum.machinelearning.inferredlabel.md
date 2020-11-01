---
uid: Microsoft.Quantum.MachineLearning.InferredLabel
title: InferredLabel function
ms.date: 11/1/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.MachineLearning
qsharp.name: InferredLabel
qsharp.summary: >-
  Given a of classification probability and a bias, returns the
  label inferred from that probability.
---

# InferredLabel function

Namespace: [Microsoft.Quantum.MachineLearning](xref:Microsoft.Quantum.MachineLearning)

Package: [](https://nuget.org/packages/)


Given a of classification probability and a bias, returns thelabel inferred from that probability.

```qsharp
function InferredLabel (bias : Double, probability : Double) : Int
```


## Input

### bias : [Double](xref:microsoft.quantum.lang-ref.double)

The bias between two classes, typically the result of training aclassifier.


### probability : [Double](xref:microsoft.quantum.lang-ref.double)

A classification probabilities for a particular sample, typicallyresulting from estimating its classification frequency.



## Output : [Int](xref:microsoft.quantum.lang-ref.int)

The label inferred from the given classification probability.