---
uid: Microsoft.Quantum.Math.ComplexAsComplexPolar
title: ComplexAsComplexPolar function
ms.date: 10/29/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Math
qsharp.name: ComplexAsComplexPolar
qsharp.summary: >-
  Converts a complex number of type `Complex` to a complex
  number of type `ComplexPolar`.
---

# ComplexAsComplexPolar function

Namespace: [Microsoft.Quantum.Math](xref:Microsoft.Quantum.Math)

Package: [](https://nuget.org/packages/)


Converts a complex number of type `Complex` to a complexnumber of type `ComplexPolar`.

```qsharp
function ComplexAsComplexPolar (input : Microsoft.Quantum.Math.Complex) : Microsoft.Quantum.Math.ComplexPolar
```


## Input

### input : [Complex](xref:Microsoft.Quantum.Math.Complex)

Complex number $c = x + i y$.



## Output : [ComplexPolar](xref:Microsoft.Quantum.Math.ComplexPolar)

Complex number $c = r e^{i t}$.