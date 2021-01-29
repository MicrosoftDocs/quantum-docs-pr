---
uid: Microsoft.Quantum.Math.ContinuedFractionConvergentI
title: ContinuedFractionConvergentI function
ms.date: 1/29/2021 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Math
qsharp.name: ContinuedFractionConvergentI
qsharp.summary: >-
  Finds the continued fraction convergent closest to `fraction`
  with the denominator less or equal to `denominatorBound`
---

# ContinuedFractionConvergentI function

Namespace: [Microsoft.Quantum.Math](xref:Microsoft.Quantum.Math)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Finds the continued fraction convergent closest to `fraction`with the denominator less or equal to `denominatorBound`

```qsharp
function ContinuedFractionConvergentI (fraction : Microsoft.Quantum.Math.Fraction, denominatorBound : Int) : Microsoft.Quantum.Math.Fraction
```


## Input

### fraction : [Fraction](xref:Microsoft.Quantum.Math.Fraction)




### denominatorBound : [Int](xref:microsoft.quantum.lang-ref.int)





## Output : [Fraction](xref:Microsoft.Quantum.Math.Fraction)

Continued fraction closest to `fraction`with the denominator less or equal to `denominatorBound`