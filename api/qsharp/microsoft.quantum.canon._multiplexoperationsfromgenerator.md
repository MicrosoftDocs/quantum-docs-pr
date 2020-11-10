---
uid: Microsoft.Quantum.Canon._MultiplexOperationsFromGenerator
title: _MultiplexOperationsFromGenerator operation
ms.date: 10/26/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Canon
qsharp.name: _MultiplexOperationsFromGenerator
qsharp.summary: Implementation step of `MultiplexOperationsFromGenerator`.
---

# _MultiplexOperationsFromGenerator operation

Namespace: [Microsoft.Quantum.Canon](xref:Microsoft.Quantum.Canon)

Package: [](https://nuget.org/packages/)


Implementation step of `MultiplexOperationsFromGenerator`.

```qsharp
operation _MultiplexOperationsFromGenerator<'T> (unitaryGenerator : (Int, Int, (Int -> ('T => Unit is Adj + Ctl))), auxiliary : Qubit[], index : Microsoft.Quantum.Arithmetic.LittleEndian, target : 'T) : Unit
```


## Input

### unitaryGenerator : ([Int](xref:microsoft.quantum.lang-ref.int),[Int](xref:microsoft.quantum.lang-ref.int),[Int](xref:microsoft.quantum.lang-ref.int) -> 'T => [Unit](xref:microsoft.quantum.lang-ref.unit) Adj + Ctl)




### auxiliary : [Qubit](xref:microsoft.quantum.lang-ref.qubit)[]




### index : [LittleEndian](xref:Microsoft.Quantum.Arithmetic.LittleEndian)




### target : 'T





## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)



## Type Parameters

### 'T



## See Also

- [Microsoft.Quantum.Canon.MultiplexOperationsFromGenerator](xref:Microsoft.Quantum.Canon.MultiplexOperationsFromGenerator)