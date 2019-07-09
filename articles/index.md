---
uid: microsoft.quantum.index
title: Setting up the Q# development environment 
author: QuantumWriter
ms.author:  
ms.date: 10/09/2017
ms.topic: article
---

# Welcome to the Microsoft Quantum Development Kit Preview

Thank you for your interest in Microsoft Quantum Development Kit preview. The development kit contains the tools you'll need to build your own quantum computing programs and experiments. 

To jump right in, go to [Getting Started with the Quantum Development Kit](xref:microsoft.quantum.install).  This shows you how to explore Q# through Jupyter Notebooks, an open source web application, without installing the Quantum Development Kit.  You'll then be guided through installing the Quantum Development Kit on Windows, Linux, or macOS machines so that you can write your own quantum programs.  With the Quantum Development Kit, you can choose which classical host (Python, C# or other .NET programming language) to use to invoke your Q# program. The development kit also offers extentions to Visual Studio and Visual Studio Code for a great developer experience.  Choose the development environment that's right for you!

Next, follow [Quickstart - your first quantum program](xref:microsoft.quantum.write-program) to write your first quantum program using your command line, Visual Studio or Visual Studio Code.  Learn about the structure of a Q# project and develop the quantum equivalent of "Hello, world!" - creating entanglement, or what is also known as a Bell State, in Q#.

To go further, the Quantum Development Kit provides many ways to learn how to develop a quantum program with Q#.  
* Visit our [samples repository](https://github.com/Microsoft/Quantum) that showcases multiple examples on how to write quantum programs using Q#. Most of these samples are written using our open-source [quantum libraries](https://github.com/Microsoft/QuantumLibraries), including our [standard](xref:microsoft.quantum.libraries.standard.intro) and [chemistry](xref:microsoft.quantum.chemistry.concepts.intro) libraries. 
* If you want to dive deeper into Q# programming, check out the [Quantum Katas](https://github.com/Microsoft/QuantumKatas) - a collection of self-paced programming exercises that introduce you to quantum computing via programming exercises in Q#.  Many of these katas are also available as Q# Notebooks.  
* [Quantum computing concepts](xref:microsoft.quantum.concepts.intro) includes more in-depth topics such as the relevance of linear algebra to quantum computing, the nature and use of a qubit, how to read a quantum circuit, and more.  See also the full list of documentation at the end of this article.

## Be a part of the Q# Open-Source Community

The Quantum Development Kit is an open-source development kit that empowers developers to make quantum computing more accessible to all so that we can solve some of the world's most pressing challenges.  Academic institutions who require open-source software will be able to deploy Q# for their quantum learning and development. Open-sourcing the development kit also empowers developers and domain experts an opportunity to contribute improvements and ideas via their code.

Your feedback, participation and contributions to the Quantum Development Kit is important.  To learn more about the Quantum Development Kit sources, provide feedback, and find out how you can participate in the decisions and contribute to this growing quantum development platform, see [Contributing to the Quantum Development  Kit](xref:microsoft.com.contributing).

If you'd like more general information about Microsoft's quantum computing initiative, see [Microsoft Quantum](https://www.microsoft.com/en-us/quantum/).

## Microsoft Quantum Development Kit Components

The Quantum Development Kit preview provides a complete quantum program development and simulation environment that contains the following components.  To find the open-source GitHub source code repository for these components, see [Contributing to the Quantum Development Kit](xref:microsoft.quantum.contributing).

| Component | Function |
| --------- | -------- |
| Q# language and compiler | Q# is a domain-specific programming language used for expressing quantum algorithms. It is used for writing sub-programs that execute on an adjunct quantum processor under the control of a classical host program and computer. |
| Q# library | The library contains operations and functions that support both the classical language control requirement and the Q# quantum algorithms. |
| Local quantum machine simulator | A full state vector simulator optimized for accurate vector simulation and speed. |
| Quantum computer trace simulator | The trace simulator does not simulate the quantum environment like the local quantum simulator. It is used to estimate the resources required to execute a quantum program and also allow faster debugging of the non-Q# control code. |
| Resource Estimator | The resource estimator estimates the resources required to run a given instance of a Q# operation on a quantum computer. |
| Visual Studio extension | This extension contains templates for Q# files and projects as well as syntax highlighting and IntelliSense support. |
| Visual Studio Code extension | This extension contains syntax highlighting, as well as code snippets for Q# and IntelliSense support. |
| `qsharp` for Python | The `qsharp` package for Python makes it easy to simulate Q# operations and functions from within Python. |
|  IQ# | IQ# (pronounced i-q-sharp) is an extension primarily used by Jupyter and Python to the .NET Core SDK that provides the core functionality for compiling and simulating Q# operations. |

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
* [Quantum trace simulator reference](xref:Microsoft.Quantum.Simulation.Simulators.QCTraceSimulators) contains reference material about trace simulator entities and exceptions.
* [Q# library reference](xref:microsoft.quantum.standardlibsintro) contains reference information about library entities by namespace.
