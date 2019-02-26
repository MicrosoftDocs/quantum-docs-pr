---
uid: microsoft.quantum.index
title: Setting up the Q# development environment 
author: QuantumWriter
ms.author:  
ms.date: 10/09/2017
ms.topic: article
---

# Welcome to the Microsoft Quantum Development Kit Preview

Thank you for your interest in Microsoft Quantum Development Kit preview. The development kit contains the tools you'll need to build your own quantum computing programs and experiments. Assuming some experience with Microsoft Visual Studio or Visual Studio Code, beginners can write their first quantum program, and experienced researchers can quickly and efficiently develop new quantum algorithms.

To jump right in, start with [Getting Started with the Quantum Development Kit](xref:microsoft.quantum.install) to create and validate your development environment. Then use [Quickstart - your first quantum program](xref:microsoft.quantum.write-program) to learn about the structure of a Q# project and how to write the quantum equivalent of "Hello, world!" - creating entanglement, or what is also known as a Bell State, in Q#.

You should also visit our [samples repository](https://github.com/Microsoft/Quantum) that showcases multiple examples on how to write quantum programs using Q#. Most of these samples are written using our open-source [quantum libraries](https://github.com/Microsoft/QuantumLibraries), including our [standard](xref:microsoft.quantum.libraries.standard.intro) and [chemistry](xref:microsoft.quantum.chemistry.concepts.intro) libraries. If you want to dive deeper into Q# programming, check out the [Quantum Katas](https://github.com/Microsoft/QuantumKatas) - a collection of self-paced tutorials introducing you to quantum computing via programming exercises in Q#.

If you'd like more general information about Microsoft's quantum computing initiative, see [Microsoft Quantum](https://www.microsoft.com/en-us/quantum/).

## Feedback Pipeline

Your feedback about all parts of the Quantum Development Kit is important. We ask you to provide feedback by joining our community of developers at [Microsoft Quantum - Feedback](https://quantum.uservoice.com/). Sign in and share your experience in one of the following forums.

- [Q# language](https://quantum.uservoice.com/forums/906208-q-language)
- [Language Interoperability](https://quantum.uservoice.com/forums/910546-language-interoperability)
- [Debugging and simulation](https://quantum.uservoice.com/forums/906940-debugging-and-simulation)
- [Libraries](https://quantum.uservoice.com/forums/906952-libraries)
- [Samples and documentation](https://quantum.uservoice.com/forums/906946-samples-and-documentation)
- [Setup and Visual Studio / VS Code Integration](https://quantum.uservoice.com/forums/906943-setup-and-visual-studio-vs-code-integration)
- [General ideas and feature requests](https://quantum.uservoice.com/forums/906097-general-ideas-and-feature-requests)

You will need a [Microsoft Account](https://signup.live.com/) to provide feedback.

## Microsoft Quantum Development Kit Components

The Quantum Development Kit preview provides a complete development and simulation environment that contains the following components.

| Component | Function |
| --------- | -------- |
| Q# language and compiler | Q# is a domain-specific programming language used for expressing quantum algorithms. It is used for writing sub-programs that execute on an adjunct quantum processor under the control of a classical host program and computer. |
| Q# library | The library contains operations and functions that support both the classical language control requirement and the Q# quantum algorithms. |
| Local quantum machine simulator | A full state vector simulator optimized for accurate vector simulation and speed. |
| Quantum computer trace simulator | The trace simulator does not simulate the quantum environment like the local quantum simulator. It is used to estimate the resources required to execute a quantum program and also allow faster debugging of the non-Q# control code. |
| Resource Estimator | The resource estimator estimates the resources required to run a given instance of a Q# operation on a quantum computer. |
| Visual Studio extension | This extension contains templates for Q# files and projects as well as syntax highlighting. |
| Visual Studio Code extension | This extension contains syntax highlighting and code snippets for Q#. |
| `qsharp` for Python | The `qsharp` package for Python makes it easy to simulate Q# operations and functions from within Python.  


## Quantum Development Kit Documentation

The current documentation includes the following topics.

* [Microsoft Quantum Development kit release notes](xref:microsoft.quantum.relnotes).
* [Quantum computing concepts](xref:microsoft.quantum.concepts.intro) includes topics such as the relevance of linear algebra to quantum computing, the nature and use of a qubit, how to read a quantum circuit, and more.
* [Getting Started with the Quantum Development Kit](xref:microsoft.quantum.install) describes how to quickly set up your quantum development environment from any platform (Windows 10, Linux, and Mac) using Visual Studio, Visual Studio Code or the command line.  
* [Quickstart - your first quantum program](xref:microsoft.quantum.write-program) walks you through how to write an application that creates a quantum entanglment state in the Visual Studio development environment. You'll learn how to define a Q# operation, call the Q# operation using C#, and how to execute your quantum algorithm.
* [Managing quantum machines and drivers](xref:microsoft.quantum.machines) describes how quantum algorithms are executed, what quantum machines are available, and how to write a non-Q# driver for the quantum program.
* [Quantum development techniques](xref:microsoft.quantum.techniques.intro) specifies the core concepts used to create quantum programs in Q#. Topics include file structures, operations and functions, working with qubits, and some advanced topics.
* [Q# standard libraries](xref:microsoft.quantum.libraries.standard.intro) describes the operations and functions that support both the classical language control requirement and the Q# quantum algorithms. Topics include control flow, data structures, error correction, testing, and debugging. 
* [Q# language reference](xref:microsoft.quantum.language.intro) details the Q# language including the type model, expressions, statements, and compiler use.
* [For more information](xref:microsoft.quantum.more-information) contains specially selected references to deep coverage of quantum computing topics.
* [Quantum trace simulator reference](https://docs.microsoft.com/dotnet/api/Microsoft.Quantum.Simulation.Simulators.QCTraceSimulators?branch=master&view=qsharp-preview) contains reference material about trace simulator entities and exceptions.
* [Q# library reference](xref:microsoft.quantum.standardlibsintro) contains reference information about library entities by namespace.
