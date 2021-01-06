---
uid: Microsoft.Quantum.Arrays.Rest
title: Rest function
ms.date: 1/5/2021 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Arrays
qsharp.name: Rest
qsharp.summary: >-
  Creates an array that is equal to an input array except that the first array
  element is dropped.
---

# Rest function

Namespace: [Microsoft.Quantum.Arrays](xref:Microsoft.Quantum.Arrays)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Creates an array that is equal to an input array except that the first arrayelement is dropped.

```qsharp
function Rest<'T> (array : 'T[]) : 'T[]
```


## Input

### array : 'T[]

An array whose second to last elements are to form the output array.



## Output : 'T[]

An array containing the elements `array[1..Length(array) - 1]`.

## Type Parameters

### 'T

The type of the array elements.