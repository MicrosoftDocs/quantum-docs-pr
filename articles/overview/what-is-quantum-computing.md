---
title: What is quantum computing?
description: 
author: natke
ms.author:  
ms.date: 10/14/2019
ms.topic: article
uid: microsoft.quantum.overview.whatis
---

# What is quantum computing?

Quantum computing is the application of quantum physics to the field of computer science. Quantum computing might sound daunting, but with the right resources you can start building quantum applications today.

## The qubit

The basic unit of quantum computing is the `qubit`. Unlike a `bit` in classical computing, which can be `0` or `1`, a qubit can be in an infinite number of states - a **superposition** of both 0 and 1.

The act of **measurement** changes a qubit. It goes from being in the infinite states of superposition to one of the binary states of 0 or 1. Again, this is unlike a classical bit which when 0 is measured as 0, and when 1 is measured as 1.

Qubits can also be **entangled**: when we make a measurement of one entangled qubit, it affects the state of the other, even if the qubits are physically far apart.

## What can a quantum computer do?

Quantum algorithms can be designed to take advantage of qubit superposition and entanglement to speed up classical algorithms, or provide entirely new ways of modeling physical systems.

One of the most famous quantum algorithms is `Shor's algorithm` for factorization, which makes the classically intractable problem of factorization of a large number into two prime numbers fast enough to challenge traditional cryptography.

On the more constructive side, algorithms for secure cryptographic key distribution are made possible by superposition, quantum entanglement, and the **no cloning** property of qubits: the inability for qubits to be copied without detection.

`Grover's algorithm` provides a quadratic factor speed up for database searching.

Using quantum programs to model quantum systems themselves is another application of quantum computing. Photosynthesis, superconductors, and chemical molecules are examples of quantum systems that can be simulated using quantum programs.

## Quantum hardware

In classical computers, bits correspond to voltage levels in silicon circuits. Quantum computing hardware can be implemented by many different physical realizations of qubits: trapped ions, superconducting, neutral atoms, electron spin, light polarization, topological qubits. Quantum hardware is an emergent technology. It requires balancing fidelity of the system with scalability. The larger the scale (i.e. number of qubits in the computer), the higher the error rate.

## Quantum simulations

Up to a certain scale (number of qubits), quantum computing can be simulated on a classical computer. This is how you can start to write quantum programs using Microsoft Quantum, the Quantum Development Kit (QDK), and the Q# language.

## Get started today

* Build a quantum program that implements [Grover's algorithm](quickstarts/grovers.md)
* Take a quick look at Q# by developing a [Bell State](quickstart.md) program
