---
uid: Microsoft.Quantum.Canon.Compose
title: Compose function
ms.date: 11/3/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Canon
qsharp.name: Compose
qsharp.summary: Returns the composition of two functions.
---

# Compose function

Namespace: [Microsoft.Quantum.Canon](xref:Microsoft.Quantum.Canon)

Package: [](https://nuget.org/packages/)


Returns the composition of two functions.

```qsharp
function Compose<'T, 'U, 'V> (outer : ('U -> 'V), inner : ('T -> 'U)) : ('T -> 'V)
```


## Description

Given two functions $f$ and $g$, returns a new function representing$f \circ g$.

## Input

### outer : 'U -> 'V

The second function to be applied.


### inner : 'T -> 'U

The first function to be applied.



## Output : 'T -> 'V

A new function $h$ such that for all inputs $x$, $f(g(x)) = h(x)$.

## Type Parameters

### 'T

The input type of the first function to be applied.
### 'U

The output type of the first function to be applied and the input typeof the second function to be applied.
### 'V

The output type of the second function to be applied.