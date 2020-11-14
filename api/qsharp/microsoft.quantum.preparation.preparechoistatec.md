---
uid: Microsoft.Quantum.Preparation.PrepareChoiStateC
title: PrepareChoiStateC operation
ms.date: 11/13/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Preparation
qsharp.name: PrepareChoiStateC
qsharp.summary: >-
  Prepares the Choi–Jamiłkowski state for a given operation with a controlled variant onto given reference
  and target registers.
---

# PrepareChoiStateC operation

Namespace: [Microsoft.Quantum.Preparation](xref:Microsoft.Quantum.Preparation)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Prepares the Choi–Jamiłkowski state for a given operation with a controlled variant onto given referenceand target registers.

```qsharp
operation PrepareChoiStateC (op : (Qubit[] => Unit is Ctl), reference : Qubit[], target : Qubit[]) : Unit is Ctl
```


## Input

### op : [Qubit](xref:microsoft.quantum.lang-ref.qubit)[] => [Unit](xref:microsoft.quantum.lang-ref.unit)  is Ctl




### reference : [Qubit](xref:microsoft.quantum.lang-ref.qubit)[]




### target : [Qubit](xref:microsoft.quantum.lang-ref.qubit)[]





## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)



## See Also

- [Microsoft.Quantum.Preparation.PrepareChoiState](xref:Microsoft.Quantum.Preparation.PrepareChoiState)