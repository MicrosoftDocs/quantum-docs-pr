---
uid: Microsoft.Quantum.Preparation.PrepareChoiStateC
title: PrepareChoiStateC operation
ms.date: 11/25/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Preparation
qsharp.name: PrepareChoiStateC
qsharp.summary: >-
  Prepares the Choi–Jamiołkowski state for a given operation with a controlled variant onto given reference
  and target registers.
---

# PrepareChoiStateC operation

Namespace: [Microsoft.Quantum.Preparation](xref:Microsoft.Quantum.Preparation)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Prepares the Choi–Jamiołkowski state for a given operation with a controlled variant onto given referenceand target registers.

```qsharp
operation PrepareChoiStateC (op : (Qubit[] => Unit is Ctl), reference : Qubit[], target : Qubit[]) : Unit is Ctl
```


## Input

### op : [Qubit](xref:microsoft.quantum.concepts.the-qubit)[] => [Unit](xref:microsoft.quantum.user-guide.language.types)  is Ctl




### reference : [Qubit](xref:microsoft.quantum.concepts.the-qubit)[]




### target : [Qubit](xref:microsoft.quantum.concepts.the-qubit)[]





## Output : [Unit](xref:microsoft.quantum.user-guide.language.types)



## See Also

- [Microsoft.Quantum.Preparation.PrepareChoiState](xref:Microsoft.Quantum.Preparation.PrepareChoiState)