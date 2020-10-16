---
uid: Microsoft.Quantum.Canon.OperationPowCA
title: OperationPowCA function
ms.date: 10/16/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Canon
qsharp.name: OperationPowCA
qsharp.summary: >-
  Raises an operation to a power.
  The modifier `A` indicates that the operation is controllable and adjointable.

  That is, given an operation representing a gate $U$, returns a new operation
  $U^m$ for a power $m$.
---

# OperationPowCA function

Namespace: [Microsoft.Quantum.Canon](xref:Microsoft.Quantum.Canon)

Package: [](https://nuget.org/packages/)


Raises an operation to a power.The modifier `A` indicates that the operation is controllable and adjointable.That is, given an operation representing a gate $U$, returns a new operation$U^m$ for a power $m$.

```Q#
OperationPowCA<'T> (op : ('T => Unit is Ctl + Adj), power : Int) : ('T => Unit is Ctl + Adj)
```


## Input

### op : 'T => Unit Ctl + Adj

An operation $U$ representing the gate to be repeated.


### power : Int

The number of times that $U$ is to be repeated.



## Output

A new operation representing $U^m$, where $m = \texttt{power}$.

## Type Parameters

### 'T

The type of the operation to be powered.



## See Also

- [microsoft.quantum.canon.operationpow](xref:microsoft.quantum.canon.operationpow)