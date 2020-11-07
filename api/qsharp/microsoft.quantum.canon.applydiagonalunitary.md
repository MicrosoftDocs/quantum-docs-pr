---
uid: Microsoft.Quantum.Canon.ApplyDiagonalUnitary
title: ApplyDiagonalUnitary operation
ms.date: 11/7/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Canon
qsharp.name: ApplyDiagonalUnitary
qsharp.summary: >-
  Applies an array of complex phases to numeric basis states of a register
  of qubits.
---

# ApplyDiagonalUnitary operation

Namespace: [Microsoft.Quantum.Canon](xref:Microsoft.Quantum.Canon)

Package: [](https://nuget.org/packages/)


Applies an array of complex phases to numeric basis states of a registerof qubits.

```qsharp
operation ApplyDiagonalUnitary (coefficients : Double[], qubits : Microsoft.Quantum.Arithmetic.LittleEndian) : Unit
```


## Description

This operation implements a diagonal unitary that applies a complex phase$e^{i \theta_j}$ on the $n$-qubit number state $\ket{j}$.In particular, this operation can be represented by the unitary$$\begin{align}U = \sum^{2^n-1}_{j=0}e^{i\theta_j}\ket{j}\bra{j}.\end{align}$$

## Input

### coefficients : [Double](xref:microsoft.quantum.lang-ref.double)[]

Array of up to $2^n$ coefficients $\theta_j$. The $j$th coefficientindexes the number state $\ket{j}$ encoded in little-endian format.


### qubits : [LittleEndian](xref:Microsoft.Quantum.Arithmetic.LittleEndian)

$n$-qubit control register that encodes number states $\ket{j}$ inlittle-endian format.



## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)



## Remarks

`coefficients` will be padded with elements $\theta_j = 0.0$ iffewer than $2^n$ are specified.

## References

- Synthesis of Quantum Logic Circuits  Vivek V. Shende, Stephen S. Bullock, Igor L. Markov  https://arxiv.org/abs/quant-ph/0406176

## See Also

- [Microsoft.Quantum.Canon.ApproximatelyApplyDiagonalUnitary](xref:Microsoft.Quantum.Canon.ApproximatelyApplyDiagonalUnitary)