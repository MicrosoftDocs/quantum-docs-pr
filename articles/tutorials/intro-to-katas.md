---
title: Introduction to the Quantum Katas
description: Learn about the katas (training exercises) provided with the Microsoft Quantum Development Kit (QDK)
author: bradben
ms.author: v-benbra 
ms.date: 06/02/2020
ms.topic: overview
uid: microsoft.quantum.overview.katas
no-loc: ['Q#', '$$v']
---

# Learn quantum computing with the Quantum Katas

[The Quantum Katas](https://github.com/Microsoft/QuantumKatas/) are open-source, self-paced tutorials and programming exercises aimed at teaching the elements of quantum computing and Q# programming at the same time.

## Learning by doing

The tutorials and exercises collected in this project emphasize learning by doing: they offer programming tasks that cover certain topics which progress from very simple to quite challenging. Each task asks you to fill in some code; the first tasks might require just one line, and the later ones might require a sizable fragment of code.

Most importantly, the katas include testing frameworks that set up, run and validate the solutions to the tasks. This allows you to get immediate feedback on your solution and to reconsider your approach if it is incorrect.

You can use the katas for learning in your environment of choice:

* Jupyter Notebooks online within the Binder environment
* Jupyter Notebooks running on your local machine
* Visual Studio
* Visual Studio Code

## What can I learn with the Quantum Katas?

Explore the basics and fundamentals of quantum computing or dive deeper into quantum algorithms and protocols. We recommend you to follow this learning path in the beginning to make sure you have a solid grasp on the fundamental concepts of quantum computing. Of course, you can skip the topics you're comfortable with, such as complex arithmetic, and learn the algorithms in any order you want.

### Introduction to quantum computing concepts

| Kata | Description |
|:-----|-------------|
|[Complex arithmetic](https://github.com/microsoft/QuantumKatas/tree/master/tutorials/ComplexArithmetic)|This tutorial explains some of the mathematical background required to work with quantum computing, such as imaginary and complex numbers.|
|[Linear algebra](https://github.com/microsoft/QuantumKatas/tree/master/tutorials/LinearAlgebra)|Linear algebra is used to represent quantum states and operations in quantum computing. This tutorial covers the basics, including matrices and vectors.|
|[The concept of a qubit](https://github.com/microsoft/QuantumKatas/tree/master/tutorials/Qubit)|Learn about qubits - one of the core concepts of quantum computing. |
|[Single-qubit quantum gates](https://github.com/microsoft/QuantumKatas/tree/master/tutorials/SingleQubitGates)|This tutorial introduces single-qubit quantum gates, which act as the building blocks of quantum algorithms and transform quantum qubit states in various ways.|
|[Multi-qubit systems](https://github.com/microsoft/QuantumKatas/tree/master/tutorials/MultiQubitSystems)|This tutorial introduces multi-qubit systems, their representation in mathematical notation and in Q# code, and the concept of entanglement.|
|[Multi-qubit quantum gates](https://github.com/microsoft/QuantumKatas/tree/master/tutorials/MultiQubitGates)|This tutorial follows the [Single-qubit quantum gates](https://github.com/microsoft/QuantumKatas/tree/master/tutorials/SingleQubitGates) tutorial, and focuses on applying quantum gates to multi-qubit systems.|

### Quantum computing fundamentals

| Kata | Description |
|:-----|-------------|
|[Recognizing quantum gates](https://github.com/microsoft/QuantumKatas/tree/master/BasicGates)|A series of exercises designed to get you familiar with the basic quantum gates in Q#. Includes exercises for basic single-qubit and multi-qubit gates, adjoint and controlled gates, and how to use gates to modify the state of a qubit.|
|[Creating quantum superposition](https://github.com/microsoft/QuantumKatas/tree/master/Superposition)|Use these exercises to get familiar with the concept of superposition and programming in Q#. Includes exercises for basic single-qubit and multi-qubit gates, superposition, and flow control and recursion in Q#.|
|[Distinguishing quantum states using measurements](https://github.com/microsoft/QuantumKatas/tree/master/Measurements)|Solve these exercises while learning about quantum measurement and orthogonal and non-orthogonal states. |
|[Joint measurements](https://github.com/microsoft/QuantumKatas/tree/master/JointMeasurements)|Learn about joint parity measurements and how to use the [Measure](xref:microsoft.quantum.intrinsic.measure) operation to distinguish quantum states.|

### Algorithms

| Kata | Description |
|:-----|-------------|
|[Quantum teleportation](https://github.com/microsoft/QuantumKatas/tree/master/Teleportation)|This kata explores quantum teleportation - a protocol which allows communicating a quantum state using only classical communication and previously shared quantum entanglement.|
|[Superdense coding](https://github.com/microsoft/QuantumKatas/tree/master/SuperdenseCoding)|Superdense coding is a protocol that allows transmission of two bits of classical information by sending just one qubit using previously shared quantum entanglement.  |
|[Deutsch–Jozsa algorithm](https://github.com/microsoft/QuantumKatas/tree/master/tutorials/ExploringDeutschJozsaAlgorithm)|This algorithm is famous for being one of the first examples of a quantum algorithm that is exponentially faster than any deterministic classical algorithm.|
|[Exploring high-level properties of Grover's search algorithm](https://github.com/microsoft/QuantumKatas/tree/master/tutorials/ExploringGroversAlgorithm)|A high-level introduction to one of the most famous algorithms in quantum computing. It solves the problem of finding an input to a black box (oracle) that produces a particular output. |
|[Implementing Grover's search algorithm](https://github.com/microsoft/QuantumKatas/tree/master/GroversAlgorithm)|This kata dives deeper into Grover's search algorithm, and covers writing oracles, performing steps of the algorithm, and finally putting it all together.|
|[Solving real problems using Grover's algorithm: SAT problems](https://github.com/microsoft/QuantumKatas/tree/master/SolveSATWithGrover)|A series of exercises that uses Grover's algorithm to solve realistic problems, using [boolean satisfiability problems](https://en.wikipedia.org/wiki/Boolean_satisfiability_problem) (SAT) as an example.  |
|[Solving real problems using Grover's algorithm: Graph coloring problems](https://github.com/microsoft/QuantumKatas/tree/master/GraphColoring)| This kata further explores Grover's algorithm, this time to solve [constraint satisfaction problems](https://en.wikipedia.org/wiki/Constraint_satisfaction_problem), using a graph coloring problem as an example. |

### Protocols and libraries

| Kata | Description |
|:-----|-------------|
|[BB84 protocol for quantum key distribution](https://github.com/microsoft/QuantumKatas/tree/master/KeyDistribution_BB84)|Learn about and implement a quantum key distribution protocol, [BB84](https://en.wikipedia.org/wiki/BB84), using qubits to exchange cryptographic keys. |
|[Bit-flip error correcting code](https://github.com/microsoft/QuantumKatas/tree/master/QEC_BitFlipCode)|Explore quantum error correction with the simplest of the quantum error-correction (QEC) codes - the three-qubit bit-flip code.|
|[Phase estimation](https://github.com/microsoft/QuantumKatas/blob/master/PhaseEstimation)|Phase estimation algorithms are some of the most fundamental building blocks of quantum computing. Learn about phase estimation with these exercises that cover quantum phase estimation and how to prepare and run phase estimation routines in Q#.|
|[Quantum arithmetic: Building ripple-carry adders](https://github.com/microsoft/QuantumKatas/blob/master/RippleCarryAdder)|An in-depth series of exercises that explores [ripple carry](https://en.wikipedia.org/wiki/Adder_(electronics)#Ripple-carry_adder) addition on a quantum computer. Build an in-place quantum adder, expand on it with a different algorithm, and finally, build an in-place quantum subtractor.   |

### Entanglement games

| Kata | Description |
|:-----|-------------|
|[CHSH game](https://github.com/microsoft/QuantumKatas/tree/master/CHSHGame)|Explore quantum entanglement with an implementation of the [CHSH](https://en.wikipedia.org/wiki/CHSH_inequality) game. This [nonlocal](https://en.wikipedia.org/wiki/Quantum_refereed_game) game shows how quantum entanglement can be used to increase the players' chance of winning beyond what would be possible with a purely classical strategy.|
|[GHZ game](https://github.com/microsoft/QuantumKatas/tree/master/GHZGame)|The GHZ game is another nonlocal game, but involves three players.|
|[Mermin-Peres magic square game](https://github.com/microsoft/QuantumKatas/tree/master/MagicSquareGame)|A series of exercises that explores [quantum pseudo-telepathy](https://en.wikipedia.org/wiki/Quantum_pseudo-telepathy#The_Mermin%E2%80%93Peres_magic_square_game) to solve a magic square game.  |

## Resources

See the full series of [Quantum Katas](https://github.com/microsoft/QuantumKatas)

[Run the katas online](https://aka.ms/try-quantum-katas)
