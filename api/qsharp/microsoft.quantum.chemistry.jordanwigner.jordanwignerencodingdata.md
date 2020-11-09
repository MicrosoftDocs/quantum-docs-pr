---
uid: Microsoft.Quantum.Chemistry.JordanWigner.JordanWignerEncodingData
title: JordanWignerEncodingData user defined type
ms.date: 11/9/2020 12:00:00 AM
ms.topic: article
qsharp.kind: udt
qsharp.namespace: Microsoft.Quantum.Chemistry.JordanWigner
qsharp.name: JordanWignerEncodingData
qsharp.summary: >-
  Format of data passed from C# to Q# to represent all information for Hamiltonian simulation.
  The meaning of the data represented is determined by the algorithm that receives it.
---

# JordanWignerEncodingData user defined type

Namespace: [Microsoft.Quantum.Chemistry.JordanWigner](xref:Microsoft.Quantum.Chemistry.JordanWigner)

Package: [](https://nuget.org/packages/)


Format of data passed from C# to Q# to represent all information for Hamiltonian simulation.The meaning of the data represented is determined by the algorithm that receives it.

```qsharp

newtype JordanWignerEncodingData = (Int, Microsoft.Quantum.Chemistry.JordanWigner.JWOptimizedHTerms, (Int, Microsoft.Quantum.Chemistry.JordanWigner.JordanWignerInputState[]), Double);
```

