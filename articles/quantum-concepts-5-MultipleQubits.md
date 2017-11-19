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

# Multiple Qubits
While single qubit gates possess some counter-intuitive features, such as the ability to be in more than one state at a given time, if all we had in a quantum computer were single qubit gates then we would have a device with computational power that would be dwarfed by a calculator let alone a classical supercomputer.  The true power of quantum computing only becomes visible as we increase the number of qubits.  This power arises, in part, because the dimension of the vector space that quantum state vectors lie in grows exponentially with the number of qubits.  This means that while a single qubit can be trivially modeled, simulating a fifty qubit quantum computation would arguably push the limits of existing supercomputers.  Increasing the size of the computation by only one additional qubit would make the simulation double the memory required to store the state and roughly double the computational time.  This rapid doubling of computational power is why a quantum computer with a relatively small number of qubits can far surpass the most powerful supercomputers ever built, for some computational tasks.

But why do we have this exponential growth for quantum state vectors?  Our goal in this section is to review the rules used to build multi-qubit states out of single qubit states as well as discuss the gate operations that we need to include in our gate set to form a universal many-qubit quantum computer.  These tools are absolutely necessary for understanding the gate sets that are commonly used in Q# code and also to gain an  intuition about why quantum effects such as entanglement or interference render quantum computing more powerful than classical computing.

## Representing two qubits
The main difference between one and two-qubit states is that two-qubit states are four dimensional rather than two-dimensional.  This happens because the computational basis for two-qubit states is formed by the tensor products of one-qubit states.  For example

$$
00 \equiv \begin{bmatrix}1 \\\\ 0 \end{bmatrix}\otimes \begin{bmatrix}1 \\\\ 0 \end{bmatrix} = \begin{bmatrix}1 \\\\ 0\\\\ 0\\\\ 0 \end{bmatrix}\qquad 01 \equiv \begin{bmatrix}1 \\\\ 0 \end{bmatrix}\otimes \begin{bmatrix}0 \\\\ 1 \end{bmatrix} = \begin{bmatrix}0 \\\\ 1\\\\ 0\\\\ 0 \end{bmatrix}\qquad 10 \equiv \begin{bmatrix}0 \\\\ 1 \end{bmatrix}\otimes \begin{bmatrix}1 \\\\ 0 \end{bmatrix} = \begin{bmatrix}0 \\\\ 0\\\\ 1\\\\ 0 \end{bmatrix}\qquad 11 \equiv \begin{bmatrix}0 \\\\ 1 \end{bmatrix}\otimes \begin{bmatrix}0 \\\\ 1 \end{bmatrix} = \begin{bmatrix}0 \\\\ 0\\\\ 0\\\\ 1 \end{bmatrix}
$$

It is easy to see that more generally the quantum state of $n$ qubits is represented by a unit vector of dimension $2^n$ using this construction.  However, for two qubits the vector

$$
\begin{bmatrix} \alpha_{00} \\\\  \alpha_{01} \\\\  \alpha_{10} \\\\  \alpha_{11} \end{bmatrix}
$$

represents a quantum state on two qubits if $|\alpha_{00}|^2+|\alpha_{01}|^2+|\alpha_{10}|^2+|\alpha_{11}|^2=1$. Just as with single qubits, the quantum state vector of multiple qubits holds all the information needed to describe the system's behavior.

If we are given two separate qubits, one in the state $\begin{bmatrix} \alpha \\\\  \beta \end{bmatrix}$ and the second qubit in state  $\begin{bmatrix} \gamma \\\\  \delta \end{bmatrix}$, the two qubit state corresponding to this is

$$
\begin{bmatrix} \alpha \\\\  \beta \end{bmatrix} \otimes \begin{bmatrix} \gamma \\\\  \delta \end{bmatrix} 
=\begin{bmatrix} \alpha \begin{bmatrix} \gamma \\\\  \delta \end{bmatrix} \\\\ \beta \begin{bmatrix}\gamma \\\\  \delta \end{bmatrix} \end{bmatrix}
= \begin{bmatrix} \alpha\gamma \\\\  \alpha\delta \\\\  \beta\gamma \\\\  \beta\delta \end{bmatrix},
$$

where the operation $\otimes$ is called the tensor product (or Kronecker product) of vectors. 
Note that while we can always take the tensor product of two single-qubit states to form a two-qubit state, not all two-qubit quantum states can be written as the tensor product of two single-qubit states.
For example, there are no states $\psi=\begin{bmatrix} \alpha \\\\  \beta \end{bmatrix}$ and $\phi=\begin{bmatrix} \gamma \\\\  \delta \end{bmatrix}$ such that their tensor product is the state 

$$\psi\otimes \phi = \begin{bmatrix} 1/\sqrt{2} \\\\  0 \\\\  0 \\\\  1/\sqrt{2} \end{bmatrix}.$$ 

Such a two-qubit state, which cannot be written as the tensor product of single-qubit states, is called an ``entangled state'' and the two qubits are said to be entangled.  Loosely speaking, because the quantum state cannot be thought of as a tensor product of single qubit states, the information that the state holds is not confined to either of the qubits individually.  Rather, the information is stored non-locally in the correlations between the two states.  This non-locality of information is one of the major distinguishing features of quantum computing over classical computing and is essential for a number of quantum protocols including quantum teleportation and quantum error correction.

## Measuring two-qubit states ##
Measuring two-qubit states is very similar to single qubit measurements. Measuring the state

$$
    \begin{bmatrix}
        \alpha_{00} \\\\ 
        \alpha_{01} \\\\ 
        \alpha_{10} \\\\ 
        \alpha_{11}
    \end{bmatrix}
$$

yields $00$ with probability $|\alpha_{00}|^2$, $01$ with probability $|\alpha_{01}|^2$, $10$ with probability $|\alpha_{10}|^2$, and $11$ with probability $|\alpha_{11}|^2$. The variables $\alpha_{00}, \alpha_{01}, \alpha_{10},$ and $\alpha_{11}$ were deliberately named to make this connection clear. As before, after the measurement if the outcome is $00$, the quantum state of the two qubit system has collapsed and is now

$$
    00 \equiv
    \begin{bmatrix}
        1 \\\\ 
        0 \\\\ 
        0 \\\\ 
        0
    \end{bmatrix}.
$$

Unlike the single qubit case, you don't need to measure every qubit in quantum computers with two or more qubits.  In cases where you measure a single qubit, the impacts of measurement are subtlely different because they do not collapse the entire state to a computational basis state but rather only one sub-system.  In such cases, measuring only one qubit only collapses one of the subsystems but not all of them.  To see this consider measuring the first qubit of the following state, which is formed by applying the Hadamard transform on two qubits initially set in the "0" state:

$$
\frac{1}{2}\begin{bmatrix}1\\\\ 1\\\\ 1\\\\ 1\end{bmatrix}\mapsto \begin{cases}\text{outcome }=0 & \frac{1}{\sqrt{2}}\begin{bmatrix}1\\\\ 1\\\\ 0\\\\ 0 \end{bmatrix}\\\\ \text{outcome }=1 & \frac{1}{\sqrt{2}}\begin{bmatrix}0\\\\ 0\\\\ 1\\\\ 1 \end{bmatrix}\\\\  \end{cases}.
$$

Both outcomes have $50\%$ probability of occurring.  This happens because the first two components in the quantum state vector correspond to $00$ and $01$ and so if the first qubit is measured to be $1$ then both are inconsistent with the measurement and as such are omitted from the quantum state.  Similarly, if the first qubit is measured to be zero only the bit strings $10$ and $11$ are consistent with this outcome and hence the remainder of the quantum state is possible.  The outcome being $50\%$ probability for both can be intuited from the fact that the initial quantum state vector is invariant under permutation of the component vector.

The mathematical rule for measuring the first, or second qubit is simple.  If we let $e_k$ be the $k^{\rm th}$ computational basis vector and let $S$ be the set of all $e_k$ such that the qubit in question takes the value $1$ for that value of $k$.  For example, if we are interested in measuring the first qubit then $S$ would consist of $e_2\equiv 10$ and $e_3\equiv 11$.  Similarly, if we are interested in the second qubit $S$ would consist of $e_1\equiv 01$ and $e_3 \equiv 11$.  Then the probability of measuring that qubit to be $1$ is for state vector $\psi$

$$
P(\text{outcome}=1)= \sum_{k \text{ in the set } S}\psi^\dagger e_k e_k^\dagger \psi.
$$

Since each qubit measurement can only yield $0$ or $1$, the probability of measuring $0$ is simply $1-P(\text{outcome}=1)$.  This is why we only explicitly give a formula for the probability of measuring $1$.

The action that such a measurement has on the state can be expressed mathematically as

$$
\psi \mapsto \frac{\sum_{k \text{ in the set } S} e_k e_k^\dagger \psi}{\sqrt{P(\text{outcome}=1)}}.
$$

The cautious reader may worry about what happens when the probability of the measurement is zero.  While the resultant state is technically undefined in this case, we never need to worry about such eventualities because the probability is zero!


If we take $\psi$ to be the uniform state vector given above and are interested in measuring the first qubit then 

$$
P(\text{measurement of first qubit}=1) = (\psi^\dagger e_2)(e_2^\dagger \psi)+(\psi^\dagger e_3)(e_3^\dagger \psi)=|e_2^\dagger \psi|^2+|e_3^\dagger \psi|^2.
$$

Note that this is just the sum of two probabilities that would be expected for measuring the results $10$ and $11$ were all the qubits to be measured.
For our example, this evaluates to

$$
\frac{1}{4}\left|\begin{bmatrix}0&0&1&0\end{bmatrix}\begin{bmatrix}1\\\\ 1\\\\ 1\\\\ 1\end{bmatrix} \right|^2+\frac{1}{4}\left|\begin{bmatrix}0&0&0&1\end{bmatrix}\begin{bmatrix}1\\\\ 1\\\\ 1\\\\ 1\end{bmatrix} \right|^2=\frac{1}{2}.
$$

which perfectly matches what our intuition tells us the probability should be.  Similarly, the state can be written as

$$
\frac{\frac{e_2}{2}+\frac{e_3}{2}}{\sqrt{\frac{1}{2}}}=\frac{1}{\sqrt{2}}\begin{bmatrix} 0\\\\ 0\\\\ 1\\\\ 1\end{bmatrix}
$$

again in accordance with our intuition.

## Two-qubit Operations
As in the single-qubit case, any unitary transformation is a valid operation on qubits. In general, a unitary transformation on $n$ qubits is a matrix $U$ of size $2^n \times 2^n$ (so that it acts on vectors of size $2^n$), such that 

$$
U^{-1} = U^\dagger	=
	\begin{bmatrix}
	ae\ af\ be\ bf \\\\
	ag\ ah\ bg\ bh \\\\
	ce\ cf\ de\ df \\\\
	cg\ ch\ dg\ dh
	\end{bmatrix}
$$

For example, the CNOT (controlled NOT) gate is a commonly used two-qubit gate and is represented by the following unitary matrix:

$$
\mathrm{CNOT} = \begin{bmatrix} 1\ 0\ 0\ 0  \\\\  0\ 1\ 0\ 0 \\\\  0\ 0\ 0\ 1 \\\\  0\ 0\ 1\ 0 \end{bmatrix}
$$

The CNOT gate corresponds to the following classical operation: Look at the first bit, if it is $0$, do nothing, and if it is $1$ then negate the second bit.   In cases when more than two qubits are present, or a CNOT gate that is controlled by the second qubit is needed, the notation $\text{CNOT}_{ij}$ is used to denote the controlled-not gate controlled on the $i^{\rm th}$ qubit and with the $j^{\rm th}$ qubit as its target (where zero is the first qubit label).  For example,

$$
\mathrm{CNOT}_{01} = \begin{bmatrix} 1\ 0\ 0\ 0  \\\\  0\ 1\ 0\ 0 \\\\  0\ 0\ 0\ 1 \\\\  0\ 0\ 1\ 0 \end{bmatrix}\qquad\mathrm{CNOT}_{10} = \begin{bmatrix} 1\ 0\ 0\ 0  \\\\  0\ 0\ 0\ 1 \\\\  0\ 0\ 1\ 0 \\\\  0\ 1\ 0\ 0 \end{bmatrix}
$$

We can also form two qubit gates by applying single-qubit gates on both qubits. For example, if we apply the gates 

$$
\begin{bmatrix}
a\ b\\\\ c\ d
\end{bmatrix}
$$

and

$$\begin{bmatrix}
e\ f\\\\ g\ h
\end{bmatrix}
$$

to the first and second qubits, this is equivalent to applying the two-qubit unitary given by their tensor product

$$
\begin{bmatrix}
a\ b\\\\ c\ d
\end{bmatrix}
\otimes 
\begin{bmatrix}
e\ f\\\\ g\ h
\end{bmatrix}
$$

Thus we can form two-qubit gates by taking the tensor product of single-qubit gates we know. Some examples of two qubit gates include $H \otimes H$, $X \otimes \mathbb{1}$, and $X \otimes Z$.

Note that while any two single-qubit gates define a two-qubit gate by taking their tensor product, the converse is not true. Not all two-qubit gates can be written as the tensor product of single-qubit gates. One example of such a gate is the CNOT gate. Such a gate is called an entangling gate.

There are infinitely many unitary matrices on two qubits, so we cannot hope to have all possible gates as elementary operations on our quantum computer. Instead, we choose a small set of elementary gates that form a universal gate set. As before, a gate set is universal if any unitary matrix can be written as a product of gates from this set to arbitrary precision.
One example of a universal gate set is the Hadamard gate, the T gate, and the CNOT gate. By taking products of these gates, we can approximate any unitary matrix on two qubits.

## Many-qubit systems
We follow the exact same patterns explored in the two-qubit case to build many-qubit quantum states from smaller systems.  Such states are built by forming tensor products of smaller states.  For example, consider encoding the bit string $1011001$ in a quantum computer.  We can encode this as

$$
1011001 \equiv \begin{bmatrix} 0 \\\\  1 \end{bmatrix}\otimes \begin{bmatrix} 1 \\\\  0 \end{bmatrix}\otimes \begin{bmatrix} 0 \\\\  1 \end{bmatrix}\otimes \begin{bmatrix} 0 \\\\  1 \end{bmatrix} \otimes \begin{bmatrix} 1 \\\\  0 \end{bmatrix}\otimes \begin{bmatrix} 1 \\\\  0 \end{bmatrix}\otimes \begin{bmatrix} 0 \\\\  1 \end{bmatrix}.
$$

Quantum gates work in exactly the same way.  For example, if we wished to apply the $X$ gate to the first qubit and then perform a CNOT between the second and third qubits we would express this transformation as

$$
(X \otimes \mathrm{CNOT}_{12}\otimes \mathbb{1}\otimes \mathbb{1} \otimes \mathbb{1}) \begin{bmatrix} 0 \\\\  1 \end{bmatrix}\otimes \begin{bmatrix} 1 \\\\  0 \end{bmatrix}\otimes \begin{bmatrix} 0 \\\\  1 \end{bmatrix}\otimes \begin{bmatrix} 0 \\\\  1 \end{bmatrix} \otimes \begin{bmatrix} 1 \\\\  0 \end{bmatrix}\otimes \begin{bmatrix} 1 \\\\  0 \end{bmatrix}\otimes \begin{bmatrix} 0 \\\\  1 \end{bmatrix}\equiv 0011001.
$$

Finally, although new gates needed to be added to our gate set to achieve universal quantum computing for two qubit quantum computers, no new gates need to be introduced in the multi-qubit case.  The gates $H$, $T$ and CNOT form a universal gate set on many qubits because any general unitary transformation can be broken into a series of two qubit rotations.  We then can leverage the theory developed for the two-qubit case and use it again here when we have many qubits.

While the linear algebraic notation that we have been using so far can certainly be used to describe many qubit states, it becomes increasingly cumbersome as we grow the states.  The resulting column-vector for the bit string shown above is $128$ dimensional, which makes expressing it formally cumbersome using the notation described previously.  For this reason, in the next section we discuss a  notation that is common in quantum computing and allows us to concisely describe these high-dimensional vectors.
