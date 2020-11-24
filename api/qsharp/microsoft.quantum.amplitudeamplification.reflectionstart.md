---
uid: Microsoft.Quantum.AmplitudeAmplification.ReflectionStart
title: ReflectionStart function
ms.date: 11/24/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.AmplitudeAmplification
qsharp.name: ReflectionStart
qsharp.summary: Constructs a reflection about the all-zero string |0...0〉, which is the typical input state to amplitude amplification.
---

# ReflectionStart function

Namespace: [Microsoft.Quantum.AmplitudeAmplification](xref:Microsoft.Quantum.AmplitudeAmplification)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Constructs a reflection about the all-zero string |0...0〉, which is the typical input state to amplitude amplification.

```qsharp
function ReflectionStart () : Microsoft.Quantum.Oracles.ReflectionOracle
```


## Output : [ReflectionOracle](xref:Microsoft.Quantum.Oracles.ReflectionOracle)

A `ReflectionOracle` that reflects about the state $\ket{0\cdots 0}$.

## See Also

- [Microsoft.Quantum.Canon.ReflectionOracle](xref:Microsoft.Quantum.Canon.ReflectionOracle)