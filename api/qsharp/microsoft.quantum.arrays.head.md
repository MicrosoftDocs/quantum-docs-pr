---
uid: Microsoft.Quantum.Arrays.Head
title: Head function
ms.date: 12/2/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Arrays
qsharp.name: Head
qsharp.summary: Returns the first element of the array.
---

# Head function

Namespace: [Microsoft.Quantum.Arrays](xref:Microsoft.Quantum.Arrays)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Returns the first element of the array.

```qsharp
function Head<'A> (array : 'A[]) : 'A
```


## Input

### array : 'A[]

Array of which the first element is taken. Array must have length at least 1.



## Output : 'A

The first element of the array.

## Type Parameters

### 'A

The type of the array elements.