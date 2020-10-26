---
uid: Microsoft.Quantum.Math.ArgComplex
title: ArgComplex function
ms.date: 10/26/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Math
qsharp.name: ArgComplex
qsharp.summary: >-
  Returns the phase of a complex number of type
  `Complex`.
---

# ArgComplex function

Namespace: [Microsoft.Quantum.Math](xref:Microsoft.Quantum.Math)

Package: [](https://nuget.org/packages/)


Returns the phase of a complex number of type`Complex`.

```qsharp
function ArgComplex (input : Microsoft.Quantum.Math.Complex) : Double
```


## Input

### input : [Complex](xref:Microsoft.Quantum.Math.Complex)

Complex number $c = x + i y$.



## Output : [Double](xref:microsoft.quantum.lang-ref.double)

Phase $\text{Arg}[c] = \text{ArcTan}(y,x) \in (-\pi,\pi]$.