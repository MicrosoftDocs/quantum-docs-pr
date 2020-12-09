---
uid: Microsoft.Quantum.Canon.MultiplexOperations
title: MultiplexOperations operation
ms.date: 12/9/2020 12:00:00 AM
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

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Applies an array of operations controlled by an array of number states.That is, applies Multiply-controlled unitary operation $U$ that applies aunitary $V_j$ when controlled by $n$-qubit number state $\ket{j}$.$U = \sum^{2^n-1}_{j=0}\ket{j}\bra{j}\otimes V_j$.

```qsharp
operation MultiplexOperations<'T> (unitaries : ('T => Unit is Adj + Ctl)[], index : Microsoft.Quantum.Arithmetic.LittleEndian, target : 'T) : Unit is Adj + Ctl
```


## Input

### unitaries : 'T => [Unit](xref:microsoft.quantum.lang-ref.unit)  is Adj + Ctl[]

Array of up to $2^n$ unitary operations. The $j$th operationis indexed by the number state $\ket{j}$ encoded in little-endian format.


### index : [LittleEndian](xref:Microsoft.Quantum.Arithmetic.LittleEndian)

$n$-qubit control register that encodes number states $\ket{j}$ inlittle-endian format.


### target : 'T

Generic qubit register that $V_j$ acts on.



## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)



## Type Parameters

### 'T



## Remarks

`coefficients` will be padded with identity elements iffewer than $2^n$ are specified. This implementation uses$n - 1$ auxiliary qubits.

## References

- Toward the first quantum simulation with quantum speedup  Andrew M. Childs, Dmitri Maslov, Yunseong Nam, Neil J. Ross, Yuan Su  https://arxiv.org/abs/1711.10980