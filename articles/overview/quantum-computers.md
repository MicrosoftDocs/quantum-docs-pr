---
title: What can quantum computers do?
description: Learn about the impact of quantum computing, from novel quantum algorithms to quantum inspired algorithms running on classical computers.
author: natke
ms.author: nakersha
ms.date: 10/23/2019
ms.topic: article
uid: microsoft.quantum.overview.computers
---

# What can we do with quantum computers?

What we can do with a quantum computer that can't be done with a classical one?

To solve some of the world's most challenging problems, where finding a solution would take current computers billions of years, a quantum computer could do so in days, hours, or even minutes. Quantum computing will enable researchers to develop new catalysts and materials, improve medicines, accelerate advances in artificial intelligence, and answer fundamental questions about the origins of our universe.

## Molecular simulations

Simulating microscopic systems that behave according to the laws of quantum mechanics is computationally expensive. We need to take into account all the possible states that can be in superposition and the number of states grows exponentially with the size of the system. In a quantum computer, we don’t need to model all of the states of the system. Instead, we embed the quantum state of the system that we want to simulate in the qubits of the computer itself, and run the simulation with a specific set of quantum gates. In other words, we use a quantum computer to simulate a quantum system.

Chemical molecules are quantum systems and therefore can be analyzed in this way. One such specific chemical is the _nitrogenase_ enzyme, which, with a better understanding of its properties, could have the potential to reduce the energy consumption and greenhouse gas emission of current fertilizers.

## Data security and cryptography

Quantum computing is relevant to cryptography in two ways: the first is that classical cryptography relies on the intractability of factorization of large numbers into two prime numbers.

Quantum computing makes this factorization theoretically tractable (via Shor's algorithm). Whilst implementation of this algorithm is not physically possible with the current scale of quantum hardware, it has spawned development of quantum resistant algorithms to future-proof data security, including novel quantum algorithms for encryption and cryptographic key distribution.

## Big data and machine learning

### Search

By exploiting superposition, Grover's algorithm only needs $O(\sqrt{N})$ queries to find a specific item in a database, rather than having to access every item. It means that if we have a database of, for example, one million elements, we only need around 1000 tries to find the target.

### Solving linear systems of equations

A great number of numerical calculations on classical computing consist mainly in solving linear systems of equations. This is especially true in the field of machine learning where most of the computation cost goes into calculating the inverse of huge matrices.

Fortunately, there exists a quantum algorithm that allows us to approximately solve the system exponentially faster than a classical computer. This opens the door to great speedups in every problem that needs the solution to linear systems of equations.

## Quantum-inspired computing

Quantum-inspired algorithms are implemented with classical software, but use quantum principles for increased speed and accuracy.

Quantum-inspired algorithms are being applied to medical research. For example, to improve the accuracy of Magnetic Resonance Imaging (MRI) scans. Quantum-inspired computing is being used to optimize the configuration of the MRI machines for identification of specific diseases.

## Next steps

* [Why should I learn quantum computing?](xref:microsoft.quantum.overview.why)
* [Get started with the Microsoft Quantum Development Kit](xref:microsoft.quantum.welcome)
