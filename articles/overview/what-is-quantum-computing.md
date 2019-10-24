---
title: What is quantum computing?
description: Learn what quantum computing is, and what a quantum computer can do
author: natke
ms.author: nakersha
ms.date: 10/22/2019
ms.topic: article
uid: microsoft.quantum.overview.what
---

# What is quantum computing?

There are some problems so difficult, so incredibly vast, that even if every supercomputer in the world worked on the problem in tandem it would still take longer than the lifetime of the universe to solve. Quantum computers hold the promise to solve some of our planet's biggest challenges - in environment, agriculture, health, energy, climate, materials science and those we’ve not yet even imagined. The impact of quantum computers will be far-reaching and have as great an impact as the creation of the transistor in 1947, which paved the way for today’s digital economy.

Quantum computing harnesses the unique behavior of quantum physics to provide a new and very powerful model of computing. The theory of quantum physics posits that matter, at a quantum level can be in a superposition of multiple classical states. And those many states interfere with each other like waves in a tide pool.

Quantum computing stores information in quantum states of matter and uses quantum operations to compute on that information, by harnessing and learning to program quantum interference.

Quantum computing might sound daunting, but with the right resources you can start building quantum applications today.

## The qubit

In quantum computing, a quantum bit - **qubit** - is a unit of quantum information, like a classical bit. Where classical bits hold a single binary value such as a 0 or 1, the state of a qubit can be in a **superposition of 0 and 1**.  Visually, A qubit can be thought of as a direction in space (also known as a vector).  Within that space, the two classical states are two directions in that space. A qubit can be in any of the possible directions.  

The act of **measurement** changes a qubit. It goes from being in superposition (any direction) to one of the two classical states (one of two directions).  A [Bloch sphere](/quantum/concepts/the-qubit#visualizing-qubits-and-transformations-using-the-bloch-sphere) is used to visualize a single qubit state. 

Qubits can also be **entangled**: When we make a measurement of one entangled qubit, our knowledge of the state of the other is updated, even if the qubits are physically far apart.

## Quantum operations and algorithms

Quantum algorithms can be designed to take advantage of qubit superposition and entanglement to speed up classical algorithms, or to provide entirely new ways of modeling physical systems.

When multiple qubits act coherently, they can process multiple options simultaneously. This allows them to process information in a fraction of the time it would take even the fastest non-quantum systems.

One of the most famous quantum algorithms is _Shor's algorithm_ for factorization, which makes the classically intractable problem of factorization of a large number into two prime numbers fast enough to challenge traditional cryptography.

On the more constructive side, algorithms for secure cryptographic key distribution are made possible by superposition, quantum entanglement, and the **no cloning** property of qubits, meaning the inability for qubits to be copied without detection.

_Grover's algorithm_ provides a quadratic factor speed-up for database searching.

Using quantum programs to model quantum systems themselves is another application of quantum computing. Photosynthesis, superconductors, and complex molecules are examples of quantum systems that can be simulated using quantum programs.

## Quantum hardware

In classical computers, bits correspond to voltage levels in silicon circuits. Quantum computing hardware can be implemented by many different physical realizations of qubits: trapped ions, superconducting, neutral atoms, electron spin, light polarization, topological qubits. Quantum hardware is an emergent technology. It requires balancing fidelity of the system with scalability. The larger the scale (that is, number of qubits), the higher the error rate.

Microsoft is developing a quantum computer based on topological qubits. We believe a topological qubit will be less impacted by changes in its environment, therefore reducing the degree of external error correction. Qubits are fragile by nature and become less coherent as they interact with their environment. Topological qubits feature increased stability and resistance to environmental noise, which means they can more readily scale and remain reliable longer.

## Quantum computing software – the Microsoft Quantum Development Kit

Designing a quantum program to harness interference may sound like a daunting challenge.  The Microsoft Quantum Development Kit (QDK) has been been introduced to make quantum programming and algorithm development more accessible. Our high-level programming language, Q#, addresses the challenges of quantum programming; it is integrated in a software stack that enables a quantum algorithm to be compiled down to the primitive operations of a quantum computer.

Up to a certain scale (number of qubits), quantum computing can be simulated on a classical computer. Using simulation, you can start to write quantum programs today for running on quantum hardware tomorrow.  

## Next steps

* [What can I do with a quantum computer?](xref:microsoft.quantum.overview.computers)
* [Get started with the Microsoft Quantum Development Kit](xref:microsoft.quantum.welcome)
* Read more about [Quantum computing concepts](xref:microsoft.quantum.concepts.intro)
