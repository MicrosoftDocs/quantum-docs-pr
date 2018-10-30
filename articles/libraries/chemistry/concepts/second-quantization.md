---
title: Second Quantization | Microsoft Docs
description: Second Quantization Conceptual Docs
author: Nathan Wiebe
ms.author: nawiebe@microsoft.com
ms.date: 10/09/2017
ms.topic: article-type-from-white-list
uid: microsoft.quantum.chemistry.concepts.secondquantization
---

# Second Quantization

Second quantization looks at the problem of electronic structure through a different lens.
Rather than assigning each of the $N_e$ electrons to a specific state (or orbital), second quantization tracks each orbital and stores whether there is an electron present in each of them and at the same time automatically ensures symmetry properties of the corresponding wave function.  This is important because it allows quantum chemistry models to be specified without having to worry about anti-symmetrizing the input state (as is required for fermions) and also because second quantization allows such models to be simulated using small quantum computers.

As an example of second quantization in action, let's assume that $\psi_0\cdots \psi_{N-1}$ are an orthonormal set of spatial orbitals. These orbitals are chosen to represent the system as accurately as possible within the finite basis set considered. A common example of such orbitals are atomic orbitals which form an eigenbasis for the hydrogen atom. Because electrons have two spin states, two electrons can be crammed into each such spatial orbital.  That is to say, the valid basis states are of the form $\psi_{0,\uparrow},\ldots,\psi_{N-1,\uparrow}, \psi_{0,\downarrow},\ldots,\psi_{N-1,\downarrow}$ where $\uparrow$ and $\downarrow$ are labels that specify the two eigenstates of the spin degree of freedom. This combined index of $(j,\sigma)$ for $\sigma \in \{\uparrow,\downarrow\}$ is called a spin-orbital because it stores both the spatial as well as the spin degree of freedom. In the chemistry library, spin-orbitals are stored in a `SpinOrbital` data structure, and are created as follows.

```csharp
    // First, we assign an orbital index, say `5`. Note that we use 0-indexing,
    // so this is the 6th orbital.
    var orbitalIdx = 5;

    // Second, we assign a spin index, say `Spin.u` for spin up or `Spin.d` for spin down.
    var spin = Spin.d;

    // the spin-orbital (5, ↓) is then
    var spinOrbital = new SpinOrbital(orbitalIdx, spin);
```

This means that we can formally think of the basis for both the spin and spatial part of the wave function as $\psi_{0} \cdots \psi_{2N-1}$ where each of the indices now is an enumeration of a $(j,\sigma)$.  One possible enumeration is $g(j,\sigma) = j+N\sigma'$.  The quantum chemistry library uses such a convention, and the spin-orbitals in such an encoding can be instantiated as follows.

```csharp
    // Let us use the spin orbital created in the previous snippet.
   var spinOrbital = new SpinOrbital(5, Spin.d);

   // Let us set the total number of orbitals to be say, `7`.
   var nOrbitals = 7;

   // This converts a spin-orbital index to a unique integer, in this case `12`.
   var integerIndex = spinOrbital.ToInt(nOrbitals);
```

For Fermionic systems, the Pauli exclusion principle prevents more than one electron from being present in any spin-orbital at the same time.  This means that we can write the two legal states for $\psi_1$ as
\begin{equation}
\psi_1 \rightarrow \begin{cases} |0\rangle_1 & \text{if $\psi_1$ is not occupied,} \\\
|1\rangle_1 & \text{if $\psi_1$ is occupied.} \end{cases}
\end{equation}
This encoding is great for quantum computers because it means that we can store the electronic occupation as a single quantum bit.

The occupation states for the $2N$ spin orbitals can similarly be stored in $2N$ qubits.  As an example, if $N=2$ then the state
$$
|0\rangle |1\rangle |1\rangle |0\rangle,
$$
would correspond to spin orbitals $1$ and $2$ being occupied with the remainder empty.  Similarly, the state
$$
|0\rangle \equiv |0\rangle_{0} \cdots |0\rangle_{N-1},
$$
has no electrons and is known as the 'vacuum state'.

A beautiful side-effect of second quantization is that we no longer have to explicitly keep track of the anti-symmetry of the quantum state.  This is because, as we will see, the anti-symmetry of the state represents itself instead through the anti-commutation rules of the operators that create and destroy electronic occupations of a spin orbital.

## Fermionic operators

The two fundamental operators that act on the second-quantized basis vectors are known as creation and annihilation operators.  These operators insert or destroy electrons at a particular location.  These are denoted $a^\dagger_j$ and $a_j$ respectively.

For example,
\begin{align}
a^\dagger_1 |0\rangle_1 &= |1\rangle_1\nonumber\\\
a^\dagger_1 |1\rangle_1 &= 0\nonumber\\\
a_1 |0\rangle_1 &= 0\nonumber\\\
a_1 |1\rangle_1 &= |0\rangle_1
\end{align}
Note that here $a^\dagger_1 |1\rangle_1=0$ and $a_1 |0\rangle_1$ yield the zero-vector not $|0\rangle_1$.  Such operators are therefore neither Hermitian nor unitary. We represent Fermionic creation and annihilation operators using the `FermionTerm` type. For instance, a single creation operator is represented as follow.

```csharp
    // Let us use the spin orbital created in the previous snippet.
    var spinOrbital = new SpinOrbital(5, Spin.d);

    // We create an array containing this spin-orbital to allow generalization
    // to cases where multiple operators are present.
    var spinOrbitalArray = new[] {spinOrbital};

    // A creation operator is represented by the integer `1L`, whereas
    // an annihilation operator is represented by the integer `0L`.
    var conjugateArray = new[] { 1L };

    // The single creation operator has a coefficient of 1.0
    var coefficient = 1.0;

    // We now construct a `FermionTerm` representing a creation operator
    // on the spin-orbital (5,↓).
    var fermionTerm = new FermionTerm(conjugateArray, spinOrbitalArray, coefficient);
```

Also using such operators we can express
$$
|0\rangle |1\rangle |1\rangle |0\rangle = a^\dagger_1 a^\dagger_2 |0\rangle^{\otimes 4}.
$$
This sequence of operators would be constructed within the hamiltonian simulation library using C# code that is similar to the single-spin orbital case considered above above:
```csharp
    // Let us use a new method to compactly create a sequence of spin-orbitals
    var spinOrbitalArray = new[] { (1, Spin.u), (2, Spin.u) }.ToSpinOrbitals();

    // A creation operator is represented by the integer `1L`, whereas
    // an annihilation operator is represented by the integer `0L`.
    var conjugateArray = new[] { 1L ,1L };

    // The product of creation operators has a coefficient of 1.0
    var coefficient = 1.0;

    // We now construct a `FermionTerm` representing a creation 
    // on the spin-orbital (2,↑) followed by (1,↑).
    var fermionTerm = new FermionTerm(conjugateArray, spinOrbitalArray, coefficient);
```

For a system of $k$ Fermions, in second quantization the action of the creation operator $a^\dagger_i$ is given by 
$$
a^\dagger_i |n_1, n_2, \ldots, 0_i, \ldots, n_k \rangle = (-1)^{S_i} |n_1, n_2, \ldots, 1_i, \ldots, n_k\rangle, 
$$
and 
$$
a^\dagger_i |n_1, n_2, \ldots, 1_i, \ldots, n_k \rangle = 0,
$$
where $S_i = \sum_{j<i} a^\dagger_j a_j$ measures the total number of Fermions that are in the state of a single particle and that have an index $j < i$.

A third operator is also often used in second quantized representations.  This operator is known as the number operator and is defined by
\begin{equation}
n_i = a^\dagger_i a_i.
\end{equation}
This operator counts the occupation of a given spin orbital, which is to say
\begin{align}
n_i |0\rangle_i &= 0\nonumber\\\
n_i |1\rangle_i &= |1\rangle_i.
\end{align}
Similar to the above `FermionTerm` examples, this number operator is constructed as follows.
```csharp
    // Let us use a new method to compactly create a sequence of spin-orbitals
    var spinOrbitalArray = new[] { (1, Spin.u), (1, Spin.u) }.ToSpinOrbitals();

    // The term has a coefficient of 1.0
    var coefficient = 1.0;

    // We now construct a `FermionTerm` representing an annihilation operator
    // on the spin-orbital (1,↑) followed by the creation operator (1,↑).
    var fermionTerm = new FermionTerm(spinOrbitalArray, coefficient);

    // Note that we have ommited the `conjugate` array specifying the sequence
    // of creation and annihilation operators in the FermionTerm constructor.
    // When unspecified, the number of creation and annihilation operators are
    // assumed to be equal. It is also assumed that these operators are in normal order,
    // meaning that all creation operators are applied after all annihilation operators.
```

A subtlety emerges though when using creation or annihilation operators in Fermionic systems.  We require that any valid quantum state is anti-symmetric under exchange of labels.  This means that
$$
a^\dagger_2 a^\dagger_1 |0\rangle = -a^\dagger_1 a^\dagger_2 |0\rangle.
$$
Such operators are said to 'anti-commute' and in general for any $i, j$ we have that
\begin{align}
a^\dagger_i a^\dagger_j  &= -(1-\delta_{i,j})a^\dagger_j a^\dagger_i\nonumber\\\
a^\dagger_i a_j &=\delta_{i,j} - a_j a^\dagger_i.
\end{align}
Thus the following two `FermionTerm` instances are considered inequivalent
```csharp
    // Let us use a new method to compactly create a sequence of spin-orbitals
    var spinOrbitalArray = new[] { (2, Spin.u), (1, Spin.u) }.ToSpinOrbitals();

    // A creation operator is represented by the integer `1L`, whereas
    // an annihilation operator is represented by the integer `0L`.
    var conjugateArray = new[] { 1L ,1L };

    // The single creation operator has a coefficient of 1.0
    var coefficient = 1.0;

    // We now construct a `FermionTerm` representing a creation operator
    // on the spin-orbital (1,↑) followed by (2,↑) and a term with the reverse ordering.
    var fermionTerm = new FermionTerm(conjugateArray, spinOrbitalArray, coefficient);
    var fermionTermReversed = new FermionTerm(conjugateArray, spinOrbitalArray.Reverse(), coefficient);

    // The following Boolean is `false`.
    var equal = fermionTerm == fermionTermReversed;
```

The requirement that each of the creation operators anti-commute means that using a second quantized representation does obviate the challenges faced by the anti-symmetry of Fermions.  Instead the challenge re-emerges in our definition of the creation operators. 

Using the anti-commutation rules, some `FermionTerm` instances actually correspond to the same sequence of Fermionic operators, sometimes up to a minus sign. For instance, consider the Hamiltonian $a_0^\dagger a_1^\dagger a_1 a_0 = - a_1^\dagger a_0^\dagger a_1 a_0$. This motivates us to define a canonical ordering for every `FermionTerm`. Any `FermionTerm` may be put into canonical order as follows.
```csharp
    // Let us use a new method to compactly create a sequence of spin-orbitals
    var spinOrbitalArray = new[] { (0, Spin.u), (1, Spin.u), (1, Spin.u), (0, Spin.u) }.ToSpinOrbitals();

    // A creation operator is represented by the integer `1L`, whereas
    // an annihilation operator is represented by the integer `0L`.
    var conjugateArray = new[] { 1L ,1L, 0L, 0L};

    // We now construct two `FermionTerms` that are equivalent with respect to
    // anti-commutation.
    var fermionTerm0 = new FermionTerm(conjugateArray, new[] 
        { (0, Spin.u), (1, Spin.u), (1, Spin.u), (0, Spin.u) }.ToSpinOrbitals(), 1.0);
    var fermionTerm1 = new FermionTerm(conjugateArray, new[] 
        { (1, Spin.u), (0, Spin.u), (1, Spin.u), (0, Spin.u) }.ToSpinOrbitals(), -1.0);

    // The following Boolean is `false`.
    var equal1 = fermionTerm0 == fermionTerm1;

    // Let us now anti-commute terms to canonical order. In general, anti-commutation
    // can generate new terms -- an array of `FermionTerm` instances.
    var fermionTerms1CanonicalOrder = fermionTerm1.ToCanonicalOrder();

    // However, since normal-ordering is assumed here, there will only be one term.
    var fermionTerm1CanonicalOrder = fermionTerms1CanonicalOrder.First();

    // The following Boolean is `true`.
    var equal2 = fermionTerm0 == fermionTerm1CanonicalOrder;

    // We may also convert a normal-ordered `FermionTerm` in-place.
    fermionTerm1.ToSpinOrbitalCanonicalOrder();

    // The following Boolean is `true`.
    var equal3 = fermionTerm0 == fermionTerm1;
```

Note that the following constructor that omits the `conjugateArray` assumes that the fermionic operators are in normal order. Thus it automatically orders the operators in the canonical order as follows.

```csharp
    // Let us use a new method to compactly create a sequence of spin-orbitals
    var spinOrbitalArray = new[] { (0, Spin.u), (1, Spin.u), (1, Spin.u), (0, Spin.u) }.ToSpinOrbitals();

    // We now construct two `FermionTerms` that are equivalent with respect to
    // anti-commutation. Internally, this constructor calls `ToCanonicalOrder()`.
    var fermionTerm0 = new FermionTerm(new[] 
        { (0, Spin.u), (1, Spin.u), (1, Spin.u), (0, Spin.u) }.ToSpinOrbitals(), 1.0);
    var fermionTerm1 = new FermionTerm(new[] 
        { (1, Spin.u), (0, Spin.u), (1, Spin.u), (0, Spin.u) }.ToSpinOrbitals(), -1.0);

    // Thus the following Boolean is `true`.
    var equal1 = fermionTerm0 == fermionTerm1;
```

## Second-Quantized Fermionic Hamiltonian

It is perhaps unsurprising that the Hamiltonian in [Quantum Models for Electronic Systems](xref:microsoft.quantum.chemistry.concepts.quantummodels) can be written in terms of creation and annihilation operators.
In particular, if $\psi\_j$ are the spin orbitals that form the basis then

\begin{equation}
\hat{H} = \sum\_{pq} h\_{pq}a^\dagger\_p a\_q + \frac{1}{2}\sum\_{pqrs} h\_{pqrs}a^\dagger\_p a^\dagger\_q a\_ra\_s +h\_{\textrm nuc},\tag{★}\label{eq:totalHam}
\end{equation}
where $h\_{\textrm nuc}$ is the nuclear energy (which is a constant under the Born-Oppenheimer approximation) and

\begin{align}
h\_{pq} &= \int\_{-\infty}^\infty \psi^\*\_p(x\_1) \left(\sum\_{i} \frac{|\hat{p}\_i|^2}{2m\_e} -\sum\_{i, k} \frac{e^2}{|\hat{x}\_i - y\_k|}\right)  \psi\_q(x\_1)\mathrm{d}^3x\_1\nonumber\\\
h\_{pqrs} &= \int\_{-\infty}^\infty \int\_{-\infty}^\infty\psi\_p^\*(x\_1)\psi\_q^\*(x\_2) \left(\frac{1}{2}\sum\_{i\ne j} \frac{e^2}{|\hat{x}\_i - \hat{x}\_j|} \right)\psi\_r(x\_2)\psi\_s(x\_1)\mathrm{d}^3x\_1\mathrm{d}^3x\_2.\tag{★}\label{eq:integrals}
\end{align}

The terms $h\_{pq}$ are refered to as one-electron integrals because all such terms only involve single electrons and likewise $h\_{pqrs}$ are the two-electron integrals.
They are called integrals because computing the values of these coefficients requires an integral.  The one electron terms describe the kinetic energy of the individual electrons and their interactions with the electric fields of the nuclei.  The two-electron integrals on the other hand describe the interactions between the electrons.

An intuition for what these terms mean can be gleaned from the creation and annihilation operators that comprise each of them.  For example, $h_{pq}a^\dagger_p a_q$ describes the electron hopping from spin orbital $q$ to spin orbital $p$.  Similarly, the term $h_{pqrs} a^\dagger_p a^\dagger_q a_r a_s$ (for distinct $p,q,r,s$) describes two electrons in spin orbitals $r$ and $s$ scattering off of each other and ending up in spin orbitals $p$ and $q$.  If $r=q$ and $p=s$ then $h_{prrp} a^\dagger_p a^\dagger_r a_r a_p = h_{prrp} n_p n_r$ gives the energy penalty associated with the two electrons being near each other, but does not describe a dynamical process.

We may represent such Hamiltonians using the `FermionHamiltonian` class, which is essentially a list containing all the desired `FermionTerm` instances. Let us construct a few illustrative examples. Consider the Hamiltonian $\hat{H} = a_0^\dagger a_1 + a_1^\dagger a_0$.
```csharp
    // We create a `FermionHamiltonian` object to store the `FermionTerms`.
    var hamiltonian = new FermionHamiltonian();
    
    // We construct the terms to be added.
    var fermionTerm0 = new FermionTerm(new[] 
        { (0, Spin.u), (1, Spin.u) }.ToSpinOrbitals(), 1.0);
    var fermionTerm1 = new FermionTerm(new[] 
        { (1, Spin.u), (0, Spin.u) }.ToSpinOrbitals(), 1.0);
    
    // We add the terms to the Hamiltonian.
    hamiltonian.AddFermionTerm(fermionTerm0);
    hamiltonian.AddFermionTerm(fermionTerm1);
```
We may simplify this construction using the fact that Hamiltonian are Hermitian operators. When adding terms to the Hamiltonian using `AddFermionTerm`, any non-Hermitian term such as `fermionTerm0` is assumed to be paired with its Hermitian conjugate. Thus the following snippet also represents the same Hamiltonian.
```csharp
    // We create a `FermionHamiltonian` object to store the `FermionTerms`.
    var hamiltonian = new FermionHamiltonian();
    
    // We construct the term to be added -- note the doubled coefficient.
    hamiltonian.AddFermionTerm(new FermionTerm(new[] 
        { (0, Spin.u), (1, Spin.u) }.ToSpinOrbitals(), 2.0));
```

Using the anti-commutation rules, some `FermionTerm` instances in the Hamiltonian actually correspond to the same sequence of Fermionic operators, sometimes up to a minus sign. For instance, consider the Hamiltonian $H=a_0^\dagger a_1^\dagger a_1 a_0 - a_1^\dagger a_0^\dagger a_1 a_0 =2a_0^\dagger a_1^\dagger a_1 a_0$, which is a sum of terms constructed above. It may not always be clear to the user that these are equivalent terms, and so they may be added to the Hamiltonian separately. Alternatively, one may be intereted in modifying already-existing terms in the Hamiltonian. In these cases, we may combine equivalent terms as follows.
```csharp
    // We create a `FermionHamiltonian` object to store the `FermionTerms`.
    var hamiltonian = new FermionHamiltonian();

    // We now add two `FermionTerms` that are equivalent with respect to
    // anti-commutation.
    hamiltonian.AddFermionTerm(new FermionTerm(new[] 
        { (0, Spin.u), (1, Spin.u), (1, Spin.u), (0, Spin.u) }.ToSpinOrbitals(), 1.0));
    hamiltonian.AddFermionTerm(new FermionTerm(new[] 
        { (1, Spin.u), (0, Spin.u), (1, Spin.u), (0, Spin.u) }.ToSpinOrbitals(), -1.0));
    // This Hamiltonian contains two terms. 
    
    //We combine equivalent terms using
    hamiltonian.SortAndAccumulate();
    // Now the Hamiltonian only contains one term.
```
By combining coefficients of equivalent terms, we reduce the total number of terms in the Hamiltonian. Later on, this reduces the number of quantum gates required to simulate the Hamiltonian.

### Internal Representation

A fermionic Hamiltonian with one- and two-body interactions is represented in second-quantized notation as
$$
\begin{align}
H=\sum\_{pq}h\_{pq}a^\dagger\_{p}a\_{q}+\frac{1}{2}\sum\_{pqrs}h\_{pqrs}a^\dagger\_{p}a^\dagger\_{q}a\_{r}a\_{s}.
\end{align}
$$
In this notation, there are at most $N^2+N^4$ coefficients. However, many of these coefficients may be collected as they correspond to the same operator. For instance, in the case where $p,q,r,s$ are distinct indices, we may use the anti-commutation rules to show that
$$
a^\dagger\_{p}a^\dagger\_{q}a\_{r}a\_{s}
=
-a^\dagger\_{q}a^\dagger\_{p}a\_{r}a\_{s}
=
-a^\dagger\_{p}a^\dagger\_{q}a\_{s}a\_{r}
=
a^\dagger\_{q}a^\dagger\_{p}a\_{s}a\_{r}.
$$
Furthermore, as $H$ is Hermitian, every non-Hermitian fermionic operator, say $h\_{pqrs}a^\dagger\_{p}a^\dagger\_{q}a\_{r}a\_{s}$, has a Hermitian conjugate that is also found in $H$. In order to uniquely index groups of terms characterized by these symmetries, we define a canonical ordering on the indices $(i\_1,\cdots,i\_n,j\_1,\cdots,j\_m)$ of any sequence of $n+m$ fermionic operators $a^\dagger\_{i\_1}\cdots a^\dagger\_{i\_n}a\_{j\_1}\cdots a\_{j\_m}$as follows:
-   All creation operators $a^\dagger\_{i\_\cdot}$ are placed before all annihilation operators $a\_{j\_\cdot}$.
-   All creation operator indices are sorted in ascending order, that is $i\_1< i\_2< \cdots < i\_n$.
-   All annihilation operator indices are sorted in descending order, that is $j\_1> j\_2 \cdots > j\_m$.
-   The left-most index is less than or equal to the right-most index, that is $i\_1\le j\_m$.

Let us identify this set of canonically ordered indices as
$$
\begin{align}
(i\_1,\cdots,i\_n,j\_1,\cdots,j\_m) \in S\_{n,m}.
\end{align}
$$

With this canonical ordering, the fermionic Hamiltonian may be expressed as
$$
\begin{align}
H=\sum\_{(p,q)\in S\_{1,1}}h'\_{pq}\frac{a^\dagger\_{p}a\_{q}+a^\dagger\_{q}a\_{p}}{2}+\sum\_{(p,q,r,s)\in S\_{2,2}}h'\_{pqrs}\frac{a^\dagger\_{p}a^\dagger\_{q}a\_{r}a\_{s}+a^\dagger\_{s}a^\dagger\_{r}a\_{q}a\_{p}}{2},
\end{align}
$$
with suitably adapted one- and two-electron integrals $h'\_{pq}$ and $h'\_{pqrs}$, respectively. 

