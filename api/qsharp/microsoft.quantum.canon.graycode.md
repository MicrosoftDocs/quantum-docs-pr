---
uid: Microsoft.Quantum.Canon.GrayCode
title: GrayCode function
ms.date: 10/16/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Canon
qsharp.name: GrayCode
qsharp.summary: Creates Gray code sequences
---

# GrayCode function

Namespace: [Microsoft.Quantum.Canon](xref:Microsoft.Quantum.Canon)

Package: [](https://nuget.org/packages/)


Creates Gray code sequences

```Q#
GrayCode (n : Int) : (Int, Int)[]
```


## Input

### n : Int

Number of bits



## Output

Array of tuples. First value in tuple is value in GrayCode sequenceSecond value in tuple is position to change in current value to getnext one.