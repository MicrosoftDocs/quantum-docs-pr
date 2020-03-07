---
uid: microsoft.quantum.welcome
title: Get started with the Quantum Development Kit (QDK)
description: Learn how to start programming quantum projects in Q# with the Microsoft Quantum Development Kit (QDK). 
author: natke
ms.author: nakersha
ms.date: 10/23/2019
ms.topic: overview
---

# Get started with the Quantum Development Kit (QDK)

Welcome to the Microsoft Quantum Development Kit!  
The QDK contains all the tools you'll need to build your own quantum programs and experiments with Q#, a programming language designed specifically for quantum application development. 

To jump right in, you can head over to the [QDK installation guide](xref:microsoft.quantum.install).
You'll then be guided through installing the Quantum Development Kit on Windows, Linux, or MacOS machines so that you can write your own quantum programs.

If you don't feel quite ready to start coding, but want to learn more about quantum computing and Q#, we encourage you to still read this article to get a feel for the resources at your disposal. 
In the [five questions about quantum computing](#five-questions-about-quantum-computing) section, you'll find links to precisely what you're looking for!

## Get started programming

The Quantum Development Kit provides many ways to learn how to develop a quantum program with Q#.
To get up and running with the power of quantum, you can try out our *quickstarts*:

* The [quantum random number generator](xref:microsoft.quantum.quickstarts.qrng) is a "Q# Hello World" style application, providing a brief introduction to quantum concepts while letting you build and run a quantum application in minutes.
* [Quantum basics with Q#](xref:microsoft.quantum.write-program) guides you on writing a Q# program that demonstrates some of the foundational concepts of quantum programming. 
	If you are not ready to start coding, you can still follow along without installing the QDK and get an overview of the Q# programming language and the first concepts of quantum computing.
* [Grover’s search algorithm](xref:microsoft.quantum.quickstarts.search) offers an example of a Q# program to get an idea of the power of Q# for expressing the quantum algorithm in a way that abstracts the low-level quantum operations. 
	This quickstart guides you through developing the program in a variety programming environments (with a Python host or with .NET language host and with Visual Studio or Visual Studio Code).

### Learning further
* If you want to dive deeper into Q# programming, check out the [Quantum Katas](https://github.com/Microsoft/QuantumKatas) - a collection of self-paced programming exercises that introduce you to quantum computing via programming exercises in Q#.
	Many of these katas are also available as Q# Notebooks. 
* Our [samples repository](https://github.com/Microsoft/Quantum) showcases multiple examples on how to write quantum programs using Q#. Most of these samples are written using our open-source [quantum libraries](https://github.com/Microsoft/QuantumLibraries), including our [standard](xref:microsoft.quantum.libraries.standard.intro) and [chemistry](xref:microsoft.quantum.chemistry.concepts.intro) libraries (more info on these below).

## Five questions about quantum computing

If you are a newcomer to quantum development, we know that this can all seem a bit daunting. We've provided resources to help you get started with learning about quantum computing. 
With the help of these short articles, we're confident you'll be eager to get started programming in no time.
* [What is quantum computing?](xref:microsoft.quantum.overview.what)
* [What can quantum computers do?](xref:microsoft.quantum.overview.computers)
* [Why learn quantum computing?](xref:microsoft.quantum.overview.why)
* [What is Q#?](xref:microsoft.quantum.overview.qsharp)
* [How to learn quantum computing with Q#](xref:microsoft.quantum.overview.learn)

## Quantum Development Kit Documentation

The current documentation includes the following additional topics.

### Using Q#
* [Quantum development techniques](xref:microsoft.quantum.techniques.intro) specifies the core concepts used to create quantum programs in Q#. Topics include file structures, operations and functions, working with qubits, and some advanced topics.
* [Q# language reference](xref:microsoft.quantum.language.intro) details the Q# language including the type model, expressions, statements, and compiler use.
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
