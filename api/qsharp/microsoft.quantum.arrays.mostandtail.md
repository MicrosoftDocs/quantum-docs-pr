---
uid: Microsoft.Quantum.Arrays.MostAndTail
title: MostAndTail function
ms.date: 2/5/2021 12:00:00 AM
ms.topic: managed-reference
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Arrays
qsharp.name: MostAndTail
qsharp.summary: Returns a tuple of all but one and the last element of the array.
---

# MostAndTail function

Namespace: [Microsoft.Quantum.Arrays](xref:Microsoft.Quantum.Arrays)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Returns a tuple of all but one and the last element of the array.

```qsharp
function MostAndTail<'A> (array : 'A[]) : ('A[], 'A)
```


## Input

### array : 'A[]

An array with at least one element.



## Output : ('A[],'A)

A tuple of all but one and the last element of the array.

## Type Parameters

### 'A

The type of the array elements.