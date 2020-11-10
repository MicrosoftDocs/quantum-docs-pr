---
uid: Microsoft.Quantum.Canon.OperationPowC
title: OperationPowC function
ms.date: 10/26/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Canon
qsharp.name: OperationPowC
qsharp.summary: >-
  Raises an operation to a power.
  The modifier `C` indicates that the operation is controllable.

  That is, given an operation representing a gate $U$, returns a new operation
  $U^m$ for a power $m$.
---

# OperationPowC function

Namespace: [Microsoft.Quantum.Canon](xref:Microsoft.Quantum.Canon)

Package: [](https://nuget.org/packages/)


Raises an operation to a power.The modifier `C` indicates that the operation is controllable.That is, given an operation representing a gate $U$, returns a new operation$U^m$ for a power $m$.

```qsharp
function OperationPowC<'T> (op : ('T => Unit is Ctl), power : Int) : ('T => Unit is Ctl)
```


## Input

### op : 'T => [Unit](xref:microsoft.quantum.lang-ref.unit) Ctl

An operation $U$ representing the gate to be repeated.


### power : [Int](xref:microsoft.quantum.lang-ref.int)

The number of times that $U$ is to be repeated.



## Output : 'T => [Unit](xref:microsoft.quantum.lang-ref.unit) Ctl

A new operation representing $U^m$, where $m = \texttt{power}$.

## Type Parameters

### 'T

The type of the operation to be powered.

## See Also

- [Microsoft.Quantum.Canon.OperationPow](xref:Microsoft.Quantum.Canon.OperationPow)