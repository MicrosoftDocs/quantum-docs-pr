---
uid: Microsoft.Quantum.Preparation.StatePreparationComplexCoefficients
title: StatePreparationComplexCoefficients function
ms.date: 1/23/2021 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Preparation
qsharp.name: StatePreparationComplexCoefficients
qsharp.summary: >-
  > [!WARNING]

  > StatePreparationComplexCoefficients has been deprecated. Please use <xref:Microsoft.Quantum.Preparation.PrepareArbitraryStateCP> instead.


  Returns an operation that prepares a specific quantum state.

  The returned operation $U$ prepares an arbitrary quantum
  state $\ket{\psi}$ with complex coefficients $r_j e^{i t_j}$ from
  the $n$-qubit computational basis state $\ket{0...0}$.

  The action of U on a newly-allocated register is given by
  $$
  \begin{align}
  U\ket{0...0}=\ket{\psi}=\frac{\sum_{j=0}^{2^n-1}r_j e^{i t_j}\ket{j}}{\sqrt{\sum_{j=0}^{2^n-1}|r_j|^2}}.
  \end{align}
  $$
---

# StatePreparationComplexCoefficients function

Namespace: [Microsoft.Quantum.Preparation](xref:Microsoft.Quantum.Preparation)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


> [!WARNING]
> StatePreparationComplexCoefficients has been deprecated. Please use <xref:Microsoft.Quantum.Preparation.PrepareArbitraryStateCP> instead.

Returns an operation that prepares a specific quantum state.The returned operation $U$ prepares an arbitrary quantumstate $\ket{\psi}$ with complex coefficients $r_j e^{i t_j}$ fromthe $n$-qubit computational basis state $\ket{0...0}$.The action of U on a newly-allocated register is given by$$\begin{align}U\ket{0...0}=\ket{\psi}=\frac{\sum_{j=0}^{2^n-1}r_j e^{i t_j}\ket{j}}{\sqrt{\sum_{j=0}^{2^n-1}|r_j|^2}}.\end{align}$$

```qsharp
function StatePreparationComplexCoefficients (coefficients : Microsoft.Quantum.Math.ComplexPolar[]) : (Microsoft.Quantum.Arithmetic.LittleEndian => Unit is Adj + Ctl)
```


## Input

### coefficients : [ComplexPolar](xref:Microsoft.Quantum.Math.ComplexPolar)[]

Array of up to $2^n$ complex coefficients represented by theirabsolute value and phase $(r_j, t_j)$. The $j$th coefficientindexes the number state $\ket{j}$ encoded in little-endian format.



## Output : [LittleEndian](xref:Microsoft.Quantum.Arithmetic.LittleEndian) => [Unit](xref:microsoft.quantum.lang-ref.unit)  is Adj + Ctl

A state-preparation unitary operation $U$.

## Example

The following snippet prepares the quantum state $\ket{\psi}=e^{i 0.1}\sqrt{1/8}\ket{0}+\sqrt{7/8}\ket{2}$in the qubit register `qubitsLE`.```qsharplet amplitudes = [Sqrt(0.125), 0.0, Sqrt(0.875), 0.0];let phases = [0.1, 0.0, 0.0, 0.0];mutable complexNumbers = new ComplexPolar[4];for (idx in 0..3) {    set complexNumbers[idx] = ComplexPolar(amplitudes[idx], phases[idx]);}let op = StatePreparationComplexCoefficients(complexNumbers);using (qubits = Qubit[2]) {    let qubitsLE = LittleEndian(qubits);    op(qubitsLE);}```

## Remarks

Negative input coefficients $r_j < 0$ will be treated as thoughpositive with value $|r_j|$. `coefficients` will be padded withelements $(r_j, t_j) = (0.0, 0.0)$ if fewer than $2^n$ arespecified.