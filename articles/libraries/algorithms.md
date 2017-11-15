---
# Mandatory fields. See more on aka.ms/skyeye/meta.
title: "Q# standard libraries | Microsoft Docs"
description: 115-145 characters including spaces. Edit the intro para describing article intent to fit here. This abstract displays in the search result.
services: service-name-with-dashes-AZURE-ONLY 
keywords: Don’t add or edit keywords without consulting your SEO champ.
author: QuantumWriter
ms.author: MSFT-alias-person-or-DL
ms.date: 10/09/2017
ms.topic: article-type-from-white-list
# Use only one of the following. Use ms.service for services, ms.prod for on-prem. Remove the # before the relevant field.
# ms.service: service-name-from-white-list
# product-name-from-white-list

# Optional fields. Don't forget to remove # if you need a field.
# ms.custom: can-be-multiple-comma-separated
# ms.devlang:devlang-from-white-list
# ms.suite: 
# ms.tgt_pltfrm:
# ms.reviewer:
# manager: MSFT-alias-manager-or-PM-counterpart
---


# Quantum Algorithms #

## Amplitude Amplification ##

Amplitude Amplification is one of the fundamental tools of Quantum Computing. There are many variants, but here we provide a very general version called Oblivious Amplitude Amplification with Partial Reflections to allow for the widest area of application. 

The general routine (`AmpAmpObliviousByReflectionPhases`) has two registers that we call `ancillaRegister` and `systemRegister`. It also accepts two oracles for the necessary reflections. The `ReflectionOracle` acts only on the `ancillaRegister` while the `ObliviousOracle` acts jointly on both registers. The input to `ancillaRegister` must be initialized to the unique -1 eigenstate of the first reflection operator $I-2|s{\rangle}{\langle}s|$. 

Typically, the oracle prepares the state in the computational basis $|0...0\rangle$. In our implementation, the `ancillaRegister` consistes of one qubit (`flagQubit`) that controls the `stateOracle` and the rest of the desired ancillas. The `stateOracle` is applied when the `flagQubit` is $|1\rangle$.

One may also provide oracles `StateOracle` and `ObliviousOracle` instead of reflections via a call to `AmpAmpObliviousByOraclePhases`. 

It is also worth noting that traditional Amplitude Amplification is just a speical case of these routines where `ObliviousOracle` is the identity operator and there are no system qubits (i.e., `systemRegister` is empty). If you wish to obtain phases for partial reflections (e.g., for Grover search), the function `AmpAmpPhasesStandard`. Please refer to `ExampleGrover.qb` for a sample implemetation of this.

We relate the single-qubit rotation phases to the reflection operator phases as described in the paper by [G.H. Low, I. L. Chuang](https://arxiv.org/abs/1707.05391). The fixed point phases that are used are detailed in [Yoder, Low and Chuang](https://arxiv.org/abs/1409.3305) along with the phases in [Low, Yoder and Chuang](https://arxiv.org/abs/1603.03996).

For background, you could start from [Standard Amplitude Amplification](https://arxiv.org/abs/quant-ph/0005055) then move to an introduction to [Oblivious Amplitude Amplification](https://arxiv.org/abs/1312.1414) and finally generalizations presented in [Low and Chuang](https://arxiv.org/abs/1610.06546). A nice overview presentation of this entire area (as it relates to Hamiltonian Simulation) was given by [Dominic Berry](http://www.dominicberry.org/presentations/Durban.pdf).

## Arithmetic ##

## Quantum Fourier Transform ##

The Fourier transform is a fundamental tool of classical analysis and is just as important for quantum computations.
In addition, the efficiency of the quantum Fourier transform (QFT) far surpasses what is possible on a classical machine making it one of the first tools of choice when designing a quantum algorithm.

As an approximate generalization of the QFT, we provide the <xref:microsoft.quantum.canon.approximateqft> operation that allows for further optimizations by pruning rotations that aren't strictly necessary for the desired algorithmic accuracy.
The approximate QFT requires the dyadic $Z$-rotation operation <xref:microsoft.quantum.primitive.RFrac> as well as the <xref:microsoft.quantum.primitive.h> operation.
The input and output are assumed to be encoded in big endian encoding (lowest bit/qubit is on the left, same as [ket notation](xref:microsoft.quantum.concepts.dirac).
The approximation parameter $a$ determines the pruning level of the $Z$-rotations, i.e., $a \in [0..n]$.
In this case all $Z$-rotations $2\pi/2^k$ where $k > a$ are removed from the QFT circuit.
It is known that for $k >= \log_2(n) + \log_2(1 / \epsilon) + 3$. one can bound $\| \operatorname{QFT} - \operatorname{AQFT} \| < \epsilon$.
<!-- TODO: explain what norms are, perhaps? -->

For more details, please refer to [M. Roetteler, Th. Beth](http://doi.org/10.1007/s00200-008-0072-2 ) and [D. Coppersmith](https://arxiv.org/abs/quant-ph/0201067).

### Quantum Phase Estimation ###

One particularly important application of the quantum Fourier transform is to learn the eigenvalues of unitary operators, a problem known as *phase estimation*.
Consider a unitary $U$ and a state $\ket{\phi}$ such that $\ket{\phi}$ is an eigenstate of $U$ with unknown eigenvalue $\phi$,
\begin{equation}
    U\ket{\phi} = \phi\ket{\phi}.
\end{equation}
If we only have access to $U$ as an [oracle](data-structures#phase-estimation-oracles), then we can learn the phase $\phi$ by utilizing that $Z$ rotations applied to the target of a controlled operation propagate back onto the control.

Suppose that $V$ is a controlled application of $U$, such that
\begin{align}
                   V (\ket{0} \otimes \ket{\phi}) & =            \ket{0} \otimes \ket{\phi} \\\\
    \textrm{ and } V (\ket{1} \otimes \ket{\phi}) & = e^{i \phi} \ket{1} \otimes \ket{\phi}.
\end{align}
Then, by linearity,
\begin{align}
    V(\ket{+} \otimes \ket{\phi}) & = \frac{
        (\ket{0} \otimes \ket{\phi}) + e^{i \phi} (\ket{1} \otimes \ket{\phi})
    }{\sqrt{2}}.
\end{align}
We can collect terms to find that
\begin{align}
    V(\ket{+} \otimes \ket{\phi}) & = \frac{\ket{0} + e^{i \phi} \ket{1}}{\sqrt{2}} \otimes \ket{\phi} \\\\
                                  & = (R_1(\phi) \ket{+}) \otimes \ket{\phi},
\end{align}
where $R_1$ is the unitary applied by the <xref:microsoft.quantum.primitive.r1> operation.

Since the control and target register remain untangled after this process, we can reuse $\ket{\phi}$ as the target of a controlled application of $U^2$ to prepare a second control qubit in the state $R_1(2 \phi) \ket{+}$.
Continuing in this way, we can obtain a register of the form
\begin{align}
    \ket{\psi} & = \sum_{j = 0}^n R_1(2^j \phi) \ket{+} \\\\
               & \propto \bigotimes_{j=0}^{n} \left(\ket{0} + \exp(i 2^{j} \phi) \ket{1}\right) \\\\
               & \propto \sum_{k = 0}^{2^n - 1} \exp(i \phi k) \ket{k}
\end{align}
where $n$ is the number of bits of precision that we require, and where we have used ${} \propto {}$ to indicate that we have suppressed the normalization factor of $1 / \sqrt{2^n}$.

If we assume that $\phi = 2 \pi p / 2^k$ for an integer $p$, then we recognize this as $\ket{\psi} = \operatorname{QFT} \ket{p_0 p_1 \dots p_n}$, where $p_j$ is the $j^{\textrm{th}}$ bit of $2 \pi \phi$.
Applying the adjoint of the quantum Fourier transform, we therefore obtain the binary representation of the phase encoded as a quantum state.

In Q#, this is implemented by the <xref:microsoft.quantum.canon.quantumphaseestimation> operation, which takes a <xref:microsoft.quantum.canon.discreteoracle> implementing application of $U^m$ as a function of positive integers $m$.

<!-- FIXME: ensure that |k〉 notation is defined above. -->


### Period Finding ###

