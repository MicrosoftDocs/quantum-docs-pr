---
uid: Microsoft.Quantum.Canon.OperationPow
title: OperationPow function
ms.date: 12/17/2020 12:00:00 AM
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

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Raises an operation to a power.That is, given an operation representing a gate $U$, returns a new operation$U^m$ for a power $m$.

```qsharp
function OperationPow<'T> (op : ('T => Unit), power : Int) : ('T => Unit)
```


## Input

### op : 'T => [Unit](xref:microsoft.quantum.lang-ref.unit) 

An operation $U$ representing the gate to be repeated.


### power : [Int](xref:microsoft.quantum.lang-ref.int)

The number of times that $U$ is to be repeated.



## Output : 'T => [Unit](xref:microsoft.quantum.lang-ref.unit) 

A new operation representing $U^m$, where $m = \texttt{power}$.

## Type Parameters

### 'T

The type of the operation to be powered.

## See Also

- [Microsoft.Quantum.Canon.OperationPowC](xref:Microsoft.Quantum.Canon.OperationPowC)
- [Microsoft.Quantum.Canon.OperationPowA](xref:Microsoft.Quantum.Canon.OperationPowA)
- [Microsoft.Quantum.Canon.OperationPowCA](xref:Microsoft.Quantum.Canon.OperationPowCA)