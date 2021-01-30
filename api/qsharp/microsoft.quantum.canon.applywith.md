---
uid: Microsoft.Quantum.Canon.ApplyWith
title: ApplyWith operation
ms.date: 1/30/2021 12:00:00 AM
ms.topic: managed-reference
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Canon
qsharp.name: ApplyWith
qsharp.summary: Given two operations, applies one as conjugated with the other.
---

# ApplyWith operation

Namespace: [Microsoft.Quantum.Canon](xref:Microsoft.Quantum.Canon)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Given two operations, applies one as conjugated with the other.

```qsharp
operation ApplyWith<'T> (outerOperation : ('T => Unit is Adj), innerOperation : ('T => Unit), target : 'T) : Unit
```


## Description

Given two operations, respectively described by unitary operators $U$and $V$, applies them in the sequence $U^{\dagger} V U$. That is,this operation implements the unitary operator given by $V$ conjugatedwith $U$.

## Input

### outerOperation : 'T => [Unit](xref:microsoft.quantum.lang-ref.unit)  is Adj

The operation $U$ that should be used to conjugate $V$. Note that theouter operation $U$ needs to be adjointable, but does notneed to be controllable.


### innerOperation : 'T => [Unit](xref:microsoft.quantum.lang-ref.unit) 

The operation $V$ being conjugated.


### target : 'T

The input to be provided to the outer and inner operations.



## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)



## Type Parameters

### 'T

The target on which each of the inner and outer operations act.

## Remarks

The outer operation is always assumed to be adjointable, but does notneed to be controllable in order for the combined operation to becontrollable.

## See Also

- [Microsoft.Quantum.Canon.ApplyWithA](xref:Microsoft.Quantum.Canon.ApplyWithA)
- [Microsoft.Quantum.Canon.ApplyWithC](xref:Microsoft.Quantum.Canon.ApplyWithC)
- [Microsoft.Quantum.Canon.ApplyWithCA](xref:Microsoft.Quantum.Canon.ApplyWithCA)