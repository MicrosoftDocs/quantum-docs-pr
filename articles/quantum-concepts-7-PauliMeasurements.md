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
uid: microsoft.quantum.concepts.pauli
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

# Advanced topics
## Pauli Measurements

  In all the previous discussion, we focused on computational basis measurements but there are other common measurements that occur in quantum computing that can be inconvenient from a notational perspective to express in terms of computational basis measurements.  The most common set of these measurements are Pauli-measurements.  In such cases, it is common to discuss measuring a Pauli-operator which in general is an operator such as $X,Y,Z$ or $Z\otimes Z, X\otimes X, X\otimes Y$ and so forth.  Discussing measurement in terms of Pauli operations is especially common in the subfield of quantum error correction. In Q# we have taken a similar convention and as such we need to explain this alternative view of measurements.

  Before delving into the details of how to think of a Pauli measurement, it is useful to think about what measuring a single qubit inside a quantum computer does to the quantum state.  Imagine that we have an $n$-qubit quantum state then measuring one qubit immediately rules out half of the $2^n$ possibilities that state could be in.  In other words, the measurement projects the quantum state onto one or two half-spaces.  We can generalize the way we think about measurement to reflect this.

  In order to concisely identify these subspaces, we need a language for describing them.  One way to do this is to describe the two subspaces by specifying them through a matrix that just has two unique eigenvalues, which are taken by convention to be $\pm 1$.  The simplest example of this is 

  $$
Z= \begin{bmatrix}1&0\\\\ 0&-1\end{bmatrix}
  $$

The Pauli-$Z$ matrix clearly has two eigenvectors $|0\rangle$ and $|1\rangle$ with eigenvalues $\pm 1$.  Thus if we measure the qubit and obtain $|0\rangle$ then we are in the $+1$ eigenspace (the set of all vectors that are formed of sums of  eigenvectors with only positive or only negative eigenvalues) of the operator and if we measure $|1\rangle$ then we are in the $-1$ eigenspace of $Z$.  This process is referred to in the language of Pauli measurements as measuring Pauli-$Z$ and it is entirely equivalent to performing a computational basis measurement.

Of course any $2\times 2$ matrix that is a unitary transformation of $Z$ also satisfies this criteria.  This is to say that we could also consider matrix $A=U^\dagger Z U$, for any unitary matrix $U$, to give a matrix that defines the two outcomes of a measurement in its $\pm 1$ eigenvectors.  The notation of Pauli measurements references this by identifying $X,Y,Z$ measurements as equivalent measurements that one could do to gain information from a qubit.  These measurements are given below for convenience.

$$
\begin{array}{|c|c|}
\text{Pauli Measurement} & U\\\\ 
Z & \boldone\\\\ 
X & H\\\\ 
Y & HS^\dagger\\\\ 
\end{array}
$$

That is to say, if you say using this language "measure $Y$" that is equivalent to applying $HS^\dagger$ and then measuring in the computational basis.  Or using this language it is equivalent to applying $HS^\dagger$ to the quantum state vector and then measuring $Z$.  The correct state would then be found by transforming back to the computational basis, which ammounts to applying $SH$ to the quantum state vector.

In Q# we say the outcome, ie the classical information extracted from interacting with the state is $j$ which is in the set $\{0,1\}$ if the result is in the $(-1)^j$ eigenspace of the Pauli-operator measured.

Measurements of multi-qubit Pauli operators are defined similarly.  You can see this from the fact that

$$
Z\otimes Z = \begin{bmatrix}1 &0 &0&0\\\\  0&-1&0&0\\\\ 0&0&-1&0\\\\ 0&0&0&1\end{bmatrix}.
$$

Thus the tensor products of two Pauli-$Z$ operators forms a matrix composed of two spaces consisting of $+1$ and $-1$ eigenvalues.  As with the single qubit case, both constitute a half-space meaning that half of the accessible vector space belongs to the $+1$ eigenspace and the remaining half to the $-1$ eigenspace.  In general, it is easy to see from the definition of the tensor product that any tensor product of Pauli-$Z$ operators and the identity also obeys this.  For example,

$$
Z\otimes\boldone=\begin{bmatrix} 1&0&0&0\\\\  0&-1&0&0\\\\  0&0&1&0\\\\ 0&0&0&-1\end{bmatrix}.
$$

As before, any unitary transformation of such matrices also describes two half-spaces labeled by $\pm 1$ eigenvalues.  For example, $X\otimes X = H\otimes H(Z\otimes Z)H\otimes H$  from the identity that $Z=HXH$.  Similar to the one-qubit case, all two qubit Pauli-measurements can be written as $U^\dagger (Z\otimes \boldone) U$ for $4\times 4$ unitary matrices $U$.  We enumerate the transformations in the following table where we introduce for convenience the swap gate which swaps qubits $0$ and $1$: $\operatorname{SWAP}=\operatorname{CNOT}\_{01}\operatorname{CNOT}\_{10}\operatorname{CNOT}\_{01}$:

$$
\begin{array}{|c|c|}
\text{Pauli Measurement} & U\\\\ 
\hline
Z\otimes \boldone & \boldone\otimes \boldone\\\\ 
X\otimes \boldone & H\otimes \boldone\\\\ 
Y\otimes \boldone & HS^\dagger\otimes \boldone\\\\ 
\boldone \otimes Z & \operatorname{SWAP}\\\\ 
\boldone \otimes X & (H\otimes \boldone)\operatorname{SWAP}\\\\ 
\boldone \otimes Y & (HS^\dagger\otimes \boldone)\operatorname{SWAP}\\\\ 
\end{array}
$$
$$
\begin{array}{|c|c|}
\text{Pauli Measurement} & U\\\\ 
\hline
Z\otimes Z & \operatorname{CNOT}\_{10}\\\\ 
X\otimes Z & \operatorname{CNOT}\_{10}(H\otimes \boldone)\\\\ 
Y\otimes Z & \operatorname{CNOT}\_{10}(HS^\dagger\otimes \boldone)\\\\ 
Z\otimes X & \operatorname{CNOT}\_{10}(\boldone\otimes H)\\\\ 
X\otimes X & \operatorname{CNOT}\_{10}(H\otimes H)\\\\ 
Y\otimes X & \operatorname{CNOT}\_{10}(HS^\dagger\otimes H)\\\\ 
Z\otimes Y & \operatorname{CNOT}\_{10}(\boldone \otimes HS^\dagger)\\\\ 
X\otimes Y & \operatorname{CNOT}\_{10}(H\otimes HS^\dagger)\\\\ 
Y\otimes Y & \operatorname{CNOT}\_{10}(HS^\dagger\otimes HS^\dagger)\\\\ 
\end{array}
$$

Here the gate $\operatorname{CNOT}\_{10}$ appears for the following reason.  Each Pauli measurement that does not include the $\boldone$ matrix is equivalent up to a unitary to $Z\otimes Z$ by the above reasoning.  The eigenvalues of $Z\otimes Z$ only depend on the parity of the qubits that comprise each computational basis vector and the controlled-not operations that appear in this list serve to compute this parity and store it in the first bit.  Then once the first bit is measured, we can recover the identity of the resultant half-space which is equivalent to measuring the Pauli operator.

One additional note, while it may be tempting to assume that measuring $Z\otimes Z$ is the same as measuring $Z\otimes \boldone$ and then $\boldone \otimes Z$ this assumption would be false.  The reason why is that measuring $Z\otimes Z$ projects the quantum state into either the $+1$ or $-1$ eigenstate of these operators.  Measuring $Z\otimes \boldone$ and then $\boldone \otimes Z$ projects the quantum state vector first onto a half space of $Z\otimes \boldone$ and then onto a half space of $\boldone \otimes Z$.  As there are four computational basis vectors, performing both measurements reduces the state to a quarter-space and hence reduces it to a single computational basis vector.

Another way of looking at measuring tensor products of Paulis such as $X\otimes X$ or $Z\otimes Z$ is that these measurements let you look at information stored in the correlations between the two qubits.  Measuring $X\otimes \boldone$ lets you look at information that is locally stored in the first qubit.  While both types of measurements are equally valuable in quantum computing, the former illuminates the power of quantum computing better because it reveals that in quantum computing often the information you wish to learn is not stored in any single qubit but rather it is stored non-locally in all the qubits at once and only by looking at it through a joint measurement with $Z\otimes Z$ does this information become manifest.

Arbitrary Pauli operators such as $X\otimes Y \otimes Z \otimes \boldone$ can also be measured.  All such tensor products of Pauli operators have only two eigenvalues $\pm 1$ and both eigenspaces constitute half-spaces of the entire vector space.  Thus they coincide with the requirements stated above.  

In Q#, such measurements return $j$ if the measurement yields a result in the eigenspace of sign $(-1)^j$.  Having this as a built in feature in Q# is helpful because measuring such operators requires long chains of controlled-not gates and basis transformations to describe the diagonalizing $U$ gate needed to express the operation as a tensor product of $Z$ and $\boldone$.  By simply being able to specify that you wish to do one of these pre-defined measurements, you don't need to worry about how to transform your basis such that a computational basis measurement provides the necessary information.  Q# handles all the necessary basis transformations for you automatically.

## The No Cloning Theorem
Quantum information is powerful.  It enables us to do amazing things such as factor numbers exponentially faster than the best known classical algorithms, or simulate correlated electron systems that require exponential cost to simulate accurately.  However, there are limitations to the power of quantum computing.  One such limitation is given by the No-Cloning Theorem.

The No-Cloning Theorem is aptly named.  It disallows cloning of generic quantum states by a quantum computer.  The proof of the theorem is remarkably straight forward.  While a full proof of the no-cloning theorem is a little too technical for our discussion here, the proof of the theorem in the case where the quantum computer in question has no additional ancilla bits is within our scope.  For such a quantum computer, the cloning operation must be a unitary matrix. We disallow measurement, since it would corrupt the quantum state we are trying to clone. The unitary matrix we want, must have the property that

$$
U|\psi\rangle|0\rangle=|\psi\rangle|\psi\rangle,
$$

for any state $|\psi\rangle$.  The linearity property of matrix multiplication then implies that that for any quantum second state $|\phi\rangle$

\begin{align}
&U\left[\frac{1}{\sqrt{2}}\left(|\phi\rangle+|\psi\rangle \right)\right]=\frac{1}{\sqrt{2}}\left(|\phi\rangle|\phi\rangle+|\psi\rangle|\psi\rangle\right)\\\\
&\qquad\qquad\ne \left(\frac{1}{\sqrt{2}}\left(|\phi\rangle+|\psi\rangle \right)\right)\otimes\left(\frac{1}{\sqrt{2}}\left(|\phi\rangle+|\psi\rangle \right)\right).
\end{align}

This provides the fundamental intuition behind the No-Cloning-Theorem, that any device that copies an unknown quantum state must induce errors on at least some of the states it copies.  While the key assumption that the cloner acts linearly on the input state can be violated through the addition of ancilla and measurement of the ancilla qubits, such interactions also leak information about the system through the measurement statistics and prevent exact cloning in such cases as well.  For a more complete proof of the No-Cloning-Theorem please see the [reference texts](quantum-ForMoreInfo.md)  recommended at the end of the documentation.

The No-Cloning Theorem is important for qualitative understanding of quantum computing because if you could clone quantum states inexpensively then you would be granted with a near-magical ability to learn from quantum states.  Indeed, you could violate Heisenberg's vaunted uncertainty principle with this.  Alternatively, you could use an optimal cloner to take a single sample from a complex quantum distribution and learn everything you could possibly learn about that distribution from just one sample.  This would be like you flipping a coin and observing heads and then upon telling a friend about the result having them respond "Ah the distribution of that coin must be Bernoulli with $p=0.512643\ldots$!"  Such a statement would be non-sensical because one bit of information (the heads outcome) simply cannot provide the many bits of information needed to encode the distribution without substantial prior information.  Similarly, without prior information we cannot perfectly clone a quantum state just as we cannot prepare an ensemble of such coins without knowing $p$.

Information is not free in quantum computing.  Each qubit measured gives a bit of information, and the No-Cloning theorem shows that there is no backdoor that can be exploited to get around the fundamental tradeoff between information gained about the system and the disturbance invoked upon it.

