---
uid: Microsoft.Quantum.Arrays.SequenceI
title: SequenceI function
ms.date: 10/16/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Arrays
qsharp.name: SequenceI
qsharp.summary: Get an array of integers in a given interval.
---

# SequenceI function

Namespace: [Microsoft.Quantum.Arrays](xref:Microsoft.Quantum.Arrays)

Package: [](https://nuget.org/packages/)


Get an array of integers in a given interval.

```Q#
SequenceI (from : Int, to : Int) : Int[]
```


## Input

### from : Int

An inclusive start index of the interval.


### to : Int

An inclusive end index of the interval that is not smaller than `from`.



## Output

An array containing the sequence of numbers `from`, `from + 1`, ...,`to`.