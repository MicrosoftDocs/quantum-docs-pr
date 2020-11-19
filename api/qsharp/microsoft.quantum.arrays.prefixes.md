---
uid: Microsoft.Quantum.Arrays.Prefixes
title: Prefixes function
ms.date: 11/19/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Arrays
qsharp.name: Prefixes
qsharp.summary: Given an array, returns all its prefixes.
---

# Prefixes function

Namespace: [Microsoft.Quantum.Arrays](xref:Microsoft.Quantum.Arrays)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Given an array, returns all its prefixes.

```qsharp
function Prefixes<'T> (array : 'T[]) : 'T[][]
```


## Description

Returns an array of all prefixes, starting with an array that onlyhas the first element until the complete array.

## Input

### array : 'T[]

An array of elements.



## Output : 'T[][]



## Type Parameters

### 'T

The type of `array` elements.