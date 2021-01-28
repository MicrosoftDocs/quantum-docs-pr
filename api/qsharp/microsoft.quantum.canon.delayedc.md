---
uid: Microsoft.Quantum.Canon.DelayedC
title: DelayedC function
ms.date: 1/28/2021 12:00:00 AM
ms.topic: managed-reference
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Canon
qsharp.name: DelayedC
qsharp.summary: >-
  Returns an operation that applies
  given operation with given argument.
---

# DelayedC function

Namespace: [Microsoft.Quantum.Canon](xref:Microsoft.Quantum.Canon)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Returns an operation that appliesgiven operation with given argument.

```qsharp
function DelayedC<'T> (op : ('T => Unit is Ctl), arg : 'T) : (Unit => Unit is Ctl)
```


## Input

### op : 'T => [Unit](xref:microsoft.quantum.lang-ref.unit)  is Ctl

An operation to be applied as a result of applying return value


### arg : 'T

The input to which the operation `op` is applied.



## Output : [Unit](xref:microsoft.quantum.lang-ref.unit) => [Unit](xref:microsoft.quantum.lang-ref.unit)  is Ctl

A new operation which applies `op` with input `arg`

## Type Parameters

### 'T

The input type of the operation to be delayed.

## See Also

- [Microsoft.Quantum.Canon.Delayed](xref:Microsoft.Quantum.Canon.Delayed)
- [Microsoft.Quantum.Canon.Delay](xref:Microsoft.Quantum.Canon.Delay)