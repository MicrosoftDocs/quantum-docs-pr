---
title: Quantum Models for Electronic Systems
description: Learn how molecular electronic systems are simulated using quantum modeling. 
author: bradben
ms.author: v-benbra
ms.date: 10/09/2017
ms.topic: article-type-from-white-list
uid: microsoft.quantum.chemistry.concepts.quantummodels
no-loc: ['Q#', '$$v']
---

# Quantum Models for Electronic Systems

In order to simulate electronic systems we need to first begin by specifying the Hamiltonian, which can be found by the canonical quantization procedure described above.
Specifically, for $N_e$ electrons with momenta $p_i$ (in three dimensions) and mass $m_e$  and position vectors $x_i$ along with nuclei with charges $Z_k e$ at positions $y_k$, the Hamiltonian operator reads
\begin{equation}
\hat{H}= \sum\_{i=1}^{N\_e} \frac{\hat{p}\_i^2}{2m\_e} + \frac{1}{2}\sum\_{i\ne j} \frac{e^2}{|\hat{x}\_i - \hat{x}\_j|} -\sum\_{i,k} \frac{Z\_ke^2}{|\hat{x}\_i - {y}\_k|}+\frac{1}{2} \sum_{k\ne k'} \frac{Z\_kZ\_{k'}e^2}{|y\_k - y\_k'|}. \label{eq:Ham}
\end{equation}
The momenta operators $\hat{p}\_i^2$ can be viewed in real space as Laplacian operators, i.e. $\hat{p}\_i^2 = -\partial\_{x\_i}^2 - \partial\_{y\_i}^2 - \partial\_{z\_i}^2$.
Here we have made the simplifying assumption that the nuclei are at rest for the molecule.
This is known as the Born-Oppenheimer approximation and it tends to be valid for the low-energy energy spectrum of $\hat{H}$ since the electron mass is about $1/1836$ the mass of a proton.
This Hamiltonian operator can be easily found by writing out the energy for a system of $N\_e$ electrons and applying the canonical quantization process described in [Quantum Dynamics](xref:microsoft.quantum.chemistry.concepts.quantumdynamics).

In order to construct the unitary matrix representation for $e^{-i\hat{H} t}$ we need to represent the operator $\hat{H}$ as a matrix.
For this, we need to choose a coordinate system or basis to represent the problem in.
For example, if $\psi_j$ are a set of orthogonal basis functions for the $N_e$ electrons then we can define the matrix

\begin{equation}
H\_{i,j} = \int\_{-\infty}^\infty\int\_{-\infty}^\infty \psi^{\*}\_i(x\_1) \hat{H} \psi\_j(x\_2) \dd^3x\_1 \dd^3x\_2.\label{eq:discreteHam}
\end{equation}

While in principle the operator $\hat{H}$ is unbounded and does not act on a finite dimensional space, the matrix with elements $H\_\{i,j\}$ above does.
This means that errors are incurred by picking too small of a basis set; however, picking a large basis can make simulating the chemical dynamics impractical.
For this reason, choosing a basis that can concisely represent the problem is vital for solving the electronic structure problem.

There are many appropriate bases that can be used and the choice of a good basis to fit the problem is much of the art of quantum chemistry.
Perhaps the simplest such basis sets are Slater-Type-Orbitals (STO) which are (orthogonalized) solutions to the Schrödinger equation (i.e. eigenfunctions of $\hat{H}$) for hydrogen-like atoms.
Other basis sets, such as plane-waves or real-space orbitals, can be used and for more detail we refer the curious reader to the standard text ['Molecular Electronic-Structure Theory'](https://onlinelibrary.wiley.com/doi/book/10.1002/9781119019572) by Helgaker.

While the states used in the above model may seem arbitrary, quantum mechanics places restrictions on the states that can be found in nature.
In particular, all valid electronic quantum states must be anti-symmetric under exchange of electron labels.
That is to say if $\psi(x_1,x_2)$ were the wave function for the joint quantum state of two electrons then we must have that
$$
\psi(x_1,x_2)= - \psi(x_2,x_1).
$$
The Pauli exclusion principle which forbids two electrons to ever be in the same quantum state is, fascinatingly, a direct consequence of this law as can be intuited from the fact that if we swap two electrons located at the same position $\psi(x_1,x_1)\mapsto \psi(x_1,x_1) \ne -\psi(x_1,x_1)$ unless $\psi(x_1,x_1)=0$.
Thus the initial states must be chosen to obey this anti-symmetry property and in turn never have two electrons in the same state at the same time.
This is crucial for electronic structure because it forbids multiple electrons from being in the same state, and in turn allows quantum computers to use a single quantum bit to store the number of electrons in a given quantum state.

While quantum mechanics can be simulated on a quantum computer by discretizing these states, most work in the field has eschewed this approach because it requires many qubits to store the states and needs a complicated state preparation procedure to prepare an anti-symmetric initial state.
Fortunately though, these problems can be sidestepped by viewing the simulation problem from a different perspective.
