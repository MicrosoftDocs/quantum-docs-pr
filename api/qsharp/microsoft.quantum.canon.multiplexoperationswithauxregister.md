---
uid: Microsoft.Quantum.Canon.MultiplexOperationsWithAuxRegister
title: MultiplexOperationsWithAuxRegister operation
ms.date: 11/25/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Canon
qsharp.name: MultiplexOperationsWithAuxRegister
qsharp.summary: Implementation step of MultiplexOperations.
---

# MultiplexOperationsWithAuxRegister operation

Namespace: [Microsoft.Quantum.Canon](xref:Microsoft.Quantum.Canon)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Implementation step of MultiplexOperations.

```qsharp
operation MultiplexOperationsWithAuxRegister<'T> (unitaries : ('T => Unit is Adj + Ctl)[], auxillaryRegister : Qubit[], index : Microsoft.Quantum.Arithmetic.LittleEndian, target : 'T) : Unit is Adj + Ctl
```


## Input

### unitaries : 'T => [Unit](xref:microsoft.quantum.user-guide.language.types)  is Adj + Ctl[]




### auxillaryRegister : [Qubit](xref:microsoft.quantum.concepts.the-qubit)[]




### index : [LittleEndian](xref:Microsoft.Quantum.Arithmetic.LittleEndian)




### target : 'T





## Output : [Unit](xref:microsoft.quantum.user-guide.language.types)



## Type Parameters

### 'T



## See Also

- [Microsoft.Quantum.Canon.MultiplexOperations](xref:Microsoft.Quantum.Canon.MultiplexOperations)