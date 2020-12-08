---
uid: Microsoft.Quantum.Arrays.SequenceI
title: SequenceI function
ms.date: 12/8/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Arrays
qsharp.name: SequenceI
qsharp.summary: Get an array of integers in a given interval.
---

# SequenceI function

Namespace: [Microsoft.Quantum.Arrays](xref:Microsoft.Quantum.Arrays)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Get an array of integers in a given interval.

```qsharp
function SequenceI (from : Int, to : Int) : Int[]
```


## Input

### from : [Int](xref:microsoft.quantum.lang-ref.int)

An inclusive start index of the interval.


### to : [Int](xref:microsoft.quantum.lang-ref.int)

An inclusive end index of the interval that is not smaller than `from`.



## Output : [Int](xref:microsoft.quantum.lang-ref.int)[]

An array containing the sequence of numbers `from`, `from + 1`, ...,`to`.