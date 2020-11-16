---
uid: Microsoft.Quantum.Arrays.Zip4
title: Zip4 function
ms.date: 11/16/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Arrays
qsharp.name: Zip4
qsharp.summary: >-
  > [!WARNING]

  > Zip4 has been deprecated. Please use <xref:Microsoft.Quantum.Arrays.Zipped4> instead.


  Given four arrays, returns a new array of 4-tuples such that each 4-tuple
  contains an element from each original array.
---

# Zip4 function

Namespace: [Microsoft.Quantum.Arrays](xref:Microsoft.Quantum.Arrays)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


> [!WARNING]
> Zip4 has been deprecated. Please use <xref:Microsoft.Quantum.Arrays.Zipped4> instead.

Given four arrays, returns a new array of 4-tuples such that each 4-tuplecontains an element from each original array.

```qsharp
function Zip4<'T1, 'T2, 'T3, 'T4> (first : 'T1[], second : 'T2[], third : 'T3[], fourth : 'T4[]) : ('T1, 'T2, 'T3, 'T4)[]
```


## Input

### first : 'T1[]

An array containing values for the first element of each tuple.


### second : 'T2[]

An array containing values for the second element of each tuple.


### third : 'T3[]

An array containing values for the third element of each tuple.


### fourth : 'T4[]

An array containing values for the fourth element of each tuple.



## Output : ('T1,'T2,'T3,'T4)[]

An array containing 4-tuples of the form `(first[idx], second[idx], third[idx], fourth[idx])` foreach `idx`. If the four arrays are not of equal length, the output willbe as long as the shorter of the inputs.

## Type Parameters

### 'T1

The type of the first array elements.
### 'T2

The type of the second array elements.
### 'T3

The type of the third array elements.
### 'T4

The type of the fourth array elements.

## See Also

- [Microsoft.Quantum.Arrays.Zip](xref:Microsoft.Quantum.Arrays.Zip)
- [Microsoft.Quantum.Arrays.Zip3](xref:Microsoft.Quantum.Arrays.Zip3)