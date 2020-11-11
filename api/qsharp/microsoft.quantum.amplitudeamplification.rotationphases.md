---
uid: Microsoft.Quantum.AmplitudeAmplification.RotationPhases
title: RotationPhases user defined type
ms.date: 11/11/2020 12:00:00 AM
ms.topic: article
qsharp.kind: udt
qsharp.namespace: Microsoft.Quantum.AmplitudeAmplification
qsharp.name: RotationPhases
qsharp.summary: Phases for a sequence of single-qubit rotations in amplitude amplification.
---

# RotationPhases user defined type

Namespace: [Microsoft.Quantum.AmplitudeAmplification](xref:Microsoft.Quantum.AmplitudeAmplification)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Phases for a sequence of single-qubit rotations in amplitude amplification.

```qsharp

newtype RotationPhases = (Double[]);
```



## Remarks

The first parameter is an array of phases for reflections, expressed as a product of single-qubit rotations.[ G.H. Low, I. L. Chuang, https://arxiv.org/abs/1707.05391].