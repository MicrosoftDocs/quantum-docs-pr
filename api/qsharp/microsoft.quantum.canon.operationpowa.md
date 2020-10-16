---
uid: Microsoft.Quantum.Canon.OperationPowA
title: OperationPowA function
ms.date: 10/16/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Canon
qsharp.name: OperationPowA
qsharp.summary: >-
  Raises an operation to a power.
  The modifier `A` indicates that the operation is adjointable.

  That is, given an operation representing a gate $U$, returns a new operation
  $U^m$ for a power $m$.
---

# OperationPowA function

Namespace: [Microsoft.Quantum.Canon](xref:Microsoft.Quantum.Canon)

Package: [](https://nuget.org/packages/)


Raises an operation to a power.The modifier `A` indicates that the operation is adjointable.That is, given an operation representing a gate $U$, returns a new operation$U^m$ for a power $m$.

```Q#
OperationPowA<'T> (op : ('T => Unit is Adj), power : Int) : ('T => Unit is Adj)
```


## Input

### op : 'T => Unit Adj

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