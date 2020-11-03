---
uid: Microsoft.Quantum.Canon.ApproximatelyMultiplexZ
title: ApproximatelyMultiplexZ operation
ms.date: 11/3/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Canon
qsharp.name: ApproximatelyMultiplexZ
qsharp.summary: >-
  Applies a Pauli Z rotation conditioned on an array of qubits, truncating
  small rotation angles according to a given tolerance.
---

# ApproximatelyMultiplexZ operation

Namespace: [Microsoft.Quantum.Canon](xref:Microsoft.Quantum.Canon)

Package: [](https://nuget.org/packages/)


Applies a Pauli Z rotation conditioned on an array of qubits, truncatingsmall rotation angles according to a given tolerance.

```qsharp
operation ApproximatelyMultiplexZ (tolerance : Double, coefficients : Double[], control : Microsoft.Quantum.Arithmetic.LittleEndian, target : Qubit) : Unit
```


## Description

This applies the multiply controlled unitary operation that performsrotations by angle $\theta_j$ about single-qubit Pauli operator $Z$when controlled by the $n$-qubit number state $\ket{j}$.In particular, this operation can be represented by the unitary$$\begin{align}U = \sum^{2^n-1}_{j=0} \ket{j}\bra{j} \otimes e^{i Z \theta_j}.\end{align}$$

## Input

### tolerance : [Double](xref:microsoft.quantum.lang-ref.double)

A tolerance below which small coefficients are truncated.


### coefficients : [Double](xref:microsoft.quantum.lang-ref.double)[]

Array of up to $2^n$ coefficients $\theta_j$. The $j$th coefficientindexes the number state $\ket{j}$ encoded in little-endian format.


### control : [LittleEndian](xref:Microsoft.Quantum.Arithmetic.LittleEndian)

$n$-qubit control register that encodes number states $\ket{j}$ inlittle-endian format.


### target : [Qubit](xref:microsoft.quantum.lang-ref.qubit)

Single qubit register that is rotated by $e^{i P \theta_j}$.



## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)



## Remarks

`coefficients` will be padded with elements $\theta_j = 0.0$ iffewer than $2^n$ are specified.

## References

- Synthesis of Quantum Logic Circuits  Vivek V. Shende, Stephen S. Bullock, Igor L. Markov  https://arxiv.org/abs/quant-ph/0406176

## See Also

- [Microsoft.Quantum.Canon.MultiplexZ](xref:Microsoft.Quantum.Canon.MultiplexZ)