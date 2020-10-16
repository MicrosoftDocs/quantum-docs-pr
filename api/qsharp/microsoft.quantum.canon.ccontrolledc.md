---
uid: Microsoft.Quantum.Canon.CControlledC
title: CControlledC function
ms.date: 10/16/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Canon
qsharp.name: CControlledC
qsharp.summary: >-
  Given an operation op, returns a new operation which
  applies the op if a classical control bit is true. If `false`, nothing happens.
  The modifier `C` indicates that the operation is controllable.
---

# CControlledC function

Namespace: [Microsoft.Quantum.Canon](xref:Microsoft.Quantum.Canon)

Package: [](https://nuget.org/packages/)


Given an operation op, returns a new operation whichapplies the op if a classical control bit is true. If `false`, nothing happens.The modifier `C` indicates that the operation is controllable.

```Q#
CControlledC<'T> (op : ('T => Unit is Ctl)) : ((Bool, 'T) => Unit is Ctl)
```


## Input

### op : 'T => Unit Ctl

An operation to be conditionally applied.



## Output

A new operation which is op if the classical control bit is true.

## Type Parameters

### 'T

The input type of the operation to be conditionally applied.



## See Also

- [Microsoft.Quantum.Canon.CControlled](xref:Microsoft.Quantum.Canon.CControlled)