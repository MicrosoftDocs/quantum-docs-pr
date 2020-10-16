---
uid: Microsoft.Quantum.Math.PNormalized
title: PNormalized function
ms.date: 10/16/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Math
qsharp.name: PNormalized
qsharp.summary: >-
  Normalizes a vector of `Double`s in the `L(p)` norm.

  That is, given an array $x$ of type `Double[]`, this returns an array where
  all elements are divided by the $p$-norm $\|x\|_p$.
---

# PNormalized function

Namespace: [Microsoft.Quantum.Math](xref:Microsoft.Quantum.Math)

Package: [](https://nuget.org/packages/)


Normalizes a vector of `Double`s in the `L(p)` norm.That is, given an array $x$ of type `Double[]`, this returns an array whereall elements are divided by the $p$-norm $\|x\|_p$.

```Q#
PNormalized (p : Double, array : Double[]) : Double[]
```


## Input

### p : Double

The exponent $p$ in the $p$-norm.



## Output

The array $x$ normalized by the $p$-norm $\|x\|_p$.

## See Also

- [Microsoft.Quantum.Math.PNorm](xref:Microsoft.Quantum.Math.PNorm)