---
uid: Microsoft.Quantum.Canon.GrayCode
title: GrayCode function
ms.date: 10/26/2020 12:00:00 AM
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

```qsharp
function GrayCode (n : Int) : (Int, Int)[]
```


## Input

### n : [Int](xref:microsoft.quantum.lang-ref.int)

Number of bits



## Output : ([Int](xref:microsoft.quantum.lang-ref.int),[Int](xref:microsoft.quantum.lang-ref.int))[]

Array of tuples. First value in tuple is value in GrayCode sequenceSecond value in tuple is position to change in current value to getnext one.