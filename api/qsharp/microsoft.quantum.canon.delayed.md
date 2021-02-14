---
uid: Microsoft.Quantum.Canon.Delayed
title: Delayed function
ms.date: 2/14/2021 12:00:00 AM
ms.topic: managed-reference
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Canon
qsharp.name: Delayed
qsharp.summary: >-
  Returns an operation that applies
  given operation with given argument.
---

# Delayed function

Namespace: [Microsoft.Quantum.Canon](xref:Microsoft.Quantum.Canon)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Returns an operation that appliesgiven operation with given argument.

```qsharp
function Delayed<'T, 'U> (op : ('T => 'U), arg : 'T) : (Unit => 'U)
```


## Input

### op : 'T => 'U 

An operation to be applied.


### arg : 'T

The input to which the operation is applied.



## Output : [Unit](xref:microsoft.quantum.lang-ref.unit) => 'U 

A new operation which applies `op` with input `arg`

## Type Parameters

### 'T

The input type of the operation to be delayed.
### 'U

The return type of the operation to be delayed.

## See Also

- [Microsoft.Quantum.Canon.DelayedC](xref:Microsoft.Quantum.Canon.DelayedC)
- [Microsoft.Quantum.Canon.DelayedA](xref:Microsoft.Quantum.Canon.DelayedA)
- [Microsoft.Quantum.Canon.DelayedCA](xref:Microsoft.Quantum.Canon.DelayedCA)
- [Microsoft.Quantum.Canon.Delay](xref:Microsoft.Quantum.Canon.Delay)