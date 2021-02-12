---
uid: Microsoft.Quantum.Preparation.ApproximatelyPrepareArbitraryStateCP
title: ApproximatelyPrepareArbitraryStateCP operation
ms.date: 2/12/2021 12:00:00 AM
ms.topic: managed-reference
qsharp.kind: operation
qsharp.namespace: Microsoft.Quantum.Preparation
qsharp.name: ApproximatelyPrepareArbitraryStateCP
qsharp.summary: >-
  Given a set of coefficients and a little-endian encoded quantum register,
  prepares an state on that register described by the given coefficients,
  up to a given approximation tolerance.
---

# ApproximatelyPrepareArbitraryStateCP operation

Namespace: [Microsoft.Quantum.Preparation](xref:Microsoft.Quantum.Preparation)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Given a set of coefficients and a little-endian encoded quantum register,prepares an state on that register described by the given coefficients,up to a given approximation tolerance.

```qsharp
operation ApproximatelyPrepareArbitraryStateCP (tolerance : Double, coefficients : Microsoft.Quantum.Math.ComplexPolar[], qubits : Microsoft.Quantum.Arithmetic.LittleEndian) : Unit is Adj + Ctl
```


## Description

This operation prepares an arbitrary quantumstate $\ket{\psi}$ with complex coefficients $r_j e^{i t_j}$ fromthe $n$-qubit computational basis state $\ket{0 \cdots 0}$.In particular, the action of this operation can be simulated by thea unitary transformation $U$ which acts on the all-zeros state as$$\begin{align}U\ket{0...0}& = \ket{\psi} \\\\& = \frac{\sum_{j=0}^{2^n-1} r_j e^{i t_j} \ket{j}}{\sqrt{\sum_{j=0}^{2^n-1} |r_j|^2}}.\end{align}$$

## Input

### tolerance : [Double](xref:microsoft.quantum.lang-ref.double)

The approximation tolerance to be used when preparing the given state.


### coefficients : [ComplexPolar](xref:Microsoft.Quantum.Math.ComplexPolar)[]

Array of up to $2^n$ complex coefficients represented by theirabsolute value and phase $(r_j, t_j)$. The $j$th coefficientindexes the number state $\ket{j}$ encoded in little-endian format.


### qubits : [LittleEndian](xref:Microsoft.Quantum.Arithmetic.LittleEndian)

Qubit register encoding number states in little-endian format. This isexpected to be initialized in the computational basis state$\ket{0...0}$.



## Output : [Unit](xref:microsoft.quantum.lang-ref.unit)



## Remarks

Negative input coefficients $r_j < 0$ will be treated as thoughpositive with value $|r_j|$. `coefficients` will be padded withelements $(r_j, t_j) = (0.0, 0.0)$ if fewer than $2^n$ arespecified.

## References

- Synthesis of Quantum Logic Circuits  Vivek V. Shende, Stephen S. Bullock, Igor L. Markov  https://arxiv.org/abs/quant-ph/0406176