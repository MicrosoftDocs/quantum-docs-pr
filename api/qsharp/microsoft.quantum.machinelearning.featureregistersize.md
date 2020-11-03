---
uid: Microsoft.Quantum.MachineLearning.FeatureRegisterSize
title: FeatureRegisterSize function
ms.date: 11/3/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.MachineLearning
qsharp.name: FeatureRegisterSize
qsharp.summary: >-
  Returns the number of qubits required to encode a particular feature
  vector.
---

# FeatureRegisterSize function

Namespace: [Microsoft.Quantum.MachineLearning](xref:Microsoft.Quantum.MachineLearning)

Package: [](https://nuget.org/packages/)


Returns the number of qubits required to encode a particular featurevector.

```qsharp
function FeatureRegisterSize (sample : Double[]) : Int
```


## Input

### sample : [Double](xref:microsoft.quantum.lang-ref.double)[]

A sample feature vector to be encoded into a qubit register.



## Output : [Int](xref:microsoft.quantum.lang-ref.int)

The size required to encode `sample` into a qubit register, expressedas a number of qubits.