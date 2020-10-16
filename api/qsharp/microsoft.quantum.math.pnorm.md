---
uid: Microsoft.Quantum.Math.PNorm
title: PNorm function
ms.date: 10/16/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Math
qsharp.name: PNorm
qsharp.summary: >-
  Returns the `L(p)` norm of a vector of `Double`s.

  That is, given an array $x$ of type `Double[]`, this returns the $p$-norm
  $\|x\|\_p= (\sum_{j}|x_j|^{p})^{1/p}$.
---

# PNorm function

Namespace: [Microsoft.Quantum.Math](xref:Microsoft.Quantum.Math)

Package: [](https://nuget.org/packages/)


Returns the `L(p)` norm of a vector of `Double`s.That is, given an array $x$ of type `Double[]`, this returns the $p$-norm$\|x\|\_p= (\sum_{j}|x_j|^{p})^{1/p}$.

```Q#
PNorm (p : Double, array : Double[]) : Double
```


## Input

### p : Double

The exponent $p$ in the $p$-norm.



## Output

The $p$-norm $\|x\|_p$.