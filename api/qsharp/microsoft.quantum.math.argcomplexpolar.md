---
uid: Microsoft.Quantum.Math.ArgComplexPolar
title: ArgComplexPolar function
ms.date: 10/26/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Math
qsharp.name: ArgComplexPolar
qsharp.summary: >-
  Returns the phase of a complex number of type
  `ComplexPolar`.
---

# ArgComplexPolar function

Namespace: [Microsoft.Quantum.Math](xref:Microsoft.Quantum.Math)

Package: [](https://nuget.org/packages/)


Returns the phase of a complex number of type`ComplexPolar`.

```qsharp
function ArgComplexPolar (input : Microsoft.Quantum.Math.ComplexPolar) : Double
```


## Input

### input : [ComplexPolar](xref:Microsoft.Quantum.Math.ComplexPolar)

Complex number $c = r e^{i t}$.



## Output : [Double](xref:microsoft.quantum.lang-ref.double)

Phase $\text{Arg}[c] = t$.