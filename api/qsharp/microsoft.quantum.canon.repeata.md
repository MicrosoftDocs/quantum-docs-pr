---
uid: Microsoft.Quantum.Canon.RepeatA
title: RepeatA operation
ms.date: 10/26/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Canon
qsharp.name: RepeatA
qsharp.summary: Repeats an operation a given number of times.
---

# RepeatA operation

Namespace: [Microsoft.Quantum.Canon](xref:Microsoft.Quantum.Canon)

Package: [](https://nuget.org/packages/)


Repeats an operation a given number of times.

```qsharp
operation RepeatA<'TInput> (op : ('TInput => Unit is Adj), nTimes : Int, input : 'TInput) : Unit
```


## Input

### op : 'TInput => [Unit](xref:microsoft.quantum.lang-ref.unit) Adj

The operation to be called repeatedly.


### nTimes : [Int](xref:microsoft.quantum.lang-ref.int)

The number of times to call `op`.


### input : 'TInput

The input to be passed to `op`.



## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)



## Type Parameters

### 'TInput



## See Also

- [Microsoft.Quantum.Arrays.DrawMany](xref:Microsoft.Quantum.Arrays.DrawMany)
- [Microsoft.Quantum.Canon.Repeat](xref:Microsoft.Quantum.Canon.Repeat)
- [Microsoft.Quantum.Canon.RepeatC](xref:Microsoft.Quantum.Canon.RepeatC)
- [Microsoft.Quantum.Canon.RepeatCA](xref:Microsoft.Quantum.Canon.RepeatCA)