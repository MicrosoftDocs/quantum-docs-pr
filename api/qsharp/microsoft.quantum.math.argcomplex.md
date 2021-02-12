---
uid: Microsoft.Quantum.Math.ArgComplex
title: ArgComplex function
ms.date: 2/11/2021 12:00:00 AM
ms.topic: managed-reference
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Math
qsharp.name: ArgComplex
qsharp.summary: >-
  Returns the phase of a complex number of type
  `Complex`.
---

# ArgComplex function

Namespace: [Microsoft.Quantum.Math](xref:Microsoft.Quantum.Math)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Returns the phase of a complex number of type`Complex`.

```qsharp
function ArgComplex (input : Microsoft.Quantum.Math.Complex) : Double
```


## Input

### input : [Complex](xref:Microsoft.Quantum.Math.Complex)

Complex number $c = x + i y$.



## Output : [Double](xref:microsoft.quantum.lang-ref.double)

Phase $\text{Arg}[c] = \text{ArcTan}(y,x) \in (-\pi,\pi]$.