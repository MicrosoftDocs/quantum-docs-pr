---
uid: Microsoft.Quantum.Canon.ApproximatelyMultiplexPauli
title: ApproximatelyMultiplexPauli operation
ms.date: 10/16/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Canon
qsharp.name: ApproximatelyMultiplexPauli
qsharp.summary: >-
  Applies a Pauli rotation conditioned on an array of qubits, truncating
  small rotation angles according to a given tolerance.
---

# ApproximatelyMultiplexPauli operation

Namespace: [Microsoft.Quantum.Canon](xref:Microsoft.Quantum.Canon)

Package: [](https://nuget.org/packages/)


Applies a Pauli rotation conditioned on an array of qubits, truncatingsmall rotation angles according to a given tolerance.

```Q#
ApproximatelyMultiplexPauli (tolerance : Double, coefficients : Double[], pauli : Pauli, control : Microsoft.Quantum.Arithmetic.LittleEndian, target : Qubit) : Unit
```


## Description

This applies a multiply controlled unitary operation that performsrotations by angle $\theta_j$ about single-qubit Pauli operator $P$when controlled by the $n$-qubit number state $\ket{j}$.In particular, the action of this operation is represented by theunitary$$\begin{align}U = \sum^{2^n - 1}_{j=0} \ket{j}\bra{j} \otimes e^{i P \theta_j}.\end{align}##

## Input

### tolerance : Double

A tolerance below which small coefficients are truncated.


### coefficients : Double[]

Array of up to $2^n$ coefficients $\theta_j$. The $j$th coefficientindexes the number state $\ket{j}$ encoded in little-endian format.


### pauli : Pauli

Pauli operator $P$ that determines axis of rotation.


### control : [LittleEndian](xref:Microsoft.Quantum.Arithmetic.LittleEndian)

$n$-qubit control register that encodes number states $\ket{j}$ inlittle-endian format.


### target : Qubit

Single qubit register that is rotated by $e^{i P \theta_j}$.



## Remarks

`coefficients` will be padded with elements $\theta_j = 0.0$ iffewer than $2^n$ are specified.

## See Also

- [Microsoft.Quantum.Canon.MultiplexPauli](xref:Microsoft.Quantum.Canon.MultiplexPauli)