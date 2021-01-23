---
uid: Microsoft.Quantum.Canon.OperationPowCA
title: OperationPowCA function
ms.date: 1/23/2021 12:00:00 AM
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

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Raises an operation to a power.The modifier `A` indicates that the operation is controllable and adjointable.That is, given an operation representing a gate $U$, returns a new operation$U^m$ for a power $m$.

```qsharp
function OperationPowCA<'T> (op : ('T => Unit is Ctl + Adj), power : Int) : ('T => Unit is Ctl + Adj)
```


## Input

### op : 'T => [Unit](xref:microsoft.quantum.lang-ref.unit)  is Adj + Ctl

An operation $U$ representing the gate to be repeated.


### power : [Int](xref:microsoft.quantum.lang-ref.int)

The number of times that $U$ is to be repeated.



## Output : 'T => [Unit](xref:microsoft.quantum.lang-ref.unit)  is Adj + Ctl

A new operation representing $U^m$, where $m = \texttt{power}$.

## Type Parameters

### 'T

The type of the operation to be powered.

## See Also

- [Microsoft.Quantum.Canon.OperationPow](xref:Microsoft.Quantum.Canon.OperationPow)