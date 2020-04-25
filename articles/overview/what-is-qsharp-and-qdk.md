---
title: What is the Q# programming language and QDK?
description: Learn about the Microsoft Quantum Development Kit, the Q# programming language, and how you can create quantum programs.
author: bradben
ms.author:  bradben
ms.date: 04/22/2020
ms.topic: overview
uid: microsoft.quantum.overview.q-sharp
---

# What is the Q# programming language and QDK?

Q# is Microsoft’s open-source programming language for developing and running quantum algorithms. It’s part of the Quantum Development Kit (QDK), which includes Q# libraries, quantum simulators, extensions for other programming environments, and API documentation. In addition the Standard Q# library, the QDK includes Chemistry, Machine Learning, and Numeric libraries.

As a programming language, Q# draws familiar elements from Python, C#, and F# and supports a basic procedural model for writing programs with loops, if/then statements, and common data types. It also introduces new quantum-specific data structures and operations.

## What can I do with the QDK?

The QDK is a full-featured development kit for Q# that you can use with common tools and languages to develop quantum applications that you can run in various environments.

### Develop in common tools and environments

Integrate your quantum development with Visual Studio, Visual Studio Code, and Jupyter notebooks. Use the built-in APIs for pairing your programs with Python and C# host languages.

### Try quantum operations and domain-specific libraries

Write and test quantum algorithms to explore superpositioning, entanglement, and other quantum operations. The Q# libraries enable you to run complex quantum operations without having to design low-level operation sequences.

### Run programs in simulators

Run your quantum programs on a full-state quantum simulator, a limited-scope Toffoli simulator, or test your Q# code in different resource estimators. 

## Where can I learn more?

|||
| ---- | ---- |
| **I'm new to quantum computing** | Review some basics of quantum physics and quantum computing in Key Concepts.|
| **I want to dive deeper into the Q# language** | Explore types, expressions, variables and quantum program structure in the Q# User Guide.|
| **I just want to start writing quantum programs** | Set up your Q# environment and start writing quantum programs in QuickStarts.|

## How does Q# work?

A Q# program doesn’t compile into a standalone executable. Instead, it is a collection of subroutines that runs inside a quantum simulator, and is called by another host program that is written either in Python or C#.

When you compile and run the host program, it creates an instance of the quantum simulator and passes the Q# code to it. The simulator uses the Q# code to create qubits (simulations of quantum particles) and apply transformations to modify their state. The results of the quantum operations in the simulator are then returned to the host program.  

Isolating the Q# code in the simulator ensures that the algorithms follow the laws of quantum physics and can run correctly on quantum computers.

<!-- ![qsharp-code-flow](~/media/qsharp-code-flow.png) -->
![qsharp-code-flow](qsharp-code-flow.png)

## How do I use the QDK?

Everything you need to write and run Q# programs, including the Q# compiler, the Q# libraries, and the quantum simulators, can be installed and run from your local computer. Eventually you will be able to run your Q# programs remotely on an actual quantum computer, but until then the quantum simulators provided with the QDK provide accurate and reliable results.

If you are new to programming, using Python as your host programming platform is the easiest way to get started. Python enjoys widespread use not only among developers, but also scientists, researchers and teachers, and is easy to learn.

If you already have experience with C# and are familiar with the Visual Studio development environment, there are just a few extensions you need to add to Visual Studio to prepare it for Q#.  

## Summary

Q# is an open-source programming language for developing quantum programs. It has libraries that let you create complex quantum operations, and quantum simulators to accurately run and test your programs. Q# programs are called from a host program written either in Python or C# and can be written, run and tested from your local computer.

## Next Steps

> [!div class="nextstepaction"]
> [Linear algebra for quantum computing](index.md)