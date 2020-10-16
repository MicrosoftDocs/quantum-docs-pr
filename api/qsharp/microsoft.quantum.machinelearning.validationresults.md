---
uid: Microsoft.Quantum.MachineLearning.ValidationResults
title: ValidationResults user defined type
ms.date: 10/16/2020 12:00:00 AM
ms.topic: article
qsharp.kind: udt
qsharp.namespace: Microsoft.Quantum.MachineLearning
qsharp.name: ValidationResults
qsharp.summary: >-
  The results from having validated a classifier against a set of
  samples.
---

# ValidationResults user defined type

Namespace: [Microsoft.Quantum.MachineLearning](xref:Microsoft.Quantum.MachineLearning)

Package: [](https://nuget.org/packages/)


The results from having validated a classifier against a set ofsamples.

```Q#

newtype ValidationResults = (NMisclassifications : Int, NValidationSamples : Int);
```



## Named Items

### NMisclassifications : Int

The number of misclassifications observed during validation.

