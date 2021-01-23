---
uid: Microsoft.Quantum.Canon.BoundA
title: BoundA function
ms.date: 1/23/2021 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Canon
qsharp.name: BoundA
qsharp.summary: >-
  Given an array of operations acting on a single input,
  produces a new operation that
  performs each given operation in sequence.
  The modifier `A` indicates that all operations in the array are adjointable.
---

# BoundA function

Namespace: [Microsoft.Quantum.Canon](xref:Microsoft.Quantum.Canon)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Given an array of operations acting on a single input,produces a new operation thatperforms each given operation in sequence.The modifier `A` indicates that all operations in the array are adjointable.

```qsharp
function BoundA<'T> (operations : ('T => Unit is Adj)[]) : ('T => Unit is Adj)
```


## Input

### operations : 'T => [Unit](xref:microsoft.quantum.lang-ref.unit)  is Adj[]

A sequence of operations to be performed on a given input.



## Output : 'T => [Unit](xref:microsoft.quantum.lang-ref.unit)  is Adj

A new operation that performs each given operation in sequenceon its input.

## Type Parameters

### 'T

The target on which each of the operations in the array act.

## Example

The following are equivalent:```qsharplet bound = BoundA([U, V]);bound(x);```and```qsharpU(x); V(x);```

## See Also

- [Microsoft.Quantum.Canon.Bound](xref:Microsoft.Quantum.Canon.Bound)