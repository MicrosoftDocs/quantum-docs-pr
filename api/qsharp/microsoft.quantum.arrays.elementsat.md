---
uid: Microsoft.Quantum.Arrays.ElementsAt
title: ElementsAt function
ms.date: 2/10/2021 12:00:00 AM
ms.topic: managed-reference
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Arrays
qsharp.name: ElementsAt
qsharp.summary: >-
  Returns the array's elements at a given range
  of indices.
---

# ElementsAt function

Namespace: [Microsoft.Quantum.Arrays](xref:Microsoft.Quantum.Arrays)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Returns the array's elements at a given rangeof indices.

```qsharp
function ElementsAt<'T> (range : Range, array : 'T[]) : 'T[]
```


## Input

### range : [Range](xref:microsoft.quantum.lang-ref.range)

Range of array indexes


### array : 'T[]

Array



## Output : 'T[]



## Type Parameters

### 'T

The type of each element of `array`.

## Example

Get the odd indexes in famous integer sequences. (notethat the 0 index corresponds to the _first_ value of the sequence.)```qsharplet lucas = [2, 1, 3, 4, 7, 11, 18, 29, 47, 76];let prime = [2, 3, 5, 7, 11, 13, 17, 19, 23, 29];let fibonacci = [0, 1, 1, 2, 3, 5, 8, 13, 21, 34];let catalan = [1, 1, 2, 5, 14, 42, 132, 429, 1430, 4862];let famousOdd = Mapped(ElementsAt<Int>(0..2..9, _), [lucas, prime, fibonacci, catalan]);// same as: famousOdd = [[2, 3, 7, 18, 47], [2, 5, 11, 17, 23], [0, 1, 3, 8, 21], [1, 2, 14, 132, 1430]]```

## See Also

- [Microsoft.Quantum.Arrays.ElementAt](xref:Microsoft.Quantum.Arrays.ElementAt)
- [Microsoft.Quantum.Arrays.LookupFunction](xref:Microsoft.Quantum.Arrays.LookupFunction)