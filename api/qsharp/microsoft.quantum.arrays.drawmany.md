---
uid: Microsoft.Quantum.Arrays.DrawMany
title: DrawMany operation
ms.date: 10/16/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Arrays
qsharp.name: DrawMany
qsharp.summary: >-
  Repeats an operation for a given number of samples, collecting its outputs
  in an array.
---

# DrawMany operation

Namespace: [Microsoft.Quantum.Arrays](xref:Microsoft.Quantum.Arrays)

Package: [](https://nuget.org/packages/)


Repeats an operation for a given number of samples, collecting its outputsin an array.

```Q#
DrawMany<'TInput, 'TOutput> (op : ('TInput => 'TOutput), nSamples : Int, input : 'TInput) : 'TOutput[]
```


## Input

### op : 'TInput => 'TOutput 

The operation to be called repeatedly.


### nSamples : Int

The number of samples of calling `op` to collect.


### input : 'TInput

The input to be passed to `op`.



## Type Parameters

### TInput

The type of input expected by `op`.


### TOutput

The type of output returned by `op`.



## See Also

- [Microsoft.Quantum.Canon.Repeat](xref:Microsoft.Quantum.Canon.Repeat)