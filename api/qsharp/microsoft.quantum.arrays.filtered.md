---
uid: Microsoft.Quantum.Arrays.Filtered
title: Filtered function
ms.date: 2/12/2021 12:00:00 AM
ms.topic: managed-reference
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Arrays
qsharp.name: Filtered
qsharp.summary: >-
  Given an array and a predicate that is defined
  for the elements of the array, returns an array that consists of
  those elements that satisfy the predicate.
---

# Filtered function

Namespace: [Microsoft.Quantum.Arrays](xref:Microsoft.Quantum.Arrays)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Given an array and a predicate that is definedfor the elements of the array, returns an array that consists ofthose elements that satisfy the predicate.

```qsharp
function Filtered<'T> (predicate : ('T -> Bool), array : 'T[]) : 'T[]
```


## Input

### predicate : 'T -> [Bool](xref:microsoft.quantum.lang-ref.bool)

A function from `'T` to Boolean that is used to filter elements.


### array : 'T[]

An array of elements over `'T`.



## Output : 'T[]

An array `'T[]` of elements that satisfy the predicate.

## Type Parameters

### 'T

The type of `array` elements.

## Example

The following code demonstrates the "Filtered" function.A predicate is defined using the @"microsoft.quantum.logical.greaterthani" function:```qsharpopen Microsoft.Quantum.Arrays;open Microsoft.Quantum.Logical;function FilteredDemo() : Unit {   let predicate = GreaterThanI(_, 5);   let filteredArray = Filtered(predicate, [2, 5, 9, 1, 8]);   Message($"{filteredArray}");}```The outcome one should expect from this example will be an array of numbers greater than 5.

## Remarks

The function is defined for generic types, i.e., whenever we havean array `'T[]` and a predicate `'T -> Bool` we can filter elements.