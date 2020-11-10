---
uid: Microsoft.Quantum.Preparation.PrepareChoiStateCA
title: PrepareChoiStateCA operation
ms.date: 10/26/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Preparation
qsharp.name: PrepareChoiStateCA
qsharp.summary: >-
  Prepares the Choi–Jamiłkowski state for a given operation with both controlled and adjoint variants onto given reference
  and target registers.
---

# PrepareChoiStateCA operation

Namespace: [Microsoft.Quantum.Preparation](xref:Microsoft.Quantum.Preparation)

Package: [](https://nuget.org/packages/)


Prepares the Choi–Jamiłkowski state for a given operation with both controlled and adjoint variants onto given referenceand target registers.

```qsharp
operation PrepareChoiStateCA (op : (Qubit[] => Unit is Adj + Ctl), reference : Qubit[], target : Qubit[]) : Unit
```


## Input

### op : [Qubit](xref:microsoft.quantum.lang-ref.qubit)[] => [Unit](xref:microsoft.quantum.lang-ref.unit) Adj + Ctl




### reference : [Qubit](xref:microsoft.quantum.lang-ref.qubit)[]




### target : [Qubit](xref:microsoft.quantum.lang-ref.qubit)[]





## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)



## See Also

- [Microsoft.Quantum.Preparation.PrepareChoiState](xref:Microsoft.Quantum.Preparation.PrepareChoiState)