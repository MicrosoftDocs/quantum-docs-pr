---
uid: Microsoft.Quantum.Math.AbsComplex
title: AbsComplex function
ms.date: 11/7/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Math
qsharp.name: AbsComplex
qsharp.summary: >-
  Returns the absolute value of a complex number of type
  `Complex`.
---

# AbsComplex function

Namespace: [Microsoft.Quantum.Math](xref:Microsoft.Quantum.Math)

Package: [](https://nuget.org/packages/)


Returns the absolute value of a complex number of type`Complex`.

```qsharp
function AbsComplex (input : Microsoft.Quantum.Math.Complex) : Double
```


## Input

### input : [Complex](xref:Microsoft.Quantum.Math.Complex)

Complex number $c = x + i y$.



## Output : [Double](xref:microsoft.quantum.lang-ref.double)

Absolute value $|c| = \sqrt{x^2 + y^2}$.