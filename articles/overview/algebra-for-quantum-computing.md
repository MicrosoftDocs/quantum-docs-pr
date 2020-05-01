---
title: Linear algebra for quantum computing
description: Learn what basic linear algebra concepts are needed to understand quantum computing
author: bradben
ms.author:  bradben
ms.date: 04/22/2020
ms.topic: overview
uid: microsoft.quantum.overview.algebra
---

# Linear algebra for quantum computing

Linear algebra is the language of quantum computing. Although you don’t need to know it to implement or write quantum programs, be aware that it is widely used to describe qubit states, quantum operations, and to predict what a quantum computer will do in response to a sequence of instructions.

Just like the basic concepts of quantum physics, knowing some basic linear algebra can help you understand how quantum computing and quantum algorithms work. At the very least, you’ll want to be familiar with **vectors** and **matrix multiplication**. If you need to refresh your knowledge of these algebra concepts, see these open-source tutorials:

- [Jupyter notebook tutorial on linear algebra](https://github.com/microsoft/QuantumKatas/tree/master/tutorials/LinearAlgebra)
- [Jupyter notebook tutorial on complex arithmetic](https://github.com/microsoft/QuantumKatas/tree/master/tutorials/ComplexArithmetic)

## Vectors and matrices in quantum computing

The state of a qubit, whether it’s 1 or 0 or a superposition of both, is described as a vector and is represented by a single column **matrix** $\begin{bmatrix} a \\\\  b \end{bmatrix}$. It is also known as a **quantum state vector** and must meet the requirement that $|a|^2 + |b|^2 = 1$.  The elements of the matrix represent the probability of the qubit collapsing one way or the other, with $a$ being the probability of collapsing to zero, and $b$ being the probability of collapsing to one. The following matrices all represent valid quantum state vectors:

$$\begin{bmatrix} 1 \\\\  0 \end{bmatrix}, \begin{bmatrix} 0 \\\\  1 \end{bmatrix}, \begin{bmatrix} \frac{1}{\sqrt{2}} \\\\  \frac{1}{\sqrt{2}} \end{bmatrix}, \begin{bmatrix} \frac{1}{\sqrt{2}} \\\\  \frac{-1}{\sqrt{2}} \end{bmatrix}, \text{ and }\begin{bmatrix} \frac{1}{\sqrt{2}} \\\\  \frac{i}{\sqrt{2}} \end{bmatrix}.$$

A quantum operation (or quantum gate) is also a matrix. When a quantum operation is applied to a quantum state vector (a qubit), the two matrices are multiplied and the resulting answer represents the new state of the qubit after the operation.  Here are two common quantum operations represented with matrix multiplication:

The Pauli-X operation $\begin{bmatrix}0 &1\\\\ 1 &0\end{bmatrix}$ flips the state of a qubit from 0 to 1 and vice-versa.

$$\begin{bmatrix}0 &1\\\\ 1 &0\end{bmatrix}\begin{bmatrix} 1 \\\\  0 \end{bmatrix} = \begin{bmatrix} 0 \\\\  1 \end{bmatrix}$$

The Hadamard operation $\dfrac{1}{\sqrt{2}}\begin{bmatrix}1 &1\\\\ 1 &-1\end{bmatrix}$ puts a qubit into a superposition state where it has an even probability of collapsing either way.

$$\frac{1}{\sqrt{2}}\begin{bmatrix}1 &1\\\\ 1 &-1\end{bmatrix}\begin{bmatrix} 1 \\\\  0 \end{bmatrix}=\frac{1}{\sqrt{2}}\begin{bmatrix} 1 \\\\  1 \end{bmatrix}=\left(\frac{1}{\sqrt{2}}\right)^2=\frac{1}{2}$$

A matrix that represents a quantum operation has one requirement – it must be a **unitary** matrix. This means that the **inverse** of the matrix must be equal to the **conjugate transpose** of the matrix.

## Summary

Linear algebra is the standard language for describing quantum computing and quantum physics. Even though the libraries included with the Microsoft Quantum Development Kit will help you run advanced quantum algorithms without diving into the underlying math, understanding the basics will help you get started quickly and provide a solid foundation to build on.

## Next steps

> [!div class="nextstepaction"]
> [Install the QDK](xref:microsoft.quantum.install)