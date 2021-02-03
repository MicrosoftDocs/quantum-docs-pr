---
uid: Microsoft.Quantum.Arrays.Any
title: Any function
ms.date: 2/3/2021 12:00:00 AM
ms.topic: managed-reference
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Arrays
qsharp.name: Any
qsharp.summary: >-
  Given an array and a predicate that is defined
  for the elements of the array, checks if at least one element of
  the array satisfies the predicate.
---

# Any function

Namespace: [Microsoft.Quantum.Arrays](xref:Microsoft.Quantum.Arrays)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Given an array and a predicate that is definedfor the elements of the array, checks if at least one element ofthe array satisfies the predicate.

```qsharp
function Any<'T> (predicate : ('T -> Bool), array : 'T[]) : Bool
```


## Input

### predicate : 'T -> [Bool](xref:microsoft.quantum.lang-ref.bool)

A function from `'T` to `Bool` that is used to check elements.


### array : 'T[]

An array of elements over `'T`.



## Output : [Bool](xref:microsoft.quantum.lang-ref.bool)

A `Bool` value of the OR function of the predicate applied to all elements.

## Type Parameters

### 'T

The type of `array` elements.

## Example

```qsharpopen Microsoft.Quantum.Arrays;open Microsoft.Quantum.Logical;function IsThreePresent() : Bool {    let arrayOfInts = [1, 2, 3, 4, 5];    let is3Present = IsNumberPresentInArray(3, arrayOfInts);    return is3Present;}function IsNumberPresentInArray(n : Int, array : Int[]) : Bool {    return Any(EqualI(_, n), array);}```

## Remarks

The function is defined for generic types, i.e., whenever we havean array `'T[]` and a function `predicate: 'T -> Bool` we can producea `Bool` value that indicates if some element satisfies `predicate`.