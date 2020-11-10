---
uid: Microsoft.Quantum.Chemistry.JordanWigner.JordanWignerInputState
title: JordanWignerInputState user defined type
ms.date: 10/26/2020 12:00:00 AM
ms.topic: article
qsharp.kind: udt
qsharp.namespace: Microsoft.Quantum.Chemistry.JordanWigner
qsharp.name: JordanWignerInputState
qsharp.summary: >-
  Format of data passed from C# to Q# to represent preparation of the initial state
  The meaning of the data represented is determined by the algorithm that receives it.
---

# JordanWignerInputState user defined type

Namespace: [Microsoft.Quantum.Chemistry.JordanWigner](xref:Microsoft.Quantum.Chemistry.JordanWigner)

Package: [](https://nuget.org/packages/)


Format of data passed from C# to Q# to represent preparation of the initial stateThe meaning of the data represented is determined by the algorithm that receives it.

```qsharp

newtype JordanWignerInputState = ((Double, Double), Int[]);
```

