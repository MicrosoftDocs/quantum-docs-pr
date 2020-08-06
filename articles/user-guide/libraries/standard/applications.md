---
# Mandatory fields. See more on aka.ms/skyeye/meta.
title: Applications in the Q# standard libraries
description: Learn about two fundamental applications in quantum computing - Hamiltonian simulation and Shor's search algorithm. 
author: QuantumWriter
uid: microsoft.quantum.libraries.applications
ms.author: martinro@microsoft.com 
ms.date: 12/11/2017
ms.topic: article
no-loc: ['Q#', '$$v']
---

# Applications #

## Hamiltonian Simulation ##

The simulation of quantum systems is one of the most exciting applications of quantum computation.
On a classical computer, the difficulty of simulating quantum mechanics, in general, scales with the dimension $N$ of its state-vector representation.
As this representation grows exponentially with the number of $n$ qubits $N=2^n$, a trait known also known as the [curse of dimensionality](xref:microsoft.quantum.concepts.multiple-qubits), quantum simulation on classical hardware is intractable.

However, the situation can be very different on quantum hardware. The most common variation of quantum simulation is called the time-independent Hamiltonian simulation problem. There, one is provided with a description of the system Hamiltonian $H$, which is a Hermitian matrix, and some initial quantum state $\ket{\psi(0)}$ that is encoded in some basis on $n$ qubits on a quantum computer. As quantum states in closed systems evolve under the Schrödinger equation
$$
\begin{align}
    i\frac{d \ket{\psi(t)}}{d t} & = H \ket{\psi(t)},
\end{align}
$$
the goal is to implement the unitary time-evolution operator $U(t)=e^{-iHt}$ at some fixed time $t$, where $\ket{\psi(t)}=U(t)\ket{\psi(0)}$ solves the Schrödinger equation.
Analogously, the time-dependent Hamiltonian simulation problem solves the same equation, but with $H(t)$ now a function of time.

Hamiltonian simulation is a major component of many other quantum simulation problems, and solutions to Hamiltonian simulation problem are algorithms that describes a sequence of primitive quantum gates for synthesizing an approximating unitary $\tilde{U}$ with error $\\|\tilde{U} - U(t)\\| \le \epsilon$ in the [spectral norm](xref:microsoft.quantum.concepts.matrix-advanced). The complexity of these algorithms depend very strongly on how a description of the Hamiltonian of interest is made accessible by a quantum computer. For instance, in the worst-case, if $H$ acting on $n$ qubits were to be provided as a list of $2^n \times 2^n$ numbers, one for each matrix element, simply reading the data would already require exponential time. In the best case, one could assume access to a black-box unitary that $O\ket{t}\ket{\psi(0)}=\ket{t}U(t)\ket{\psi(0)}$ trivially solves the problem. Neither of these input models are particularly interesting -- the former as it is no better than classical approaches, and the latter as the black-box hides the primitive gate complexity of its implementation, which could be exponential in the number of qubits.

### Descriptions of Hamiltonians ###

Additional assumptions of the format of the input are therefore required. A fine balance must be struck between input models that are sufficiently descriptive to encompass interesting Hamiltonians, such as those for realistic physical systems or interesting computational problems, and input models that are sufficiently restrictive to be efficiently implementable on a quantum computer. A variety of non-trivial input model may be found in the literature, and they range from quantum to classical. 

As examples of quantum input models, [sample-based Hamiltonian simulation](http://www.nature.com/articles/s41534-017-0013-7) assumes black-box access to quantum operations that produce copies of a density matrix $\rho$, which are taken to be the Hamiltonian $H$. In the [unitary access model](https://arxiv.org/abs/1202.5822) one supposes that the Hamiltonian instead decomposes into a sum of unitaries
$$
\begin{align}
    H & = \sum^{d-1}\_{j=0} a\_j \hat{U}\_j,
\end{align}
$$
where $a\_j>0$ are coefficients, and $\hat{U}\_j$ are unitaries. It is then assumed that one has black-box access to the unitary oracle $V=\sum^{d-1}\_{j=0}\ket{j}\bra{j}\otimes \hat{U}\_j$ that selects the desired $\hat{U}\_j$, and the oracle $A\ket{0}=\sum^{d-1}\_{j=0}\sqrt{a\_j/\sum^{d-1}\_{k=0}\alpha\_j}\ket{j}$ that create a quantum state encoding these coefficients. In the case of [sparse Hamiltonian simulation](https://arxiv.org/abs/quant-ph/0301023), one assumes that the Hamiltonian is a sparse matrix with only $d=\mathcal{O}(\text{polylog}(N))$ non-zero element in every row. Moreover, one assumes the existence of efficient quantum circuits that output the location of these non-zero elements, as well as the their values. The complexity of [Hamiltonian simulation algorithms](xref:microsoft.quantum.more-information) is evaluated in terms of number of queries to these black-boxes, and the primitive gate complexity then depends very much on the difficulty of implementing these black-boxes.

> [!NOTE]
> The big-O notation is commonly used to describe the complexity scaling of algorithms. Given two real functions $f,g$, the expression $g(x)=\mathcal{O}(f(x))$ means that there exists an absolute positive constant $x\_0, c>0$ such that $g(x) \le c f(x)$ for all $x\ge x\_0$. 

In most practical applications to be implemented on a quantum computer, these black-boxes must be efficiently implementable, that is with $\mathcal{O}(\text{polylog}(N))$ primitive quantum gates. More strongly, efficiently simulable Hamiltonians must have some sufficiently sparse classical description. In one such formulation, it is assumed that the Hamiltonian decomposes into a sum of Hermitian parts
$$
\begin{align}
    H & = \sum^{d-1}_{j=0} H_j.
\end{align}
$$
Moreover, it is assumed that each part, a Hamiltonian $H\_j$, is easy to simulate. This means that the unitary $e^{-iH\_j t}$ for any time $t$ may be implemented exactly using $\mathcal{O}(1)$ primitive quantum gates. For instance, this is true in the special case where each $H\_j$ are local Pauli operators, meaning that they are of tensor products of $\mathcal{O}(1)$ non-identity Pauli operators that act on spatially close qubits. This model is particularly applicable to physical systems with bounded and local interaction, as the number of terms is $d=\mathcal{O}(\text{polylog}(N))$, and may clearly be written down, i.e. classically described, in polynomial time.

> [!TIP]
> Hamiltonians that decompose into a sum of parts may be described using the Dynamical Generator Representation library. For more information, see the Dynamical Generator Representation section in [data structures](xref:microsoft.quantum.libraries.data-structures).

### Simulation Algorithms ###

A quantum simulation algorithm converts a given description of a Hamiltonian into a sequence of primitive quantum gates that, as a whole, approximate time-evolution by said Hamiltonian.

In the special case where the Hamiltonian decomposes into a sum of Hermitian parts, the Trotter-Suzuki decomposition is a particularly simple and intuitive algorithm for simulating Hamiltonians that decompose into a sum of Hermitian components. For instance, a first-order integrator of this family approximates
$$
\begin{align}
    U(t) & = \left( e^{-iH\_0 t / r} e^{-iH\_1 t / r} \cdots e^{-iH\_{d-1} t / r} \right)^{r} + \mathcal{O}(d^2 \max_j\\|H\_j\\|^2 t^2/r),
\end{align}
$$
using a product of $r d$ terms. 

> [!TIP]
> Applications of the Trotter-Suzuki simulation algorithm are covered in the samples.
> For the Ising model using only the intrinsic operations provided by each target machine, please see the [**SimpleIsing** sample](https://github.com/microsoft/Quantum/blob/master/samples/simulation/ising/simple).
> For the Ising model using the Trotter-Suzuki library control structure, please see the [**IsingTrotter** sample](https://github.com/microsoft/Quantum/tree/master/samples/simulation/ising/trotter-evolution).
> For molecular Hydrogen using the Trotter-Suzuki library control structure, please see the [**H2 simulation** sample](https://github.com/microsoft/Quantum/tree/master/samples/simulation/h2/command-line).

In many cases, we would like to implement the simulation algorithm, but are not interested in the details of its implementation. For instance, the second-order integrator approximates
$$
\begin{align}
    U(t) & = \left( 
            e^{-iH\_0 t / 2r} e^{-iH\_1 t / 2r} \cdots e^{-iH\_{d-1} t / 2r} 
             e^{-iH\_{d-1} t / 2r}  \cdots e^{-iH\_1 t / 2r} e^{-iH\_0 t / 2r}
    \right)^{r} + \mathcal{O}(d^3 \max_j\\|H\_j\\|^3 t^3/r^2),
\end{align}
$$ 
using a product of $2rd$ terms. Larger orders will involve even more terms and optimized variants may require highly non-trivial orderings on the exponentials. Other advanced algorithms may also involve the use of ancilla qubits in intermediate steps. Thus we package simulation algorithms in the canon as the user-defined type

```qsharp
newtype SimulationAlgorithm = ((Double, EvolutionGenerator, Qubit[]) => Unit is Adj + Ctl);
```

The first parameter `Double` is the time of simulation, the second parameter `EvolutionGenerator`, covered in the Dynamical Generator Representation section of [data-structures](xref:microsoft.quantum.libraries.data-structures), is a classical description of a time-independent Hamiltonian packaged with instructions on how each term in the Hamiltonian may be simulated by a quantum circuit. Types of this form approximate the unitary operation $e^{-iHt}$ on the third parameter `Qubit[]`, which is the register storing the quantum state of the simulated system. Similarly for the time-dependent case, we define a user-defined type with an `EvolutionSchedule` type instead, which is a classical description of a time-dependent Hamiltonian.

```qsharp
newtype TimeDependentSimulationAlgorithm = ((Double, EvolutionSchedule, Qubit[]) => Unit : Adjoint, Controlled);
```

As an example, the Trotter-Suzuki decomposition may be called using the following canon functions, with parameters `trotterStepSize` modifying the duration of simulation in each exponential, and `trotterOrder` for the order of the desired integrator.

```qsharp
function TrotterSimulationAlgorithm(
    trotterStepSize : Double, 
    trotterOrder : Int) 
: SimulationAlgorithm {
    ...
}

function TimeDependentTrotterSimulationAlgorithm(
    trotterStepSize : Double, 
    trotterOrder : Int) 
: TimeDependentSimulationAlgorithm {
    ...
}
```

> [!TIP]
> Applications of the simulation library are covered in the samples. 
> For phase estimation in the Ising model using `SimulationAlgorithm`, please see the [**IsingPhaseEstimation** sample](https://github.com/microsoft/Quantum/tree/master/samples/simulation/ising/phase-estimation).
> For adiabatic state preparation in the Ising model using `TimeDependentSimulationAlgorithm`, please see the [**AdiabaticIsing** sample](https://github.com/microsoft/Quantum/tree/master/samples/simulation/ising/adiabatic).


### Adiabatic State Preparation & Phase Estimation ###

One common application of Hamiltonian simulation is adiabatic state preparation. Here, one is provided with two Hamiltonians $H\_{\text{start}}$ and $H\_{\text{end}}$, and a quantum state $\ket{\psi(0)}$ that is a ground state of the start Hamiltonian $H\_{\text{start}}$. Typically, $H\_{\text{start}}$ is chosen such that $\ket{\psi(0)}$ is easy to prepare from a computational basis state $\ket{0\cdots 0}$. By interpolating between these Hamiltonians in the time-dependent simulation problem sufficiently slowly, it is possible to end up, with high probability, in a ground state of the final Hamiltonian $H\_{\text{end}}$. Though preparing good approximations to Hamiltonian ground states could proceed in this manner by calling upon on time-dependent Hamiltonian simulation algorithms as a subroutine, other conceptually different approaches such as the variational quantum eigensolver are possible.

Yet another application ubiquitous in quantum chemistry is estimating the ground state energy of Hamiltonians representing the intermediate steps of chemical reaction. Such a scheme could, for instance, rely on adiabatic state preparation to create the ground state, and then incorporate time-independent Hamiltonian simulation as a subroutine in phase estimation characterization to extract this energy with some finite error and probability of success. 

Abstracting simulation algorithms as the user-defined types `SimulationAlgorithm` and `TimeDependentSimulationAlgorithm` allow us to conveniently incorporate their functionality into more sophisticated quantum algorithms. This motivates us to do the same for these commonly used subroutines.

Thus we define the convenient function

```qsharp
function InterpolatedEvolution(
        interpolationTime : Double, 
        evolutionGeneratorStart : EvolutionGenerator,
        evolutionGeneratorEnd : EvolutionGenerator,
        timeDependentSimulationAlgorithm : TimeDependentSimulationAlgorithm)
: (Qubit[] => Unit is Adj + Ctl) {
        ...
}
 
```

This returns a unitary operation that implements all steps of adiabatic state preparation. The first parameter `interpolatedTime` defines the time over which we linearly interpolate between the start Hamiltonian described by the second parameter `evolutionGeneratorStart` and the end Hamiltonian described by the third parameter `evolutionGeneratorEnd`. The fourth parameter `timeDependentSimulationAlgorithm` is where one makes the choice of simulation algorithm. Note that if `interpolatedTime` is long enough, an initial ground state remains an instantaneous ground state of the Hamiltonian over the entire duration of time-dependent simulation, and thus ends in the ground state of the end Hamiltonian.

We also define a helpful operation that automatically performs all steps of a typical quantum chemistry experiment. For instance we have the following, which returns an energy estimate of the state produced by adiabatic state preparation:

```qsharp
operation EstimateAdiabaticStateEnergy(
    nQubits : Int,
    statePrepUnitary : (Qubit[] => Unit),
    adiabaticUnitary : (Qubit[] => Unit),
    qpeUnitary: (Qubit[] => Unit is Adj + Ctl),
    phaseEstAlgorithm : ((DiscreteOracle, Qubit[]) => Double))
: Double {
...
}
```

`nQubits` is the number of qubits used to encode the initial quantum state. `statePrepUnitary` prepares the start state from the computational basis $\ket{0\cdots 0}$. `adiabaticUnitary` is the unitary operation that implements adiabatic state preparation, such as produced by the  `InterpolatedEvolution` function. `qpeUnitary` is the unitary operation that is used to perform phase estimation on the resulting quantum state. `phaseEstAlgorithm` is our choice of phase estimation algorithm.

> [!TIP]
> Applications of adiabatic state preparation are covered in the samples. 
> For the Ising model using a manual implementation of adiabatic state preparation versus using the `AdiabaticEvolution` function, please see the [**AdiabaticIsing** sample](https://github.com/microsoft/Quantum/tree/master/samples/simulation/ising/adiabatic).
> For phase estimation and adiabatic state preparation in the Ising model, please see the [**IsingPhaseEstimation** sample](https://github.com/microsoft/Quantum/tree/master/samples/simulation/ising/phase-estimation).

> [!TIP]
> The [simulation of molecular Hydrogen](https://github.com/microsoft/Quantum/tree/master/samples/simulation/h2/command-line) is an interesting and brief sample. The model and experimental results reported in [O'Malley et. al.](https://arxiv.org/abs/1512.06860) only requires Pauli matrices and takes the form $\hat H = g\_{0}I\_0I\_1+g\_1{Z\_0}+g\_2{Z\_1}+g\_3{Z\_0}{Z\_1}+g\_4{Y\_0}{Y\_1}+g\_5{X\_0}{X\_1}$. This is an effective Hamiltonian only requiring only 2 qubits, where the constants $g$ are computed from the distance $R$ between the two Hydrogen atoms. Using canon functions, the Paulis are converted to unitaries and then evolved over short periods of time using the Trotter-Suzuki decomposition. A good approximation to the $H_2$ ground state can be created without using adiabatic state preparation, and so the ground state energy may be found directly by utilizing phase estimation from the canon.

## Shor's Algorithm ##
Shor's algorithm remains one of the most significant developments in quantum computing because it showed that quantum computers could be used to solve important, currently classically intractable problems.
Shor's algorithm provides a fast way to factor large numbers using a quantum computer, a problem called *factoring*.
The security of many present-day cryptosystems is based on the assumption that no fast algorithm exists for factoring.
Thus Shor's algorithm has had a profound impact on how we think about security in a post-quantum world.

Shor's algorithm can be thought of as a hybrid algorithm.
The quantum computer is used to perform a computationally hard task known as period finding.
The results from period finding are then classically processed to estimate the factors.
We review these two steps below.

### Period Finding ###

Having seen how the quantum Fourier transform and phase estimation work (see [Quantum algorithms](xref:microsoft.quantum.libraries.standard.algorithms)), we can use these tools to solve a classically hard computational problem called *period finding*.  In the next section, we will see how to apply period finding to factoring.

Given two integers $a$ and $N$, where $a<N$, the goal of period finding, also called order finding, is to find the _order_ $r$ of $a$ modulo $N$, where $r$ is defined to be the least positive integer such that $a^r \equiv 1 \text{ mod } N$.  

To find the order using a quantum computer, we can use the phase estimation algorithm applied to the following unitary operator $U_a$:
$$ U_a\ket{x} \equiv \ket{(ax)\text{ mod }N} .$$
The eigenvectors of $U_a$ are for integer $s$ and $0\leq s \leq r - 1$,
$$\ket{x_s} \equiv 1 / \sqrt{r} \sum\_{k=0}^{r-1} e^{\frac{-2\pi i sk}{r}} \ket{a^k\text{ mod }N},$$
are _eigenstates_ of $U_a$.
The eigenvalues of $U_a$ are
$$ U\_a \ket{x\_s} = e^{2\pi i s / r} \ket{x\_s} . $$

Phase estimation thus outputs the eigenvalues $e^{2\pi i s / r}$ from which $r$ can be learned efficiently using [continued fractions](https://en.wikipedia.org/wiki/Continued_fraction) from $s / r$.

The circuit diagram for quantum period finding is:

![Circuit diagram for quantum period finding](~/media/QPE.svg)

Here $2n$ qubits are initialized to $\ket{0}$ and $n$ qubits are initialized to $\ket{1}$.
The reader again may wonder why the quantum register to hold the eigenstates is initialized to $\ket{1}$.
As one does not know the order $r$ in advance, we cannot actually prepare $\ket{x_s}$ states directly.
Luckily, it turns out that $1/\sqrt{r} \sum\_{s=0}^{r-1} \ket{x\_s} = \ket{1}$.
We don't need to actually prepare $\ket{x}$!
We can just prepare a quantum register of $n$ qubits in state $\ket{1}$. 

The circuit contains the QFT and several controlled gates.
The QFT gate has been described [previously](xref:microsoft.quantum.libraries.standard.algorithms).
The controlled-$U_a$ gate maps $\ket{x}$ to $\ket{(ax)\text{ mod } N}$ if the control qubit is $\ket{1}$, and maps $\ket{x}$ to $\ket{x}$ otherwise.

To achieve $(a^nx)\text{ mod } N$,  we can simply apply controlled-$U_{a^n}$, where we calculate $a^n \text{ mod } N$ classically to plug into the quantum circuit.  
The circuits to achieve such modular arithmetic have been described in the [quantum arithmetic documentation](./algorithms.md#arithmetic), specifically we require a modular exponentiation circuit to implement the controlled-$U\_{a^i}$ operations.

While the circuit above corresponds to [Quantum Phase Estimation](xref:microsoft.quantum.characterization.quantumphaseestimation) and explicitly enables order finding, we can reduce the number of qubits required. We can either follow Beauregard's method for order finding as described 
[on Page 8 of arXiv:quant-ph/0205095v3](https://arxiv.org/pdf/quant-ph/0205095v3.pdf#page=8), or 
use one of the phase estimation routines available in Microsoft.Quantum.Characterization. For example, 
[Robust Phase Estimation](xref:microsoft.quantum.characterization.robustphaseestimation) also uses one extra qubit.
 
### Factoring ###
The goal of factoring is to determine the two prime factors of integer $N$, where $N$ is an $n$-bit number.  
Factoring consists of the steps described below. The steps are split into three parts: a classical preprocessing routine (1-4); a quantum computing routine to find the order of $a \text{ mod } N$ (5); and a classical postprocessing routine to derive the prime factors from the order (6-9).

The classical preprocessing routine consists of the following steps:
1. If $N$ is even, return the prime factor $2$.
2. If $N=p^q$ for $p\geq1$, $q\geq2$, return the prime factor $p$.  This step is performed classically.
3. Choose a random number $a$ such that $1 < a < N-1$.
4. If $\text{gcd}(a,N)>1$, return the prime factor $\text{gcd}(a,N)$. This step is computed using Euclid's algorithm.
If no prime factor has been returned, we proceed to the quantum routine:
5. Call the quantum period finding algorithm to calculate the order $r$ of $a \text{ mod } N$. Use $r$ in the classical postprocessing routine to determine the prime factors:
6. If $r$ is odd, go back to preprocessing step (3).
7. If $r$ is even and $a^{r/2} = -1\text{ mod }N$, go back to preprocessing step (3).
8. If $\text{gcd}(a^{r/2}+1, N)$ is a non-trivial factor of $N$, return $\text{gcd}(a^{r/2}+1, N)$.
9. If $\text{gcd}(a^{r/2}-1, N)$ is a non-trivial factor of $N$, return $\text{gcd}(a^{r/2}-1, N)$.


The factoring algorithm is probabilistic: it can been shown that with probability at least one half that $r$ will be even and $a^{r/2} \neq -1 \text{ mod }N$, thus producing a prime factor.  (See [Shor's original paper](https://doi.org/10.1109/SFCS.1994.365700) for details, or one of the *Basic quantum computing* texts in [For more information](xref:microsoft.quantum.more-information)).
If a prime factor is not returned, then we simply repeat the algorithm from step (1).  After $n$ tries, the probability that every attempt has failed is at most $2^{-n}$.
Thus after repeating the algorithm a small number of times success is virtually assured.
