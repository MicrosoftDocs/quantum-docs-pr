---
uid: Microsoft.Quantum.Arrays.Zip3
title: Zip3 function
ms.date: 10/16/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Arrays
qsharp.name: Zip3
qsharp.summary: >-
  Given three arrays, returns a new array of 3-tuples such that each 3-tuple
  contains an element from each original array.
  > [!WARNING]

  > Deprecated


  Zip3 has been deprecated. Please use @"microsoft.quantum.arrays.zipped3" instead.
---

# Zip3 function

Namespace: [Microsoft.Quantum.Arrays](xref:Microsoft.Quantum.Arrays)

Package: [](https://nuget.org/packages/)


Given three arrays, returns a new array of 3-tuples such that each 3-tuplecontains an element from each original array.> [!WARNING]
> Deprecated
Zip3 has been deprecated. Please use @"microsoft.quantum.arrays.zipped3" instead.

```Q#
Zip3<'T1, 'T2, 'T3> (first : 'T1[], second : 'T2[], third : 'T3[]) : ('T1, 'T2, 'T3)[]
```


## Input

### first : 'T1[]

An array containing values for the first element of each tuple.


### second : 'T2[]

An array containing values for the second element of each tuple.


### third : 'T3[]

An array containing values for the third element of each tuple.



## Output

An array containing 3-tuples of the form `(first[idx], second[idx], third[idx])` foreach `idx`. If the three arrays are not of equal length, the output willbe as long as the shorter of the inputs.

## Type Parameters

### 'T1

The type of the first array elements.


### 'T2

The type of the second array elements.


### 'T3

The type of the third array elements.



## See Also

- [Microsoft.Quantum.Arrays.Zip](xref:Microsoft.Quantum.Arrays.Zip)
- [Microsoft.Quantum.Arrays.Zip4](xref:Microsoft.Quantum.Arrays.Zip4)