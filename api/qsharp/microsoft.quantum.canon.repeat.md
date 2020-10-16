---
uid: Microsoft.Quantum.Canon.Repeat
title: Repeat operation
ms.date: 10/16/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Canon
qsharp.name: Repeat
qsharp.summary: Repeats an operation a given number of times.
---

# Repeat operation

Namespace: [Microsoft.Quantum.Canon](xref:Microsoft.Quantum.Canon)

Package: [](https://nuget.org/packages/)


Repeats an operation a given number of times.

```Q#
Repeat<'TInput> (op : ('TInput => Unit), nTimes : Int, input : 'TInput) : Unit
```


## Input

### op : 'TInput => Unit 

The operation to be called repeatedly.


### nTimes : Int

The number of times to call `op`.


### input : 'TInput

The input to be passed to `op`.



## Type Parameters

### TInput

The type of input expected by `op`.



## See Also

- [Microsoft.Quantum.Arrays.DrawMany](xref:Microsoft.Quantum.Arrays.DrawMany)
- [Microsoft.Quantum.Canon.RepeatA](xref:Microsoft.Quantum.Canon.RepeatA)
- [Microsoft.Quantum.Canon.RepeatC](xref:Microsoft.Quantum.Canon.RepeatC)
- [Microsoft.Quantum.Canon.RepeatCA](xref:Microsoft.Quantum.Canon.RepeatCA)