---
uid: Microsoft.Quantum.Arrays.Partitioned
title: Partitioned function
ms.date: 12/7/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Arrays
qsharp.name: Partitioned
qsharp.summary: Splits an array into multiple parts.
---

# Partitioned function

Namespace: [Microsoft.Quantum.Arrays](xref:Microsoft.Quantum.Arrays)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Splits an array into multiple parts.

```qsharp
function Partitioned<'T> (nElements : Int[], arr : 'T[]) : 'T[][]
```


## Input

### nElements : [Int](xref:microsoft.quantum.lang-ref.int)[]

Number of elements in each part of array


### arr : 'T[]

Input array to be split.



## Output : 'T[][]

Multiple arrays where the first array is the first `nElements[0]` of `arr`and the second array are the next `nElements[1]` of `arr` etc. The last arraywill contain all remaining elements.

## Type Parameters

### 'T

