---
uid: Microsoft.Quantum.Arrays.Unzipped
title: Unzipped function
ms.date: 1/23/2021 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Arrays
qsharp.name: Unzipped
qsharp.summary: >-
  Given an array of 2-tuples, returns a tuple of two arrays, each containing
  the elements of the tuples of the input array.
---

# Unzipped function

Namespace: [Microsoft.Quantum.Arrays](xref:Microsoft.Quantum.Arrays)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Given an array of 2-tuples, returns a tuple of two arrays, each containing
the elements of the tuples of the input array.

```qsharp
function Unzipped<'T, 'U> (arr : ('T, 'U)[]) : ('T[], 'U[])
```


## Input

### arr : ('T,'U)[]

An array containing 2-tuples



## Output : ('T[],'U[])

Two arrays, the first one containing all first elements of the input
tuples, the second one containing all second elements of the input tuples.

## Type Parameters

### 'T

The type of the first element in each tuple
### 'U

The type of the second element in each tuple

## Example

```qsharp
// split is same as ([6, 5, 5, 3, 2, 1], [true, false, false, false, true, false])
let split = Unzipped([(6, true), (5, false), (5, false), (3, false), (2, true), (1, false)]);
```

## See Also

- [Microsoft.Quantum.Arrays.Zipped](xref:Microsoft.Quantum.Arrays.Zipped)