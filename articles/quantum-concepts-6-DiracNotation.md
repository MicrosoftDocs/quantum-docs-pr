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

While column vector notation is ubiquitous in linear algebra, it is often cumbersome in quantum computing especially when dealing with multiple qubits.  The two main reasons for this are that when we define $\psi$ to be a vector it is not explicitly clear whether $\psi$ is a row or a column vector.  Thus if $\phi$ and $\psi$ are vectors then it is not clear whether $\phi \psi$ is defined because the shapes of $\phi$ and $\psi$ may be unclear in the context.  Apart from ambiguity about the shapes of vectors expressing even expressing simple vectors using the linear algebraic notation introduced earlier can be very cumbersome. For example, if we wish to describe an $n$-qubit state where each qubit takes the value $0$ then we would formally express the state as $$\begin{bmatrix}1 \\ 0 \end{bmatrix}\otimes \cdots \otimes\begin{bmatrix}1 \\ 0 \end{bmatrix}. $$  Of course evaluating this tensor product is impractical because the vector lies in an exponentially large space and so this notation is in fact the best description of the state that can be given using the previous notation.  Dirac notation solves these issues by developing a new language to fit the precise needs of quantum mechanics.  For this reason, we recommend not looking at any of these examples in this section as a rigid prescription of how to describe quantum states but rather encourage the reader to view these as suggestions that can be used to concisely express quantum ideas.

There are two types of vectors in Dirac notation: the bra-vector and the ket-vector, so named because when put together they form a braket or inner product.  If $\psi$ is a column vector then we can write it in Dirac notation as $|\psi \rangle$, where the $|\cdot \rangle$ denotes that it is a unit-column vector i.e. a ``ket" vector.  Similarly, the row vector $\psi^\dagger$ is expressed as $\langle \psi |$.  This notation directly implies that $\langle \psi |\psi \rangle$ is the inner product of vector $\psi$ with itself which is by definition $1$.  More generally, if $\psi$ and $\phi$ are quantum state vectors their inner product is $\langle \phi | \psi \rangle$ which implies that the probability of measuring the state $|{\psi}\rangle$ to be $|{\phi}\rangle$ is $|\langle \phi|\psi\rangle|^2$.  

The following convention is used to describe the quantum states that encode values of zero and one (the single-qubit computational basis states)
$$
\begin{bmatrix} 1 \\ 0 \end{bmatrix} = |0\rangle,\qquad
\begin{bmatrix} 0 \\ 1 \end{bmatrix} = |1\rangle,
$$
 and the following notation is often used to describe the states that result from applying the Hadamard gate to $|0\rangle$ and $|1\rangle$ (which correspond to the unit vectors in the +x and -x directions on the Bloch sphere)
$$
\frac{1}{\sqrt{2}}\begin{bmatrix} 1 \\ 1 \end{bmatrix}=H|0\rangle = |{+}\rangle,\qquad
\frac{1}{\sqrt{2}}\begin{bmatrix} 1 \\ -1 \end{bmatrix} =H|1\rangle = |{-}\rangle .
$$
These states can also be expanded using Dirac notation as sums of $|0\rangle$ and $|1\rangle$:
$$
|+\rangle = \frac{1}{\sqrt{2}}(|0\rangle + |1\rangle),\qquad |-\rangle = \frac{1}{\sqrt{2}}(|0\rangle - |1\rangle).
$$
This demonstrates why these states are often called a computational basis: every quantum state can always be expressed as sums of computational basis vectors and such sums are easily expressed using Dirac notation.  The converse is also true in that the states $|+\rangle$ and $|-\rangle$ also form a basis for quantum states.  You can see this from the fact that
$$
|0\rangle = \frac{1}{\sqrt{2}}(|+\rangle + |-\rangle),\qquad |1\rangle = \frac{1}{\sqrt{2}}(|+\rangle - |-\rangle).
$$

As an example of Dirac notation, consider the braket $\langle 0 | 1\rangle$, which is the inner product between $0$ and $1$.  It can be written as $$\langle 0| 1 \rangle=\begin{bmatrix} 1 & 0 \end{bmatrix}\begin{bmatrix}0\\1\end{bmatrix}=0.$$
This says that $|0\rangle$ and $|1\rangle$ are orthogonal vectors, meaning that $\langle 0 |1\rangle = \langle 1 | 0\rangle =0$.  Also by definition $\langle 0 | 0 \rangle = \langle 1 | 1\rangle=1$, which means that the two computational basis vectors can also be called orthonormal.
These orthonormality properties will be useful in the following example. If we have a state $|\psi\rangle = {\frac{3}{5}} |1\rangle + {\frac{4}{5}} |0\rangle$ then because $\langle 1 | 0\rangle =0$ the probability of measuring $1$  is  $$\big|\langle 1 | \psi\rangle \big|^2= \left|\frac{3}{5}\langle 1 | 1\rangle +\frac{4}{5}\langle 1 |0 \rangle\right|^2=\frac{9}{25}.$$ 


Dirac notation also includes an implicit tensor product structure within it.  This is important because in quantum computing, the state vector described by two uncorollated quantum registers is the tensor products of the two state vectors.  Concisely describing the tensor product structure, or lack thereof, is therefore vital if you want to explain a quantum computation.  This tensor product structure implies that we can write $\psi \otimes \phi$ for any two quantum state vectors $\phi$ and $\psi$ as $|\psi\rangle |\phi\rangle$ which is sometimes explicitly written as $|\psi\rangle \otimes |\phi\rangle$ but by convention writing $\otimes$ in between the vectors is unnecessary.  For example, the state with two qubits initialized to the zero state would be
$$
\begin{bmatrix} 1 \\ 0 \\ 0 \\ 0 \end{bmatrix}= \begin{bmatrix} 1 \\ 0 \end{bmatrix} \otimes \begin{bmatrix} 1 \\ 0 \end{bmatrix} = |0\rangle \otimes |0\rangle= |0\rangle |0\rangle.
$$
 Similarly,  the state $|{p}\rangle$ for integer $p$ represents a quantum state that encodes in a binary representation the integer $p$.  For example, if we wished to express the number $3$ using an unsigned binary encoding we could equally express it as
$$
|{1}\rangle|{0}\rangle|{1}\rangle = |{101}\rangle = |{3}\rangle.
$$
Within this notation $|{0}\rangle$ need not refer to a single qubit state but rather a qubit register storing a binary encoding of $0$.  The differences between these two notations can is usually clear within the context it is used.  This convention is useful for simplifying the first example which can be written in any of the following ways
$$
\begin{bmatrix}1 \\ 0 \end{bmatrix}\otimes \cdots \otimes\begin{bmatrix}1 \\ 0 \end{bmatrix} = |0\rangle \otimes \cdots \otimes |0\rangle= |0\cdots 0\rangle = |0\rangle^{\otimes n} = |0\rangle.
$$
As another example of how you can use Dirac notation to describe a quantum state, consider the following equivalent ways of writing a quantum state that is an equal superposition over every possible bit string of length $n$
$$
H^{\otimes n} |{0}\rangle = \frac{1}{2^{n/2}} \sum_{j=0}^{2^n-1} |{j}\rangle=|+\rangle^{\otimes n}.
$$
Here you may wonder why the sum goes from $0$ to $2^{n}-1$ for $n$ bits.  First note that there are $2^{n}$ different configurations that $n$ bits can take.  You can see this by noting that one bit can take $2$ values but two bits can take $4$ values and so forth. In general, this means that there are $2^n$ different possible bit strings but the largest value encoded in any of them $1\cdots 1=2^n-1$ and hence it is the upper limit for the sum.
As a side note, in this example we did not use $|+\rangle^{\otimes n}=|+\rangle$ in analogy to $|0\rangle^{\otimes n} = |0\rangle$ because this notational convention is usually reserved for the computational basis state that has every qubit initialized to zero.  While such a convention would be sensible in this case, it is not employed in the quantum computing literature.

Another nice feature of Dirac notation is the fact that it is linear.  If we wished to write for any four quantum state vectors, 
$$(\alpha |\psi\rangle +\beta|\phi\rangle)\otimes (\gamma |\chi\rangle + \delta |\omega\rangle)= \alpha\gamma |\psi\rangle|\chi\rangle + \alpha\delta |\psi\rangle|\omega\rangle+\beta\gamma|\phi\rangle|\chi\rangle+\beta\omega|\phi\rangle|\omega\rangle.$$
That is to say, you can distribute the tensor product notation in Dirac notation so that taking tensor products between state vectors ends up looking just like ordinary multiplication.

Bra vectors follow a similar convention to ket vectors.  For example the vector $\langle\psi|\langle \phi|$ is equivalent to the state vector $\psi^\dagger \otimes \phi^\dagger=(\psi\otimes \phi)^\dagger$.  For example if the ket vector $|\psi\rangle$ is $\alpha |0\rangle + \beta |1\rangle$ then the bra vector version of the vector is $\langle{\psi}|=|\psi\rangle^\dagger = (\langle 0|\alpha^* +\langle 1 |\beta^*)$.  This 
As an example, imagine that we wished to calculate the probability of measuring the state $|\psi\rangle = \frac{3}{5} |1\rangle + \frac{4}{5} |0\rangle$ using a quantum program for measuring states to be either $|+\rangle$ or $|-\rangle$ then the probability that the device would output that the state is $|-\rangle$ is 
$$|\langle - |\psi\rangle|^2= \left|\frac{1}{\sqrt{2}}(\langle 0| - \langle 1|)(\frac{3}{5} |1\rangle + \frac{4}{5} |0\rangle) \right|^2=\left|-\frac{3}{5\sqrt{2}} + \frac{4}{5\sqrt{2}}\right|^2=\frac{1}{50}.$$
  The fact that the negative sign appears in the calculation of the probability is a manifestation of quantum interference, which is one of the mechanisms by which quantum computing gains advantages over classical computing.

  The final object that is worth discussing in Dirac notation is the outer product or ketbra.  Such terms are represented within Dirac notations as $|\psi\rangle \langle \phi|$, and are sometimes called ketbras because the bras and kets occur in the opposite order as brakets.  The outer product is defined via matrix multiplication as $|\psi\rangle \langle \phi| = \psi \phi^\dagger$ for quantum state vectors $\psi$ and $\phi$.  The simplest, and arguably most common example of this notation is
  $$
|0\rangle \langle 0| = \begin{bmatrix}1\\0 \end{bmatrix}\begin{bmatrix}1&0 \end{bmatrix}= \begin{bmatrix}1 &0\\0 &0\end{bmatrix} \qquad |1\rangle \langle 1| = \begin{bmatrix}0\\1 \end{bmatrix}\begin{bmatrix}0&1 \end{bmatrix}= \begin{bmatrix}0 &0\\0 &1\end{bmatrix}.
  $$
  Such ketbras are often called projectors because they project a quantum state onto a fixed value.  Since these operations are not unitary (and do not even preserve the norm of a vector), it should come as no surprise that a quantum computer cannot deterministically apply a projector.  However projectors do a beautiful job of describing the action that measurement has on a quantum state.  For example, if we measure a state $|\psi \rangle$ to be $0$ then the resulting transformation that the state experiences as a result of the measurement is
  $$|\psi \rangle \rightarrow \frac{(|0\rangle \langle 0|)|\psi\rangle}{\langle 0|\psi\rangle}= |0\rangle,$$
  as one expects if you were to measure the state and find it to be $|0\rangle$.  Again to reiterate, such projectors cannot be applied on a state in a quantum computer deterministically.  Instead, they can at best be applied randomly with the result $|0\rangle$ appearing with some fixed probability.  The probability of such a measurement succeeding can be written as the expectation value of the quantum projector in the state
  $$
\langle \psi| (|0\rangle \langle 0|)|\psi\rangle = |\langle \psi|0\rangle|^2,
  $$
  which illustrates that projectors simply give a new way of expressing the measurement process.

  The other such operator that is useful to express in this language is a state operator.  A state operator for a quantum state vector takes the form $\rho = |\psi\rangle \langle \psi|$.  This concept of representing the state as a matrix, rather than a vector, is often convenient because it gives a convenient way of representing probability calculations but also allows one to describe both statistical uncertainty as well as quantum uncertainty within the same formalism.  These general quantum state operators, rather than vectors, are ubiquitous in some areas of quantum computing but are not necessary to understand the basics of the field.  For the interested reader, we recommend reading one of the reference books provided in the further reading section.

A final point that is worth raising about quantum notation.  While at the onset of this document we mentioned that the quantum state is the fundamental object of quantum computing.  It may then come as a surprise that in Q# there is no notion of a quantum state.  Instead, all states are described only by the circuit used to prepare them.  The previous example is an excellent illustration of this.  Rather than expressing a uniform superposition over every quantum bit string in a register, we can represent the result as $H^{\otimes n} |{0}\rangle$.  This exponentially shorter description of the state not only has the advantage that we can classically reason about it but it also because it concisely gives the operations needed to be propagated through the software stack to implement the algorithm.  For this reason, Q# is designed to emit gate sequences rather than quantum states; however, at a theoretical level the two perspectives are equivalent.