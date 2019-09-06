---
title: Jordan-Wigner Representation | Microsoft Docs
description: Jordan-Wigner Representation Conceptual Docs
author: nathanwiebe2
ms.author: nawiebe@microsoft.com
ms.date: 10/09/2017
ms.topic: article-type-from-white-list
uid: microsoft.quantum.chemistry.concepts.jordanwigner
---

 
# Jordan-Wigner Representation

While second quantized Hamiltonians are conveniently represented in terms of $a^\dagger$ (creation) and $a$ (annihilation), these operations are not fundamental operations in quantum computers.
As a result, if we wish it implement them on a quantum computer we need to map the operators to unitary matrices that can be implemented on a quantum computer.
The Jordan–Wigner representation gives one such map.
However, others such as the Bravyi–Kitaev representation also exist and have their own relative advantages and disadvantages.
The main advantage of the Jordan-Wigner representation is its simplicity.

The Jordan-Wigner representation is straight forward to derive.
Recall that a state $\ket{0}_j$ implies that spin orbital $j$ is empty and $\ket{1}_j$ implies that it is occupied.
This means that qubits can naturally store the occupation of a given spin orbital.
We then have that $a^\dagger_j \ket{0}_j = \ket{1}_j$ and $a^\dagger_j \ket{1}_j = 0$.
It is easy to verify that
\begin{align}
a^\dagger_j &= \begin{bmatrix}0 & 1 \\\ 0 &0 \end{bmatrix}=\frac{X_j + iY_j}{2}, \nonumber\\\\
a_j &= \begin{bmatrix}0 & 0 \\\ 1 &0 \end{bmatrix}=\frac{X_j - iY_j}{2},
\end{align}
where $X_j$ and $Y_j$ are the Pauli-$X$ and -$Y$ operators acting on qubit $j$.
This shows that for a single spin orbital it is easy to represent creation and annihilation operators in terms of unitary matrices that quantum computers understand.
 Note that while $X$ and $Y$ are unitary $a^\dagger$ and $a$ are not.
 We will see later that this does not pose a challenge for simulation.

One problem that remains is that while the above construction works for a single spin orbital, it fails for systems with two or more spin orbitals.
Since Fermions are antisymmetic, we know that $a^\dagger_j a^\dagger_k = - a^\dagger_k a^\dagger_j$ for any $j$ and $k$.
 However, 
$$
\left(\frac{X_j - iY_j}{2}\right)\left(\frac{X_k - iY_k}{2}\right) = \left(\frac{X_k - iY_k}{2}\right) \left(\frac{X_j - iY_j}{2}\right).
$$
In other words, the two creation operators do not anti-commute as required.
This can be remedied though in a straightforward, if inelegant fashion.
The fix is to note that Pauli operators naturally anti-commute.
In particular, $XZ = -ZX$ and $YZ=-ZY$.
Thus, by interspersing $Z$ operators into the construction of the operator, we can emulate the correct anti-commutation.
 The full construction is as follows: 

\begin{align}
a^\dagger_1 &= \left(\frac{X-iY}{2}\right)\otimes 1 \otimes 1 \otimes 1 \otimes \cdots \otimes 1,\\\\
a^\dagger_2 &= Z\otimes\left(\frac{X-iY}{2}\right)\otimes 1\otimes 1 \otimes \cdots \otimes 1,\\\\
a^\dagger_3 &= Z\otimes Z\otimes \left(\frac{X-iY}{2}\right)\otimes 1 \otimes \cdots \otimes 1,\\\\
&\vdots\\\\
 a^\dagger_N &= Z\otimes Z\otimes Z\otimes Z \otimes \cdots \otimes Z\otimes \left(\frac{X-iY}{2}\right). \label{eq:JW}
\end{align}

It is also convenient to express the number operators, $n_j$, in terms of Pauli operators.
Thankfully, the strings of $Z$ operators (known as Jordan-Wigner strings) cancel after one makes this substitution.
After carrying this out (and recalling that $X_jY_j=iZ_j$), we have
\begin{equation}
n_j = a^\dagger_j a_j = \frac{(1-Z_j)}{2}.
\end{equation}


## Constructing Hamiltonians in Jordan-Wigner Representation

Once we have invoked the Jordan-Wigner representation translating the Hamiltonian to a sum of Pauli operators is straight forward.
 One simply has to replace each of the $a^\dagger$ and $a$ operators in the Fermionic Hamiltonian with the strings of Pauli-operators given above.
 When one performs this substitution, there are only five classes of terms within the Hamiltonian.
 These five classes correspond to the different ways we can pick the $p,q$ and $p,q,r,s$ in the one-body and the two-body terms in the Hamiltonian.
 These five classes, for the case where $p>q>r>s$ and real-valued orbitals, are

\begin{align}
h_{pp}a_p^\dagger a_p &= \sum_p \frac{h_{pp}}{2}(1 - Z_p)\\\\
h_{pq}(a_p^\dagger a_q + a^\dagger_q a_p) &= \frac{h_{pq}}{2}\left(\prod_{j=q+1}^{p-1} Z_j \right)\left( X_pX_q + Y_pY_q\right)\\\\
h_{pqqp} n_p n_q &=  \frac{h_{pqqp}}{4}\left(1-Z_p - Z_q +Z_pZ_q \right)\\\\
H_{pqqr} &= \frac{h_{pqqr}}{2}\left(\prod_{j=r+1}^{p-1} Z_j \right)\left( X_pX_r + Y_pY_r\right)\left(\frac{1-Z_q}{2}\right)\\\\
H_{pqrs} &= \frac{h_{pqrs}}{8}\prod_{j=s+1}^{r-1} Z_j\prod_{k=q+1}^{p-1} Z_k \Big(XXXX - XXYY+XYXY\nonumber\\\\
&\qquad\qquad\qquad\qquad\qquad+YXXY+YXYX-YYXX\nonumber\\\\
&\qquad\qquad\qquad\qquad\qquad+XYYX+YYYY\Big)
\end{align}

While generating such Hamiltonians by hand only requires applying these replacement rules, doing so would be infeasible for large molecules which can consist of millions of Hamiltonian terms.
 As an alternative, we can automatically construct the `JordanWignerEncoding` given a `FermionHamiltonian` representation of the Hamiltonian.

```csharp
    // We load the namespace containing fermion and Pauli objects. 
    using Microsoft.Quantum.Chemistry.Fermion;
    using Microsoft.Quantum.Chemistry.Pauli;
    
    // We create an example `FermionHamiltonian` instance.
    var fermionHamiltonian = new FermionHamiltonian();

    // We convert this Fermion Hamiltonian to a Jordan-Wigner representation.
    var jordanWignerEncoding = fermionHamiltonian.ToPauliHamiltonian(QubitEncoding.JordanWigner);
```

Once the Hamiltonians are constructed in this form, we can use a host of quantum simulation algorithms to compile the dynamics generated by $e^{-iHt}$ into a sequence of elementary gates (within some user definable error tolerance).
We discuss the two most popular methods for quantum simulation, qubitization and Trotter–Suzuki formulas, in the algorithmic documentation. We provide implementations for both methods in the Hamiltonian simulation library.
