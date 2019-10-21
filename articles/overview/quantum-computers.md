---
title: What can quantum computers do?
description: Learn about the impact of quantum computing, from novel quantum algorithms to quantum inspired algorithms running on classical computers.
author: natke
ms.author: nakersha
ms.date: 10/16/2019
ms.topic: article
uid: microsoft.quantum.overview.computers
---

# What can we do with quantum computers?

What we can do with a quantum computer that can't be done with a classical one?

Where current computers would require billions of years to solve the world’s most challenging problems, a quantum computer would find a solution in minutes, hours, or days. Quantum computing will enable researchers to develop new catalysts and materials, improve medicines, accelerate advances in artificial intelligence, and answer fundamental questions about the origins of our universe.

## Molecular simulations

In a quantum computer, we don’t need to model all of the states of a complex system. Instead the computer itself can be in superposition. We embed the quantum state of the system that we want to simulate in the computer and run the simulation with a specific set of quantum gates. In other words, we use a quantum computer to simulate a quantum system.

Chemical molecules can be analyzed in this way. One such specific chemical is the _nitrogenase_ enzyme, which has the potential to reduce the energy consumption and greenhouse gas emission of current fertilizers.

## Data security and cryptography

Quantum computing is relevant to cryptography in two ways: the first is that classical cryptography relies on the intractability of factorization of large numbers into two prime numbers.

Quantum computing makes this factorization theoretically tractable (via Shor's algorithm). Whilst implementation of this algorithm is not physically possible with the current scale of quantum hardware, it has spawned development of quantum resistant algorithms to future-proof data security, including novel quantum algorithms for encryption and cryptographic key distribution.

## Quantum-inspired computing

Quantum-inspired algorithms are implemented with classical software, but use quantum principles for increased speed and accuracy.

Quantum-inspired algorithms are being applied to medical research. For example, to improve the accuracy of Magnetic Resonance Imaging (MRI) scans. Quantum-inspired computing is being used to optimize the configuration of the MRI machines for identification of specific diseases.

## Big data and machine learning

### Search

By exploiting superposition, Grover's algorithm only needs $O(\sqrt{N})$ queries to find a specific item in a database, rather than having to access every item. It means that if we have a database of, for example, one million elements, we only need around 1000 tries to find the target.

### Solving linear systems of equations

A great number of numerical calculations on classical computing consist mainly in solving linear systems of equations. This is especially true in the field of machine learning where most of the computation cost goes into calculating the inverse of huge matrices.

Fortunately, there exists a quantum algorithm that allows us to approximately solve the system exponentially faster than a classical computer. This opens the door to great speedups in every problem that needs the solution to linear systems of equations.

## Dive deeper

Write code to implement [Grover's algorithm](xref:microsoft.quantum.quickstarts.search)

Learn how to implement quantum algorithms with the [Quantum Katas](xref:microsoft.quantum.overview.katas)
