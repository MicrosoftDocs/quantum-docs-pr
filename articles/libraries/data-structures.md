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

# Data Structures and Modeling #

## Classical Data Structures ##

Along with user-defined types for representing quantum concepts, the canon also provides operations, functions, and types for working with classical data used in the control of quantum systems.
For instance, the @"microsoft.quantum.canon.reverse" function takes an array as input and returns the same array in reverse order.
This can then be used on an array of type `Qubit[]` to avoid having to apply unnecessary $\operatorname{SWAP}$ gates when converting between quantum representations of integers.
Similarly, we saw in the previous section that types of the form `(Int, Int -> T)` can be useful for representing random access collections, so the @"microsoft.quantum.canon.lookupfunction" function provides a convienent way of constructing such types from array types.

<!-- TOOD: point out that MapIndex can be used to reconstruct an array from a lookup function. Also, write MapIndex. -->

### Pairs ###

The canon supports functional-style notation for pairs, complementing accessing tuples by deconstruction:

```
let pair = (PauliZ, register); // type (Pauli, Qubit[])
ApplyToEach(H, Snd(pair)); // No need to deconstruct to access the register.
```

### Arrays ###

The canon provides several functions for manipulating arrays.
These functions are type-parameterized, and thus can be used with arrays of any Q# type.
For instance, the <xref:microsoft.quantum.canon.reverse> function returns a new array whose elements are in reverse order from its input.
This can be used to change how a quantum register is represented when calling operations:

```
let leRegister = LittleEndian(register);
// QFT expects a BigEndian, so we can reverse before calling.
QFT(BigEndian(Reverse(leRegister)));
```

Similarly, the <xref:microsoft.quantum.canon.permute> function can be used to reorder or take subsets of the elements of an array:

```qsharp
// Applies H to qubits 2 and 5.
ApplyToEach(H, Permute([2; 5], register));
```

When combined with flow control, array manipulation functions such as <xref:microsoft.quantum.canon.zip> can provide a powerful way to express quantum programs:

```qsharp
// FIXME: uses type-parameterization, and needs checked.
// Applies X₃ Y₁ Z₇ to a register of any size.
ApplyToEach(
    ApplyPauli(_, register),
    Map(
        EmbedPauli(_, _, Length(register)),
        Zip([PauliX; PauliY; PauliZ], [3; 1; 7])
    )
);
```

## Oracles ##

In the phase estimation and amplitude amplification literature the concept of an oracle appears frequently.
Here the term oracle refers to a blackbox quantum subroutine that acts upon a set of qubits and returns the answer as a phase.
This subroutine often can be thought of as an input to a quantum algorithm that accepts the oracle, in addition to some other parameters, and applies a series of quantum operations and treating a call to this quantum subroutine as if it were a fundamental gate.
Obviously, in order to actually implement the larger algorithm a concrete decomposition of the oracle into fundamental gates must be provided but such a decomposition is not needed in order to understand the algorithm that calls the oracle.
In Q#, this abstraction is represented by using that operations are first-class values, such that operations can be passed to implementations of quantum algorithms in a black-box manner.
Moreover, user-defined types are used to label the different oracle representations in a type-safe way, making it difficult to accidently conflate different kinds of black box operations.

Such oracles appear in a number of different contexts, including famous examples such as Grover's search and quantum simulation algorithms.
Here we focus on the oracles needed for just two applications: amplitude amplification and phase estimation.
We will first discuss amplitude amplification oracles before proceding to phase estimation.

### Amplitude Amplification Oracles ###

The amplitude amplification algorithm aims to perform a rotation between an initial state and a final state by applying a sequence of reflections of the state.
In order for the algorithm to function, it needs a specification of both of these states.
These specifications are given by two oracles.
These oracles work by breaking the inputs into two spaces, a "target" subspace and an "initial" subspace.
The oracles identify such subspaces, similar to how Pauli operators identify two spaces, by applying a $\pm 1$ phase to these spaces.
The main difference is that these spaces need not be half-spaces in this application.
Also note that these two subspaces are not usually mutually exclusive: there will be vectors that are members of both spaces.
If this were not true then amplitude amplification would have no effect so we need the initial subspace to have non-zero overlap with the target subspace.

We will denote the first oracle that we need for amplitude amplification to be $P_0$, defined to have the following action.  For all states $\ket{x}$ in the "initial" subspace $P_0 \ket{x} = -\ket{x}$ and for all states $\ket{y}$ that are not in this subspace we have $P_0 \ket{y} = \ket{y}$.
The oracle that marks the target subspace, $P_1$, takes exactly the same form.
For all states $\ket{x}$ in the target subspace (i.e., for all states that you'd like the algorithm to output), $P_1\ket{x} = -\ket{x}$.
Similarly, for all states $\ket{y}$ that are not in the target subspace $P_1\ket{y} = \ket{y}$.
These two reflections are then combined to form an operator that enacts a single step of amplitude amplification, $Q = -P_0 P_1$, where the overall minus sign is only important to consider in controlled applications.
Amplitude amplification then proceeds by taking an initial state, $\ket{\psi}$ that is in the initial subspace and then performs $\ket{\psi} \mapsto Q^m \ket{\psi}$.
Performing such an iteration guarantees that if one starts with an initial state that has overlap $\sin^2(\theta)$ with the marked space then after $m$ iterations this overlap becomes $\sin^2([2m + 1] \theta)$.
We therefore typically wish to choose $m$ to be a free parameter such that $[2m+1]\theta = \pi/2$; however, such rigid choices are not as important for some forms of amplitude amplification such as fixed point amplitude amplification.
This process allows us to prepare a state in the marked subspace using quadratically fewer queries to the marking function and the state preparation function than would be possible on a strictly classical device.
This is why amplitude amplification is a significant primitive for many applications of quantum computing.

In order to understand how to use the algorithm, it is useful to provide an example that gives a construction of the oracles.  Consider performing Grover's algorithm for database searches in this setting.
In Grover's search the goal is to transform the state $\ket{+}^{\otimes n} = H^{\otimes n} \ket{0}$ into one of (potentially) many marked states.
To further simplify, let's just look at the case where the only marked state is $\ket{0}$.
Then we have design two oracles: one that only marks the initial state $\ket{+}^{\otimes n}$ with a minus sign and another that marks the marked state $\ket{0}$ with a minus sign.
The latter gate can be implemented using the following process operation, by using the control flow operations in the canon:

```qsharp
operation ReflectAboutAllZeros(register : Qubit[]) : () {
    body {
        // Apply $X$ gates to every qubit.
        ApplyToEach(X, register);

        // Apply an $n-1$ controlled $Z$-gate to the $n^{\text{th}}$ qubit.
        // This gate will lead to a sign flip if and only if every qubit is
        // $1$, which happens only if each of the qubits were $0$ before step 1.
        (Controlled Z)(register[0..Length(register) - 2], register[Length(register) - 1]);

        // Apply $X$ gates to every qubit.
        ApplyToEach(X, register);
    }

    adjoint auto
    controlled auto
    controlled adjoint auto
}
```

This oracle is then a special case of the <xref:microsoft.quantum.canon.rall1> operation, which allows for rotating by an arbitrary phase instead of the reflection case $\phi = -1$.
In this case, `RAll1` is similar to the <xref:microsoft.quantum.primitive.r1> prelude operation, in that it rotates about $\ket{11\cdots1}$ instead of the single-qubit state $\ket{1}$.

The oracle that marks the initial subspace can be constructed similarly.
In pseudocode:

1. Apply $H$ gates to every qubit.
2. Apply $X$ gates to every qubit.
3. Apply an $n-1$ controlled $Z$-gate to the $n^{\text{th}}$ qubit.
4. Apply $X$ gates to every qubit.
5. Apply $H$ gates to every qubit.

This time, we also demonstrate using <xref:microsoft.quantum.canon.with> together with the <xref:microsoft.quantum.canon.rall1> operation discussed above.:

```qsharp
operation ReflectAboutInitial(register : Qubit[]) : () {
    body {
        With(ApplyToEach(H, _), With(ApplyToEach(X, _), RAll1(_, PI()), _), register);
    }

    adjoint auto
    controlled auto
    controlled adjoint auto
}
```

We can then combine these two oracles together to rotate between the two states and deterministically transform $\ket{+}^{\otimes n}$ to $\ket{0}$ using a number of layers of Hadamard gates that is proportional to $\sqrt{2^n}$ (ie $m\propto \sqrt{2^n}$) versus the roughly $2^n$ layers that would be needed to non-deterministically prepare the $\ket{0}$ state by preparing and measuring the initial state until the outcome $0$ is observed.

### Phase Estimation Oracles ###

For phase estimation the oracles are somewhat more natural.
The aim in phase estimation is to design a subroutine that is capable of sampling from the eigenvalues of a unitary matrix.
This method is indispensible in quantum simulation because for many physical problems in chemistry and material science these eigenvalues give the ground-state energies of quantum systems which provides us valuable information about the phase diagrams of materials and reaction dynamics for molecules.
Every flavor of phase estimation needs an input unitary.
This unitary is customarily described by one of two types of oracles.

> [!TIP]
> Both of the oracle types described below are covered in the samples.
> To learn more about continuous query oracles, please see the [**PhaseEstimation** sample](TODO: link).
> To learn more about discrete query oracles, please see the [**IsingPhaseEstimation** sample](TODO: link).

The first type of oracle, which we call a discrete query oracle and represent with the user-defined type <xref:microsoft.quantum.canon.discreteoracle>, simply involves a unitary matrix.
If $U$ is the unitary whose eigenvalues we wish to estimate then the oracle for $U$ is simply a standin for a subroutine that implements $U$.
For example, one could take $U$ to be the oracle $Q$ defined above for amplitude estimation.
The eigenvalues of this matrix can be used to estimate the overlap between the initial and target states, $\sin^2(\theta)$, using quadratically fewer samples than one would need otherwise.
This earns the application of phase estimation using the Grover oracle $Q$ as input the moniker of amplitude estimation.
Another common application, widely used in quantum metrology, involves estimating a small rotation angle.
In other words, we wish to estimate $\theta$ for an unknown rotation gate of the form $R_z(\theta)$.
In such cases, the subroutine that we would interact with in order to learn this fixed value of $\theta$ for the gate is
$$
\begin{align}
    U & = R_z(\theta) \\\\
    & = \begin{bmatrix}
        e^{-i \theta / 2} & 0 \\\\
        0 & e^{i\theta/2}
    \end{bmatrix}.
\end{align}
$$

The second type of oracle used in phase estimation is the continuous query oracle, represented by the <xref:microsoft.quantum.canon.continuousoracle> type.
A continuous query oracle for phase estimation takes the form $U(t)$ where $t$ is a classically known real number.
If we let $U$ be a fixed unitary then the continuous query oracle takes the form $U(t) = U^t$.
This allows us to query matrices such as $\sqrt{U}$, which could not be implemented directly in the discrete query model.

This type of oracle is valuable when you're not probing a particular unitary, but rather wish to learn the properties of the generator of the unitary.
For example, in dynamical quantum simulation the goal is to devise quantum circuits that closely approximate $U(t)=e^{-i H t}$ for a Hermitian matrix $H$ and evolution time $t$.
The eigenvalues of $U(t)$ are directly related to the eigenvalues of $H$.
To see this, consider an eigenvector of $H$: $H \ket{E} = E\ket{E}$ then it is easy to see from the power-series definition of the matrix exponential that $U(t) \ket{E} =e^{i\phi}\ket{E}= e^{-iEt}\ket{E}$.
Thus estimating the eigenphase of $U(t)$ gives the eigenvalue $E$ assuming the eigenvector $\ket{E}$ is input into the phase estimation algorithm.
However, in this case the value $t$ can be chosen at the user's discretion since for any sufficiently small value of $t$ the eigenvalue $E$ can be uniquely inverted through $E=-\phi/t$.
Since quantum simulation methods provide the ability to perform a fractional evolution, this grants phase estimation algorithms an additional freedom when querying the unitary, specifically while the discrete query model allows only unitaries of the form $U^j$ to applied for integer $j$ the continuous query oracle allows us to approximate unitaries of the form $U^t$ for any real valued $t$.
This is important to squeeze every last ounce of efficiency out of phase estimation algorithms because it allows us to choose precisely the experiment that would provide the most information about $E$; whereas methods based on discrete queries must make do with compromising by choosing the best integer number of queries in the algorithm.

As a concrete example of this, consider the problem of estimating not the rotation angle of a gate but the procession frequency of a rotating quantum system.
The unitary that describes such quantum dynamics is $U(t)=R_z(2\omega t)$ for evolution time $t$ and unknown frequency $\omega$.
In this context, we can simulate $U(t)$ for any $t$ using a single $R_z$ gate and as such do not need to restrict ourselves to only discrete queries to the unitary.
Such a continuous model also has the property that frequencies greater than $2\pi$ can be learned from phase estimation processes that use continuous queries because phase information that would otherwise be masked by the branch-cuts of the logarithm function can be revealed from the results of experiments performed on non-commensurate values of $t$.
Thus for problems such as this continuous query models for the phase estimation oracle are not only appropriate but are also preferable to the discrete query model.
For this reason Q# has functionality for both forms of queries and leave it to the user to decide upon a phase estimation algorithm to fit their needs and the type of oracle that is available.

<!-- TODO: summarize the following.

    - ReflectionOracle
    - ContinousOracle (FIXME: rename to ContinuousPhaseOracle)
    - DiscreteOracle (same FIXME)
    - StateOracle
    - DeterministicStateOracle
    - ObliviousOracle (FIXME: need to expand on the API docs here)
    - ProbabilityOracle (TODO: add this type.)

-->

## Dynamical Generator Modeling ##

Generators of time-evolution describe how states evolve through time. For instance, the dynamics of a quantum state $\ket{\psi}$ is governed by the Schrödinger equation
$$
\begin{align}
    i\frac{d \ket{\psi(t)}}{d t} & = H \ket{\psi(t)},
\end{align}
$$
with a Hermitian matrix $H$, known as the Hamiltonian, as the generator of motion. Given an initial state $\ket{\psi(0)}$ at time $t=0$, the formal solution to this equation at time $t$ may be, in principle, written
$$
\begin{align}
    \ket{\psi(t)} = U(t)\ket{\psi(0)},
\end{align}
$$
where the matrix exponential $U(t)=e^{-i H t}$ is known as the unitary time-evolution operator. Though we focus on generators of this form in the following, we emphasize that the concept applies more broadly, such as to the simulation of open quantum systems, or to more abstract differential equations.

A primary goal of dynamical simulation is to implement the time-evolution operator on some quantum state encoded in qubits of a quantum computer.  In many cases, the Hamiltonian may be broken into into a sum of some $d$ simpler, or primitive, terms

$$
\begin{align}
    H & = \sum^{d-1}_{j=0} H_j,
\end{align}
$$

where time-evolution by each term alone is easy to implement on a quantum computer. For instance, if $H_j$ is a Pauli $X_1X_2$ operator acting on the 1st and 2nd elements of the qubit register `qubits`, time-evolution by it for any time $t$ may be implemented simply by calling the operation `Exp([PauliX;PauliX], t, qubits[1..2])`, which has signature `((Pauli[], Double, Qubit[]) => () : Adjoint, Controlled)`. As discussed later in Hamiltonian Simulation, one solution then is to approximate time-evolution by $H$ with a sequence of simpler operations

$$
\begin{align}
    U(t) & = \left( e^{-iH\_0 t / r} e^{-iH\_1 t / r} \cdots e^{-iH\_{d-1} t / r} \right)^{r} + \mathcal{O}(d^2 \max_j \\|H\_j\\|^2 t^2/r),
\end{align}
$$

where the integer $r>0$ controls the approximation error. 

The dynamical generator modeling library provides a framework for systematically encoding complicated generators in terms of simpler generators. Such a description may then be passed to, say, the simulation library to implement time-evolution by a simulation algorithm of choice, with many details automatically taken care of.

> [!TIP]
> The dynamical generator library described below is covered in the samples. 
> For an example based on the Ising model, please see the [**IsingGenerators** sample](TODO: link).
> For an example based on molecular Hydrogen, please see the [*H2Simulation** sample](TODO: link).

### Complete Description of a Generator ###

At the top level, a complete description of a Hamiltonian is contained in the `EvolutionGenerator` user-defined type which has has two components.:

```qsharp
newtype EvolutionGenerator = (EvolutionSet, GeneratorSystem);
```

The `GeneratorSystem` user-defined type is a classical description of the Hamiltonian.

```qsharp
newtype GeneratorSystem = (Int, (Int -> GeneratorIndex));
```

The first element `Int` of the tuple stores the number of terms $d$ in the Hamiltonian, and the second element `(Int -> GeneratorIndex)` is a function that maps an integer index in $\{0,1,...,d-1\}$ to a `GeneratorIndex` user-defined type which uniquely identifies each primitive term in the Hamiltonian. Note that by expressing the collection of terms in the Hamiltonian as a function rather than as an array `GeneratorIndex[]`, this allows for on-the-fly computation of the `GeneratorIndex` which is especially useful when describing Hamiltonians with a large number of terms.

Crucially, we do not impose a convention on what primitive terms identified by the `GeneratorIndex` are easy-to-simulate. For instance, primitive terms could be Pauli operators as discussed above, but they could also be Fermionic annihilation and creation operators commonly used in quantum chemistry simulation. By itself, a `GeneratorIndex` is meaningless as it does not describe how time-evolution by the term it points to may be implemented as a quantum circuit. 

This is resolved by specifying an `EvolutionSet` user-defined type that maps any `GeneratorIndex`, drawn from some canonical set, to a unitary operator, the `EvolutionUnitary`, expressed as a quantum circuit. The `EvolutionSet` defines the convention of how a `GeneratorIndex` is structured, and also defines the set of possible `GeneratorIndex`.

```qsharp
newtype EvolutionSet = (GeneratorIndex -> EvolutionUnitary);
```

### Pauli Operator Generators ###

A concrete and useful example of generators are Hamiltonians that are a sum of Pauli operators, each possibly with a different coefficient.
$$
\begin{align}
    H & = \sum^{d-1}_{j=0} a_j H_j,
\end{align}
$$
where each $\hat H_j$ is now drawn from the Pauli group. For such systems, we provide the `PauliEvolutionSet()` of type `EvolutionSet` that defines a convention for how an element of the Pauli group and a coefficient may be identified by a `GeneratorIndex`, which has the following signature.

```qsharp
newtype GeneratorIndex = ((Int[], Double[]), Int[]);
```

In our encoding, the first parameter `Int[]` specifies a Pauli string, where $\hat I\rightarrow 0$, $\hat X\rightarrow 1$, $\hat Y\rightarrow 2$, and $\hat Z\rightarrow 3$. The second parameter `Double[]` stores the coefficient of the Pauli string in the Hamiltonian. Note that only the first element of this array is used. The third parameter `Int[]` indexes the qubits that this Pauli string acts on, and must have no duplicate elements. Thus the Hamiltonian term $0.4 \hat X_0 \hat Y_8\hat I_2\hat Z_1$ may be represented as

```qsharp
let generatorIndexExample = GeneratorIndex(([1;2;0;3], [0.4]]), [0;8;2;1]);
```

The `PauliEvolutionSet()` is a function that maps any `GeneratorIndex` of this form to an `EvolutionUnitary` with the following signature.

```qsharp
newtype EvolutionUnitary = ((Double, Qubit[]) => () : Adjoint, Controlled);
```

The first parameter represents a time-duration, that will be multiplied by the coefficient in the `GeneratorIndex`, of unitary evolution. The second parameter is the qubit register the unitary acts on. For example: 

```qsharp
let stepSize = 0.6;
PauliEvolutionSet()(generatorIndexExample)(stepSize, qubits);

// This is the same as

Exp([1;2;0;3], 0.4 * stepSize, [qubits[0];qubits[8];qubits[2];qubits[1]]);
```

### Time-Dependent Generators ###

In many cases, we are also interested in modelling time-dependent generators, as might occur in the Schrödinger equation 
$$
\begin{align}
    i\frac{d \ket{\psi(t)}}{d t} & = \hat H(t) \ket{\psi(t)},
\end{align}
$$
where the generator $\hat H(t)$ is now time-dependent. The extension from the time-independent generators above to this case is straightforward. Rather than having a fixed `GeneratorSystem` describing the Hamiltonian for all times $t$, we instead have the `GeneratorSystemTimeDependent` user-defined type.

```qsharp
newtype GeneratorSystemTimeDependent = (Double -> GeneratorSystem);
```

The first parameter is a continuous schedule parameter $s\in [0,1]$, and functions of this type return a `GeneratorSystem` for that schedule. Note that the schedule parameter may be linearly related to the physical time parameter e.g. $s = t / T$, for some total time of simulation $T$. In general however, this need not be the case.

Similarly, a complete description of this generator requires an `EvolutionSet`, and so we define an `EvolutionSchedule` user-defined type.

```qsharp
newtype EvolutionSchedule = (EvolutionSet, GeneratorSystemTimeDependent);
```

