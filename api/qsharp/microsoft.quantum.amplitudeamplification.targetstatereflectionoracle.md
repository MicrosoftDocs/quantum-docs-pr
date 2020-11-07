---
uid: Microsoft.Quantum.AmplitudeAmplification.TargetStateReflectionOracle
title: TargetStateReflectionOracle function
ms.date: 11/7/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.AmplitudeAmplification
qsharp.name: TargetStateReflectionOracle
qsharp.summary: >-
  Constructs a `ReflectionOracle` about the target state uniquely marked by the flag qubit.

  The target state has a single qubit set to 1, and all others 0: $\ket{1}_f$.
---

# TargetStateReflectionOracle function

Namespace: [Microsoft.Quantum.AmplitudeAmplification](xref:Microsoft.Quantum.AmplitudeAmplification)

Package: [](https://nuget.org/packages/)


Constructs a `ReflectionOracle` about the target state uniquely marked by the flag qubit.The target state has a single qubit set to 1, and all others 0: $\ket{1}_f$.

```qsharp
function TargetStateReflectionOracle (idxFlagQubit : Int) : Microsoft.Quantum.Oracles.ReflectionOracle
```


## Input

### idxFlagQubit : [Int](xref:microsoft.quantum.lang-ref.int)

Index to flag qubit $f$ of oracle.



## Output : [ReflectionOracle](xref:Microsoft.Quantum.Oracles.ReflectionOracle)

A `ReflectionOracle` that reflects about the state marked by $\ket{1}_f$.

## See Also

- [Microsoft.Quantum.Canon.ReflectionOracle](xref:Microsoft.Quantum.Canon.ReflectionOracle)