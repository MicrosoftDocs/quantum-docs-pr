---
uid: Microsoft.Quantum.Math.ComplexPolarAsComplex
title: ComplexPolarAsComplex function
ms.date: 11/11/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Math
qsharp.name: ComplexPolarAsComplex
qsharp.summary: >-
  Converts a complex number of type `ComplexPolar` to a complex
  number of type `Complex`.
---

# ComplexPolarAsComplex function

Namespace: [Microsoft.Quantum.Math](xref:Microsoft.Quantum.Math)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Converts a complex number of type `ComplexPolar` to a complexnumber of type `Complex`.

```qsharp
function ComplexPolarAsComplex (input : Microsoft.Quantum.Math.ComplexPolar) : Microsoft.Quantum.Math.Complex
```


## Input

### input : [ComplexPolar](xref:Microsoft.Quantum.Math.ComplexPolar)

Complex number $c = r e^{i t}$.



## Output : [Complex](xref:Microsoft.Quantum.Math.Complex)

Complex number $c = x + i y$.