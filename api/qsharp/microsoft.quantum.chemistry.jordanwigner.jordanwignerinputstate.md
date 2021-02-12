---
uid: Microsoft.Quantum.Chemistry.JordanWigner.JordanWignerInputState
title: JordanWignerInputState user defined type
ms.date: 2/11/2021 12:00:00 AM
ms.topic: managed-reference
qsharp.kind: udt
qsharp.namespace: Microsoft.Quantum.Chemistry.JordanWigner
qsharp.name: JordanWignerInputState
qsharp.summary: >-
  Format of data passed from C# to Q# to represent preparation of the initial state
  The meaning of the data represented is determined by the algorithm that receives it.
---

# JordanWignerInputState user defined type

Namespace: [Microsoft.Quantum.Chemistry.JordanWigner](xref:Microsoft.Quantum.Chemistry.JordanWigner)

Package: [Microsoft.Quantum.Chemistry](https://nuget.org/packages/Microsoft.Quantum.Chemistry)


Format of data passed from C# to Q# to represent preparation of the initial stateThe meaning of the data represented is determined by the algorithm that receives it.

```qsharp

newtype JordanWignerInputState = ((Double, Double), Int[]);
```

