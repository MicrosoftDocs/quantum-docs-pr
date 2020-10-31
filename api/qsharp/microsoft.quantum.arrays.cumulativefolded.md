---
uid: Microsoft.Quantum.Arrays.CumulativeFolded
title: CumulativeFolded function
ms.date: 10/31/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Arrays
qsharp.name: CumulativeFolded
qsharp.summary: Combines Mapped and Fold into a single function
---

# CumulativeFolded function

Namespace: [Microsoft.Quantum.Arrays](xref:Microsoft.Quantum.Arrays)

Package: [](https://nuget.org/packages/)


Combines Mapped and Fold into a single function

```qsharp
function CumulativeFolded<'State, 'T> (fn : (('State, 'T) -> 'State), state : 'State, array : 'T[]) : 'State[]
```


## Description

This function iterates the `fn` function through the array, starting froman initial state `state` and returns all intermediate values, not includingthe inital state.

## Input

### fn : ('State,'T) -> 'State

A function to be folded over the array


### state : 'State

The initial state to be folded


### array : 'T[]

An array of values to be folded over



## Output : 'State[]

All intermediate states, including the final state, but not the initial state.The length of the output array is of the same length as `array`.

## Type Parameters

### 'State

The type of states that the `fn` function operates on, i.e., accepts as its firstinput and returns.
### 'T

The type of `array` elements.