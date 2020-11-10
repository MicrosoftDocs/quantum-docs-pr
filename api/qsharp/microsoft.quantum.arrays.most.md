---
uid: Microsoft.Quantum.Arrays.Most
title: Most function
ms.date: 10/26/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Arrays
qsharp.name: Most
qsharp.summary: >-
  Creates an array that is equal to an input array except that the last array
  element is dropped.
---

# Most function

Namespace: [Microsoft.Quantum.Arrays](xref:Microsoft.Quantum.Arrays)

Package: [](https://nuget.org/packages/)


Creates an array that is equal to an input array except that the last arrayelement is dropped.

```qsharp
function Most<'T> (array : 'T[]) : 'T[]
```


## Input

### array : 'T[]

An array whose first to second-to-last elements are to form the output array.



## Output : 'T[]

An array containing the elements `array[0..Length(array) - 2]`.

## Type Parameters

### 'T

The type of the array elements.