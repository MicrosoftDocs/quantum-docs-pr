---
uid: Microsoft.Quantum.Canon.ApplyIf
title: ApplyIf operation
ms.date: 11/1/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Canon
qsharp.name: ApplyIf
qsharp.summary: Applies an operation conditioned on a classical bit.
---

# ApplyIf operation

Namespace: [Microsoft.Quantum.Canon](xref:Microsoft.Quantum.Canon)

Package: [](https://nuget.org/packages/)


Applies an operation conditioned on a classical bit.

```qsharp
operation ApplyIf<'T> (op : ('T => Unit), bit : Bool, target : 'T) : Unit
```


## Description

Given an operation `op` and a bit value `bit`, applies `op` to the `target`if `bit` is `true`. If `false`, nothing happens to the `target`.

## Input

### op : 'T => [Unit](xref:microsoft.quantum.lang-ref.unit) 

An operation to be conditionally applied.


### bit : [Bool](xref:microsoft.quantum.lang-ref.bool)

a boolean that controls whether op is applied or not.


### target : 'T

The input to which the operation is applied.



## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)



## Type Parameters

### 'T

The input type of the operation to be conditionally applied.

## See Also

- [Microsoft.Quantum.Canon.ApplyIfC](xref:Microsoft.Quantum.Canon.ApplyIfC)
- [Microsoft.Quantum.Canon.ApplyIfA](xref:Microsoft.Quantum.Canon.ApplyIfA)
- [Microsoft.Quantum.Canon.ApplyIfCA](xref:Microsoft.Quantum.Canon.ApplyIfCA)