---
title: Hartree-Fock Theory | Microsoft Docs
description: Hartree-Fock Theory Docs
author: nathanwiebe2
ms.author: nawiebe@microsoft.com
ms.date: 10/09/2017
ms.topic: article-type-from-white-list
uid: microsoft.quantum.chemistry.concepts.hartreefock
---


## Hartree–Fock Theory

Perhaps the most important quantity in quantum chemistry simulation is the ground state, which is the minimum energy eigenvector of the Hamiltonian matrix.
This is because for most molecules at room temperature quantities such as reaction rates are dominated by free energy differences between quantum states that describe the beginning and end of a step in a reaction pathway and at room temperature such intermediate state are usually ground states.
While the ground state is typically too hard to learn (even with a quantum computer) because it is a distribution over an exponentially large number of configurations.
Quantities such as ground state energy can be learned.
For example, if $\ket{\psi}$ is any pure quantum state then 
\begin{equation}
E = \bra{ \psi } \hat{H} \ket{\psi}
\end{equation}
gives the mean energy that the system has in that state.
The ground state then is the state that gives the smallest such value. As a result, choosing a state that is as close as possible to the true ground state is vitally important for estimating the energy either directly (as is done in variational eigensolvers) or through phase estimation.

Hartree–Fock theory gives a simple way to construct the initial state for quantum systems. It yields a single Slater-determinant approximation to the ground state of a quantum system. To that end, it finds a rotation within Fock-space that minimizes the ground state energy. In particular, for a system of $N$ electrons the method performs the rotation
\begin{equation}
\prod_{j=0}^{N-1} a^\dagger_j \ket{0} \mapsto \prod_{j=0}^{N-1} e^{u} a^\dagger_j e^{-u} \ket{0}\defeq\prod_{j=0}^{N-1}  \widetilde{a}^\dagger_j  \ket{0},
\end{equation}
with an anti-Hermitian (i.e. $u= -u^\dagger$) matrix $u = \sum_{pq} u_{pq} a^\dagger_p a_q$. It should be noted that the matrix $u$ represents the orbital rotations and $\widetilde{a}^\dagger_j$ and $\widetilde{a}_j$ represent creation and annihilation operators for electrons occupying Hartree–Fock molecular spin-orbitals.


The matrix $u$ is then optimized to minimize the expected energy $\bra{0} \prod_{j=0}^{N-1}  \widetilde{a}\_j  H \prod\_{k=0}^{N-1}  \widetilde{a}^\dagger_k\ket{0}$. 
While such optimization problems may be generically hard, in practice the Hartree–Fock algorithm tends to rapidly converge to a near-optimal solution to the optimization problem, especially for closed-shell molecules in the equilibrium geometries. 

The most striking feature about Hartree–Fock theory is that it yields a quantum state that has no entanglement between the electrons.
This means that, while it is often quite successful, it may not always be well suited to approximate ground states for
strongly correlated systems that are targets for quantum computation.
However, the simplicity and accuracy of Hartree-Fock theory for many small systems makes 
it the workhorse of state preparation in quantum computing and a spring board on top of which most post-Hartree–Fock methods are based.

For this reason, the [Broombridge schema](xref:microsoft.quantum.libraries.chemistry.schema.spec) used to input quantum chemistry Hamiltonians into the chemistry library incorporates a field that gives Hartree–Fock data if available.
This is useful not only as a diagnostic, but also because it allows the correlation energy to be reported, which is the difference between the Hartree–Fock energy and the true ground state energy as yielded by full-configuration interaction simulations or quantum computation.
