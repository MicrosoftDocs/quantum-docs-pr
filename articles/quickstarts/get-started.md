---
uid: microsoft.quantum.welcome
title: Get started with the Quantum Development Kit (QDK)
description: Learn how to start programming quantum projects in Q# with the Microsoft Quantum Development Kit. 
author: bradben
ms.author: v-benbra
ms.date: 5/10/2020
ms.topic: overview
no-loc: ['Q#', '$$v']
---

# Get started with the Quantum Development Kit (QDK)

Welcome to the Microsoft Quantum Development Kit!  

The Quantum Development Kit (QDK) contains all the tools you'll need to build your own quantum programs and experiments with Q#, a programming language designed specifically for quantum application development.

To jump right in, start with the [QDK installation guide](xref:microsoft.quantum.install).
You'll be guided through installing the Quantum Development Kit on Windows, Linux, or MacOS machines so that you can write your own quantum programs.

If you're new to quantum computing, review the [Overview](xref:microsoft.quantum.overview.introduction) section to learn what quantum computers can do and the fundamentals of quantum computing.

## Get started programming

The Quantum Development Kit provides many ways to learn how to develop a quantum program with Q#.
To get up and running with the power of quantum, you can try out our tutorials:

* [Quantum random number generator](xref:microsoft.quantum.quickstarts.qrng) - Start with a "Q# Hello World" style application, providing a brief introduction to quantum concepts while letting you build and run a quantum application in minutes.
* [Explore entanglement with Q#](xref:microsoft.quantum.write-program) - This tutorial guides you on writing a Q# program that demonstrates some of the foundational concepts of quantum programming.
	If you are not ready to start coding, you can still follow along without installing the QDK and get an overview of the Q# programming language and the first concepts of quantum computing.
* [Grover’s search algorithm](xref:microsoft.quantum.quickstarts.search) - Explore this example of a Q# program to get an idea of the power of Q# for expressing the quantum algorithm in a way that abstracts the low-level quantum operations.
	This tutorial guides you through developing the program as a Q# application, using Visual Studio or Visual Studio Code.

### Learning further
* The [Microsoft Learn modules for quantum computing](https://docs.microsoft.com/learn/browse/?term=quantum) will teach you to master core concepts at your speed and on your schedule. You can learn the basics of how to create quantum programs with the QDK with our [first module](https://docs.microsoft.com/learn/modules/qsharp-create-first-quantum-development-kit/).
* If you want to dive deeper into Q# programming, check out the [Quantum Katas](https://github.com/Microsoft/QuantumKatas) - a collection of self-paced programming exercises that introduce you to quantum computing via programming exercises in Q#.
	Many of these katas are also available as Q# Notebooks. 
* Our [samples repository](https://github.com/Microsoft/Quantum) showcases multiple examples on how to write quantum programs using Q#. Most of these samples are written using our open-source [quantum libraries](https://github.com/Microsoft/QuantumLibraries), including our [standard](xref:microsoft.quantum.libraries.standard.intro) and [chemistry](xref:microsoft.quantum.chemistry.concepts.intro) libraries (more info on these below).

## Key concepts for quantum computing

If you are a newcomer to quantum development, we know that this can all seem a bit daunting. These key concepts are designed to help you step into the quantum world and understand how quantum computing differs from classical computing.

* [Understanding quantum computing](xref:microsoft.quantum.overview.understanding)
* [Quantum computers and quantum simulators](xref:microsoft.quantum.overview.simulators)
* [What are the Q# programming language and the QDK?](xref:microsoft.quantum.overview.q-sharp)
* [Linear algebra for quantum computing](xref:microsoft.quantum.overview.algebra)

## Quantum Development Kit Documentation

The current documentation includes the following additional topics.

### Q# developer guides

* [Q# User Guide](xref:microsoft.quantum.guide) details the core concepts used to create quantum programs in Q#.
* [Quantum simulators and host applications](xref:microsoft.quantum.machines) describes how quantum algorithms are executed, what quantum machines are available, and how to write a non-Q# driver for the quantum program.

### Q# libraries

* [Q# standard libraries](xref:microsoft.quantum.libraries.standard.intro) describes the operations and functions that support both the classical language control requirement and the Q# quantum algorithms. 
	Topics include control flow, data structures, error correction, testing, and debugging. 
* [Q# chemistry library](xref:microsoft.quantum.chemistry.concepts.intro) describes the operations and functions that support quantum chemistry simulation---a critical application of quantum computing. Topics include simulating Hamiltonian dynamics and quantum phase estimation, among others.
* [Q# numerics library](xref:microsoft.quantum.numerics.intro) describes the operations and functions that support expressing complicated arithmetic functions in terms of the native operations of target machines.
* [Q# library reference](xref:microsoft.quantum.standardlibsintro) contains reference information about library entities by namespace.

### General quantum computing

* [Quantum computing concepts](xref:microsoft.quantum.concepts.intro) includes topics such as the relevance of linear algebra to quantum computing, the nature and use of a qubit, how to read a quantum circuit, and more.
* [Quantum computing glossary](xref:microsoft.quantum.glossary) is a glossary of some crucial terms specific to quantum computing and program development.
	If you are new to the field, this could be a handy reference as you read through our documentation.
* [Further reading](xref:microsoft.quantum.more-information) contains specially selected references for in-depth coverage of quantum computing topics.

### Additional info

* [Microsoft Quantum Development kit release notes](xref:microsoft.quantum.relnotes).


## Be a part of the Q# Open-Source Community

The Quantum Development Kit is an open-source development kit that empowers developers to make quantum computing more accessible to all so that we can solve some of the world's most pressing challenges.  Academic institutions who require open-source software will be able to deploy Q# for their quantum learning and development. Open-sourcing the development kit also empowers developers and domain experts an opportunity to contribute improvements and ideas via their code.

Your feedback, participation and contributions to the Quantum Development Kit is important.  To learn more about the Quantum Development Kit sources, provide feedback, and find out how you can participate in the decisions and contribute to this growing quantum development platform, see [Contributing to the Quantum Development Kit](xref:microsoft.quantum.contributing).

If you'd like more general information about Microsoft's quantum computing initiative, see [Microsoft Quantum](https://www.microsoft.com/en-us/quantum/).
