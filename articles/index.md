---
uid: microsoft.quantum.index
# Mandatory fields.
title: Setting up the Q# development environment 
author: QuantumWriter
ms.author:  
ms.date: 10/09/2017
ms.topic: article
# Use only one of the following. Use ms.service for services, ms.prod for on-prem. Remove the # before the relevant field.
# For Quantum products none of these categories have been defined  yet.
# ms.service: service-name-from-white-list
# ms.prod: product-name-from-white-list
# ms.technology: tech-name-from-white-list
---
# Welcome to the Microsoft Quantum Development Kit Preview

Thank you for your interest in Microsoft's Quantum Development Kit preview. The development kit contains the tools you'll need to build your own quantum computing programs and experiments. Assuming some experience with Microsoft Visual Studio, beginners can write their first quantum program, and experienced researchers can quickly and efficiently develop new quantum algorithms.

To jump right in, start with [Installation and validation](quantum-InstallConfig.md) to create and validate your development environment. Then use [Quickstart - your first computer program](quantum-WriteAQuantumProgram.md) to learn about the structure of a Q# project and how to write the quantum equivalent of "Hello, world!" --  a quantum teleport application.

If you'd like more general information about Microsoft's quantum computing initiative, see [Microsoft Quantum](https://www.microsoft.com/en-us/quantum/).

## Feedback Pipeline

Your feedback about all parts of the Quantum Development Kit is important. We ask you to provide feedback by joining our community of developers at [Microsoft Quantum - Feedback](https://quantum.uservoice.com/). Sign in and share your experience in one of the following forums.

- Q# language
- Debugging and simulation
- Samples and documentation
- Libraries
- Setup and Visual Studio integration
- General ideas and feature requests

You will need a [Microsoft Account](https://signup.live.com/) to provide feedback.

## Microsoft Quantum Development Kit Components

The Quantum Development Kit preview provides a complete development and simulation environment that contains the following components.

| Component | Function |
| --------- | -------- |
| Q# language and compiler | Q# is a domain-specific programming language used for expressing quantum algorithms. It is used for writing sub-programs that execute on an adjunct quantum processor under the control of a classical host program and computer. |
| Q# standard library | The library contains operations and functions that support both the classical language control requirement and the Q# quantum algorithms. |
| Local quantum machine simulator | A full state vector simulator optimized for accurate vector simulation and speed. |
| Quantum computer trace simulator | The trace simulator does not simulate the quantum environment like the local quantum simulator. It is used to estimate the resources required to execute a quantum program and also allow faster debugging of the non-Q# control code. |
| Visual Studio extension | The extension contains templates for Q# files and projects as well as syntax highlighting. The extension also installs and creates automatic hooks to the compiler. |

## Quantum Development Kit Documentation

The current documentation includes the following topics.

* [Microsoft Quantum Development kit release notes](quantum-RelNotes.md)
* [Quantum computing concepts](quantum-concepts-1-Intro.md) includes topics such as the relevance of linear algebra to quantum computing, the nature and use of a qubit, how to read a quantum circuit, and more.
* [Installation and validation](quantum-InstallConfig.md) describes how to quickly set up your quantum development environment. Your Visual Studio environment will be enhanced with a compiler for the Q# language and templates for Q# projects and files.
* [Quickstart - your first quantum program](quantum-WriteAQuantumProgram.md) walks you through how to create the Teleport application in the Visual Studio development environment. You'll learn how to define a Q# operation, call the Q# operation using C#, and how to execute your quantum algorithm.
* [Managing quantum machines and drivers](quantum-SimulatorsAndMachines.md) describes how quantum algorithms are executed, what quantum machines are available, and how to write a non-Q# driver for the quantum program.
* [Quantum development techniques](quantum-devguide-1-Intro.md) specifies the core concepts used to create quantum programs in Q#. Topics include file structures, operations and functions, working with qubits, and some advanced topics.
* [Q# standard libraries](libraries/intro.md) describes the operations and functions that support both the classical language control requirement and the Q# quantum algorithms. Topics include control flow, data structures, error correction, testing, and debugging. 
* [Q# language reference](quantum-QR-Intro.md) details the Q# language including the type model, expressions, statements, and compiler use.
* [For more information](quantum-ForMoreInfo.md) contains specially selected references to deep coverage of quantum computing topics.
* [Quantum trace simulator reference](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Quantum.Simulation.Simulators.QCTraceSimulators?branch=master&view=qsharp-preview) contains reference material about trace simulator entities and exceptions.
* [Q# library reference](https://docs.microsoft.com/en-us/qsharp/api/) contains reference information about library entities by namespace.