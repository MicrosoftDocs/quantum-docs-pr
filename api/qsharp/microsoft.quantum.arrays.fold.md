---
uid: Microsoft.Quantum.Arrays.Fold
title: Fold function
ms.date: 12/17/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Arrays
qsharp.name: Fold
qsharp.summary: >-
  Iterates a function `f` through an array `array`, returning
  `f(f(f(initialState, array[0]), array[1]), ...)`.
---

# Fold function

Namespace: [Microsoft.Quantum.Arrays](xref:Microsoft.Quantum.Arrays)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Iterates a function `f` through an array `array`, returning`f(f(f(initialState, array[0]), array[1]), ...)`.

```qsharp
function Fold<'State, 'T> (folder : (('State, 'T) -> 'State), state : 'State, array : 'T[]) : 'State
```


## Input

### folder : ('State,'T) -> 'State

A function to be folded over the array.


### state : 'State

The initial state of the folder.


### array : 'T[]

An array of values to be folded over.



## Output : 'State

The final state returned by the folder after iterating overall elements of `array`.

## Type Parameters

### 'State

The type of states the `folder` function operates on, i.e., accepts as its firstargument and returns.
### 'T

The type of `array` elements.