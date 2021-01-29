---
uid: Microsoft.Quantum.Math.SquaredNorm
title: SquaredNorm function
ms.date: 1/29/2021 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Math
qsharp.name: SquaredNorm
qsharp.summary: Returns the squared 2-norm of a vector.
---

# SquaredNorm function

Namespace: [Microsoft.Quantum.Math](xref:Microsoft.Quantum.Math)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Returns the squared 2-norm of a vector.

```qsharp
function SquaredNorm (array : Double[]) : Double
```


## Description

Returns the squared 2-norm of a vector; that is, given an input$\vec{x}$, returns $\sum_i x_i^2$.

## Input

### array : [Double](xref:microsoft.quantum.lang-ref.double)[]

The vector whose squared 2-norm is to be returned.



## Output : [Double](xref:microsoft.quantum.lang-ref.double)

The squared 2-norm of `array`.