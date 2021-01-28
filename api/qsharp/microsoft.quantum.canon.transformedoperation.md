---
uid: Microsoft.Quantum.Canon.TransformedOperation
title: TransformedOperation function
ms.date: 1/28/2021 12:00:00 AM
ms.topic: managed-reference
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Canon
qsharp.name: TransformedOperation
qsharp.summary: >-
  Given a function and an operation, returns a new operation whose
  input is transformed by the given function.
---

# TransformedOperation function

Namespace: [Microsoft.Quantum.Canon](xref:Microsoft.Quantum.Canon)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Given a function and an operation, returns a new operation whoseinput is transformed by the given function.

```qsharp
function TransformedOperation<'T, 'U> (fn : ('U -> 'T), op : ('T => Unit)) : ('U => Unit)
```


## Input

### fn : 'U -> 'T

A function that transforms the given input into a form expected by theoperation.


### op : 'T => [Unit](xref:microsoft.quantum.lang-ref.unit) 

The operation to be transformed.



## Output : 'U => [Unit](xref:microsoft.quantum.lang-ref.unit) 

A new operation tbat calls `fn` with its input, then passes theresulting output to `op`.

## Type Parameters

### 'T


### 'U



## Example

The following call uses@"Microsoft.Quantum.Arithmetic.LittleEndianAsBigEndian" to transforman operation designed for@"Microsoft.Quantum.Arithmetic.BigEndian" inputs into an operationthat accepts inputs of type@"Microsoft.Quantum.Arithmetic.LittleEndian":```qsharplet leOp = TransformedOperation(LittleEndianAsBigEndian, ApplyXorInPlaceBE);```

## See Also

- [Microsoft.Quantum.Canon.TransformedOperationA](xref:Microsoft.Quantum.Canon.TransformedOperationA)
- [Microsoft.Quantum.Canon.TransformedOperationC](xref:Microsoft.Quantum.Canon.TransformedOperationC)
- [Microsoft.Quantum.Canon.TransformedOperationCA](xref:Microsoft.Quantum.Canon.TransformedOperationCA)
- [Microsoft.Quantum.Canon.ApplyWithInputTransformation](xref:Microsoft.Quantum.Canon.ApplyWithInputTransformation)
- [Microsoft.Quantum.Canon.Composed](xref:Microsoft.Quantum.Canon.Composed)