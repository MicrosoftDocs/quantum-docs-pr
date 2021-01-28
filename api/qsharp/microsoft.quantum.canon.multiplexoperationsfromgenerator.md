---
uid: Microsoft.Quantum.Canon.MultiplexOperationsFromGenerator
title: MultiplexOperationsFromGenerator operation
ms.date: 1/28/2021 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Canon
qsharp.name: MultiplexOperationsFromGenerator
qsharp.summary: >-
  Applies a multiply-controlled unitary operation $U$ that applies a
  unitary $V_j$ when controlled by n-qubit number state $\ket{j}$.

  $U = \sum^{N-1}_{j=0}\ket{j}\bra{j}\otimes V_j$.
---

# MultiplexOperationsFromGenerator operation

Namespace: [Microsoft.Quantum.Canon](xref:Microsoft.Quantum.Canon)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Applies a multiply-controlled unitary operation $U$ that applies aunitary $V_j$ when controlled by n-qubit number state $\ket{j}$.$U = \sum^{N-1}_{j=0}\ket{j}\bra{j}\otimes V_j$.

```qsharp
operation MultiplexOperationsFromGenerator<'T> (unitaryGenerator : (Int, (Int -> ('T => Unit is Adj + Ctl))), index : Microsoft.Quantum.Arithmetic.LittleEndian, target : 'T) : Unit is Adj + Ctl
```


## Input

### unitaryGenerator : ([Int](xref:microsoft.quantum.lang-ref.int),[Int](xref:microsoft.quantum.lang-ref.int) -> 'T => [Unit](xref:microsoft.quantum.lang-ref.unit)  is Adj + Ctl)

A tuple where the first element `Int` is the number of unitaries $N$,and the second element `(Int -> ('T => () is Adj + Ctl))`is a function that takes an integer $j$ in $[0,N-1]$ and outputs the unitaryoperation $V_j$.


### index : [LittleEndian](xref:Microsoft.Quantum.Arithmetic.LittleEndian)

$n$-qubit control register that encodes number states $\ket{j}$ inlittle-endian format.


### target : 'T

Generic qubit register that $V_j$ acts on.



## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)



## Type Parameters

### 'T



## Remarks

`coefficients` will be padded with identity elements iffewer than $2^n$ are specified. This implementation uses$n-1$ auxiliary qubits.

## References

- [ *Andrew M. Childs, Dmitri Maslov, Yunseong Nam, Neil J. Ross, Yuan Su*,  arXiv:1711.10980](https://arxiv.org/abs/1711.10980)