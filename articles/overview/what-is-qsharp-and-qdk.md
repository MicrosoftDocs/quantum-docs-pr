---
title: What are the Q# programming language and QDK?
description: Learn about the Microsoft Quantum Development Kit, the Q# programming language, and how you can create quantum programs.
author: bradben
ms.author:  bradben
ms.date: 5/5/2020
ms.topic: overview
uid: microsoft.quantum.overview.q-sharp
---

# What is the Q# programming language and QDK?

Q# is Microsoft’s open-source programming language for developing and running quantum algorithms. It’s part of the Quantum Development Kit (QDK), which includes [Q# libraries](xref:microsoft.quantum.libraries), [quantum simulators](xref:microsoft.quantum.machines), [extensions for other programming environments](xref:microsoft.quantum.install), and [API documentation](xref:microsoft.quantum.standardlibsintro). In addition to the Standard Q# library, the QDK includes Chemistry, Machine Learning, and Numeric libraries.

As a programming language, Q# draws familiar elements from Python, C#, and F# and supports a basic procedural model for writing programs with loops, if/then statements, and common data types. It also introduces new quantum-specific data structures and operations.

## What can I do with the QDK?

The QDK is a full-featured development kit for Q# that you can use with common tools and languages to develop quantum applications that you can run in various environments. Q# programs can run as a command-line app, through Jupyter Notebooks, or use a Python or .NET host program.

### Develop in common tools and environments

Integrate your quantum development with [Visual Studio, Visual Studio Code](xref:xref:microsoft.quantum.install.standalone), and [Jupyter Notebooks](xref:xref:microsoft.quantum.install.jupyter). Use the built-in APIs for pairing your programs with [Python](xref:xref:microsoft.quantum.install.python) and [.NET](xref:xref:microsoft.quantum.install.cs) host languages.

### Try quantum operations and domain-specific libraries

Write and test quantum algorithms to explore superposition, entanglement, and other quantum operations. The Q# libraries enable you to run complex quantum operations without having to design low-level operation sequences.

### Run programs in simulators

Run your quantum programs on a full-state quantum simulator, a limited-scope Toffoli simulator, or test your Q# code in different resource estimators. 

## Where can I learn more?

|||
| ---- | ---- |
| **I'm new to quantum computing** | Review some basics of quantum physics and quantum computing in [Key Concepts](xref:microsoft.quantum.overview.understanding).|
| **I want to dive deeper into the Q# language** | Explore types, expressions, variables, and quantum program structure in the [Q# User Guide](xref:microsoft.quantum.language.intro).|
| **I just want to start writing quantum programs** | Set up your Q# environment and start writing quantum programs in [QuickStarts](xref:microsoft.quantum.install).|

## How does Q# work?

A Q# program can compile into a standalone executable or be called by a host program that is written either in Python or a .NET language.

When you compile and run the program, it creates an instance of the quantum simulator and passes the Q# code to it. The simulator uses the Q# code to create qubits (simulations of quantum particles) and apply transformations to modify their state. The results of the quantum operations in the simulator are then returned to the program.  

Isolating the Q# code in the simulator ensures that the algorithms follow the laws of quantum physics and can run correctly on quantum computers.

[qsharp-code-flow](~/media/qsharp-code-flow.png)

## How do I use the QDK?

Everything you need to write and run Q# programs, including the Q# compiler, the Q# libraries, and the quantum simulators, can be installed and run from your local computer. Eventually you will be able to run your Q# programs remotely on an actual quantum computer, but until then the quantum simulators provided with the QDK provide accurate and reliable results.

- Running [Q# from the command line](xref:microsoft.quantum.install.standalone) is the quickest way to get started.

- If you are familiar with [Python](xref:microsoft.quantum.install.python), you can use it as a host programming platform to get started. Python enjoys widespread use not only among developers, but also scientists, researchers and teachers.

- If you already have experience with [C#, F#, or VB.NET](xref:microsoft.quantum.install.cs) and are familiar with the Visual Studio development environment, there are just a few extensions you need to add to Visual Studio to prepare it for Q#.  

## Summary

Q# is an open-source programming language for developing quantum programs. It has libraries that let you create complex quantum operations, and quantum simulators to accurately run and test your programs. Q# programs can run as standalone apps or be called from a Python or .NET host program, and can be written, run, and tested from your local computer.

## Next Steps

> [!div class="nextstepaction"]
> [Linear algebra for quantum computing](xref:microsoft.quantum.overview.algebra)
