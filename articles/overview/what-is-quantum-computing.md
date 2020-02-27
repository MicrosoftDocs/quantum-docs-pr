---
title: What is quantum computing?
description: An introduction to quantum computing features, algorithms and hardware, and the Microsoft Quantum Development Kit (QDK).  
author: natke
ms.author: nakersha
ms.date: 10/22/2019
ms.topic: article
uid: microsoft.quantum.overview.what
---

# What is quantum computing?

There are some problems so difficult, so incredibly vast, that even if every supercomputer in the world worked on the problem, it would still take longer than the lifetime of the universe to solve.

Quantum computers hold the promise to solve some of our planet's biggest challenges - in environment, agriculture, health, energy, climate, materials science, and problems we’ve not yet even imagined. The impact of quantum computers will be far-reaching and have as great an impact as the creation of the transistor in 1947, which paved the way for today’s digital economy.

Quantum computing harnesses the unique behavior of quantum physics to provide a new and powerful model of computing. The theory of quantum physics posits that matter, at a quantum level can be in a superposition of multiple classical states. And those many states interfere with each other like waves in a tide pool.  The state of matter after a measurement "collapses" into one of the classical states. 

Thereafter, repeating the same measurement will produce the same classical result.  Quantum entanglement occurs when particles interact in ways such that the quantum state of each cannot be described independently of the others, even if the particles are physically far apart.  

Quantum computing stores information in quantum states of matter and uses its quantum nature of superposition and entanglement to realize quantum operations that compute on that information, thereby harnessing and learning to program quantum interference.

Quantum computing might sound daunting, but with the right resources you can start building quantum applications today.

## The qubit

Quantum computing defines computing concepts that reflect the quantum behavior.  Quantum computing begins with the notion of a qubit.  In quantum computing, a quantum bit - **qubit** - is a unit of quantum information, like a classical bit. Where classical bits hold a single binary value such as a 0 or 1, the state of a qubit can be in a **superposition** of 0 and 1 simultaneously.  

The act of measuring a qubit changes a qubit state. With measurement, the qubit goes from being in superposition to one of the classical states.  

Multiple qubits can also be **entangled**. When we make a measurement of one entangled qubit, our knowledge of the state of the other(s) is updated as well.

## Quantum algorithms

Quantum algorithms are designed to take advantage of quantum nature and behavior to speed up classical algorithms, or to provide entirely new ways of modeling physical systems.  These algorithms exploit the way qubits encode information and the parallel nature of operating on multiple entangled qubits in superposition.  

Classical computers encode information in bits; each bit encoding two possible values, 0 or 1.  One qubit encodes two values simultaneously, 0 and 1.  Two classical bits encode one of 4 possible values, (00, 01, 10, 11) whereas two qubits encode any superposition of the 4 states simultaneously, although we can obtain only one of those values when measuring. Four qubits encode any superposition of 16 values simultaneously, and so on, exponentially.  100 qubits can encode more information than is available in the largest computer systems today.  

Furthermore, when multiple entangled qubits act coherently, they can process multiple options simultaneously. Entangled qubits can process information in a fraction of the time it would take even the fastest non-quantum systems.

Harnessing these quantum attributes has been the pursuit of multiple decades of quantum algorithm research, and there are many innovative techniques that have been found that solve problems in a fraction of the time it takes to solve classically.  

One of the most famous quantum algorithms is _Shor's algorithm_ for factorization, which makes the classically intractable problem of factorization of a large number into two prime numbers fast enough to challenge traditional cryptography.

On the more constructive side, algorithms for secure cryptographic key distribution are made possible by superposition, quantum entanglement, and the **no cloning** property of qubits, meaning the inability for qubits to be copied without detection.

_Grover's algorithm_ highlights a quantum algorithm technique that provides a quadratic speed-up for searching unstructured data.

## Quantum hardware

In classical computers, bits correspond to voltage levels in silicon circuits. Quantum computing hardware can be implemented by many different physical realizations of qubits: trapped ions, superconducting, neutral atoms, electron spin, light polarization, topological qubits. Quantum hardware is an emergent technology. Qubits are fragile by nature and become less coherent as they interact with their environment. Balancing fidelity of the system with scalability is needed. The larger the scale (that is, number of qubits), the higher the error rate.

Microsoft is developing a quantum computer based on topological qubits. We believe a topological qubit will be less impacted by changes in its environment, therefore reducing the degree of external error correction. Topological qubits feature increased stability and resistance to environmental noise, which means they can more readily scale and remain reliable longer.

## Quantum computing – a full hardware and software stack

Microsoft's quantum program is unique in that we focus on scaling each and every component of the system to deliver real quantum impact. This comprehensive approach involves:

* building a quantum computer using reliable, scalable, and fault-tolerant topological qubits, 
* engineering a unique cryogenic control plane with low power and heat dissipation, 
* developing a complete software stack to enable programming the quantum computer and controlling the system at scale.

The open source Quantum Development Kit (QDK) has been introduced to make quantum programming and algorithm development more accessible. Our high-level programming language, Q#, addresses the challenges of quantum programming.  We designed Q# as a high-level quantum-focused programming language focused on algorithm and application development. The Q# compiler is integrated in a software stack that enables a quantum algorithm to be compiled down to the primitive operations of a quantum computer.  Up to a certain scale (number of qubits), quantum computing can be simulated on a classical computer. Using simulation, you can start to write quantum programs today for running on quantum hardware tomorrow.  We’ve also paired Q# with samples, libraries, and learning exercises to make it easy to begin quantum programming today. 

## Next steps

* [What can quantum computers do?](xref:microsoft.quantum.overview.computers)
* [Get started with the Microsoft Quantum Development Kit](xref:microsoft.quantum.welcome)
* Read more about [Quantum computing concepts](xref:microsoft.quantum.concepts.intro)
