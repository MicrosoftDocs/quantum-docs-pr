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

## Applications ##

### Hamiltonian Simulation ###

The simulation of quantum systems is one of the most exciting applications of quantum computation. On a classical computer, the difficulty of simulating quantum mechanics, in general, scales with the dimension $N$ of its state-vector representation. As this representation grows exponentially with the number of $n$ qubits $N=\mathcal{O}(n)$, a trait known also known as the [Curse of dimensionality][quantum-computing-concepts#multiple-qubits], quantum simulation on classical hardware is intractable. However, the situation is very different on quantum hardware -- so long the system of interest has a classical description that is, in some sense, sufficiently sparse, efficient simulation using a number of quantum gates poly-logarithmic in the dimension of the system is possible.  

The most common variation of quantum simulation called the time-independent Hamiltonian simulation problem. There, one is provided with a classical description of the system Hamiltonian $H$, which is a Hermitian matrix, and some initial quantum state $\ket{\psi(0)}$ that is encoded in some basis on some number of qubits on a quantum computer. As quantum states in closed systems evolve under the Schrödinger equation
$$
\begin{align}
    \frac{d \ket{\psi(t)}}{d t} & = \hat{H}(t) \ket{\psi(t)},
\end{align}
$$
the goal is to to implement the unitary time-evolution operator $U(t)=e^{-i\hat{H}t}$ at some fixed time $t$, where $\ket{\psi(t)}=U(t)\ket{\psi(0)}$ solves the Schrödinger equation. Analogously, the time-dependent Hamiltonian simulation problem solves the same equation, but with $H(t)$ now a function of time. 

#### Classical Descriptions of Hamiltonians ####
Hamiltonian simulation problem is a major component of many quantum simulation problems. The solution to Hamiltonian simulation is an algorithm that describes a sequence of primitive quantum gates for  synthesizing an approximating unitary $\tilde{U}$ with error $\|\tilde{U} - U(t)\| \le \epsilon$. The complexity of this algorithm depends very strongly on the form of this classical description. For instance, if $H$ acting on $n$ qubits were to be provided as a list of $2^n \times 2^n$ numbers, one for each matrix element, simply reading the data would already require exponential time. Additional assumptions of the format of the input are therefore required. 

In the original formulation by [Seth Lloyd](http://science.sciencemag.org/content/273/5278/1073), it is assumed that the Hamiltonian decomposes into a sum of parts.
$$
\begin{align}
    \hat{H} & = \sum^{d-1}_{j=0} \hat{H}_j.
\end{align}
$$
Moreover, it is assumed that that each part, a Hamiltonian $\hat{H}_j$, is easy to simulate. This means that the unitary $e^{-\hat{H}_j t}$ for any time $t$ may be implemented exactly using $\mathcal{O}(1)$ primitive quantum gates. The best simulation algorithms are then able to approximate time-evolution by the whole $e^{-i\hat{H}t}$ using a product of $\mathcal{O}(\text{poly}(d,t,\epsilon, \|H_j\|))$ time-evolutions of the parts. As such, Hamiltonian simulation is defined to be efficient if the number of terms $d=\text{polylog}(N)$ is polylogarithmic in the number of qubits acted upon by $\hat{H}. 

> [!TIP]
> Hamiltonians that decompose into a sum of parts may be described using the [Dynamical Generator Representation](data-structures#dynamical-generator-modeling) library

There exist other major variations of how quantum Hamiltonians may be sprasely described by a classical input. In the case where the parts $\hat{H}_j$ are also proportional to unitaries, this is generalized by a more recent formulation based on the unitary-access-model introduced by [Childs et al.](https://arxiv.org/abs/1202.5822). Here, one assumes that the Hamiltonian instead decomposes into a sum of unitaries 
$$
\begin{align}
    \hat{H} & = \sum^{d-1}_{j=0} a_j \hat{U}_j.
\end{align}
$$
where the $a_j$ are in general complex coefficients. In the case of $d$-sparse Hamiltonian simulation, one assumes that the Hamiltonian only has $d=\text{polylog}(N)$ non-zero element in every row. Moreover, one assumes the existence of efficient quantum circuits that output the location of these 
non-zero elements, as well as the their value. One may also suppose that Hamiltonians are described as a quantum input, such as as density matrices fed directly into the quantum computer.

#### Simulation Algorithms ####

A quantum simulation algorithm converts a given classical description of a Hamiltonian into a sequence of primitive quantum gates that, as a whole, approximate time-evolution by said Hamiltonian.

The [Trotter-Suzuki decomposition](control-flow#time-ordered-composition) is a particularly simple and intuitive algorithm for simulating Hamiltonians that decompose into a sum of Hermitian components. For instance, a first-order integrator of this family approximates
$$
\begin{align}
    U(t) & = \left( e^{-i\hat{H}\_0 t / r} e^{-i\hat{H}\_1 t / r} \cdots e^{-i\hat{H}\_{d-1} t / r} \right)^{r} + \mathcal{O}(d^2 \|\hat{H}\_j\|^2 t^2/r),
\end{align}
$$
using a product of $r d$ terms. 

> [!TIP]
> Applications of the Trotter-Suziki simulation algorithm is covered in the samples. 
> Ising model using only the primitive library; please see the [**SimpleIsing** sample](TODO: link).
> Ising model using the Trotter-Suzuki library control structure; please see the [**IsingTrotter** sample](TODO: link).
> Molecular hydrogen using the Trotter-Suzuki library control structure; please see the [**H2 simulation** sample](TODO: link).

In many cases, we would like to implement the simulation algorithm, but are not interested in the details of it implementation. For instance, the second-order integrator approximates
$$
\begin{align}
    U(t) & = \left( 
            e^{-i\hat{H}\_0 t / 2r} e^{-i\hat{H}\_1 t / 2r} \cdots e^{-i\hat{H}\_{d-1} t / 2r} 
             e^{-i\hat{H}\_{d-1} t / 2r}  \cdots e^{-i\hat{H}\_1 t / 2r} e^{-i\hat{H}\_0 t / 2r}
    \right)^{r} + \mathcal{O}(d^3 \|\hat{H}\_j\|^3 t^3/r^2),
\end{align}
$$ 
using a product of $2rd$ terms. Larger orders will involve even more terms and optimized variants may require highly non-trivial orderings on the exponentials. Other advanced algorithms may also involve the use of ancilla qubits in intermediate steps. Thus we package simulation algorithms as the user-defined type

```qsharp
newtype SimulationAlgorithm = ((Double, EvolutionGenerator, Qubit[]) => () : Adjoint, Controlled);
```

The first parameter `Double` is the time of simulation, the second parameter `EvolutionGenerator` , covered in [Dynamical Generator Representation](data-structures#dynamical-generator-modeling), is a classical description of a time-independent Hamiltonian packaged with instructions on how each term in the Hamiltonian may be simulated by a quantum circuit. Types of this form approximate the unitary operation $e^{-i\hat{H}t}$ on the third parameter `Qubit[]`, which is the register storing the quantum state of the simulated system. Similarly for the thime-dependent case, we define a user-defined type with an `EvolutionSchedule` instead, which is a classical description of a time-dependent Hamiltonians.

```qsharp
newtype TimeDependentSimulationAlgorithm = ((Double, EvolutionSchedule, Qubit[]) => () : Adjoint, Controlled);
```

As an example, the Trotter-Suzuki decomposition may be called usingcanon functions, with parameters `trotterStepSize` for the duration of simulation in each exponential, and `trotterOrder` for the order of the desired integrator as follows.

```qsharp
TrotterSimulationAlgorithm(trotterStepSize: Double, trotterOrder: Int) : SimulationAlgorithm
TimeDependentTrotterSimulationAlgorithm(trotterStepSize: Double, trotterOrder: Int) : TimeDependentSimulationAlgorithm
```

> [!TIP]
> Applications of the simulation algorithms library are covered in the samples. 
> Phase estimation in the Ising model using `SimulationAlgorithm`; please see the [**IsingPhaseEstimation** sample](TODO: link).
> Adiabatic state preparation in the Ising model using `TimeDependentSimulationAlgorithm`; please see the [**AdiabaticIsing** sample](TODO: link).

#### Adiabatic State Preparation & Phase Estimation####

One common application of Hamiltonian simulation is adiabatic state preparation. Here, one is provided with two Hamiltonians $\hat{H}\_{\text{start}}$ and $\hat{H}\_{\text{end}}$, and a quantum state $\ket{\psi(0)}$ that is a gound state of the start Hamiltonian $\hat{H}\_{\text{start}}$. Typically, $\hat{H}\_{\text{start}}$ is chosen such that $\ket{\psi(0)}$ is easy to prepare from a computational basis state $\ket{0...0}$. By slowly interpolating between these Hamiltonians in the time-dependent simulation problem, it is possible to end up, with high probability, in a ground state of the final Hamiltonian $\hat{H}\_{\text{end}}$. Though preparing good approximations to Hamiltonian ground states could proceed this manner by calling upon on time-dependent Hamiltonian simulation algorithms as a sub-routine, other conceptually different approaches such as variational eigensolver are possible.

Yet another application ubiquitous in quantum chemistry is estimating the ground state energy of Hamiltonians representing the intermediate steps of chemical interactions. Such a scheme could, for instance, rely on adiabatic state preparation to create the ground state, and then incorporate time-independent Hamiltonian simulation as a sub-routine in [phase estimation](quantum-characterization-and-statistics) to extract this energy with some finite error and probability of success. 

Abstracting simulation algorithms as the user-defined types `SimulationAlgorithm` and `TimeDependentSimulationAlgorithm` allow us to conveniently incorporate their functionality into more sophisticated quantum algorithms. We would like to do the same for these commonly used sub-routines

Thus we define the convenient function

```qsharp
    function AdiabaticEvolution(
        adiabaticTime: Double, 
        evolutionGeneratorStart: EvolutionGenerator,
        evolutionGeneratorEnd: EvolutionGenerator,
        timeDependentSimulationAlgorithm: TimeDependentSimulationAlgorithm)
        : (Qubit[] => () : Adjoint, Controlled) 
        {
        ...
}
 
```

This returns a unitary operation that implements all steps of adiabatic state preparation. The first parameter `adiabaticTime` defines the time over which we interpolate between the start Hamiltonian described by the second parameter `evolutionGeneratorStart` and the end Hamiltonian described by the third parameter `evolutionGeneratorEnd`. The fourth parameter `timeDependentSimulationAlgorithm` is where one makes the choice of simulation algorithm. Note that if `adiabaticTime` is long enough, an initial ground state remains an instanteous ground state of the Hamiltonian over the entire duration of time-dependent simulation, and thus ends in the ground state of the end Hamiltonian.

We also define helpful operation that automatically performs all steps of a typical quantum chemistry experiment. For instance we have the following, which returns an energy estimate of the state produced by adiabatic state preparation.

```qsharp
operation AdiabaticStateEnergyEstimate( nQubits : Int, 
                                        statePrepUnitary: (Qubit[] => ()),
                                        adiabaticUnitary: (Qubit[] => ()),
                                        qpeUnitary: (Qubit[] => () :  Adjoint, Controlled),
                                        phaseEstAlgorithm : ((DiscreteOracle, Qubit[]) => Double)) : Double 
                                        {
...
}
```

`nQubits` is the number of qubits used to encode the initial quantum state. `statePrepUnitary` prepares the start state from the computational basis $\ket{0..0}$. `adiabaticUnitary` is the unitary operation that implements adiabatic state preparation, such as produced by the  `AdiabaticEvolution` function. `qpeUnitary` is the unitary operation that is used to perform phase estimation on the resulting quantum state. `phaseEstAlgorithm` is our choice of phase estimation algorithm.

> [!TIP]
> Applications of adiabatic state preparation are covered in the samples. 
> Ising model using a manual implementation of adiabtic state preparation versus using the `AdiabaticEvolution` function; please see the [**AdiabaticIsing** sample](TODO: link).
> Phase estimation and adiabatic state preparation in the Ising model ; please see the [**IsingPhaseEstimation** sample](TODO: link).

#### Other Samples ####

The modeling of Hamiltonians is one of the major application areas desired for Quantum Computing. We provide a simple example of this based on the experimental results reported in [O'Malley et. al.](https://arxiv.org/abs/1512.06860) using superconducting qubits. The model used for molecular hydrogen ($H_2$) only requires Pauli matrices and takes the form:

        $H = g_{0}\bold{1}+g_1{Z_0}+g_2{Z_1}+g_3{Z_0}{Z_1}+g_4{Y_0}{Y_1}+g_5{X_0}{X_1}$

We represent the target Hamiltonian as an expansion in a set of unitaries which allows the system to find a solution using either Trotter-Suzuki with Phase Estimation or a Linear Combination of Unitaries (LCU) with Amplitude Amplification. For an in-depth treatment of LCU, please refer to Chapter 2 of  [Robin Kohari's thesis](https://uwspace.uwaterloo.ca/bitstream/handle/10012/8625/Kothari_Robin.pdf). A nice overview of the area was presented by [Dominic Berry](http://www.dominicberry.org/presentations/Durban.pdf).

The $H_2$ example is an Effective Hamiltonian only representing the off-diagonal elements, requiring only 2 qubits. The constants $g$ are computed from the distance $R$ between the two Hydrogen atoms. 

Using canon functions, the Paulis are converted to Unitaries and then evolved over short periods of time, implementing Trotterization. This allows us to use a product of Unitaries (quantum circuit) to represent the sum of terms in the Hamiltonian. See `ExampleH2.qs` for how this is done.

The solution for the Hamiltonian ground state is found by utilizing Phase Estimation (described earlier) from the canon.

To demonstrate the solution, a top level driver program (`H2SimulationExample`) is provided which performs a plot of the resulting ground state energy for several bond lengths $R$ using the `FSharp.Charting` package and is shown along with the theoretical values.
> For an example based on molecular Hydrogen, please see the [*H2Simulation** sample](TODO: link).


### Factorization ###

