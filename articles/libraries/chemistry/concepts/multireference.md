---
title: Multireference wavefunctions | Microsoft Docs
description: Quantum Dynamics Conceptual Docs
author: guanghaolow
ms.author: gulow@microsoft.com
ms.date: 05/28/2019
ms.topic: article-type-from-white-list
uid: microsoft.quantum.chemistry.concepts.multireference
---

# Multi-reference wavefunctions

The quantum states of many electronic structure problems of interest are strongly correlated. In these situations, the single-reference [Hartree–Fock](xref:microsoft.quantum.chemistry.concepts.hartreefock) state, composed of a single Slater determiniant, is inadequate. Then, multi-reference approaches, which represent superpositions of Slater determinants, are required to approximate eigenstates of the electronic structure Hamiltonian to the desired accuracy. The chemistry library provides two ways to specify multi-reference state for such problems, and also constructs the quantum circuits that generate these states on a quantum computer. 

The first approach, which we call sparse multi-reference wavefunctions, is effective when only a few components suffice to specify the superposition. The second component, known as unitary coupled-cluster methods, specify the state implicity through a unitary operator acting on a reference state. These states may be specified in the [Broombridge schema](xref:microsoft.quantum.libraries.chemistry.schema.broombridge), and we also provide the functionality to manually specify these states through the chemistry library.

## Sparse multi-reference wavefunction
On one hand, multi-reference state $|\psi_{\rm {MCSCF}}\rangle$ may be specified explicitly as a linear combination of $N$-electron Slater determininants.
\begin{align}
|\psi_{\rm {MCSCF}}\rangle \propto \sum_{i_1 < i_2 < \cdots < i_N} \lambda_{i_1,i_2} a^\dagger_{i_1}a^\dagger_{i_2}\cdots a^\dagger_{i_N}|0\rangle.
\end{align}
For example, the state $\propto(0.1 a^\dagger_1a^\dagger_2a^\dagger_6 - 0.2 a^\dagger_2a^\dagger_1a^\dagger_5)|0\rangle$ may be specified in the chemistry library as follows.
```csharp
// Create a list of tuples where the first item of each 
// tuple are indices to the creation operators acting on the
// vacuum state, and the second item is the coefficient
// of that basis state.
var superposition = new[] {
    (new[] {1, 2, 6}, 0.1),
    (new[] {2, 1, 5}, -0.2) };

// Create a fermion wavefunction object that represents the superposition.
var wavefunction = new FermionWavefunction<int>(superposition);
```
This explicit representation of the superposition components is effective when only a few components need to be specified. One should avoid using this representation when many components are required to accurately capture the desired state. The reason for this is the gate cost of quantum circuit that prepares this state on a quantum computer, which scales at least linearly with the number of superposition components, and at most quadratically with the one-norm of the superposition amplitudes.

## Unitary coupled-cluster wavefunction
It is also possible to efficiently specify a multi-reference state that has exponentially many components. One common example is the unitary coupled-cluster wavefunction $|\psi_{\rm {UCC}}\rangle$. In this situation, we have a single-reference state, say, $|\psi_{\rm{SCF}}\rangle$. The components of the unitary coupled-cluster wavefunction is then specified implicity through a unitary operator acting on a reference state. This unitary operator is commonly written as $e^{T-T^\dagger}$, where $T-T^\dagger$ is the anti-Hermitian cluster operator. Thus
\begin{align}
|\psi_{\rm {UCC}}\rangle = e^{T-T^\dagger}|\psi_{\rm{SCF}}\rangle.
\end{align}

It is also common to split the cluster operator $T = T_1 + T_2 + \cdots$ into parts, where each part $T_j$ contains on $j$-body terms. For instance, one-body cluster operators (singles) are of the form
\begin{align}
T_1 = \sum_{pq}t^{q}_{p} a^\dagger_p a_q,
\end{align}

and two-body cluster operators (doubles) are of the form
\begin{align}
T_2 = \sum_{pqrs}t^{rs}_{pq} a^\dagger_p a^\dagger_q a_r a_s.
\end{align}

Higher-order terms (triples, quadruples, etc.) are possible, but not currently supported by the chemistry library. It is common, though not always the case, that the annihilation operators share indices with occupied spin-orbitals of the reference state, and the creation operators share indices with unoccupied spin-orbitals. 

For example, let $|\psi_{\rm{SCF}}\rangle = a^\dagger_1 a^\dagger_2|0\rangle$, and let $T= 0.123 a^\dagger_0 a_1 + 0.456 a^\dagger_0a^\dagger_3 a_1 a_2 - 0.789 a^\dagger_3a^\dagger_2 a_1 a_0 + \text{Hermitian conjugate}$. Then this state is instantiated in the chemistry library as follows.
```csharp
// Create a list of indices of the creation operators
// for the single-reference state
var reference = new[] { 1, 2 };

// Create a list describing the cluster operator
// The first half of each list of integers will be
// associated with the creation operators, and
// the second half with the annihilation operators.
var clusterOperator = new[]
{
    (new [] {0, 1}, 0.123),
    (new [] {0, 3, 1, 2}, 0.456),
    (new [] {3, 2, 1, 0}, 0.789)
};

// Create a fermion wavefunction object that represents the 
// unitary coupled-cluster wavefunction. It is assumed implicity
// that the exponent of the unitary coupled-cluster operator
// is the cluster operator minus its Hermitian conjugate.
var wavefunction = new FermionWavefunction<int>(reference, clusterOperator);
```

Spin convervation may be made explicit by instead specifying `SpinOrbital` indices instead of integer indices. For example, let $|\psi_{\rm{SCF}}\rangle = a^\dagger_{1,\uparrow} a^\dagger_{2, \downarrow}|0\rangle$, and let $T= 0.123 a^\dagger_{0, \uparrow} a_{1, \uparrow} + 0.456 a^\dagger_{0, \uparrow} a^\dagger_{3, \downarrow} a_{1, \uparrow} a_{2, \downarrow} - 0.789 a^\dagger_{3,\uparrow} a^\dagger_{2,\uparrow} a_{1,\uparrow} a_{0, \uparrow} + \text{Hermitian conjugate}$ be spin convserving. Then this state is instantiated in the chemistry library as follows.
```csharp
// Create a list of indices of the creation operators
// for the single-reference state
var reference = new[] { (1, Spin.u), (2, Spin.d) }.ToSpinOrbitals();

// Create a list describing the cluster operator
// The first half of each list of integers will be
// associated with the creation operators, and
// the second half with the annihilation operators.
var clusterOperator = new[]
{
    (new [] {(0, Spin.u), (1, Spin.u)}, 0.123),
    (new [] {(0, Spin.u), (3, Spin.d), (1, Spin.u), (2, Spin.d)}, 0.456),
    (new [] {(3, Spin.u), (2, Spin.u), (1, Spin.u), (0, Spin.u)}, 0.789)
}.Select(o => (o.Item1.ToSpinOrbitals(), o.Item2);

// Create a fermion wavefunction object that represents the 
// unitary coupled-cluster wavefunction. It is assumed implicity
// that the exponent of the unitary coupled-cluster operator
// is the cluster operator minus its Hermitian conjugate.
var wavefunctionSpinOrbital = new FermionWavefunction<SpinOrbital>(reference, clusterOperator);

// Convert the wavefunction indexed by spin-orbitals to one indexed
// by integers
var wavefunctionInteger = wavefunctionSpinOrbital.ToIndexing(IndexConvention.UpDown);
```

We also provide a convenience function that enumerates over all spin-conversing cluster operators that annihilate only occupied spin-orbitals and excite to only unoccupied spin-orbitals.
```csharp
// Create a list of indices of the creation operators
// for the single-reference state
var reference = new[] { (1, Spin.u), (2, Spin.d) }.ToSpinOrbitals();

// Generate all spin-conversing excitations from spin-orbitals 
// occupied by the reference state to virtual orbitals.
var generatedExcitations = reference.CreateAllUCCSDSingletExcitations(nOrbitals: 3).Excitations;

// This is the list of expected spin-consvering excitations
var expectedExcitations = new[]
{
    new []{ (0, Spin.u), (1,Spin.u)},
    new []{ (2, Spin.u), (1,Spin.u)},
    new []{ (0, Spin.d), (2,Spin.d)},
    new []{ (1, Spin.d), (2,Spin.d)},
    new []{ (0, Spin.u), (0, Spin.d), (2, Spin.d), (1,Spin.u)},
    new []{ (0, Spin.u), (1, Spin.d), (2, Spin.d), (1,Spin.u)},
    new []{ (0, Spin.d), (2, Spin.u), (2, Spin.d), (1,Spin.u)},
    new []{ (1, Spin.d), (2, Spin.u), (2, Spin.d), (1,Spin.u)}
}.Select(o => new IndexOrderedSequence<SpinOrbital>(o.ToLadderSequence()));

// The following two assertions are true, and verify that the generated 
// excitations exactly match the expected excitations.
var bool0 = generatedExcitations.Keys.All(expectedExcitations.Contains);
var bool1 = generatedExcitations.Count() == expectedExcitations.Count();
```