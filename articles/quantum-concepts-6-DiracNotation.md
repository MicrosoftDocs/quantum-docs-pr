---
# Mandatory fields. See more on aka.ms/skyeye/meta.
title: Intent and product brand in a unique string of 43-59 chars including spaces | Microsoft Docs 
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

# Dirac notation

While column vector notation is ubiquitous in linear algebra, it is often cumbersome in quantum computing especially when dealing with multiple qubits.  The two main reasons for this are that when we define $\psi$ to be a vector it is not explicitly clear whether $\psi$ is a row or a column vector.  Thus if $\phi$ and $\psi$ are vectors then it is not clear whether $\phi \psi$ is defined because the shapes of $\phi$ and $\psi$ may be unclear in the context.  Furthermore, if we wish to represent a system of $n$ qubits, formally expressing the vector as $\begin{bmatrix}1 \\ 0 \end{bmatrix}\otimes \cdots \otimes\begin{bmatrix}1 \\ 0 \end{bmatrix} $.  Dirac notation solves this by modifying the standard notation used in linear algebra to fit the needs of quantum mechanics.

There are two types of vectors in Dirac notation: the ``bra" vector and the ``ket" vector, so named because when put together they form a ``braket" or inner product.  Specifically, let $\psi$ be a column vector we then denote $\psi$ in Dirac notation as $|\psi \rangle$, where the $|\cdot \rangle$ denotes that it is a unit-column vector i.e. a ``ket" vector.  Similarly, the row vector $\psi^\dagger$ is expressed as $\langle \psi |$.  As mentioned, this notation directly implies that $\langle \psi |\psi \rangle$ is the inner product of vector $\psi$ with itself which is by definition $1$.  More generally if $\psi$ and $\phi$ are quantum state vectors their inner product is $\langle \phi | \psi \rangle$ which implies that the probability of measuring the state $\ket{\psi}$ to be $\ket{\phi}$ is $|\langle \phi|\psi\rangle|^2$.  For example, if we have a state $|\psi\rangle = \sqrt{\frac{3}{5}} |1\rangle + \sqrt{\frac{4}{5}} |0\rangle$ then the probability of measuring $1$  is  $\big|\langle 1 | \psi\rangle \big|^2= \big|\sqrt{\frac{3}{5}}+0\big|^2=3/5.$ 

By convention, in quantum computing we use the following notation to describe the quantum states that encode values of zero and one (the single-qubit computational basis states)
$$
\begin{bmatrix} 1 \\ 0 \end{bmatrix} = |0\rangle,\qquad
\begin{bmatrix} 0 \\ 1 \end{bmatrix} = |1\rangle,
$$
 and the following notation is often used to describe their Hadamard transforms (which correspond to the unit vectors in the +x and -x directions on the Bloch sphere)
$$
\frac{1}{\sqrt{2}}\begin{bmatrix} 1 \\ 1 \end{bmatrix}=H|0\rangle = |{+}\rangle,\qquad
\frac{1}{\sqrt{2}}\begin{bmatrix} 1 \\ -1 \end{bmatrix} =H|1\rangle = |{-}\rangle .
$$
Furthermore, we define an implicit tensor product structure within Dirac notation.  For example, the state with two qubits initialized to the zero state would be
$$
\begin{bmatrix} 1 \\ 0 \\ 0 \\ 0 \end{bmatrix}= \begin{bmatrix} 1 \\ 0 \end{bmatrix} \otimes \begin{bmatrix} 1 \\ 0 \end{bmatrix} = |0\rangle \otimes |0\rangle= |0\rangle |0\rangle.
$$
 Similarly,  the state $\ket{p}$ for integer $p$ represents a quantum state that encodes in a binary representation the integer $p$.  For example, if we wished to express the number $3$ using an unsigned binary encoding we could equally express it as
$$
\ket{1}\ket{0}\ket{1} = \ket{101} = \ket{3}.
$$
Similarly, within this notation $\ket{0}$ need not refer to a single qubit state but rather a qubit register storing a binary encoding of $0$.  The differences between these two notations can is usually clear within the context it is used.  This convention is useful in the following example 
$$
H^{\otimes n} \ket{0} = \frac{1}{2^{n/2}} \sum_{j=0}^{2^n-1} \ket{j}.
$$
The result is a quantum superposition over every possible bit string and so if we had to specify such strings without making reference to the encoding of the integers $j$ that comprise the quantum superposition of states.

A final point that is worth raising about quantum notation.  While at the onset of this document we mentioned that the quantum state is the fundamental object of quantum computing.  It may then come as a surprise that in \Qb there is no notion of a quantum state.  Instead, all states are described only by the circuit used to prepare them.  The previous example is an excellent illustration of this.  Rather than expressing a uniform superposition over every quantum bit string in a register, we can represent the result as $H^{\otimes n} \ket{0}$.  This exponentially shorter description of the state not only has the advantage that we can classically reason about it but it also because it concisely gives the operations needed to be propagated through the software stack to implement the algorithm.  For this reason, \Qb is designed to emit gate sequences rather than quantum states; however, at a theoretical level the two perspectives are equivalent.