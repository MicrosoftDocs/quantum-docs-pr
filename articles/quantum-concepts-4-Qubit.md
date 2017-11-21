---
# Mandatory fields. See more on aka.ms/skyeye/meta.
title: The qubit | Microsoft Docs 
description: The qubit
services: service-name-with-dashes-AZURE-ONLY 
keywords: Don’t add or edit keywords without consulting your SEO champ.
author: QuantumWriter
ms.author: MSFT-alias-person-or-DL
ms.date: 10/09/2017
ms.topic: article-type-from-white-list
uid: microsoft.quantum.concepts.qubit
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

# The qubit
Just as bits are the fundamental object of information in classical computing, *qubits* (quantum bits) are the fundamental object of information in quantum computing.  To understand this correspondence, lets look at the simplest example: a single qubit. 

## Representing a qubit ##

While a bit, or binary digit, can have value either $0$ or $1$, a qubit can have a value that is either of these or a quantum superposition of $0$ and $1$.
The state of a single qubit can be described by a two-dimensional column vector of unit norm, that is, the magnitude squared of its entries must sum to $1$. This vector, called the quantum state vector, holds all the information needed to describe the one-qubit quantum system just as a single bit holds all of the information needed to describe the state of a binary variable.

Any two-dimensional column vector of real or complex numbers with norm $1$ represents a possible quantum state held by a qubit. Thus $\begin{bmatrix} \alpha \\\\  \beta \end{bmatrix}$ represents a qubit state if $\alpha$ and $\beta$ are complex numbers satisfying $|\alpha|^2 + |\beta|^2 = 1$. Some examples of valid quantum state vectors representing qubits include 

$$\begin{bmatrix} 1 \\\\  0 \end{bmatrix}, \begin{bmatrix} 0 \\\\  1 \end{bmatrix}, \begin{bmatrix} \frac{1}{\sqrt{2}} \\\\  \frac{1}{\sqrt{2}} \end{bmatrix}, \begin{bmatrix} \frac{1}{\sqrt{2}} \\\\  \frac{-1}{\sqrt{2}} \end{bmatrix}, \text{ and }\begin{bmatrix} \frac{1}{\sqrt{2}} \\\\  \frac{i}{\sqrt{2}} \end{bmatrix}.$$

The quantum state vectors $\begin{bmatrix} 1 \\\\  0 \end{bmatrix}$ and $\begin{bmatrix} 0 \\\\  1 \end{bmatrix}$ take a special role.  These two vectors form a basis for the vector space that describes the qubit's state.  This means that any quantum state vector can be written as a sum of these basis vectors. Specifically, the vector $\begin{bmatrix} x \\\\  y \end{bmatrix}$ can be written as $x \begin{bmatrix} 1 \\\\ 0 \end{bmatrix} + y \begin{bmatrix} 0 \\\\  1 \end{bmatrix}$.  While any rotation of these vectors would serve as a perfectly valid basis for the qubit, we choose to privilege this one, by calling it the *computational basis*.  

We take these two quantum states to correspond to the two states of a classical bit, namely $0$ and $1$.  The standard convention is to choose

$$0\equiv \begin{bmatrix} 1 \\\\  0 \end{bmatrix}\qquad 1 \equiv \begin{bmatrix} 0 \\\\  1 \end{bmatrix}$$

although the opposite choice could equally well be taken.  Thus, out of the infinite number of possible single-qubit quantum state vectors, only two correspond to states of classical bits; all other quantum states do not.

## Measuring a qubit
Now that we know how to represent a qubit, we can gain some intuition for what these states represent by discussing the concept of *measurement*. A measurement corresponds to the informal idea of “looking” at a qubit, which immediately collapses the quantum state to one of the two classical states  $\begin{bmatrix} 1 \\\\  0 \end{bmatrix}$ or  $\begin{bmatrix} 0 \\\\  1 \end{bmatrix}$. When a qubit given by the quantum state vector  $\begin{bmatrix} \alpha \\\\  \beta \end{bmatrix}$ is measured, we obtain the outcome $0$ with probability $|\alpha|^2$ and the outcome $1$  with probability $|\beta|^2$. On outcome $0$, the qubit's new state is $\begin{bmatrix} 1 \\\\  0 \end{bmatrix}$; on outcome $1$ its state is $\begin{bmatrix} 0 \\\\  1 \end{bmatrix}$. Note that these probabilities sum up to $1$ because of the normalization condition $|\alpha|^2 + |\beta|^2 = 1$.

The properties of measurement also mean that the overall sign of the quantum state vector is irrelevant. Negating a vector is equivalent to $\alpha \rightarrow -\alpha$ and $\beta \rightarrow -\beta$.  Because the probability of measuring $0$ and $1$ depends on the magnitude squared of the terms, inserting such signs does not change the probabilities whatsoever.  Such phases are commonly called ``global phases'' and more generally can be of the form $e^{i \phi}$ rather than just $\pm 1$.

A final important property of measurement is that it does not necessarily damage all quantum state vectors.  If we start with a qubit in the state $\begin{bmatrix} 1 \\\\  0 \end{bmatrix}$, which corresponds to the classical state $0$, measuring this state will always yield the outcome $0$ and leave the quantum state unchanged.  In this sense, if we only have classical bits (i.e., qubits that are either $\begin{bmatrix}1 \\\\  0 \end{bmatrix}$ or $\begin{bmatrix}0 \\\\  1 \end{bmatrix}$) then measurement does not damage the system.  This means that we can replicate classical data and manipulate it on a quantum computer just as one could do on a classical computer.  The ability, however, to store information in both states at once is what elevates quantum computing beyond what is possible classically and further robs quantum computers of the ability to copy quantum data indiscriminately.
<!--- TODO: need to link in with no-cloning once its moved. --->

## Visualizing qubits and transformations using the Bloch sphere ##

Qubits may also be pictured in $3$D using the *Bloch sphere* representation.  The Bloch sphere gives a way of describing a single-qubit quantum state (which is a two-dimensional complex vector) as a three-dimensional real-valued vector.  This is important because it allows us to visualize single-qubit states and thereby develop reasoning that can be invaluable in understanding multi-qubit states (where sadly the Bloch sphere representation breaks down).  The bloch sphere can be visualized as follows:

<!--- ![](.\media\bloch.svg){ width=50% } --->
![Bloch sphere](./media/concepts_bloch.png)

The arrows in this diagram show the direction in which the quantum state vector is pointing and each transformation of the arrow can be thought of as a rotation about one of the cardinal axes.
While thinking about a quantum computation as a sequence of rotations is a powerful intuition, it is challenging to use this intuition to design and describe algorithms.  Q# alleviates this issue by providing a language for describing such rotations.

## Single-qubit operations

Quantum computers process data by applying a universal set of quantum gates that can emulate any rotation of the quantum state vector.  This notion of universality is akin to the notion of universality for traditional (i.e., classical) computing where a gate set is considered to be universal if every transformation of the input bits can be performed using a finite length circuit. 

In quantum computing, the valid transformations that we are allowed to perform on a qubit are unitary transformations and measurement.
The *adjoint operation* or the complex conjugate transpose is of crucial importance to quantum computing because it is needed to invert quantum transformations.  Q# reflects this by providing methods to automatically compile gate sequences to their adjoint, which saves the programmer from having to hand code adjoints in many cases.

There are only four functions that map one bit to one bit on a classical computer.  In contrast, there are an infinite number of unitary transformations on a single qubit on a quantum computer. Therefore, no finite set of primitive quantum operations, called gates, can exactly replicate the infinite set of unitary transformations allowed in quantum computing.  This means, unlike classical computing, it is impossible for a quantum computer to implement every possible quantum program exactly using a finite number of gates.  Thus quantum computers cannot be universal in the same sense of classical computers.  As a result, when we say that a set of gates is *universal* for quantum computing we actually mean something slightly weaker than we mean with classical computing.
For universality, we require that a quantum computer only *approximate* every unitary matrix within a finite error using a finite length gate sequence.
In other words, a set of gates is a universal gate set if any unitary transformation can be approximately written as a product of gates from this set. We require that for any prescribed error bound, there exist gates $G_{1}, G_{2},\ldots, G_N$ from the gate set such that

$$
G_N G_{N-1} \cdots G_2 G_1 \approx U.
$$

Note that because the convention for matrix multiplication is to multiply from right to left the first gate operation in this sequence, $G_N$, is actually the last one applied to the quantum state vector.  More formally, we say that such a gate set is universal if for every error tolerance $\epsilon>0$ there exists $G_1,\ldots, G_N$ such that  the distance between $G_N\ldots G_1$ and $U$ is at most $\epsilon$. Ideally the value of $N$ needed to reach this distance of $\epsilon$ should scale poly-logarithmically with $1/\epsilon$.

What does such a universal gate set look like in practice?  The simplest such universal gate set for single-qubit gates consists of only two gates: the Hadamard gate $H$ and the so-called $T$-gate (also known as the $\pi/8$ gate):

$$
H=\frac{1}{\sqrt{2}}\begin{bmatrix} 1 & 1 \\\\  1 &-1  \end{bmatrix},\qquad T=\begin{bmatrix} 1 & 0 \\\\  0 & e^{i\pi/4} \end{bmatrix}.
$$

However, for practical reasons related to quantum error correction it can be more convenient to consider a larger gate set, namely one that can be generated using $H$ and $T$.  We can classify the quantum gates into two categories: Clifford gates and the $T$-gate.  This subdivision is useful because in many quantum error correction schemes the so-called Clifford gates are easy to implement, that is they require very few resources in terms of operations and qubits to implement fault tolerantly, whereas non-Clifford gates are quite costly when requiring fault tolerance.  The standard set of single-qubit Clifford gates, [included by default in Q#](./libraries/prelude.md), include

$$
H=\frac{1}{\sqrt{2}}\begin{bmatrix} 1 & 1 \\\\  1 &-1  \end{bmatrix} ,\qquad S =\begin{bmatrix} 1 & 0 \\\\  0 & i \end{bmatrix}= T^2,\qquad X=\begin{bmatrix} 0 &1 \\\\  1& 0 \end{bmatrix}= HT^4H,
$$

$$
Y = \begin{bmatrix} 0 & -i \\\\  i & 0 \end{bmatrix}=T^2HT^4  HT^6, \qquad Z=\begin{bmatrix}1&0\\\\ 0&-1 \end{bmatrix}=T^4.
$$

Here the operations $X$, $Y$ and $Z$ are used especially frequently and are named *Pauli operators* after their creator Wolfgang Pauli.  Together with the non-Clifford gate (the $T$-gate), these operations can be composed to approximate any unitary transformation on a single qubit.

As an example of how unitary transformations can be built from these primitives, the three transformations pictured in the Bloch spheres above correspond to the gate sequence $\begin{bmatrix} 1 \\\\  0 \end{bmatrix} \mapsto HZH \begin{bmatrix} 1 \\\\  0 \end{bmatrix} = \begin{bmatrix} 0 \\\\  1 \end{bmatrix}$.  

While the previous constitute the most popular primitive gates for describing operations on the logical level of the stack (think of the logical level as the level of the quantum algorithm), it is often convenient to consider less basic operations at the algorithmic level, for example operations closer to a function description level.  Fortunately, Q# also has methods available for implementing higher-level unitaries, which in turn allows high-level algorithms to be implemented without explicitly decomposing everything down to Clifford and $T$-gates.  

The simplest such primitive is the single qubit-rotation.  Three single-qubit rotations are typically considered: $R_x$, $R_y$ and $R_z$.  To visualize the action of the rotation $R_x(\theta)$, for example, imagine pointing your right thumb along the direction of the $x$-axis of the Bloch sphere and rotating the vector with your hand through an angle of $\theta/2$ radians.  This confusing factor of $2$ arises from the fact that orthogonal vectors are $180^\circ$ apart when plotted on the Bloch sphere, yet are actually $90^\circ$ degrees apart geometrically.   The corresponding unitary matrices are:

$$
R_z(\theta) = \begin{bmatrix} e^{-i\theta/2} & 0\\\\  0& e^{i\theta/2} \end{bmatrix},\qquad R_x(\theta) = H R_z(\theta) H, \qquad R_y(\theta) = SHR_z(\theta)HS^\dagger.
$$

Just as any three rotations can be combined together to perform an arbitrary rotation in three dimensions, it can be seen from the Bloch sphere representation that any unitary matrix can be written as a sequence of three rotations as well.  Specifically, for every unitary matrix $U$ there exists $\alpha,\beta,\gamma,\delta$ such that $U= e^{i\alpha} R_x(\beta)R_z(\gamma)R_x(\delta)$.  Thus $R_z(\theta)$ and $H$ also form a universal gate set although it is not a discrete set because $\theta$ can take any value. For this reason, and due to applications in quantum simulation, such continuous gates are crucial for quantum computation, especially at the quantum algorithm design level.  Ultimately, to achieve fault-tolerant hardware implementation, they will ultimately be compiled into discrete gate sequences that closely approximate these rotations.
