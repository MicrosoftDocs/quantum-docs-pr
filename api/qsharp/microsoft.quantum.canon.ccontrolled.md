---
uid: Microsoft.Quantum.Canon.CControlled
title: CControlled function
ms.date: 10/26/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Canon
qsharp.name: CControlled
qsharp.summary: >-
  Given an operation op, returns a new operation which
  applies the op if a classical control bit is true. If `false`, nothing happens.
---

# CControlled function

Namespace: [Microsoft.Quantum.Canon](xref:Microsoft.Quantum.Canon)

Package: [](https://nuget.org/packages/)


Given an operation op, returns a new operation whichapplies the op if a classical control bit is true. If `false`, nothing happens.

```qsharp
function CControlled<'T> (op : ('T => Unit)) : ((Bool, 'T) => Unit)
```


## Input

### op : 'T => [Unit](xref:microsoft.quantum.lang-ref.unit) 

An operation to be conditionally applied.



## Output : ([Bool](xref:microsoft.quantum.lang-ref.bool),'T) => [Unit](xref:microsoft.quantum.lang-ref.unit) 

A new operation which is op if the classical control bit is true.

## Type Parameters

### 'T

The input type of the operation to be conditionally applied.

## See Also

- [Microsoft.Quantum.Canon.CControlledC](xref:Microsoft.Quantum.Canon.CControlledC)
- [Microsoft.Quantum.Canon.CControlledA](xref:Microsoft.Quantum.Canon.CControlledA)
- [Microsoft.Quantum.Canon.CControlledCA](xref:Microsoft.Quantum.Canon.CControlledCA)