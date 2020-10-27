---
title: Simulating Hamiltonian Dynamics
description: Learn how to use Trotter-Suzuki formulas and qubitization to work with Hamiltonian simulations.
author: bradben
ms.author: v-benbra
ms.date: 10/09/2017
ms.topic: article-type-from-white-list
uid: microsoft.quantum.chemistry.concepts.simulationalgorithms
no-loc: ['Q#', '$$v']
---



# Simulating Hamiltonian Dynamics

Once the Hamiltonian has been expressed as a sum of elementary operators the dynamics can then be compiled into fundamental gate operations using a host of well-known techniques.
Three efficient approaches include are Trotter–Suzuki formulas, linear combinations of unitaries, and qubitization.
We explain these three approaches below and give concrete Q# examples of how to implement these methods using the Hamiltonian simulation library.


## Trotter–Suzuki Formulas
The idea behind Trotter–Suzuki formulas is simple: express the Hamiltonian as a sum of easy to simulate Hamiltonians and then approximate the total evolution as a sequence of these simpler evolutions.
In particular, let $H=\sum_{j=1}^m H_j$ be the Hamiltonian.
Then,
$$
    e^{-i\sum_{j=1}^m H_j t} =\prod_{j=1}^m e^{-iH_j t} + O(m^2 t^2),
$$
which is to say that, if $t\ll 1$, then the error in this approximation becomes negligible.
Note that if $e^{-i H t}$ were an ordinary exponential then the error in this approximation would not be $O(m^2 t^2)$: it would be zero.
This error occurs because $e^{-iHt}$ is an operator exponential and as a result there is an error incurred when using this formula due to the fact that the $H_j$ terms do not commute (*i.e.*, $H_j H_k \ne H_k H_j$ in general).

If $t$ is large, Trotter–Suzuki formulas can still be used to simulate the dynamics accurately by breaking it up into a sequence of short time-steps.
Let $r$ be the number of steps taken in the time evolution, so each time step runs for time $t/r$. 
Then, we have that
$$
    e^{-i\sum_{j=1}^m H_j t} =\left(\prod_{j=1}^m e^{-iH_j t/r}\right)^r + O(m^2 t^2/r),
$$
which implies that if $r$ scales as $m^2 t^2/\epsilon$ then the error can be made at most $\epsilon$ for any $\epsilon>0$.

More accurate approximations can be built by constructing a sequence of operator exponentials such that the error terms cancel.
The simplest such formula, the second order Trotter-Suzuki formula, takes the form
$$
    U_2(t) = \left(\prod_{j=1}^{m} e^{-iH_j t/2r} \prod_{j=m}^1 e^{-iH_j t/2r}\right)^r = e^{-iHt} + O(m^3 t^3/r^2),
$$
the error of which can be made less than $\epsilon$ for any $\epsilon>0$ by choosing $r$ to scale as $m^{3/2}t^{3/2}/\sqrt{\epsilon}$.

Even higher-order formulas, specifically ($2k$)th-order for $k>0$, can be constructed recursively:
$$
    U_{2k}(t) = [U_{2k-2}(s_k\~ t)]^2 U_{2k-2}([1-4s_k]t) [U_{2k-2}(s_k\~ t)]^2 = e^{-iHt} + O((m t)^{2k+1}/r^{2k}),
$$
where $s_k = (4-4^{1/(2k-1)})^{-1}$.

The simplest is the following fourth order ($k=2$) formula, originally introduced by Suzuki:
$$
    U_4(t) = [U_2(s_2\~ t)]^2 U_2([1-4s_2]t) [U_2(s_2\~ t)]^2 = e^{-iHt} +O(m^5t^5/r^4),
$$
where $s_2 = (4-4^{1/3})^{-1}$.
In general, arbitrarily high-order formulas can be similarly constructed; however, the costs incurred from using more complex integrators often outweigh the benefits beyond fourth order for most practical problems.

In order to make the above strategies work, we need to have a method for simulating a wide class of $e^{-iH_j t}$.
The simplest family of Hamiltonians, and arguably most useful, that we could use here are Pauli operators.
Pauli operators can be easily simulated because they can be diagonalized using Clifford operations (which are standard gates in quantum computing).
Further, once they have been diagonalized, their eigenvalues can be found by computing the parity of the qubits on which they act.

For example,
$$
    e^{-iX\otimes X t}= (H\otimes H)e^{-iZ\otimes Z t}(H\otimes H),
$$
where
$$
    e^{-i Z \otimes Z t} = \begin{bmatrix}
        e^{-it} & 0  & 0  & 0 \\\
        0 & e^{i t}  & 0 & 0 \\\
        0 & 0 & e^{it} & 0 \\\
        0 & 0 & 0 & e^{-it}
    \end{bmatrix}.
$$
Here, $e^{-iHt} \ket{00} = e^{it} \ket{00}$ and $e^{-iHt} \ket{01} = e^{-it} \ket{01}$, which can be seen directly as a consequence of the fact that the parity of $00$ is $0$ while the parity of the bit string $01$ is $1$.

Exponentials of Pauli operators can be implemented directly in Q# using the <xref:Microsoft.Quantum.Intrinsic.Exp> operation:
```qsharp
    using(qubits = Qubit[2]){
        let pauliString = [PauliX, PauliX];
        let evolutionTime = 1.0;

        // This applies 𝑒^{- 𝑖 𝑋⊗𝑋 𝑡} to qubits 0 and 1.
        Exp(pauliString, - evolutionTime, qubits);
    }
```

For Fermionic Hamiltonians, the [Jordan–Wigner decomposition](xref:microsoft.quantum.chemistry.concepts.jordanwigner) conveniently maps the Hamiltonian into a sum of Pauli operators.
This means that the above approach can easily be adapted to simulating chemistry.
Rather than manually looping over all Pauli terms in the Jordan-Wigner representation, below is a simple example of how running such a simulation within the chemistry would look.
Our starting point is a [Jordan–Wigner encoding](xref:microsoft.quantum.chemistry.concepts.jordanwigner) of the Fermionic Hamiltonian, expressed in code as an instance of the `JordanWignerEncoding` class.

```csharp
    // This example uses the following namespaces:
    // using Microsoft.Quantum.Chemistry.OrbitalIntegrals;
    // using Microsoft.Quantum.Chemistry.Fermion;
    // using Microsoft.Quantum.Chemistry.Pauli;
    // using Microsoft.Quantum.Chemistry.QSharpFormat;

    // We create an instance of the `FermionHamiltonian` objecclasst to store the terms.
    var hamiltonian = new OrbitalIntegralHamiltonian(new[] 
    {
        new OrbitalIntegral(new[] { 0, 1, 2, 3 }, 0.123),
        new OrbitalIntegral(new[] { 0, 1 }, 0.456)
    }).ToFermionHamiltonian(IndexConvention.UpDown);

    // We convert this fermion Hamiltonian to a Jordan-Wigner representation.
    var jordanWignerEncoding = hamiltonian.ToPauliHamiltonian(QubitEncoding.JordanWigner);

    // We now convert this representation into a format consumable by Q#.
    var qSharpData = jordanWignerEncoding.ToQSharpFormat();
```

This format of the Jordan–Wigner representation that is consumable by the Q# simulation algorithms is a user-defined type `JordanWignerEncodingData`.
Within Q#, this format is passed to a convenience function `TrotterStepOracle` that returns an operator approximating time-evolution using the Trotter—Suzuki integrator, in addition to other parameters required for its run.

```qsharp
// qSharpData passed from driver
let qSharpData = ... 

// Choose the integrator step size
let stepSize = 1.0;

// Choose the order of the Trotter—Suzuki integrator.
let integratorOrder = 4;

// `oracle` is an operation that applies a single time-step of evolution for duration `stepSize`.
// `rescale` is just `1.0/stepSize` -- the number of steps required to simulate unit-time evolution.
// `nQubits` is the number of qubits that must be allocated to run the `oracle` operation.
let (nQubits, (rescale, oracle)) =  TrotterStepOracle (qSharpData, stepSize, integratorOrder);

// Let us now apply a single time-step.
using(qubits = Qubit[nQubits]){

    // Apply single step of time-evolution
    oracle(qubits);

    // Reset all qubits to the 0 state to be successfully released.
    ResetAll(qubits);
}
```

Importantly, this implementation applies some optimizations discussed in [Simulation of Electronic Structure Hamiltonians Using Quantum Computers](https://arxiv.org/abs/1001.3855) and [Improving Quantum Algorithms for Quantum Chemistry](https://arxiv.org/abs/1403.1539) to minimize the number of single-qubit rotations required, as well as reduce simulation errors.

## Qubitization

Qubitization is an alternative approach to simulation that uses ideas from quantum walks to simulate quantum dynamics.
While qubitization requires more qubits than Trotter formulas, the method promises optimal scaling with the evolution time and the error tolerance.
For these reasons it has become a favored method for simulating Hamiltonian dynamics in general, and for solving the electronic structure problem in particular.

At a high level, qubitization accomplishes this through the following steps.
First, let $H=\sum_j h_j H_j$ for unitary and Hermitian $H_j$ and $h_j\ge 0$.
By performing a pair of reflections, qubitization implements an operator that is equivalent to
$$W=e^{\pm i \cos^{-1}(H/|h|_1)},$$
where $|h|_1 = \sum_j |h_j|$.
The next step involves transforming the eigenvalues of the walk operator from $e^{i\pm \cos^{-1}(E_k/|h|_1)}$, where $E_k$ are the eigenvalues of $H$ to $e^{-iE_k t}$.
This can be achieved using a variety of quantum singular value transformation methods including [quantum signal processing](https://journals.aps.org/prl/abstract/10.1103/PhysRevLett.118.010501).

Alternatively, if only static quantities are desired (such as the ground state energy of the Hamiltonian) then it suffices to apply [phase estimation](xref:microsoft.quantum.libraries.characterization) directly to $W$ to estimate the ground state energy from the result by taking the cosine of the result.
This is significant because it allows the spectral transformation to be performed classically rather than using a quantum singular value transformation method.

On a more detailed level, the implementation of qubitization requires two subroutines that provide the interfaces for the Hamiltonian.
Unlike Trotter–Suzuki methods, these subroutines are quantum not classical and their implementation will necessitate using logarithmically more qubits than would be required for a Trotter-based simulation.

The first quantum subroutine that qubitization uses is called $\operatorname{Select}$ and it is promised to yield
\begin{equation}
    \operatorname{Select} \ket{j} \ket{\psi} = \ket{j} H_j \ket{\psi},
\end{equation}
where each $H_j$ is assumed to be Hermitian and unitary.
While this may seem to be restrictive, recall that Pauli operators are Hermitian and unitary and so applications like quantum chemistry simulation naturally fall into this framework.
The $\operatorname{Select}$ operation, perhaps surprisingly, is actually a reflection operation.
This can be seen from the fact that $\operatorname{Select}^2\ket{j} \ket{\psi} = \ket{j} \ket{\psi}$ since each $H_j$ is unitary and Hermitian and thus has eigenvalues $\pm 1$.

The second subroutine is called $\operatorname{Prepare}$.
While the select operation provides a means to coherently access each of the Hamiltonian terms $H_j$ the prepare subroutine gives a method for accessing the coefficients $h_j$,
\begin{equation}
    \operatorname{Prepare}\ket{0} = \sum_j \sqrt{\frac{h_j}{|h|_1}}\ket{j}.
\end{equation}
Then, by using a multiply controlled phase gate, we see that
$$
    \Lambda\ket{0}^{\otimes n} = \begin{cases}
        \-\ket{x} & \text{if } x = 0 \\\
        \ket{x}   & \text{otherwise}
    \end{cases}.
$$

The $\operatorname{Prepare}$ operation is not used directly in qubitization, but rather is used to implement a reflection about the state that $\operatorname{Prepare}$ creates
$$
\begin{align}
    R &amp; = 1 - 2\operatorname{Prepare} \ket{0}\bra{0} \operatorname{Prepare}^{-1} \\\\
      &amp; = \operatorname{Prepare} \Lambda \operatorname{Prepare}^{-1}.
\end{align}
$$

The walk operator, $W$, can be expressed in terms of the $\operatorname{Select}$ and $R$ operations as
$$
W = \operatorname{Select} R,
$$
which again can be seen to implement an operator that is equivalent (up to an isometry) to $e^{\pm i \cos^{-1}(H/|h|_1)}$.

These subroutines are easy to set up in Q#.
As an example, consider the simple qubit transverse-Ising Hamiltonian where $H = X_1 + X_2 + Z_1 Z_2$.
In this case, Q# code that would implement the $\operatorname{Select}$ operation is invoked by <xref:Microsoft.Quantum.Canon.MultiplexOperations>, whereas the $\operatorname{Prepare}$ operation can be implemented using <xref:Microsoft.Quantum.Preparation.PrepareArbitraryState>.
An example that involves simulating the Hubbard model can be found as a [Q# sample](https://github.com/microsoft/Quantum/tree/main/samples/simulation/hubbard).

Manually specifying these steps for arbitrary chemistry problems would require much effort, which is avoided using the chemistry library.
Similarly to the Trotter–Suzuki simulation algorithm above, the `JordanWignerEncodingData` is passed to the convenience function `QubitizationOracle` that returns the walk-operator, in addition to other parameters required for its run.

```qsharp
// qSharpData passed from driver
let qSharpData = ... 

// `oracle` is an operation that applies a single time-step of evolution for duration `stepSize`.
// `rescale` is just `1.0/oneNorm`, where oneNorm is the sum of absolute values of all probabilities in state prepared by `Prepare`.
// `nQubits` is the number of qubits that must be allocated to run the `oracle` operation.
let (nQubits, (rescale, oracle)) =  QubitizationOracle (qSharpData, stepSize, integratorOrder);

// Let us now apply a single step of the quantum walk.
using(qubits = Qubit[nQubits]){

    // Apply single step of quantum walk.
    oracle(qubits);

    // Reset all qubits to the 0 state to be successfully released.
    ResetAll(qubits);
}
```

Importantly, the implementation <xref:Microsoft.Quantum.Chemistry.JordanWigner.QubitizationOracle> is applicable to arbitrary Hamiltonians specified as a linear combination of Pauli strings.
A version optimized for chemistry simulations is invoked using <xref:Microsoft.Quantum.Chemistry.JordanWigner.OptimizedQubitizationOracle>.
This version is optimized to minimize the number of T gates using techniques discussed in [Encoding Electronic Spectra in Quantum Circuits with Linear T Complexity](https://arxiv.org/abs/1805.03662).
