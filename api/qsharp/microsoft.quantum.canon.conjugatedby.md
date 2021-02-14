---
uid: Microsoft.Quantum.Canon.ConjugatedBy
title: ConjugatedBy function
ms.date: 2/14/2021 12:00:00 AM
ms.topic: managed-reference
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Canon
qsharp.name: ConjugatedBy
qsharp.summary: >-
  Given outer and inner operations, returns a new operation that
  conjugates the inner operation by the outer operation.
---

# ConjugatedBy function

Namespace: [Microsoft.Quantum.Canon](xref:Microsoft.Quantum.Canon)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Given outer and inner operations, returns a new operation thatconjugates the inner operation by the outer operation.

```qsharp
function ConjugatedBy<'T> (outerOperation : ('T => Unit is Adj), innerOperation : ('T => Unit)) : ('T => Unit)
```


## Input

### outerOperation : 'T => [Unit](xref:microsoft.quantum.lang-ref.unit)  is Adj

The operation $U$ that should be used to conjugate $V$. Note that theouter operation $U$ needs to be adjointable, but does notneed to be controllable.


### innerOperation : 'T => [Unit](xref:microsoft.quantum.lang-ref.unit) 

The operation $V$ being conjugated.



## Output : 'T => [Unit](xref:microsoft.quantum.lang-ref.unit) 

A new operation whose action is represented by the unitary$U^{\dagger} V U$.

## Type Parameters

### 'T

The type of the target on which each of the inner and outer operationsact.

## Remarks

The outer operation is always assumed to be adjointable, but does notneed to be controllable in order for the combined operation to becontrollable.

## See Also

- [Microsoft.Quantum.Canon.ConjugatedByA](xref:Microsoft.Quantum.Canon.ConjugatedByA)
- [Microsoft.Quantum.Canon.ConjugatedByC](xref:Microsoft.Quantum.Canon.ConjugatedByC)
- [Microsoft.Quantum.Canon.ConjugatedByCA](xref:Microsoft.Quantum.Canon.ConjugatedByCA)
- [Microsoft.Quantum.Canon.ApplyWith](xref:Microsoft.Quantum.Canon.ApplyWith)