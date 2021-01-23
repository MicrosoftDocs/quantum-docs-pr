---
uid: Microsoft.Quantum.Canon.RepeatC
title: RepeatC operation
ms.date: 1/23/2021 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Canon
qsharp.name: RepeatC
qsharp.summary: Repeats an operation a given number of times.
---

# RepeatC operation

Namespace: [Microsoft.Quantum.Canon](xref:Microsoft.Quantum.Canon)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Repeats an operation a given number of times.

```qsharp
operation RepeatC<'TInput> (op : ('TInput => Unit is Ctl), nTimes : Int, input : 'TInput) : Unit is Ctl
```


## Input

### op : 'TInput => [Unit](xref:microsoft.quantum.lang-ref.unit)  is Ctl

The operation to be called repeatedly.


### nTimes : [Int](xref:microsoft.quantum.lang-ref.int)

The number of times to call `op`.


### input : 'TInput

The input to be passed to `op`.



## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)



## Type Parameters

### 'TInput



## Example

The following are equivalent:```Q#RepeatC(U, 17, target);(BoundC(ConstantArray(17, U)))(target);```

## See Also

- [Microsoft.Quantum.Arrays.DrawMany](xref:Microsoft.Quantum.Arrays.DrawMany)
- [Microsoft.Quantum.Canon.Repeat](xref:Microsoft.Quantum.Canon.Repeat)
- [Microsoft.Quantum.Canon.RepeatA](xref:Microsoft.Quantum.Canon.RepeatA)
- [Microsoft.Quantum.Canon.RepeatCA](xref:Microsoft.Quantum.Canon.RepeatCA)