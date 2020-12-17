---
uid: Microsoft.Quantum.Arrays.Zipped3
title: Zipped3 function
ms.date: 12/17/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Arrays
qsharp.name: Zipped3
qsharp.summary: >-
  Given three arrays, returns a new array of 3-tuples such that each 3-tuple
  contains an element from each original array.
---

# Zipped3 function

Namespace: [Microsoft.Quantum.Arrays](xref:Microsoft.Quantum.Arrays)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Given three arrays, returns a new array of 3-tuples such that each 3-tuplecontains an element from each original array.

```qsharp
function Zipped3<'T1, 'T2, 'T3> (first : 'T1[], second : 'T2[], third : 'T3[]) : ('T1, 'T2, 'T3)[]
```


## Input

### first : 'T1[]

An array containing values for the first element of each tuple.


### second : 'T2[]

An array containing values for the second element of each tuple.


### third : 'T3[]

An array containing values for the third element of each tuple.



## Output : ('T1,'T2,'T3)[]

An array containing 3-tuples of the form `(first[idx], second[idx], third[idx])` foreach `idx`. If the three arrays are not of equal length, the output willbe as long as the shorter of the inputs.

## Type Parameters

### 'T1

The type of the first array elements.
### 'T2

The type of the second array elements.
### 'T3

The type of the third array elements.

## See Also

- [Microsoft.Quantum.Arrays.Zipped](xref:Microsoft.Quantum.Arrays.Zipped)
- [Microsoft.Quantum.Arrays.Zipped4](xref:Microsoft.Quantum.Arrays.Zipped4)