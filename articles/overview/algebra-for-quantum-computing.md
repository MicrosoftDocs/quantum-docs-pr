---
title: Linear algebra for quantum computing
description: Learn what basic linear algebra concepts are needed to understand quantum computing
author: bradben
ms.author:  v-benbra
ms.date: 5/5/2020
ms.topic: overview
uid: microsoft.quantum.overview.algebra
no-loc: ['Q#', '$$v']
---

# Linear algebra for quantum computing

Linear algebra is the language of quantum computing. Although you don’t need to know it to implement or write quantum programs, it is widely used to describe qubit states, quantum operations, and to predict what a quantum computer will do in response to a sequence of instructions.

Just like being familiar with the [basic concepts of quantum physics](xref:microsoft.quantum.overview.understanding) can help you understand quantum computing, knowing some basic linear algebra can help you understand how quantum algorithms work. At the least, you’ll want to be familiar with **vectors** and **matrix multiplication**. If you need to refresh your knowledge of these algebra concepts, here are some tutorials that cover the basics:

- [Jupyter notebook tutorial on linear algebra](https://github.com/microsoft/QuantumKatas/tree/main/tutorials/LinearAlgebra)
- [Jupyter notebook tutorial on complex arithmetic](https://github.com/microsoft/QuantumKatas/tree/main/tutorials/ComplexArithmetic)
- [Linear Algebra for Quantum Computation](https://cds.cern.ch/record/1522001/files/978-1-4614-6336-8_BookBackMatter.pdf)
- [Fundamentals of Linear Algebra](https://www.math.ubc.ca/~carrell/NB.pdf)
- [Quantum Computation Primer](https://www.codeproject.com/Articles/5155638/Quantum-Computation-Primer-Part-1#exploring-quantum-superposition)

## Vectors and matrices in quantum computing

In the topic [Understanding quantum computing](xref:microsoft.quantum.overview.understanding), you saw that a qubit can be in a state of 1 or 0 or a superposition or both. Using linear algebra, the state of a qubit is described as a vector and is represented by a single column **matrix** $\begin{bmatrix} a \\\\  b \end{bmatrix}$. It is also known as a **quantum state vector** and must meet the requirement that $|a|^2 + |b|^2 = 1$.  

The elements of the matrix represent the probability of the qubit collapsing one way or the other, with $|a|^2$ being the probability of collapsing to zero, and $|b|^2$ being the probability of collapsing to one. The following matrices all represent valid quantum state vectors:

$$\begin{bmatrix} 1 \\\\  0 \end{bmatrix}, \begin{bmatrix} 0 \\\\  1 \end{bmatrix}, \begin{bmatrix} \frac{1}{\sqrt{2}} \\\\  \frac{1}{\sqrt{2}} \end{bmatrix}, \begin{bmatrix} \frac{1}{\sqrt{2}} \\\\  \frac{-1}{\sqrt{2}} \end{bmatrix}, \text{ and }\begin{bmatrix} \frac{1}{\sqrt{2}} \\\\  \frac{i}{\sqrt{2}} \end{bmatrix}.$$

In [Quantum computers and quantum simulators](xref:microsoft.quantum.overview.simulators) you also saw that quantum operations are used to modify the state of a qubit.  Quantum operations can also be represented by a matrix. When a quantum operation is applied to a qubit, the two matrices that represent them are multiplied and the resulting answer represents the new state of the qubit after the operation.  

Here are two common quantum operations represented with matrix multiplication.


The [`X` operation](xref:microsoft.quantum.intrinsic.x) is represented by the Pauli matrix $X$,

$$X = \begin{bmatrix}
        0 & 1 \\\\
        1 & 0
    \end{bmatrix},$$
    
and is used to flip the state of a qubit from 0 to 1 (or vice-versa), for example

$$\begin{bmatrix}0 &1\\\\ 1 &0\end{bmatrix}\begin{bmatrix} 1 \\\\  0 \end{bmatrix} = \begin{bmatrix} 0 \\\\  1 \end{bmatrix}.$$

The ['H' operation](xref:microsoft.quantum.intrinsic.h) is represented by the Hadamard transformation $H$,

$$H = \dfrac{1}{\sqrt{2}}\begin{bmatrix}1 &1\\\\ 1 &-1\end{bmatrix},$$

 and puts a qubit into a superposition state where it has an even probability of collapsing either way, as shown here

$$\frac{1}{\sqrt{2}}\begin{bmatrix}1 &1\\\\ 1 &-1\end{bmatrix}\begin{bmatrix} 1 \\\\  0 \end{bmatrix}=\frac{1}{\sqrt{2}}\begin{bmatrix} 1 \\\\  1 \end{bmatrix}=\left(\frac{1}{\sqrt{2}}\right)^2=\frac{1}{2}.$$

A matrix that represents a quantum operation has one requirement – it must be a **unitary** matrix. A matrix is unitary if the **inverse** of the matrix is equal to the **conjugate transpose** of the matrix.

## Representing two-qubit states

In the examples above, the state of one qubit was described using a single column matrix $\begin{bmatrix} a \\\\  b \end{bmatrix}$, and applying an operation to it was described by multiplying the two matrices. However, quantum computers use more than one qubit, so how do you describe the combined state of two qubits? 

Remember that each qubit is a vector space, so they can't just be multiplied. Instead, you use a **tensor product**, which is a related operation that creates a new vector space from individual vector spaces, and is represented by the $\otimes$ symbol. For example, the tensor product of two qubit states $\begin{bmatrix} a \\\\  b \end{bmatrix}$ and $\begin{bmatrix} c \\\\  d \end{bmatrix}$ is calculated

$$ \begin{bmatrix} a \\\\  b \end{bmatrix} \otimes \begin{bmatrix} c \\\\  d \end{bmatrix} =\begin{bmatrix} a \begin{bmatrix} c \\\\  d \end{bmatrix} \\\\ b \begin{bmatrix}c \\\\  d \end{bmatrix} \end{bmatrix} = \begin{bmatrix} ac \\\\  ad \\\\  bc \\\\  bd \end{bmatrix}. $$

The result is a four-dimensional matrix, with each element representing a probability. For example, $ac$ is the probability of the two qubits collapsing to 0 and 0, $ad$ is the probability of 0 and 1, and so on. 

Just as a single qubit state $\begin{bmatrix} a \\\\  b \end{bmatrix}$ must meet the requirement that $|a|^2 + |b|^2 = 1$ in order to represent a quantum state, a two-qubit state $\begin{bmatrix} ac \\\\  ad \\\\  bc \\\\  bd \end{bmatrix}$ must meet the requirement that $|ac|^2 + |ad|^2 + |bc|^2+ |bd|^2 = 1$.

## Summary

Linear algebra is the standard language for describing quantum computing and quantum physics. Even though the [libraries](xref:microsoft.quantum.libraries) included with the Microsoft Quantum Development Kit will help you run advanced quantum algorithms without diving into the underlying math, understanding the basics will help you get started quickly and provide a solid foundation to build on.

## Next steps

[Install the QDK](xref:microsoft.quantum.install)
