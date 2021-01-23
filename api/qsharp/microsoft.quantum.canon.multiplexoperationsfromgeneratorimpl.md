---
uid: Microsoft.Quantum.Canon.MultiplexOperationsFromGeneratorImpl
title: MultiplexOperationsFromGeneratorImpl operation
ms.date: 1/23/2021 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Canon
qsharp.name: MultiplexOperationsFromGeneratorImpl
qsharp.summary: Implementation step of `MultiplexOperationsFromGenerator`.
---

# MultiplexOperationsFromGeneratorImpl operation

Namespace: [Microsoft.Quantum.Canon](xref:Microsoft.Quantum.Canon)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Implementation step of `MultiplexOperationsFromGenerator`.

```qsharp
operation MultiplexOperationsFromGeneratorImpl<'T> (unitaryGenerator : (Int, Int, (Int -> ('T => Unit is Adj + Ctl))), auxiliary : Qubit[], index : Microsoft.Quantum.Arithmetic.LittleEndian, target : 'T) : Unit is Adj + Ctl
```


## Input

### unitaryGenerator : ([Int](xref:microsoft.quantum.lang-ref.int),[Int](xref:microsoft.quantum.lang-ref.int),[Int](xref:microsoft.quantum.lang-ref.int) -> 'T => [Unit](xref:microsoft.quantum.lang-ref.unit)  is Adj + Ctl)




### auxiliary : [Qubit](xref:microsoft.quantum.lang-ref.qubit)[]




### index : [LittleEndian](xref:Microsoft.Quantum.Arithmetic.LittleEndian)




### target : 'T





## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)



## Type Parameters

### 'T



## See Also

- [Microsoft.Quantum.Canon.MultiplexOperationsFromGenerator](xref:Microsoft.Quantum.Canon.MultiplexOperationsFromGenerator)