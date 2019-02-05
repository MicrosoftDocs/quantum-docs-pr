---
title: Symmetries of Molecular Integrals | Microsoft Docs
description: Symmetries of Molecular Integrals Conceptual Docs
keywords: Don’t add or edit keywords without consulting your SEO champ.
author: nathanwiebe2
ms.author: nawiebe
ms.date: 10/09/2017
ms.topic: article-type-from-white-list
uid: microsoft.quantum.chemistry.concepts.symmetries
---

## Symmetries of Molecular Integrals

The inherent symmetry of the Coulomb Hamiltonian, which is the Hamiltonian given in [Quantum Models for Electronic Systems](xref:microsoft.quantum.chemistry.concepts.quantummodels), that describes electrons interacting electrically with each other and with the nuclei, leads to a number of symmetries that can be exploited to compress the terms in the Hamiltonian.
In general if no further assumptions are made about the basis functions $\psi_j$ then we only have that
\begin{equation}
h_{pqrs}= h_{qpsr},\tag{★}\label{eq:hpqrs}
\end{equation}
which can be immediately seen from the integrals in [Quantum Models for Electronic Systems](xref:microsoft.quantum.chemistry.concepts.quantummodels) upon noting that their values remain identical if $p,q$ and $r,s$ are interchanged from anti-commutation.

If we assume that the spin-orbitals are real-valued (as they are for Gaussian orbital bases) then we further have that 
\begin{equation}
h_{pqrs} = h_{qpsr} = h_{srqp} = h_{rspq}=h_{rqps}=h_{psrq}=h_{spqr}=h_{qrsp}.\tag{★}\label{eq:hpqrsreal}
\end{equation}
Given such assumptions hold, we can use the above symmetries to reduce the data needed to store the matrix elements of the Hamiltonian by a factor of $8$; although doing so makes importing data in a consistent way slightly more challenging.  Fortunately the Hamiltonian simulation library has subroutines that can be used to import integral files from either [LIQUI$|\rangle$](https://www.microsoft.com/en-us/research/project/language-integrated-quantum-operations-liqui/) or directly from [NWChem](http://www.nwchem-sw.org/index.php/Main_Page).

Molecular orbital integrals (i.e. the $h\_{pq}$ and $h\_{pqrs}$ terms) such as these are represented using the `OrbitalIntegral` type, which provides a number of helpful functions to express this symmetry.
```csharp
    // We create a `OrbitalIntegral` object to store a one-electron molecular 
    // orbital integral data.
    var oneElectronOrbitalIndices = new[] { 0, 1 };
    var oneElectronCoefficient = 1.0;
    var oneElectronIntegral = new OrbitalIntegral(oneElectronOrbitalIndices, oneElectronCoefficient);

    // This enumerates all one-electron integrals with the same coefficient --
    // an array of equivalent `OrbitalIntegral` instances is generated. In this
    //  case, there are two elements.
    var oneElectronIntegrals = oneElectronIntegral.EnumerateOrbitalSymmetries();

    // We create a `OrbitalIntegral` object to store a two-electron molecular orbital integral data.
    var twoElectronOrbitalIndices = new[] { 0, 1, 2, 3 };
    var twoElectronCoefficient = 0.123;
    var twoElectronIntegral = new OrbitalIntegral(twoElectronOrbitalIndices, twoElectronCoefficient);

    // This enumerates all two-electron integrals with the same coefficient -- 
    // an array of equivalent `OrbitalIntegral` instances is generated. In 
    // this case, there are 8 elements.
    var twoElectronIntegrals = twoElectronIntegral.EnumerateOrbitalSymmetries();
```

In addition to enumerating over all orbital integrals that are numerically identical, we may generate a list of all spin-orbital indices contained in the Hamiltonian represented by an `OrbitalIntegral` as follows.
```csharp
    // We create a `OrbitalIntegral` object to store a two-electron molecular
    //  orbital integral data.
    var twoElectronIntegral = new OrbitalIntegral(new[] { 0, 1, 2, 3 }, 0.123);

    // This enumerates all spin-orbital indices of the `FermionTerm`s in the 
    // Hamiltonian represented by this integral -- this is an array of array 
    // of `SpinOrbital` instances.
    var twoElectronSpinOrbitalIndices = twoElectronIntegral.EnumerateSpinOrbitals();
```
## Constructing Fermionic Hamiltonians from Molecular Integrals

Rather than constructing a Fermionic Hamiltonian by adding `FermionTerm`s, we may directly add all terms corresponding to each orbital integral automatically. For example, the following code automatically enumerates over all permutational symmetries and orders the terms in canonical order: 
```csharp
    // We create a `FermionHamiltonian` object to store the `FermionTerm`
    // instances.
    var hamiltonian = new FermionHamiltonian();

    // We create a `OrbitalIntegral` object to store a two-electron molecular 
    // orbital integral data.
    var orbitalIntegral = new OrbitalIntegral(new[] { 0, 1, 2, 3 }, 0.123);

    // We now add all `FermionTerm`s corresponding to the orbital integral. 
    // This automatically enumerates over all symmetries, and orders 
    // the `FermionTerm` instances in canonical order.
    hamiltonian.AddFermionTerm(orbitalIntegral);
```
