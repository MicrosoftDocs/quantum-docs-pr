---
uid: Microsoft.Quantum.Canon.CControlledCA
title: CControlledCA function
ms.date: 2/3/2021 12:00:00 AM
ms.topic: managed-reference
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Canon
qsharp.name: CControlledCA
qsharp.summary: >-
  Given an operation op, returns a new operation which
  applies the op if a classical control bit is true. If `false`, nothing happens.
  The modifier `CA` indicates that the operation is controllable and adjointable.
---

# CControlledCA function

Namespace: [Microsoft.Quantum.Canon](xref:Microsoft.Quantum.Canon)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Given an operation op, returns a new operation whichapplies the op if a classical control bit is true. If `false`, nothing happens.The modifier `CA` indicates that the operation is controllable and adjointable.

```qsharp
function CControlledCA<'T> (op : ('T => Unit is Ctl + Adj)) : ((Bool, 'T) => Unit is Ctl + Adj)
```


## Input

### op : 'T => [Unit](xref:microsoft.quantum.lang-ref.unit)  is Adj + Ctl

An operation to be conditionally applied.



## Output : ([Bool](xref:microsoft.quantum.lang-ref.bool),'T) => [Unit](xref:microsoft.quantum.lang-ref.unit)  is Adj + Ctl

A new operation which is op if the classical control bit is true.

## Type Parameters

### 'T

The input type of the operation to be conditionally applied.

## See Also

- [Microsoft.Quantum.Canon.CControlled](xref:Microsoft.Quantum.Canon.CControlled)