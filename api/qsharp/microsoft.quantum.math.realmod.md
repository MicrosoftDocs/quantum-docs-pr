---
uid: Microsoft.Quantum.Math.RealMod
title: RealMod function
ms.date: 1/28/2021 12:00:00 AM
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



## Example

```qsharp    // Returns 3 π / 2.    let y = RealMod(5.5 * PI(), 2.0 * PI(), 0.0);    // Returns -1.2, since +3.6 and -1.2 are 4.8 apart on the real line,    // which is a multiple of 2.4.    let z = RealMod(3.6, 2.4, -1.2);```

## Remarks

This function computes the real modulus by wrapping the realline about the unit circle, then finding the angle on theunit circle corresponding to the input.The `minValue` input then effectively specifies where to cut theunit circle.