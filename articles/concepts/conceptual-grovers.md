---
title: Quantum circuits
description: Learn how to visually represent simple and complex quantum operations with quantum circuit diagrams. 
author: QuantumWriter
uid: microsoft.quantum.concepts.circuits
ms.author: v-benbra
ms.date: 12/11/2017
ms.topic: article
no-loc: ['Q#', '$$v', '$$', "$$", '$', "$", $, $$, '\cdots', 'bmatrix', '\ddots', '\equiv', '\sum', '\begin', '\end', '\sqrt', '\otimes', '{', '}', '\text', '\phi', '\kappa', '\psi', '\alpha', '\beta', '\gamma', '\delta', '\omega', '\bra', '\ket', '\boldone', '\\\\', '\\', '=', '\frac', '\text', '\mapsto', '\dagger', '\to', '\begin{cases}', '\end{cases}', '\operatorname', '\braket', '\id', '\expect', '\defeq', '\variance', '\dd', '&', '\begin{align}', '\end{align}', '\Lambda', '\lambda', '\Omega', '\mathrm', '\left', '\right', '\qquad', '\times', '\big', '\langle', '\rangle', '\bigg', '\Big', '|', '\mathbb', '\vec', '\in', '\texttt', '\ne', '<', '>', '\leq', '\geq', '~~', '~', '\begin{bmatrix}', '\end{bmatrix}', '\_']
---

# Theory of Grover's search algorithm

In this article you'll find a detailed theoretical explanation of the
mathematical principles that make Grover's algorithm work.

For a practical implementation of Grover's algorithm to solve mathematical
problems you can read our [guide to implement Grover's search algorithm](xref:todo).

## Statement of the problem

Any searching task can be mathematically formulated with an abstract function $f(x)$ that accepts search items $x$. If the item $x$ is a solution for the search task, then $f(x)=1$. If the item $x$ isn't a solution, then $f(x)=0$. The search problem consists on finding any item $x_0$ such that $f(x_0)=1$. This is, an item $x_0$ that is a solution of the search problem.

The task that Grover's algorithm aims to solve is, given a classical function $f(x):\\{0,1\\}^n \rightarrow\\{0,1\\}$, find an input $x_0$ for which $f(x_0)=1$.

## Outline of the algorithm

Suppose we have $N=2^n$ eligible items for the search task and we index them by assigning each item a integer from $0$ to
$N-1$. Let's assume for the moment that there's only a single item $x_0$ that is a solution for the problem. The steps of the algorithm are:

1. Start with a register of $n$ qubits initialized in the state $\ket{0}$ by applying $H$ to each qubit of the register.
1. Prepare the register into a uniform superposition: $$|\psi\rangle=\frac{1}{N^{1 / 2}} \sum_{x=0}^{N-1}|x\rangle$$
1. Apply $N_{\text{optimal}}$ times the following operations to the register:
   1. The phase oracle $O_f$ that applies a conditional phase shift of $-1$ for the solution items.
   1. Apply $H$ to each qubit of the register.
   1. A conditional phase shift of $-1$ to every computational basis state except $\ket{0}$.
   1. Apply $H$ to each qubit of the register.
1. Measure the register to obtain the index of a item that's a solution with very high probability.
1. Check if it's a valid solution. If not, start again.

$N_{\text{optimal}} is the optimal number of iterations that maximizes the likelihood of obtaining the correct item by measuring the register.

## Following the register's state step by step

To illustrate the process, let's follow the mathematical transformations of the state of the register for a simple case.

1. We start with the register in the state:
$$|\text{register}\rangle = \sum_{i\in\{0,1\}^n} |i\rangle$$

1. After applying $H$ to each qubit the register's state transforms to:
$$|\text{register}\rangle = \frac{1}{\sqrt{N}} \sum_{\{0,1\}^n}

## Geometrical explanation

## Optimal number of iterations

## Multiple targets

## Complexity analysis

## Limitations and oportunities