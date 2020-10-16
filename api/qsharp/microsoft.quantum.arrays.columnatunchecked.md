---
uid: Microsoft.Quantum.Arrays.ColumnAtUnchecked
title: ColumnAtUnchecked function
ms.date: 10/16/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Arrays
qsharp.name: ColumnAtUnchecked
qsharp.summary: This function does not check for matrix shape
---

# ColumnAtUnchecked function

Namespace: [Microsoft.Quantum.Arrays](xref:Microsoft.Quantum.Arrays)

Package: [](https://nuget.org/packages/)


This function does not check for matrix shape

```Q#
ColumnAtUnchecked<'T> (column : Int, matrix : 'T[][]) : 'T[]
```


## Description

This function can be used in other multidimensional functions,which already check the input matrix for a valid rectangular shape.