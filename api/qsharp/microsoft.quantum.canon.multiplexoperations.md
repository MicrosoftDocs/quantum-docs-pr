---
uid: Microsoft.Quantum.Canon.MultiplexOperations
title: MultiplexOperations operation
ms.date: 10/26/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Canon
qsharp.name: MultiplexOperations
qsharp.summary: >-
  Applies an array of operations controlled by an array of number states.

  That is, applies Multiply-controlled unitary operation $U$ that applies a
  unitary $V_j$ when controlled by $n$-qubit number state $\ket{j}$.

  $U = \sum^{2^n-1}_{j=0}\ket{j}\bra{j}\otimes V_j$.
---

# MultiplexOperations operation

Namespace: [Microsoft.Quantum.Canon](xref:Microsoft.Quantum.Canon)

Package: [](https://nuget.org/packages/)


Applies an array of operations controlled by an array of number states.

```qsharp
operation MultiplexOperations<'T> (unitaries : ('T => Unit is Adj + Ctl)[], index : Microsoft.Quantum.Arithmetic.LittleEndian, target : 'T) : Unit
```


## Input

### unitaries : 'T => [Unit](xref:microsoft.quantum.lang-ref.unit) Adj + Ctl[]

Array of up to $2^n$ unitary operations. The $j$th operation


### index : [LittleEndian](xref:Microsoft.Quantum.Arithmetic.LittleEndian)

$n$-qubit control register that encodes number states $\ket{j}$ in


### target : 'T

Generic qubit register that $V_j$ acts on.



## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)



## Type Parameters

### 'T



## Remarks

`coefficients` will be padded with identity elements if

## References

- Toward the first quantum simulation with quantum speedup