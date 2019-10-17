---
title: What can quantum computers do?
description: Learn what quantum computers can do
author: natke
ms.author: nakersha
ms.date: 10/16/2019
ms.topic: article
uid: microsoft.quantum.overview.computers
---

# What can we do with quantum computers?

What we can do with a quantum computer that cannot be done with a classical one?

Where current computers would require billions of years to solve the world’s most challenging problems, a quantum computer would find a solution in minutes, hours, or days. Quantum computing will enable researchers to develop new catalysts and materials, improve medicines, accelerate advances in artificial intelligence, and answer fundamental questions about the origins of our universe.

## Simulation of quantum systems

It is not surprising that quantum computers are better than classical computers to simulate quantum physics. Let’s outline why.

In [What is quantum computing?](xref:microsoft.quantum.overview.what) we used a simplified version of an atom with two possible states to model a qubit. Let’s take the same system to explain the difficulties of simulating quantum systems with classical computers.

First, let’s suppose that our quantum system only has one atom. There are two possible classical states in which we can find the system, therefore we only need 2 parameters (one for each classical state) to describe a general superposition of the system. That’s easy to store in a computer.

Now let’s add a second atom to the system. Now the system can be found in four different classical states: 

Therefore, now we need 4 parameters to describe the quantum superposition of the system. Still easy. If we add one more atom, we need 8 parameters, because there will be eight possible combinations. Add another atom and we will need 16 parameters. Still not a big deal.

The number of parameters doubles each time we add an atom. This means that for N atoms we will need 2^N parameters to describe the quantum state of the system. With ~50 atoms our best classical supercomputers start to struggle. For N≈80 we will need more parameters than transistors are in the Earth. For N≈280 we need more parameters than the estimated number of atoms in the Universe. Even supposing that we need only one bit per parameter (which is not true) we will need more transistors than atoms exist in the universe to simulate a relatively small system!

How can a quantum computer help us here? In a quantum computer we don’t need to store the parameters because the computer itself can be in a superposition! We just need to embed the quantum state of the system that we want to simulate in the computer and run the simulation with a specific set of quantum gates.

## Factorization problem and cryptography

This is the most known example in which a quantum computer outperforms the best known classical algorithm. Suppose we have a very large integer N and we want to find its decomposition in prime factors. After many attempts of world-class mathematicians during centuries, the best known classical algorithm would take longer than the age of the universe run on our best supercomputer for factorizing the numbers used in today’s encryption protocols. However, it only took 13 years after the quantum computers were first-ever proposed to find a quantum algorithm that can solve the problem in acceptable times.  

## Quantum computers are faster for certain tasks

Quantum computers are also a great tool to solve problems that are solvable with classical computers. A quantum boost means that the quantum computer solves the problem faster than competing classical computers using the best available hardware and running the best algorithm which performs the same task. Let’s see two important examples:

### Search algorithm

Suppose we have a black box that accepts as input a string of n bits and outputs 1 for one of the configurations of the string and 0 for the rest. Our objective is to find which one of the N=2^n possible configurations gives the output 1. This is equivalent to having an unstructured database of N elements and searching for one specific element of the database. Classically, if we are unlucky, we need to make N queries to our black box (in complexity theory we say that we need O(N) queries).

By exploiting superposition and quantum gates we can design an algorithm that only needs O(√N) queries to find the correct item. This is a very good improvement! It means that if we have a database of, for example, one million elements, we only need around one thousand tries to find the target.

However, the implementation of this algorithm to search on a real database is very unlikely due to technological considerations. Nonetheless, this algorithm provides a powerful tool to solve faster by brute force computationally difficult mathematical problems like the traveling salesman problem.

### Solving linear systems of equations

A great number of numerical calculations on classical computing consist mainly in solving linear systems of equations. This is especially true in the field of machine learning where most of the computation cost goes into calculating the inverse of huge matrices.

Fortunately, there exists a quantum algorithm that allows us to approximately solve the system exponentially faster than a classical computer. This opens the door to great speedups in every algorithm which involves solving linear systems of equations.
