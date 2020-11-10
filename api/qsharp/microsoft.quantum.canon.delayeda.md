---
uid: Microsoft.Quantum.Canon.DelayedA
title: DelayedA function
ms.date: 10/26/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Canon
qsharp.name: DelayedA
qsharp.summary: >-
  Returns an operation that applies
  given operation with given argument.
---

# DelayedA function

Namespace: [Microsoft.Quantum.Canon](xref:Microsoft.Quantum.Canon)

Package: [](https://nuget.org/packages/)


Returns an operation that appliesgiven operation with given argument.

```qsharp
function DelayedA<'T> (op : ('T => Unit is Adj), arg : 'T) : (Unit => Unit is Adj)
```


## Input

### op : 'T => [Unit](xref:microsoft.quantum.lang-ref.unit) Adj

An operation to be applied as a result of applying return value


### arg : 'T

The input to which the operation `op` is applied.



## Output : [Unit](xref:microsoft.quantum.lang-ref.unit) => [Unit](xref:microsoft.quantum.lang-ref.unit) Adj

A new operation which applies `op` with input `arg`

## Type Parameters

### 'T

The input type of the operation to be delayed.

## See Also

- [Microsoft.Quantum.Canon.Delayed](xref:Microsoft.Quantum.Canon.Delayed)
- [Microsoft.Quantum.Canon.Delay](xref:Microsoft.Quantum.Canon.Delay)