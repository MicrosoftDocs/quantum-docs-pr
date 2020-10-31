---
uid: Microsoft.Quantum.Arrays.DrawMany
title: DrawMany operation
ms.date: 10/31/2020 12:00:00 AM
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

```qsharp
operation DrawMany<'TInput, 'TOutput> (op : ('TInput => 'TOutput), nSamples : Int, input : 'TInput) : 'TOutput[]
```


## Input

### op : 'TInput => 'TOutput 

The operation to be called repeatedly.


### nSamples : [Int](xref:microsoft.quantum.lang-ref.int)

The number of samples of calling `op` to collect.


### input : 'TInput

The input to be passed to `op`.



## Output : 'TOutput[]



## Type Parameters

### 'TInput


### 'TOutput



## See Also

- [Microsoft.Quantum.Canon.Repeat](xref:Microsoft.Quantum.Canon.Repeat)