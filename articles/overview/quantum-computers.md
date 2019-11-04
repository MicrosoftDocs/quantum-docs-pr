---
title: What can quantum computers do?
description: Learn about the impact of quantum computing, from novel quantum algorithms to quantum inspired algorithms running on classical computers.
author: natke
ms.author: nakersha
ms.date: 10/23/2019
ms.topic: article
uid: microsoft.quantum.overview.computers
---

# What can a quantum computer do?

What we can do with a quantum computer that can't be done with a classical one?

To solve some of the world's most challenging problems, where finding a solution would take current computers billions of years, a quantum computer could do so in days, hours, or even minutes.

Quantum computing will enable researchers to develop new catalysts and materials, improve medicines, accelerate advances in artificial intelligence, and answer fundamental questions about the origins of our universe.

## Quantum simulation

Using quantum programs to model quantum systems themselves has vast potential for unlocking insights leading to innovations across many industries. Photosynthesis, superconductors, and complex molecules are examples of quantum systems that can be simulated using quantum programs.

Simulating microscopic systems that behave according to the laws of quantum mechanics is computationally expensive. We need to take into account all the possible states that can be in superposition and the number of states grows exponentially with the size of the system. In a quantum computer, we don’t need to model all of the states of the system. Instead, we embed the quantum state of the system that we want to simulate in the qubits of the computer itself, and run the simulation with a specific set of quantum gates. In other words, we use a quantum computer to simulate a quantum system.

Chemical molecules are quantum systems and therefore can be analyzed in this way. One such specific chemical is the _nitrogenase_ enzyme, which, with a better understanding of its properties, could have the potential to reduce the energy consumption and greenhouse gas emission of current fertilizers.

## Cryptography

Perhaps the most famous application of quantum computers is in cryptography, where Peter Shor showed in 1994 that a scalable quantum computer can break every widely used encryption technique.  Classical cryptography relies on the intractability of operations on large numbers, such as factorization of large numbers into two prime numbers.

Quantum computing makes these operations theoretically tractable (via Shor's algorithm). Whilst implementation of this algorithm is not physically possible with the current scale of quantum hardware, it has spawned development of quantum-resistant algorithms to future-proof data security, including novel quantum algorithms for encryption and cryptographic key distribution.

Here at Microsoft, we have the world's leading team in post-quantum cryptography and security developing quantum-resistant algorithms.

## Optimization

Optimization is the task of performing a large search over a high-dimensional space for a solution that minimizes a given cost function.   On a quantum computer, we can speed up optimization algorithms, enabling finding solutions that otherwise were not possible. Applications range from transportation and logistics, healthcare, diagnostics, and material science. There can be a profound impact on how these industries can become more efficient.

Optimization with quantum computing allows us to innovate around transportation and logistics in a way that is not possible with today’s classical systems.

Optimizing traffic flow can reduce congestion.  In addition to route planning, there is airplane gate assignment, package delivery, job scheduling and more. With breakthroughs in materials science, there will be new forms of energy, batteries with greater capacity, lighter and stronger materials.

## Machine learning

A great number of numerical calculations on classical computing consist mainly in solving linear systems of equations, especially true in the field of machine learning where most of the computation cost goes into calculating the inverse of huge matrices.

Fortunately, there is a quantum algorithm that allows us to approximately solve the system exponentially faster than a classical computer. The algorithm opens the door to great speedups in every problem that needs the solution to linear systems of equations.

Solutions to problems in these areas will help address the energy crisis, climate change, food scarcity, and personal and precise medical diagnosis.

## Quantum-inspired computing

Quantum-inspired algorithms are implemented with classical software, but use quantum principles for increased speed and accuracy.

Quantum-inspired algorithms are being applied to medical research. For example, to improve the accuracy of Magnetic Resonance Imaging (MRI) scans. Quantum-inspired computing is being used to optimize the configuration of the MRI machines for identification of specific diseases.

## Next steps

* [Why should I learn quantum computing?](xref:microsoft.quantum.overview.why)
* [Get started with the Microsoft Quantum Development Kit](xref:microsoft.quantum.welcome)
