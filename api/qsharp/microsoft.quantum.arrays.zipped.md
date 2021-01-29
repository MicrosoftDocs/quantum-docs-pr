---
uid: Microsoft.Quantum.Arrays.Zipped
title: Zipped function
ms.date: 1/29/2021 12:00:00 AM
ms.topic: managed-reference
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Arrays
qsharp.name: Zipped
qsharp.summary: >-
  Given two arrays, returns a new array of pairs such that each pair
  contains an element from each original array.
---

# Zipped function

Namespace: [Microsoft.Quantum.Arrays](xref:Microsoft.Quantum.Arrays)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Given two arrays, returns a new array of pairs such that each paircontains an element from each original array.

```qsharp
function Zipped<'T, 'U> (left : 'T[], right : 'U[]) : ('T, 'U)[]
```


## Input

### left : 'T[]

An array containing values for the first element of each tuple.


### right : 'U[]

An array containing values for the second element of each tuple.



## Output : ('T,'U)[]

An array containing pairs of the form `(left[idx], right[idx])` foreach `idx`. If the two arrays are not of equal length, the output willbe as long as the shorter of the inputs.

## Type Parameters

### 'T

The type of the left array elements.
### 'U

The type of the right array elements.

## Example

```qsharplet left = [1, 3, 71];let right = [false, true];let pairs = Zipped(left, right); // [(1, false), (3, true)]```

## See Also

- [Microsoft.Quantum.Arrays.Zipped3](xref:Microsoft.Quantum.Arrays.Zipped3)
- [Microsoft.Quantum.Arrays.Zipped4](xref:Microsoft.Quantum.Arrays.Zipped4)
- [Microsoft.Quantum.Arrays.Unzipped](xref:Microsoft.Quantum.Arrays.Unzipped)