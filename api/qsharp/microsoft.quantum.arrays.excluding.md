---
uid: Microsoft.Quantum.Arrays.Excluding
title: Excluding function
ms.date: 12/8/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Arrays
qsharp.name: Excluding
qsharp.summary: >-
  Returns an array containing the elements of another array,
  excluding elements at a given list of indices.
---

# Excluding function

Namespace: [Microsoft.Quantum.Arrays](xref:Microsoft.Quantum.Arrays)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Returns an array containing the elements of another array,excluding elements at a given list of indices.

```qsharp
function Excluding<'T> (remove : Int[], array : 'T[]) : 'T[]
```


## Input

### remove : [Int](xref:microsoft.quantum.lang-ref.int)[]

An array of indices denoting which elements should be excludedfrom the output.


### array : 'T[]

Array of which the values in the output array are taken.



## Output : 'T[]

An array `output` such that `output[0]` is the first elementof `array` whose index does not appear in `remove`,such that `output[1]` is the second such element, and soforth.

## Type Parameters

### 'T

The type of the array elements.