---
uid: Microsoft.Quantum.Canon.ApplyWithInputTransformation
title: ApplyWithInputTransformation operation
ms.date: 2/4/2021 12:00:00 AM
ms.topic: managed-reference
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Canon
qsharp.name: ApplyWithInputTransformation
qsharp.summary: >-
  Given an operation that accepts some input, a function that
  returns an output compatible with that operation, and an input to that
  function, applies the operation using the function to transform the
  input to a form expected by the operation.
---

# ApplyWithInputTransformation operation

Namespace: [Microsoft.Quantum.Canon](xref:Microsoft.Quantum.Canon)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Given an operation that accepts some input, a function thatreturns an output compatible with that operation, and an input to thatfunction, applies the operation using the function to transform theinput to a form expected by the operation.

```qsharp
operation ApplyWithInputTransformation<'T, 'U> (fn : ('U -> 'T), op : ('T => Unit), input : 'U) : Unit
```


## Input

### fn : 'U -> 'T

A function that transforms the given input into a form expected by theoperation.


### op : 'T => [Unit](xref:microsoft.quantum.lang-ref.unit) 

The operation to be applied.


### input : 'U

An input to the function.



## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)



## Type Parameters

### 'T


### 'U



## Example

The following call uses@"Microsoft.Quantum.Arithmetic.LittleEndianAsBigEndian" to applyan operation designed for@"Microsoft.Quantum.Arithmetic.BigEndian" inputs to an input of type@"Microsoft.Quantum.Arithmetic.LittleEndian":```qsharpApplyWithInputTransformation(LittleEndianAsBigEndian, ApplyXorInPlaceBE, LittleEndian(qubits));```

## See Also

- [Microsoft.Quantum.Canon.ApplyWithInputTransformationA](xref:Microsoft.Quantum.Canon.ApplyWithInputTransformationA)
- [Microsoft.Quantum.Canon.ApplyWithInputTransformationC](xref:Microsoft.Quantum.Canon.ApplyWithInputTransformationC)
- [Microsoft.Quantum.Canon.ApplyWithInputTransformationCA](xref:Microsoft.Quantum.Canon.ApplyWithInputTransformationCA)
- [Microsoft.Quantum.Canon.TransformedOperation](xref:Microsoft.Quantum.Canon.TransformedOperation)