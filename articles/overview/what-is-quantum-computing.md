---
title: What is quantum computing?
description: Learn what quantum computing is, and what a quantum computer can do
author: natke
ms.author: nakersha
ms.date: 10/14/2019
ms.topic: article
uid: microsoft.quantum.overview.what
---

# What is quantum computing?

Quantum computing is a model of computation based on the underlying logic of quantum physics.

The theory of quantum physics posits that matter, at a quantum level can be in a superposition of multiple classical states. And those many states interfere with each other like waves in a tide pool.

Quantum computing stores information in quantum states of matter and uses quantum operations to compute on that information, by harnessing and learning to program quantum interference.

Quantum computing might sound daunting, but with the right resources you can start building quantum applications today.

## The qubit

In quantum computing, a quantum bit - **qubit** - is a unit of quantum information, like a classical bit. Where classical bits hold a single binary value such as a 0 or 1, the state of a qubit is between the values of 0 and 1. This is called **superposition**.

The act of **measurement** changes a qubit. It goes from being in superposition to one of the binary states of 0 or 1. Again, measurement of a qubit is unlike a classical bit, which when 0 is measured as 0, and when 1 is measured as 1.

Qubits can also be **entangled**: when we make a measurement of one entangled qubit, our knowledge of the state of the other is updated, even if the qubits are physically far apart.

## What can a quantum computer do?

Quantum algorithms can be designed to take advantage of qubit superposition and entanglement to speed up classical algorithms, or to provide entirely new ways of modeling physical systems.

When multiple qubits act coherently, they can process multiple options simultaneously. This allows them to process information in a fraction of the time it would take even the fastest non-quantum systems.

One of the most famous quantum algorithms is _Shor's algorithm_ for factorization, which makes the classically intractable problem of factorization of a large number into two prime numbers fast enough to challenge traditional cryptography.

On the more constructive side, algorithms for secure cryptographic key distribution are made possible by superposition, quantum entanglement, and the **no cloning** property of qubits: the inability for qubits to be copied without detection.

_Grover's algorithm_ provides a quadratic factor speed-up for database searching.

Using quantum programs to model quantum systems themselves is another application of quantum computing. Photosynthesis, superconductors, and complex molecules are examples of quantum systems that can be simulated using quantum programs.

## Quantum hardware

In classical computers, bits correspond to voltage levels in silicon circuits. Quantum computing hardware can be implemented by many different physical realizations of qubits: trapped ions, superconducting, neutral atoms, electron spin, light polarization, topological qubits. Quantum hardware is an emergent technology. It requires balancing fidelity of the system with scalability. The larger the scale (that is, number of qubits), the higher the error rate.

## Quantum simulations

Up to a certain scale (number of qubits), quantum computing can be simulated on a classical computer. Using simulations is how you can start to write quantum programs using Microsoft Quantum, the Quantum Development Kit (QDK), and the Q# language.

## Get started today

* [Build a quantum program that implements Grover's algorithm](xref:microsoft.quantum.quickstarts.search)
* [Take a quick look at Q# by developing a Bell State](xref:microsoft.quantum.write-program) program
