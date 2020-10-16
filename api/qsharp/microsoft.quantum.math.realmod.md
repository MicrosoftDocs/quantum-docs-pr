---
uid: Microsoft.Quantum.Math.RealMod
title: RealMod function
ms.date: 10/16/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Math
qsharp.name: RealMod
qsharp.summary: Computes the modulus between two real numbers.
---

# RealMod function

Namespace: [Microsoft.Quantum.Math](xref:Microsoft.Quantum.Math)

Package: [](https://nuget.org/packages/)


Computes the modulus between two real numbers.

```Q#
RealMod (value : Double, modulo : Double, minValue : Double) : Double
```


## Input

### value : Double

A real number $x$ to take the modulus of.


### modulo : Double

A real number to take the modulus of $x$ with respect to.


### minValue : Double

The smallest value to be returned by this function.



## Remarks

This function computes the real modulus by wrapping the realline about the unit circle, then finding the angle on theunit circle corresponding to the input.The `minValue` input then effectively specifies where to cut theunit circle.