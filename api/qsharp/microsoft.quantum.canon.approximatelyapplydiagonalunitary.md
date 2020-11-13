---
uid: Microsoft.Quantum.Canon.ApproximatelyApplyDiagonalUnitary
title: ApproximatelyApplyDiagonalUnitary operation
ms.date: 11/13/2020 12:00:00 AM
ms.topic: article
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Canon
qsharp.name: ApproximatelyApplyDiagonalUnitary
qsharp.summary: >-
  Applies an array of complex phases to numeric basis states of a register
  of qubits, truncating small rotation angles according to a given
  tolerance.
---

# ApproximatelyApplyDiagonalUnitary operation

Namespace: [Microsoft.Quantum.Canon](xref:Microsoft.Quantum.Canon)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Applies an array of complex phases to numeric basis states of a registerof qubits, truncating small rotation angles according to a giventolerance.

```qsharp
operation ApproximatelyApplyDiagonalUnitary (tolerance : Double, coefficients : Double[], qubits : Microsoft.Quantum.Arithmetic.LittleEndian) : Unit is Adj + Ctl
```


## Description

This operation implements a diagonal unitary that applies a complex phase$e^{i \theta_j}$ on the $n$-qubit number state $\ket{j}$.In particular, this operation can be represented by the unitary$$\begin{align}U = \sum^{2^n-1}_{j=0}e^{i\theta_j}\ket{j}\bra{j}.\end{align}$$

## Input

### tolerance : [Double](xref:microsoft.quantum.lang-ref.double)

A tolerance below which small coefficients are truncated.


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

- [Microsoft.Quantum.Canon.ApplyDiagonalUnitary](xref:Microsoft.Quantum.Canon.ApplyDiagonalUnitary)