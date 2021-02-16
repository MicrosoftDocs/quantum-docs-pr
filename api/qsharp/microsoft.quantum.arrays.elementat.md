---
uid: Microsoft.Quantum.Arrays.ElementAt
title: ElementAt function
ms.date: 2/16/2021 12:00:00 AM
ms.topic: managed-reference
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Arrays
qsharp.name: ElementAt
qsharp.summary: Returns the at the given index of an array.
---

# ElementAt function

Namespace: [Microsoft.Quantum.Arrays](xref:Microsoft.Quantum.Arrays)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Returns the at the given index of an array.

```qsharp
function ElementAt<'T> (index : Int, array : 'T[]) : 'T
```


## Input

### index : [Int](xref:microsoft.quantum.lang-ref.int)

Index of element


### array : 'T[]

The array being indexed.



## Output : 'T



## Type Parameters

### 'T

The type of each element of `array`.

## Example

Get the third number in four famous integer sequences. (notethat the 0 index corresponds to the _first_ value of the sequence.)```qsharplet lucas = [2, 1, 3, 4, 7, 11, 18, 29, 47, 76];let prime = [2, 3, 5, 7, 11, 13, 17, 19, 23, 29];let fibonacci = [0, 1, 1, 2, 3, 5, 8, 13, 21, 34];let catalan = [1, 1, 2, 5, 14, 42, 132, 429, 1430, 4862];let famous2 = Mapped(ElementAt<Int>(2, _), [lucas, prime, fibonacci, catalan]);// same as: famous2 = [3, 5, 1, 2]```

## See Also

- [Microsoft.Quantum.Arrays.LookupFunction](xref:Microsoft.Quantum.Arrays.LookupFunction)
- [Microsoft.Quantum.Arrays.ElementsAt](xref:Microsoft.Quantum.Arrays.ElementsAt)