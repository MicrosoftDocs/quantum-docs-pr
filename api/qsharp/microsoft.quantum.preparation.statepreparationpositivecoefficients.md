---
uid: Microsoft.Quantum.Preparation.StatePreparationPositiveCoefficients
title: StatePreparationPositiveCoefficients function
ms.date: 11/14/2020 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Preparation
qsharp.name: StatePreparationPositiveCoefficients
qsharp.summary: >-
  Returns an operation that prepares the given quantum state.

  The returned operation $U$ prepares an arbitrary quantum
  state $\ket{\psi}$ with positive coefficients $\alpha_j\ge 0$ from
  the $n$-qubit computational basis state $\ket{0...0}$.

  The action of U on a newly-allocated register is given by
  $$
  \begin{align}
  U \ket{0\cdots 0} = \ket{\psi} = \frac{\sum_{j=0}^{2^n-1}\alpha_j \ket{j}}{\sqrt{\sum_{j=0}^{2^n-1}|\alpha_j|^2}}.
  \end{align}
  $$
---

# StatePreparationPositiveCoefficients function

Namespace: [Microsoft.Quantum.Preparation](xref:Microsoft.Quantum.Preparation)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


Returns an operation that prepares the given quantum state.The returned operation $U$ prepares an arbitrary quantumstate $\ket{\psi}$ with positive coefficients $\alpha_j\ge 0$ fromthe $n$-qubit computational basis state $\ket{0...0}$.The action of U on a newly-allocated register is given by$$\begin{align}U \ket{0\cdots 0} = \ket{\psi} = \frac{\sum_{j=0}^{2^n-1}\alpha_j \ket{j}}{\sqrt{\sum_{j=0}^{2^n-1}|\alpha_j|^2}}.\end{align}$$

```qsharp
function StatePreparationPositiveCoefficients (coefficients : Double[]) : (Microsoft.Quantum.Arithmetic.LittleEndian => Unit is Adj + Ctl)
```


## Input

### coefficients : [Double](xref:microsoft.quantum.lang-ref.double)[]

Array of up to $2^n$ coefficients $\alpha_j$. The $j$th coefficientindexes the number state $\ket{j}$ encoded in little-endian format.



## Output : [LittleEndian](xref:Microsoft.Quantum.Arithmetic.LittleEndian) => [Unit](xref:microsoft.quantum.lang-ref.unit)  is Adj + Ctl

A state-preparation unitary operation $U$.

## Remarks

Negative input coefficients $\alpha_j < 0$ will be treated as thoughpositive with value $|\alpha_j|$. `coefficients` will be padded withelements $\alpha_j = 0.0$ if fewer than $2^n$ are specified.