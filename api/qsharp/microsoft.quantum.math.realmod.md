---
uid: Microsoft.Quantum.Math.RealMod
title: RealMod function
ms.date: 1/5/2021 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Math
qsharp.name: RealMod
qsharp.summary: Computes the modulus between two real numbers.
---

# RealMod function

Namespace: [Microsoft.Quantum.Math](xref:Microsoft.Quantum.Math)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Computes the modulus between two real numbers.

```qsharp
function RealMod (value : Double, modulo : Double, minValue : Double) : Double
```


## Input

### value : [Double](xref:microsoft.quantum.lang-ref.double)

A real number $x$ to take the modulus of.


### modulo : [Double](xref:microsoft.quantum.lang-ref.double)

A real number to take the modulus of $x$ with respect to.


### minValue : [Double](xref:microsoft.quantum.lang-ref.double)

The smallest value to be returned by this function.



## Output : [Double](xref:microsoft.quantum.lang-ref.double)



## Remarks

This function computes the real modulus by wrapping the realline about the unit circle, then finding the angle on theunit circle corresponding to the input.The `minValue` input then effectively specifies where to cut theunit circle.