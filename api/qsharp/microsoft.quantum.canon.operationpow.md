---
uid: Microsoft.Quantum.Canon.OperationPow
title: OperationPow function
ms.date: 10/16/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Canon
qsharp.name: OperationPow
qsharp.summary: >-
  Raises an operation to a power.

  That is, given an operation representing a gate $U$, returns a new operation
  $U^m$ for a power $m$.
---

# OperationPow function

Namespace: [Microsoft.Quantum.Canon](xref:Microsoft.Quantum.Canon)

Package: [](https://nuget.org/packages/)


Raises an operation to a power.That is, given an operation representing a gate $U$, returns a new operation$U^m$ for a power $m$.

```Q#
OperationPow<'T> (op : ('T => Unit), power : Int) : ('T => Unit)
```


## Input

### op : 'T => Unit 

An operation $U$ representing the gate to be repeated.


### power : Int

The number of times that $U$ is to be repeated.



## Output

A new operation representing $U^m$, where $m = \texttt{power}$.

## Type Parameters

### 'T

The type of the operation to be powered.



## See Also

- [microsoft.quantum.canon.operationpowc](xref:microsoft.quantum.canon.operationpowc)
- [microsoft.quantum.canon.operationpowa](xref:microsoft.quantum.canon.operationpowa)
- [microsoft.quantum.canon.operationpowca](xref:microsoft.quantum.canon.operationpowca)