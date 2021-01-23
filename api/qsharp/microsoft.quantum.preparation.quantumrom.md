---
uid: Microsoft.Quantum.Preparation.QuantumROM
title: QuantumROM function
ms.date: 1/23/2021 12:00:00 AM
ms.topic: article
qsharp.kind: function
qsharp.namespace: Microsoft.Quantum.Preparation
qsharp.name: QuantumROM
qsharp.summary: >-
  > [!WARNING]

  > QuantumROM has been deprecated. Please use <xref:Microsoft.Quantum.Preparation.PurifiedMixedState> instead.


  Uses the Quantum ROM technique to represent a given density matrix.

  Given a list of $N$ coefficients $\alpha_j$, this returns a unitary $U$ that uses the Quantum-ROM
  technique to prepare
  an approximation  $\tilde\rho\sum_{j=0}^{N-1}p_j\ket{j}\bra{j}$ of the purification of the density matrix
  $\rho=\sum_{j=0}^{N-1}\frac{|alpha_j|}{\sum_k |\alpha_k|}\ket{j}\bra{j}$. In this approximation, the
  error $\epsilon$ is such that $|p_j-\frac{|alpha_j|}{\sum_k |\alpha_k|}|\le \epsilon / N$ and
  $\|\tilde\rho - \rho\| \le \epsilon$. In other words,
  $$
  \begin{align}
  U\ket{0}^{\lceil\log_2 N\rceil}\ket{0}^{m}=\sum_{j=0}^{N-1}\sqrt{p_j} \ket{j}\ket{\text{garbage}_j}.
  \end{align}
  $$
---

# QuantumROM function

Namespace: [Microsoft.Quantum.Preparation](xref:Microsoft.Quantum.Preparation)

Package: [Microsoft.Quantum.Standard](https://nuget.org/packages/Microsoft.Quantum.Standard)


> [!WARNING]
> QuantumROM has been deprecated. Please use <xref:Microsoft.Quantum.Preparation.PurifiedMixedState> instead.

Uses the Quantum ROM technique to represent a given density matrix.Given a list of $N$ coefficients $\alpha_j$, this returns a unitary $U$ that uses the Quantum-ROMtechnique to preparean approximation  $\tilde\rho\sum_{j=0}^{N-1}p_j\ket{j}\bra{j}$ of the purification of the density matrix$\rho=\sum_{j=0}^{N-1}\frac{|alpha_j|}{\sum_k |\alpha_k|}\ket{j}\bra{j}$. In this approximation, theerror $\epsilon$ is such that $|p_j-\frac{|alpha_j|}{\sum_k |\alpha_k|}|\le \epsilon / N$ and$\|\tilde\rho - \rho\| \le \epsilon$. In other words,$$\begin{align}U\ket{0}^{\lceil\log_2 N\rceil}\ket{0}^{m}=\sum_{j=0}^{N-1}\sqrt{p_j} \ket{j}\ket{\text{garbage}_j}.\end{align}$$

```qsharp
function QuantumROM (targetError : Double, coefficients : Double[]) : ((Int, (Int, Int)), Double, ((Microsoft.Quantum.Arithmetic.LittleEndian, Qubit[]) => Unit is Adj + Ctl))
```


## Input

### targetError : [Double](xref:microsoft.quantum.lang-ref.double)

The target error $\epsilon$.


### coefficients : [Double](xref:microsoft.quantum.lang-ref.double)[]

Array of $N$ coefficients specifying the probability of basis states.Negative numbers $-\alpha_j$ will be treated as positive $|\alpha_j|$.



## Output : (([Int](xref:microsoft.quantum.lang-ref.int),([Int](xref:microsoft.quantum.lang-ref.int),[Int](xref:microsoft.quantum.lang-ref.int))),[Double](xref:microsoft.quantum.lang-ref.double),([LittleEndian](xref:Microsoft.Quantum.Arithmetic.LittleEndian),[Qubit](xref:microsoft.quantum.lang-ref.qubit)[]) => [Unit](xref:microsoft.quantum.lang-ref.unit)  is Adj + Ctl)

## First parameterA tuple `(x,(y,z))` where `x = y + z` is the total number of qubits allocated,`y` is the number of qubits for the `LittleEndian` register, and `z` is the Numberof garbage qubits.## Second parameterThe one-norm $\sum_j |\alpha_j|$ of the coefficient array.## Third parameterThe unitary $U$.

## Example

The following code snippet prepares an purification of the $3$-qubit state$\rho=\sum_{j=0}^{4}\frac{|alpha_j|}{\sum_k |\alpha_k|}\ket{j}\bra{j}$, where$\vec\alpha=(1.0,2.0,3.0,4.0,5.0)$, and the error is `1e-3`;```qsharplet coefficients = [1.0,2.0,3.0,4.0,5.0];let targetError = 1e-3;let ((nTotalQubits, (nIndexQubits, nGarbageQubits)), oneNorm, op) = QuantumROM(targetError, coefficients);using (indexRegister = Qubit[nIndexQubits]) {    using (garbageRegister = Qubit[nGarbageQubits]) {        op(LittleEndian(indexRegister), garbageRegister);    }}```

## References

- Encoding Electronic Spectra in Quantum Circuits with Linear T Complexity  Ryan Babbush, Craig Gidney, Dominic W. Berry, Nathan Wiebe, Jarrod McClean, Alexandru Paler, Austin Fowler, Hartmut Neven  https://arxiv.org/abs/1805.03662