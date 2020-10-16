---
uid: Microsoft.Quantum.Arrays.Merged
title: Merged function
ms.date: 10/16/2020 12:00:00 AM
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

Package: [](https://nuget.org/packages/)


Given two sorted arrays, returns a single array containing theelements of both in sorted order. Used internally by merge sort.

```Q#
Merged<'T> (comparison : (('T, 'T) -> Bool), left : 'T[], right : 'T[]) : 'T[]
```
