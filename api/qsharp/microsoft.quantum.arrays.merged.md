---
uid: Microsoft.Quantum.Arrays.Merged
title: Merged function
ms.date: 11/26/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Arrays
qsharp.name: Merged
qsharp.summary: >-
  Given two sorted arrays, returns a single array containing the
  elements of both in sorted order. Used internally by merge sort.
---

# Merged function

Namespace: [Microsoft.Quantum.Arrays](xref:Microsoft.Quantum.Arrays)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Given two sorted arrays, returns a single array containing theelements of both in sorted order. Used internally by merge sort.

```qsharp
function Merged<'T> (comparison : (('T, 'T) -> Bool), left : 'T[], right : 'T[]) : 'T[]
```


## Input

### comparison : ('T,'T) -> [Bool](xref:microsoft.quantum.lang-ref.bool)




### left : 'T[]




### right : 'T[]





## Output : 'T[]



## Type Parameters

### 'T

