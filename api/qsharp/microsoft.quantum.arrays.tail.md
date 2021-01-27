---
uid: Microsoft.Quantum.Arrays.Tail
title: Tail function
ms.date: 1/27/2021 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Arrays
qsharp.name: Tail
qsharp.summary: Returns the last element of the array.
---

# Tail function

Namespace: [Microsoft.Quantum.Arrays](xref:Microsoft.Quantum.Arrays)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Returns the last element of the array.

```qsharp
function Tail<'A> (array : 'A[]) : 'A
```


## Input

### array : 'A[]

Array of which the last element is taken. Array must have length at least 1.



## Output : 'A

The last element of the array.

## Type Parameters

### 'A

The type of the array elements.