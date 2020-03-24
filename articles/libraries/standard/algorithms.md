---
title: Quantum algorithms in Q#
description: Learn about fundamental quantum computing algorithms, including amplitude amplification, Fourier transform, Draper and Beauregard adders, and phase estimation. 
author: QuantumWriter
ms.author: martinro@microsoft.com 
ms.date: 12/11/2017
ms.topic: article
uid: microsoft.quantum.libraries.standard.algorithms
---
# Quantum Algorithms #

## Amplitude Amplification ##

*Amplitude Amplification* is one of the fundamental tools of Quantum Computing. It is the fundamental idea that underlies Grover's search, amplitude estimation and many quantum machine learning algorithms.  There are many variants, and in Q# we provide a general version based on Oblivious Amplitude Amplification with Partial Reflections to allow for the widest area of application.

The central idea behind amplitude amplification is to amplify the probability of a desired outcome occurring by performing a sequence of reflections.  These reflections rotate the initial state closer towards a desired target state, often called a marked state.  Specifically, if the probability of measuring the initial state to be in a marked state is $\sin^2(\theta)$ then after applying amplitude amplification $m$ times the probability of success becomes $\sin^2((2m+1)\theta)$.  This means that if $\theta = \pi/[2(2n+1)]$ for some value of $n$ then amplitude amplification is capable of boosting the probability of success to $100\\%$ after $n$ iterations of amplitude amplification.  Since $\theta = \sin^{-1}(\sqrt{\Pr(success)})$ this means that the number of iterations needed to obtain a success deterministically is quadratically lower than the expected number needed to find a marked state non-deterministically using random sampling.

Each iteration of Amplitude amplification requires that two reflection operators be specified. Specifically, if $Q$ is the amplitude amplification iterate and $P_0$ is a projector operator onto the initial subspace and $P_1$ is the projector onto the marked subspace then $Q=-(\boldone-2P_0)(\boldone -2P_1)$.  Recall that a projector is a Hermitian operator that has eigenvalues $+1$ and $0$ and as a result $(\boldone -2P_0)$ is unitary because it has eigenvalues that are roots of unity (in this case $\pm 1$). As an example, consider the case of Grover's search with initial state $H^{\otimes n} \ket{0}$ and marked state $\ket{m}$, $P_0 = H^{\otimes n}\ket{0}\bra{0}H^{\otimes n}$ and $P_1= \ket{m}\bra{m}$.  In most applications of amplitude amplification $P_0$ will be a projector onto an initial state meaning that $P_0 = \boldone -2\ket{\psi}\bra{\psi}$ for some vector $\ket{\psi}$; however, for oblivious amplitude amplication $P_0$ will typically project onto many quantum states (i.e. the multiplicity of the $+1$ eigenvalue of $P_0$ is greater than $1$).

The logic behind amplitude amplification follows directly from the eigen-decomposition of $Q$.  Specifically, the eigenvectors of $Q$ that the initial state has non-zero support over can be shown to be linear combinations of the $+1$ eigenvectors of $P_0$ and $P_1$.  Specifically, the initial state for amplitude amplification (assuming it is a $+1$ eigenvector of $P_0$) can be written as
$$
\ket{\psi}=\frac{-i}{\sqrt{2}}\left(e^{i\theta}\ket{\psi_+} + e^{-i\theta}\ket{\psi_-}\right),
$$
where $\ket{\psi_\pm}$ are eigenvectors of $Q$ with eigenvalues $e^{\pm  2i\theta}$ and only have support on the $+1$ eigenvectors of $P_0$ and $P_1$.  The fact that the eigenvalues are $e^{\pm i \theta}$ implies that the operator $Q$ performs a rotation in a two-dimensional subspace specified by the two projectors and the initial state where the rotation angle is $2\theta$.  This is why after $m$ iterations of $Q$ the success probability is $\sin^2([2m+1]\theta)$.

Another useful property that comes out of this is that the eigenvalue $\theta$ is directly related to probability that the initial state would be marked (in the case where $P_0$ is a projector onto only the initial state).  Since the eigenphases of $Q$ are $2\theta = 2\sin^{-1}(\sqrt{\Pr(success)})$ it then follows that if we apply phase estimation to $Q$ then we can learn the probability of success for a unitary quantum procedure.  This is useful because it requires quadratically fewer applications of the quantum procedure to learn the success probability than would otherwise be needed.

Q# introduces amplitude amplification as a specialization of oblivious amplitude amplification.  Oblivious amplitude amplification earns this moniker because the projector onto the initial eigenspace need not be a projector onto the initial state.  In this sense, the protocol is oblivious to the initial state.  The key application of oblivious amplitude amplification is in certain *linear combinations of unitary* Hamiltonian simulation methods, wherein the initial state is unknown but becomes entangled with an ancilla register in the simulation protocol.  If this ancilla register were to be measured to be a fixed value, say $0$, then such simulation methods apply the desired unitary transformation to the remaining qubits (called the system register).  All other measurement outcomes lead to failure however.  Oblivious amplitude amplification allows the probability of success of this measurement to be boosted to $100\\%$ using the above reasoning.  Further, ordinary amplitude amplification corresponds to the case where the system register is empty.  This is why Q# uses oblivious amplitude amplification as its fundamental amplitude amplification subroutine.

The general routine (`AmpAmpObliviousByReflectionPhases`) has two registers that we call `ancillaRegister` and `systemRegister`. It also accepts two oracles for the necessary reflections. The `ReflectionOracle` acts only on the `ancillaRegister` while the `ObliviousOracle` acts jointly on both registers. The input to `ancillaRegister` must be initialized to a -1 eigenstate of the first reflection operator $\boldone -2P_1$.

Typically, the oracle prepares the state in the computational basis $\ket{0...0}$. In our implementation, the `ancillaRegister` consistes of one qubit (`flagQubit`) that controls the `stateOracle` and the rest of the desired ancillas. The `stateOracle` is applied when the `flagQubit` is $\ket{1}$.

One may also provide oracles `StateOracle` and `ObliviousOracle` instead of reflections via a call to `AmpAmpObliviousByOraclePhases`.

As mentioned, traditional Amplitude Amplification is just a special case of these routines where `ObliviousOracle` is the identity operator and there are no system qubits (i.e., `systemRegister` is empty). If you wish to obtain phases for partial reflections (e.g., for Grover search), the function `AmpAmpPhasesStandard` is available. Please refer to `DatabaseSearch.qs` for a sample implementation of Grover's algorithm.

We relate the single-qubit rotation phases to the reflection operator phases as described in the paper by [G.H. Low, I. L. Chuang](https://arxiv.org/abs/1707.05391). The fixed point phases that are used are detailed in [Yoder, Low and Chuang](https://arxiv.org/abs/1409.3305) along with the phases in [Low, Yoder and Chuang](https://arxiv.org/abs/1603.03996).

For background, you could start from [Standard Amplitude Amplification](https://arxiv.org/abs/quant-ph/0005055) then move to an introduction to [Oblivious Amplitude Amplification](https://arxiv.org/abs/1312.1414) and finally generalizations presented in [Low and Chuang](https://arxiv.org/abs/1610.06546). A nice overview presentation of this entire area (as it relates to Hamiltonian Simulation) was given by [Dominic Berry](http://www.dominicberry.org/presentations/Durban.pdf).

## Quantum Fourier Transform ##

The Fourier transform is a fundamental tool of classical analysis and is just as important for quantum computations.
In addition, the efficiency of the *quantum Fourier transform* (QFT) far surpasses what is possible on a classical machine making it one of the first tools of choice when designing a quantum algorithm.

As an approximate generalization of the QFT, we provide the <xref:microsoft.quantum.canon.approximateqft> operation that allows for further optimizations by pruning rotations that aren't strictly necessary for the desired algorithmic accuracy.
The approximate QFT requires the dyadic $Z$-rotation operation <xref:microsoft.quantum.intrinsic.rfrac> as well as the <xref:microsoft.quantum.intrinsic.h> operation.
The input and output are assumed to be encoded in big endian encoding---that is, the qubit with index `0` is encoded in the left-most (highest) bit of the binary integer representation.
This aligns with [ket notation](xref:microsoft.quantum.concepts.dirac), as a register of three qubits in the state $\ket{100}$ corresponds to $q_0$ being in the state $\ket{1}$ while $q_1$ and $q_2$ are both in state $\ket{0}$.
The approximation parameter $a$ determines the pruning level of the $Z$-rotations, i.e., $a \in [0..n]$.
In this case all $Z$-rotations $2\pi/2^k$ where $k > a$ are removed from the QFT circuit.
It is known that for $k \ge \log_2(n) + \log_2(1 / \epsilon) + 3$. one can bound $\\| \operatorname{QFT} - \operatorname{AQFT} \\| < \epsilon$.
Here $\\|\cdot\\|$ is the operator norm which in this case is the square root of the largest [eigenvalue](xref:microsoft.quantum.concepts.matrix-advanced) of $(\operatorname{QFT} - \operatorname{AQFT})(\operatorname{QFT} - \operatorname{AQFT})^\dagger$.

## Arithmetic ##

Just as arithmetic plays a central role in classical computing, it is also indispensable in quantum computing.  Algorithms such as Shor's factoring algorithm, quantum simulation methods as well as many oracular algorithms rely upon coherent arithmetic operations.  Most approaches to arithmetic build upon quantum adder circuits.  The simplest adder takes a classical input $b$ and adds the value to a quantum state holding an integer $\ket{a}$.  Mathematically, the adder (which we denote $\operatorname{Add}(b)$ for classical input $b$) has the property that

$$
\operatorname{Add}(b)\ket{a}=\ket{a + b}.
$$
This basic adder circuit is more of an incrementer than an adder.
It can be converted into an adder that has two quantum inputs via
$$
\operatorname{Add}\ket{a}\ket{b}=\ket{a}\ket{a+b},
$$
using $n$ controlled applications of adders of the form
\begin{align}
\operatorname{Add} \ket{a} \ket{b}
    & = \Lambda\_{a\_0} \left(\operatorname{Add}(1) \right)
        \Lambda\_{a\_1} \left(\operatorname{Add}(2) \right)
        \Lambda\_{a\_2} \left(\operatorname{Add}(4) \right)
        \cdots
        \Lambda\_{a\_{n-1}} \left(\operatorname{Add}({{n-1}}) \right) \ket{a}\ket{b} \\\\
    & = \ket{a} \ket{b + a},
\end{align}
for $n$-bit integers $a$ and $b$ and addition modulo $2^n$.  Recall that the notation $\Lambda\_x(A)$ refers, for any operation $A$, to the controlled version of that operation with the qubit $x$ as control.

Similarly, classically controlled multiplication (a modular form of which is essential for Shor's factoring algorithm) can be performed by using a similar series of controlled  additions:
\begin{align}
\operatorname{Mult}(a)\ket{x}\ket{b}
    & = \Lambda\_{x\_0}\left(\operatorname{Add}(2^0 a)\right)
        \Lambda\_{a\_1}\left(\operatorname{Add}(2^1a)\right)
        \Lambda\_{a\_2}\left(\operatorname{Add}(2^2 a)\right)
        \cdots \Lambda\_{x\_{n-1}}
        \left(\operatorname{Add}({2^{n-1}}a) \right)\ket{x}\ket{b} \\\\
    & = \ket{x}\ket{b+ax}.
\end{align}
There is a subtlety with multiplication on quantum computers that you may notice from the definition of $\operatorname{Mult}$ above.  Unlike addition, the quantum version of this circuit stores the product of the inputs in an ancillary register rather than in the input register.  In this example, the register is initialized with the value $b$, but typically it will start holding the value zero.  This is needed in because in general there is not a multiplicative inverse for general $a$ and $x$.  Since all quantum operations, save measurement, are reversible we need to keep enough information around to invert the multiplication.  For this reason the result is stored in a separate array.  This trick of saving the output of an irreversible operation, like multiplication, in a separate register is known as the "Bennett trick" after Charlie Bennett and is a fundamental tool in both reversible and quantum computing.

Many quantum circuits have been proposed for addition and each explores a different tradeoff in terms of the number of qubits (space) and the number of gate operations (time) required.  We review two highly space efficient adders below known as the Draper adder and the Beauregard adder.

### Draper Adder ###

The Draper adder is arguably one of the most elegant quantum adders, as it directly invokes quantum properties to perform addition.  The insight behind the Draper adder is that the Fourier transform can be used to translate phase shifts into a bit shift.  It then follows that by applying a Fourier transform, applying appropriate phase shifts, and then undoing the Fourier transform you can implement an adder.  Unlike many other adders that have been proposed, the Draper adder explicitly uses quantum effects introduced through the quantum Fourier transform.  It does not have a natural classical counterpart.  The specific steps of the Draper adder are given below.

Assume that you have two $n$-bit qubit registers storing the integers $a$ and $b$ then for all $a$
$$
\operatorname{QFT}\ket{a}= \frac{1}{\sqrt{2^n}}\sum\_{j=0}^{2^n-1} e^{i2\pi(aj)/2^n} \ket{j}.
$$
If we define
$$
\ket{\phi\_k(a)} = \frac{1}{\sqrt{2}}\left(\ket{0} + e^{i2\pi a /2^k}\ket{1} \right),
$$
then after some algebra you can see that
$$
\operatorname{QFT}\ket{a}=\ket{\phi\_1(a)}\otimes \cdots \otimes \ket{\phi\_n(a)}.
$$
The path towards performing an adder then becomes clear after observing that the sum of the inputs can be written as
$$
\ket{a+b}=\operatorname{QFT}^{-1}\ket{\phi\_1(a+b)}\otimes \cdots \otimes \ket{\phi\_n(a+b)}.
$$
The integers $b$ and $a$ can then be added by performing controlled-phase rotation on each of the qubits in the decomposition using the bits of $b$ as controls.

This expansion can be further simplified by noting that for any integer $j$ and real number $x$, $e^{i2\pi(x+j)}=e^{i2\pi x}$.  This is because if you rotate $360^{\circ}$ degrees ($2\pi$ radians) in a circle then you end up precisely where you started.  The only important part of $x$ for $e^{i2\pi x}$ is therefore the fractional part of $x$.  Specifically, if we have a binary expansion of the form $x=y+0.x\_0x\_2\ldots x\_n$ then $e^{i2\pi x}=e^{i2\pi (0.x\_0x\_2\ldots x\_{n-1})}$ and hence
$$\ket{\phi\_k(a+b)}=\frac{1}{\sqrt{2}}\left(\ket{0} + e^{i2\pi [a/2^k+0.b\_k\ldots b\_1]}\ket{1} \right).$$
This means that if we perform addition by incrementing each of the tensor factors in the expansion of the Fourier transform of $\ket{a}$ then the number of rotations shrinks as $k$ decreases.  This substantially reduces the number of quantum gates needed in the adder.  We denote the Fourier transform, phase addition and the inverse Fourier transform steps that comprise the Draper adder as $\operatorname{QFT}^{-1} \left(\phi\\\!\operatorname{ADD}\right) \operatorname{QFT}$. A quantum circuit that uses this simplification to implement the entire process can be seen below.

![Draper adder shown as circuit diagram](~/media/draper.svg)

Each controlled $e^{i2\pi/k}$ gate in the circuit refers to a controlled-phase gate.  Such gates have the property that on the pair of qubits on which they act, $\ket{00}\mapsto \ket{00}$ but $\ket{11}\mapsto e^{i2\pi/k}\ket{11}$.  This circuit allows us to perform addition using no additional qubits apart from those needed to store the inputs and the outputs.

### Beauregard Adder ###

The Beauregard adder is a quantum modular adder that uses the Draper adder in order to perform addition modulo $N$ for an arbitrary value positive integer $N$.  The significance of quantum modular adders, such as the Beauregard adder, stems to a large extent from their use in the modular exponentiation step within Shor's algorithm for factoring.  A quantum modular adder has the following action for quantum input $\ket{b}$ and classical input $a$ where $a$ and $b$ are promised to be integers mod $N$, meaning that they are in the interval $[0,\ldots, N-1]$.

$$
\ket{b}\rightarrow \ket{b+a \text{ mod }N}=\begin{cases} \ket{b+a},& b+a < N\\\\ \ket{b+a-N},& (b+a)\ge N \end{cases}.
$$

The Beauregard adder uses the Draper adder, or more specifically $\phi\\\!\operatorname{ADD}$, to add $a$ and $b$ in phase.  It then uses the same operation to identify whether $a+b <N$ by subtracting $N$ and testing if $a+b-N<0$.  The circuit stores this information in an ancillary qubit and then adds $N$ back the register if $a+b<N$.  It then concludes by uncomputing this ancillary bit (this step is needed to ensure that the ancilla can be de-allocated after calling the adder).  The circuit for the Beauregard adder is given below.

![Beauregard adder shown as circuit diagram](~/media/beau.svg)

Here the gate $\Phi\\\!\operatorname{ADD}$ takes the same form as $\phi\\\!\operatorname{ADD}$ except that in this context the input is classical rather than quantum.  This allows the controlled phases in $\Phi\\\!\operatorname{ADD}$ to be replaced with phase gates that can then be compiled together into fewer operations to reduce both the number of qubits and number of gates needed for the adder.

For more details, please refer to [M. Roetteler, Th. Beth](http://doi.org/10.1007/s00200-008-0072-2 ) and [D. Coppersmith](https://arxiv.org/abs/quant-ph/0201067).

### Quantum Phase Estimation ###

One particularly important application of the quantum Fourier transform is to learn the eigenvalues of unitary operators, a problem known as *phase estimation*.
Consider a unitary $U$ and a state $\ket{\phi}$ such that $\ket{\phi}$ is an eigenstate of $U$ with unknown eigenvalue $\phi$,
\begin{equation}
    U\ket{\phi} = \phi\ket{\phi}.
\end{equation}
If we only have access to $U$ as an oracle, then we can learn the phase $\phi$ by utilizing that $Z$ rotations applied to the target of a controlled operation propagate back onto the control.

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
where $R_1$ is the unitary applied by the <xref:microsoft.quantum.intrinsic.r1> operation.
Put differently, the effect of applying $V$ is precisely the same as applying $R_1$ with an unknown angle, even though we only have access to $V$ as an oracle.
Thus, for the rest of this discussion we will discuss phase estimation in terms of $R_1(\phi)$, which we implement by using so-called *phase kickback*.

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

In Q#, this is implemented by the <xref:microsoft.quantum.characterization.quantumphaseestimation> operation, which takes a <xref:microsoft.quantum.oracles.discreteoracle> implementing application of $U^m$ as a function of positive integers $m$.
