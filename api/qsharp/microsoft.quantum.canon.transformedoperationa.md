---
uid: Microsoft.Quantum.Canon.TransformedOperationA
title: TransformedOperationA function
ms.date: 10/26/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Canon
qsharp.name: TransformedOperationA
qsharp.summary: >-
  Given a function and an operation, returns a new operation whose
  input is transformed by the given function.
---

# TransformedOperationA function

Namespace: [Microsoft.Quantum.Canon](xref:Microsoft.Quantum.Canon)

Package: [](https://nuget.org/packages/)


Given a function and an operation, returns a new operation whoseinput is transformed by the given function.

```qsharp
function TransformedOperationA<'T, 'U> (fn : ('U -> 'T), op : ('T => Unit is Adj)) : ('U => Unit is Adj)
```


## Input

### fn : 'U -> 'T

A function that transforms the given input into a form expected by theoperation.


### op : 'T => [Unit](xref:microsoft.quantum.lang-ref.unit) Adj

The operation to be transformed.



## Output : 'U => [Unit](xref:microsoft.quantum.lang-ref.unit) Adj

A new operation tbat calls `fn` with its input, then passes theresulting output to `op`.

## Type Parameters

### 'T


### 'U



## See Also

- [Microsoft.Quantum.Canon.TransformedOperation](xref:Microsoft.Quantum.Canon.TransformedOperation)
- [Microsoft.Quantum.Canon.TransformedOperationC](xref:Microsoft.Quantum.Canon.TransformedOperationC)
- [Microsoft.Quantum.Canon.TransformedOperationCA](xref:Microsoft.Quantum.Canon.TransformedOperationCA)
- [Microsoft.Quantum.Canon.ApplyWithInputTransformation](xref:Microsoft.Quantum.Canon.ApplyWithInputTransformation)
- [Microsoft.Quantum.Canon.Composed](xref:Microsoft.Quantum.Canon.Composed)