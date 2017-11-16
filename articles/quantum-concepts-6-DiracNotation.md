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

# Advanced topics
## Dirac Notation

While column vector notation is ubiquitous in linear algebra, it is often cumbersome in quantum computing especially when dealing with multiple qubits.  The two main reasons for this are that when we define $\psi$ to be a vector it is not explicitly clear whether $\psi$ is a row or a column vector.  Thus if $\phi$ and $\psi$ are vectors then it is not clear whether $\phi \psi$ is defined because the shapes of $\phi$ and $\psi$ may be unclear in the context.  Apart from ambiguity about the shapes of vectors expressing even expressing simple vectors using the linear algebraic notation introduced earlier can be very cumbersome. For example, if we wish to describe an $n$-qubit state where each qubit takes the value $0$ then we would formally express the state as $$\begin{bmatrix}1 \\\\  0 \end{bmatrix}\otimes \cdots \otimes\begin{bmatrix}1 \\\\  0 \end{bmatrix}. $$  Of course evaluating this tensor product is impractical because the vector lies in an exponentially large space and so this notation is in fact the best description of the state that can be given using the previous notation.  Dirac notation solves these issues by developing a new language to fit the precise needs of quantum mechanics.  For this reason, we recommend not looking at any of these examples in this section as a rigid prescription of how to describe quantum states but rather encourage the reader to view these as suggestions that can be used to concisely express quantum ideas.

There are two types of vectors in Dirac notation: the bra-vector and the ket-vector, so named because when put together they form a braket or inner product.  If $\psi$ is a column vector then we can write it in Dirac notation as $|\psi \rangle$, where the $|\cdot \rangle$ denotes that it is a unit-column vector i.e. a ``ket" vector.  Similarly, the row vector $\psi^\dagger$ is expressed as $\langle \psi |$.  This notation directly implies that $\langle \psi |\psi \rangle$ is the inner product of vector $\psi$ with itself which is by definition $1$.  More generally, if $\psi$ and $\phi$ are quantum state vectors their inner product is $\langle \phi | \psi \rangle$ which implies that the probability of measuring the state $|{\psi}\rangle$ to be $|{\phi}\rangle$ is $|\langle \phi|\psi\rangle|^2$.  

The following convention is used to describe the quantum states that encode values of zero and one (the single-qubit computational basis states)
$$
\begin{bmatrix} 1 \\\\  0 \end{bmatrix} = |0\rangle,\qquad
\begin{bmatrix} 0 \\\\  1 \end{bmatrix} = |1\rangle,
$$
 and the following notation is often used to describe the states that result from applying the Hadamard gate to $|0\rangle$ and $|1\rangle$ (which correspond to the unit vectors in the +x and -x directions on the Bloch sphere)
$$
\frac{1}{\sqrt{2}}\begin{bmatrix} 1 \\\\  1 \end{bmatrix}=H|0\rangle = |{+}\rangle,\qquad
\frac{1}{\sqrt{2}}\begin{bmatrix} 1 \\\\  -1 \end{bmatrix} =H|1\rangle = |{-}\rangle .
$$
These states can also be expanded using Dirac notation as sums of $|0\rangle$ and $|1\rangle$:
$$
|+\rangle = \frac{1}{\sqrt{2}}(|0\rangle + |1\rangle),\qquad |-\rangle = \frac{1}{\sqrt{2}}(|0\rangle - |1\rangle).
$$
This demonstrates why these states are often called a computational basis: every quantum state can always be expressed as sums of computational basis vectors and such sums are easily expressed using Dirac notation.  The converse is also true in that the states $|+\rangle$ and $|-\rangle$ also form a basis for quantum states.  You can see this from the fact that
$$
|0\rangle = \frac{1}{\sqrt{2}}(|+\rangle + |-\rangle),\qquad |1\rangle = \frac{1}{\sqrt{2}}(|+\rangle - |-\rangle).
$$

As an example of Dirac notation, consider the braket $\langle 0 | 1\rangle$, which is the inner product between $0$ and $1$.  It can be written as $$\langle 0| 1 \rangle=\begin{bmatrix} 1 & 0 \end{bmatrix}\begin{bmatrix}0\\\\ 1\end{bmatrix}=0.$$
This says that $|0\rangle$ and $|1\rangle$ are orthogonal vectors, meaning that $\langle 0 |1\rangle = \langle 1 | 0\rangle =0$.  Also by definition $\langle 0 | 0 \rangle = \langle 1 | 1\rangle=1$, which means that the two computational basis vectors can also be called orthonormal.
These orthonormality properties will be useful in the following example. If we have a state $|\psi\rangle = {\frac{3}{5}} |1\rangle + {\frac{4}{5}} |0\rangle$ then because $\langle 1 | 0\rangle =0$ the probability of measuring $1$  is  $$\big|\langle 1 | \psi\rangle \big|^2= \left|\frac{3}{5}\langle 1 | 1\rangle +\frac{4}{5}\langle 1 |0 \rangle\right|^2=\frac{9}{25}.$$ 


Dirac notation also includes an implicit tensor product structure within it.  This is important because in quantum computing, the state vector described by two uncorollated quantum registers is the tensor products of the two state vectors.  Concisely describing the tensor product structure, or lack thereof, is therefore vital if you want to explain a quantum computation.  This tensor product structure implies that we can write $\psi \otimes \phi$ for any two quantum state vectors $\phi$ and $\psi$ as $|\psi\rangle |\phi\rangle$ which is sometimes explicitly written as $|\psi\rangle \otimes |\phi\rangle$ but by convention writing $\otimes$ in between the vectors is unnecessary.  For example, the state with two qubits initialized to the zero state would be
$$
\begin{bmatrix} 1 \\\\  0 \\\\  0 \\\\  0 \end{bmatrix}= \begin{bmatrix} 1 \\\\  0 \end{bmatrix} \otimes \begin{bmatrix} 1 \\\\  0 \end{bmatrix} = |0\rangle \otimes |0\rangle= |0\rangle |0\rangle.
$$
 Similarly,  the state $|{p}\rangle$ for integer $p$ represents a quantum state that encodes in a binary representation the integer $p$.  For example, if we wished to express the number $3$ using an unsigned binary encoding we could equally express it as
$$
|{1}\rangle|{0}\rangle|{1}\rangle = |{101}\rangle = |{3}\rangle.
$$
Within this notation $|{0}\rangle$ need not refer to a single qubit state but rather a qubit register storing a binary encoding of $0$.  The differences between these two notations can is usually clear within the context it is used.  This convention is useful for simplifying the first example which can be written in any of the following ways
$$
\begin{bmatrix}1 \\\\  0 \end{bmatrix}\otimes \cdots \otimes\begin{bmatrix}1 \\\\  0 \end{bmatrix} = |0\rangle \otimes \cdots \otimes |0\rangle= |0\cdots 0\rangle = |0\rangle^{\otimes n} = |0\rangle.
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
|0\rangle \langle 0| = \begin{bmatrix}1\\\\ 0 \end{bmatrix}\begin{bmatrix}1&0 \end{bmatrix}= \begin{bmatrix}1 &0\\\\ 0 &0\end{bmatrix} \qquad |1\rangle \langle 1| = \begin{bmatrix}0\\\\ 1 \end{bmatrix}\begin{bmatrix}0&1 \end{bmatrix}= \begin{bmatrix}0 &0\\\\ 0 &1\end{bmatrix}.
  $$
  Such ketbras are often called projectors because they project a quantum state onto a fixed value.  Since these operations are not unitary (and do not even preserve the norm of a vector), it should come as no surprise that a quantum computer cannot deterministically apply a projector.  However projectors do a beautiful job of describing the action that measurement has on a quantum state.  For example, if we measure a state $|\psi \rangle$ to be $0$ then the resulting transformation that the state experiences as a result of the measurement is
  $$|\psi \rangle \rightarrow \frac{(|0\rangle \langle 0|)|\psi\rangle}{|\langle 0|\psi\rangle|}= |0\rangle,$$
  as one expects if you were to measure the state and find it to be $|0\rangle$.  Again to reiterate, such projectors cannot be applied on a state in a quantum computer deterministically.  Instead, they can at best be applied randomly with the result $|0\rangle$ appearing with some fixed probability.  The probability of such a measurement succeeding can be written as the expectation value of the quantum projector in the state
  $$
\langle \psi| (|0\rangle \langle 0|)|\psi\rangle = |\langle \psi|0\rangle|^2,
  $$
  which illustrates that projectors simply give a new way of expressing the measurement process.

If instead we consider measuring the first qubit to be $1$ of a multi-qubit state then we can also describe this process conveniently using projectors and Dirac notation:
$$
P(\text{outcome of measuring first qubit = 1})= \langle\psi|\left(|1\rangle\langle{1}|\otimes \boldone^{\otimes n-1}\right) |\psi\rangle.
$$
Here the identity matrix can be conveniently written in Dirac notation as
$$
\boldone = |0\rangle \langle 0|+|1\rangle \langle 1|= \begin{bmatrix}1&0\\\\ 0&1 \end{bmatrix}.
$$
For the case where there are two-qubits the projector can be expanded as $|1\rangle \langle 1| \otimes \boldone = |1\rangle\langle 1 \otimes (|0\rangle \langle 0|+|1\rangle \langle 1|)= |10\rangle\langle 10| + |11\rangle\langle 11|$.  We can then see that this is consistent with the discussion from the discussion about measurement likelihoods for multiqubit states using column-vector notation:
$$
P(\text{outcome of measuring first qubit = 1})= \psi^\dagger (e_{10}e_{10}^\dagger + e_{11}e_{11}^\dagger)\psi = |e_{10}^\dagger \psi|^2 + |e_{11}^\dagger \psi|^2,
$$
which matches our discussion from the multi-qubit measurement section.  The generalization though of this result to the multi-qubit case is slightly more straight forward to express using Dirac notation than column-vector notation, but it is entirely equivalent to the previous treatment.

  The other such operator that is useful to express in this language is a state operator.  A state operator for a quantum state vector takes the form $\rho = |\psi\rangle \langle \psi|$.  This concept of representing the state as a matrix, rather than a vector, is often convenient because it gives a convenient way of representing probability calculations but also allows one to describe both statistical uncertainty as well as quantum uncertainty within the same formalism.  These general quantum state operators, rather than vectors, are ubiquitous in some areas of quantum computing but are not necessary to understand the basics of the field.  For the interested reader, we recommend reading one of the reference books provided in the further reading section.

  A final point that is worth raising about quantum notation.  While at the onset of this document we mentioned that the quantum state is the fundamental object of quantum computing.  It may then come as a surprise that in Q# there is no notion of a quantum state.  Instead, all states are described only by the circuit used to prepare them.  The previous example is an excellent illustration of this.  Rather than expressing a uniform superposition over every quantum bit string in a register, we can represent the result as $H^{\otimes n} |{0}\rangle$.  This exponentially shorter description of the state not only has the advantage that we can classically reason about it but it also because it concisely gives the operations needed to be propagated through the software stack to implement the algorithm.  For this reason, Q# is designed to emit gate sequences rather than quantum states; however, at a theoretical level the two perspectives are equivalent.

## Pauli Measurements

  In all the previous discussion, we focused on computational basis measurements but there are other common measurements that occur in quantum computing that can be inconvenient from a notational perspective to express in terms of computational basis measurements.  The most common set of these measurements are Pauli-measurements.  In such cases, it is common to discuss measuring a Pauli-operator which in general is an operator such as $X,Y,Z$ or $Z\otimes Z, X\otimes X, X\otimes Y$ and so forth.  Discussing measurement in terms of Pauli operations is especially common in the subfield of quantum error correction and in Q# we have taken a similar convention and as such we need to explain this alternative view of measurements.

  Before delving into the details of how to think of a Pauli measurement, it is useful to think about what measuring a single qubit inside a quantum does to the quantum state.  Imagine that we have an $n$--qubit quantum state then measuring one qubit immediately rules out half of the $2^n$ possibilities that state could be in.  In other words, the measurement projects the quantum state onto one or two half-spaces.  We can generalize the way we think about measurement to reflect this.

  In order to concisely identify these subspaces, we need a language for describing them.  One way to do this is to describe the two subspaces by specifying them through a matrix that just has two unique eigenvalues, which are taken by convention to be $\pm 1$.  The simplest example of this is 
  $$
Z= \begin{bmatrix}1&0\\\\ 0&-1\end{bmatrix}
  $$
The Pauli-$Z$ matrix clearly has two eigenvectors $\ket{0}$ and $\ket{1}$ with eigenvalues $\pm 1$.  Thus if we measure the qubit and obtain $\ket{0}$ then we are in the $+1$ eigenspace (the set of all vectors that are formed of sums of  eigenvectors with only positive or only negative eigenvalues) of the operator and if measure $\ket{1}$ then we are in the $-1$ eigenspace of $Z$.  This process is referred to in the language of Pauli measurements as measuring Pauli-$Z$ and it is entirely equivalent to performing a computational basis measurement.

Of course any $2\times 2$ matrix that is a unitary transformation of $Z$ also satisfies this criteria.  This is to say that we could also consider matrix $A=U^\dagger Z U$, for any unitary matrix $U$, to give a matrix that defines the two outcomes of a measurement in its $\pm 1$ eigenvectors.  The notation of Pauli measurements references this by identifying $X,Y,Z$ measurements as equivalent measurements that one could do to gain information from a qubit.  These measurements are given below for convenience.
$$
\begin{array}{|c|c|}
\hline
\text{Pauli Measurement} & U\\\\ 
\hline
Z & \boldone\\\\ 
X & H\\\\ 
Y & HS^\dagger\\\\ 
\hline
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

As before, any unitary transformation of such matrices also describes two half-spaces labeled by $\pm 1$ eigenvalues.  For example, $X\otimes X = H\otimes H(Z\otimes Z)H\otimes H$  from the identity that $Z=HXH$.  Similar to the one-qubit case, all two qubit Pauli-measurements can be written as either $U^\dagger (Z\otimes \boldone) U $ for $4\times 4$ unitary matrices $U$.  We enumerate the transformations in the following table where we introduce for convenience the swap gate which swaps qubits $0$ and $1$: $\text{SWAP}=\text{CNOT}\_{01}\text{CNOT}\_{10}\text{CNOT}\_{01}$:

$$
\begin{array}{|c|c|}
\hline
\text{Pauli Measurement} & U\\\\ 
\hline
Z\otimes \boldone & \boldone\otimes \boldone\\\\ 
X\otimes \boldone & H\otimes \boldone\\\\ 
Y\otimes \boldone & HS^\dagger\otimes \boldone\\\\ 
\boldone \otimes Z & \text{SWAP}\\\\ 
\boldone \otimes X & (H\otimes \boldone)\text{SWAP}\\\\ 
\boldone \otimes Y & (HS^\dagger\otimes \boldone)\text{SWAP}\\\\ 
\hline
\end{array}
\qquad
\begin{array}{|c|c|}
\hline
\text{Pauli Measurement} & U\\\\ 
\hline
Z\otimes Z & \mathrm{CNOT}_{10}\\\\ 
X\otimes Z & \mathrm{CNOT}_{10}(H\otimes \boldone)\\\\ 
Y\otimes Z & \mathrm{CNOT}_{10}(HS^\dagger\otimes \boldone)\\\\ 
Z\otimes X & \mathrm{CNOT}_{10}(\boldone\otimes H)\\\\ 
X\otimes X & \mathrm{CNOT}_{10}(H\otimes H)\\\\ 
Y\otimes X & \mathrm{CNOT}_{10}(HS^\dagger\otimes H)\\\\ 
\hline
\end{array}
$$
$$
\begin{array}{|c|c|}
\hline
\text{Pauli Measurement} & U\\\\ 
\hline
Z\otimes Y & \mathrm{CNOT}_{10}(\boldone \otimes HS^\dagger)\\\\ 
X\otimes Y & \mathrm{CNOT}_{10}(H\otimes HS^\dagger)\\\\ 
Y\otimes Y & \mathrm{CNOT}_{10}(HS^\dagger\otimes HS^\dagger)\\\\ 
\\\\ 
\\\\ 
\\\\ 
\hline
\end{array}
$$
Here the gate $\mathrm{CNOT}_{10}$ appears for the following reason.  Each Pauli measurement that does not include the $\boldone$ matrix is equivalent up to a unitary to $Z\otimes Z$ by the above reasoning.  The eigenvalues of $Z\otimes Z$ only depend on the parity of the qubits that comprise each computational basis vector and the controlled-not operations that appear in this list serve to compute this parity and store it in the first bit.  Then once the first bit is measured, we can recover the identity of the resultant half-space which is equivalent to measuring the Pauli operator.

One additional note, while it may be tempting to assume that measuring $Z\otimes Z$ is the same as measuring $Z\otimes \boldone$ and then $\boldone \otimes Z$ this assumption would be false.  The reason why is that measuring $Z\otimes Z$ projects the quantum state into either the $+1$ or $-1$ eigenstate of these operators.  Measuring $Z\otimes \boldone$ and then $\boldone \otimes Z$ projects the quantum state vector first onto a half space of $Z\otimes \boldone$ and then onto a half space of $\boldone \otimes Z$.  As there are four computational basis vectors, performing both measurements reduces the state to a quarter-space and hence reduces it to a single computational basis vector.

Another way of looking at measuring tensor products of Paulis such as $X\otimes X$ or $Z\otimes Z$ is that these measurements let you look at information stored in the correlations between the two qubits.  Measuring $X\otimes \boldone$ lets you look at information that is locally stored in the first qubit.  While both types of measurements are equally valuable in quantum computing, the former illuminates the power of quantum computing better because it reveals that in quantum computing often the information you wish to learn is not stored in any single qubit but rather it is stored non-locally in all the qubits at once and only by looking at it through a joint measurement with $Z\otimes Z$ does this information become manifest.

Arbitrary Pauli operators such as $X\otimes Y \otimes Z \otimes \boldone$ can also be measured.  All such tensor products of Pauli operators have only two eigenvalues $\pm 1$ and both eigenspaces constitute half-spaces of the entire vector space.  Thus they coincide with the requirements stated above.  

In Q#, such measurements return $j$ if the measurement yields a result in the eigenspace of sign $(-1)^j$.  Having this as a built in feature in Q# is helpful because measuring such operators requires long chains of controlled-not gates and basis transformations to describe the diagonalizing $U$ gate needed to express the operation as a tensor product of $Z$ and $\boldone$.  By simply being able to specify that you wish to do one of these pre-defined measurements, you don't need to worry about how to transform your basis such that a computational basis measurement provides the necessary information.  Q# handles all the necessary basis transformations for you automatically.

## The No Cloning Theorem
Quantum information is powerful.  It enables us to do amazing things such as factor numbers exponentially faster than the best known classical algorithms, or simulate correlated electron systems that require exponential cost to simulate accurately.  However, there are limitations to the power of quantum computing.  One such limitation is given by the No-Cloning Theorem.

The No-Cloning Theorem is aptly named.  It disallows cloning of generic quantum states by a quantum computer.  The proof of the theorem is remarkably straight forward.  While a full proof of the no-cloning theorem is a little too technical for our discussion here, the proof of the theorem in the case where the quantum computer in question has no additional ancilla bits to use to potentially aid the cloning process.  For such a quantum computer, the cloning operation must be a unitary matrix because all legal quantum operations are measurement and measurement would corrupt the quantum states.  This unitary matrix must have the property that
$$
U\ket{\psi}\ket{0}=\ket{\psi}\ket{\psi},
$$
for any state $\ket{\psi}$.  The linearity property of matrix multiplication then implies that that for any quantum second state $\ket{\phi}$
$$
U\left[\frac{1}{\sqrt{2}}\left(\ket{\phi}+\ket{\psi} \right)\right]=\frac{1}{\sqrt{2}}\left(\ket{\phi}\ket{\phi}+\ket{\psi}\ket{\psi}\right)\ne \left(\frac{1}{\sqrt{2}}\left(\ket{\phi}+\ket{\psi} \right)\right)\otimes\left(\frac{1}{\sqrt{2}}\left(\ket{\phi}+\ket{\psi} \right)\right).
$$
This provides the fundamental intuition behind the No-Cloning-Theorem, that any device that copies an unknown quantum state must induce errors on at least some of the states it copies.  While the key assumption that the cloner acts linearly on the input state can be violated through the addition of ancilla and measurement of the ancilla qubits, such interactions also leak information about the system through the measurement statistics and prevent exact cloning in such cases as well.  For a more complete proof of the No-Cloning-Theorem please see the reference texts recommended at the end of the documentation.

The No-Cloning Theorem is important for qualitative understanding of quantum computing because if you could clone quantum states inexpensively then you would be granted with a near-magical ability to learn from quantum states.  Indeed, you could violate Heisenberg's vaunted uncertainty principle with this.  Alternatively, you could use an optimal cloner to take a single sample from a complex quantum distribution and learn everything you could possibly learn about that distribution from just one sample.  This would be like you flipping a coin and observing heads and then upon telling a friend about the result having them respond "Ah the distribution of that coin must be Bernoulli with $p=0.512643\ldots$!"  Such a statement would be non-sensical because one bit of information (the heads outcome) simply cannot provide the many bits of information needed to encode the distribution without substantial prior information.  Similarly, without prior information we cannot perfectly clone a quantum state just as we cannot prepare an ensemble of such coins without knowing $p$.

Information is not free in quantum computing.  Each qubit measured gives a bit of information, and the No-Cloning theorem shows that there is no backdoor that can be exploited to get around the fundamental tradeoff between information gained about the system and the disturbance invoked upon it.

