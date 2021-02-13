---
uid: Microsoft.Quantum.Canon.TransformedOperationC
title: TransformedOperationC function
ms.date: 2/13/2021 12:00:00 AM
ms.topic: managed-reference
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Canon
qsharp.name: TransformedOperationC
qsharp.summary: >-
  Given a function and an operation, returns a new operation whose
  input is transformed by the given function.
---

# TransformedOperationC function

Namespace: [Microsoft.Quantum.Canon](xref:Microsoft.Quantum.Canon)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Given a function and an operation, returns a new operation whoseinput is transformed by the given function.

```qsharp
function TransformedOperationC<'T, 'U> (fn : ('U -> 'T), op : ('T => Unit is Ctl)) : ('U => Unit is Ctl)
```


## Input

### fn : 'U -> 'T

A function that transforms the given input into a form expected by theoperation.


### op : 'T => [Unit](xref:microsoft.quantum.lang-ref.unit)  is Ctl

The operation to be transformed.



## Output : 'U => [Unit](xref:microsoft.quantum.lang-ref.unit)  is Ctl

A new operation tbat calls `fn` with its input, then passes theresulting output to `op`.

## Type Parameters

### 'T


### 'U



## Example

The following call uses@"Microsoft.Quantum.Arithmetic.LittleEndianAsBigEndian" to transforman operation designed for@"Microsoft.Quantum.Arithmetic.BigEndian" inputs into an operationthat accepts inputs of type@"Microsoft.Quantum.Arithmetic.LittleEndian":```qsharplet leOp = TransformedOperation(LittleEndianAsBigEndian, ApplyXorInPlaceBE);```

## See Also

- [Microsoft.Quantum.Canon.TransformedOperation](xref:Microsoft.Quantum.Canon.TransformedOperation)
- [Microsoft.Quantum.Canon.TransformedOperationA](xref:Microsoft.Quantum.Canon.TransformedOperationA)
- [Microsoft.Quantum.Canon.TransformedOperationCA](xref:Microsoft.Quantum.Canon.TransformedOperationCA)
- [Microsoft.Quantum.Canon.ApplyWithInputTransformation](xref:Microsoft.Quantum.Canon.ApplyWithInputTransformation)
- [Microsoft.Quantum.Canon.Composed](xref:Microsoft.Quantum.Canon.Composed)