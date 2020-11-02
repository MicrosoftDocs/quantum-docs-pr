---
uid: Microsoft.Quantum.Canon.MultiplexPauli
title: MultiplexPauli operation
ms.date: 11/2/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Canon
qsharp.name: MultiplexPauli
qsharp.summary: Applies a Pauli rotation conditioned on an array of qubits.
---

# MultiplexPauli operation

Namespace: [Microsoft.Quantum.Canon](xref:Microsoft.Quantum.Canon)

Package: [](https://nuget.org/packages/)


Applies a Pauli rotation conditioned on an array of qubits.

```qsharp
operation MultiplexPauli (coefficients : Double[], pauli : Pauli, control : Microsoft.Quantum.Arithmetic.LittleEndian, target : Qubit) : Unit
```


## Description

This applies a multiply controlled unitary operation that performsrotations by angle $\theta_j$ about single-qubit Pauli operator $P$when controlled by the $n$-qubit number state $\ket{j}$.In particular, the action of this operation is represented by theunitary$$\begin{align}U = \sum^{2^n - 1}_{j=0} \ket{j}\bra{j} \otimes e^{i P \theta_j}.\end{align}$$

## Input

### coefficients : [Double](xref:microsoft.quantum.lang-ref.double)[]

Array of up to $2^n$ coefficients $\theta_j$. The $j$th coefficientindexes the number state $\ket{j}$ encoded in little-endian format.


### pauli : [Pauli](xref:microsoft.quantum.lang-ref.pauli)

Pauli operator $P$ that determines axis of rotation.


### control : [LittleEndian](xref:Microsoft.Quantum.Arithmetic.LittleEndian)

$n$-qubit control register that encodes number states $\ket{j}$ inlittle-endian format.


### target : [Qubit](xref:microsoft.quantum.lang-ref.qubit)

Single qubit register that is rotated by $e^{i P \theta_j}$.



## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)



## Remarks

`coefficients` will be padded with elements $\theta_j = 0.0$ iffewer than $2^n$ are specified.

## See Also

- [Microsoft.Quantum.Canon.ApproximatelyMultiplexPauli](xref:Microsoft.Quantum.Canon.ApproximatelyMultiplexPauli)