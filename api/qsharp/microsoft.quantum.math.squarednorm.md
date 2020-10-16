---
uid: Microsoft.Quantum.Math.SquaredNorm
title: SquaredNorm function
ms.date: 10/16/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Math
qsharp.name: SquaredNorm
qsharp.summary: Returns the squared 2-norm of a vector.
---

# SquaredNorm function

Namespace: [Microsoft.Quantum.Math](xref:Microsoft.Quantum.Math)

Package: [](https://nuget.org/packages/)


Returns the squared 2-norm of a vector.

```Q#
SquaredNorm (array : Double[]) : Double
```


## Description

Returns the squared 2-norm of a vector; that is, given an input$\vec{x}$, returns $\sum_i x_i^2$.

## Input

### array : Double[]

The vector whose squared 2-norm is to be returned.



## Output

The squared 2-norm of `array`.