---
uid: Microsoft.Quantum.Arrays.DrawMany
title: DrawMany operation
ms.date: 1/29/2021 12:00:00 AM
ms.topic: managed-reference
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Arrays
qsharp.name: DrawMany
qsharp.summary: >-
  Repeats an operation for a given number of samples, collecting its outputs
  in an array.
---

# DrawMany operation

Namespace: [Microsoft.Quantum.Arrays](xref:Microsoft.Quantum.Arrays)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


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



## Example

The following samples an integer, given an operationthat samples a single bit at a time.```qsharplet randomInteger = BoolArrayAsInt(DrawMany(SampleRandomBit, 16, ()));```

## See Also

- [Microsoft.Quantum.Canon.Repeat](xref:Microsoft.Quantum.Canon.Repeat)