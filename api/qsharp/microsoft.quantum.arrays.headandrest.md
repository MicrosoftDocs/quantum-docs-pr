---
uid: Microsoft.Quantum.Arrays.HeadAndRest
title: HeadAndRest function
ms.date: 1/31/2021 12:00:00 AM
ms.topic: managed-reference
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Arrays
qsharp.name: HeadAndRest
qsharp.summary: Returns a tuple of first and all remaining elements of the array.
---

# HeadAndRest function

Namespace: [Microsoft.Quantum.Arrays](xref:Microsoft.Quantum.Arrays)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Returns a tuple of first and all remaining elements of the array.

```qsharp
function HeadAndRest<'A> (array : 'A[]) : ('A, 'A[])
```


## Input

### array : 'A[]

An array with at least one element.



## Output : ('A,'A[])

A tuple of first and all remaining elements of the array.

## Type Parameters

### 'A

The type of the array elements.