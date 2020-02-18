---
title: What are Q# and the QDK?
description: Learn about Q#, a programming language created by Microsoft to develop applications for quantum computers, and a key component of Microsoft's Quantum Development Kit
author: natke
ms.author:  nakersha
ms.date: 10/22/2019
ms.topic: article
uid: microsoft.quantum.overview.qsharp
---

# What are Q# and the QDK?

Q# is a programming language with features specifically designed for use with quantum computing.
As a key component of Microsoft's Quantum Development Kit (QDK), it provides quantum programmers a framework that allows you to focus on the algorithms without having to worry about technical details like gate sequence optimization or the physical implementation of a quantum computer.

The QDK comprises a wide range of tools which give developers everything they need to start writing quantum programs.
Alongside the Q# language, the QDK includes:
* the *Q# libraries*, which allow developers to hit the ground running and create real-world quantum applications today
* various *target machines* on which Q# programs can be run. These include resource estimators and simulators for larger quantum programs, as well as a full-state quantum simulator, which behaves as a noise-free quantum computer. The latter is very useful for tinkering with ideas, debugging programs, and learning about quantum physics, but only efficient for programs with relatively few qubits. We're very much looking forward to making quantum computing hardware available as target machines in the future.
* *tools* for making work with Q# as seamless as possible, such as extensions for Visual Studio and VS Code, and packages for use with Python and Jupyter Notebooks.
* *API documentation* for pairing Q# with classical host languages such as Python and C#

Applications developed with Microsoft's Quantum Development Kit typically consist of two parts:
1. One or more quantum algorithms, implemented using the Q# quantum programming language, and invoked by the classical host program. These consist of 
    - Q# operations: subroutines containing quantum operations, and 
    - Q# functions: classical subroutines used within the quantum algorithm.
2. A classical program, implemented in a classical programming language like Python or C#, that serves as the main entry point and will invoke Q# operations when it wants to execute a quantum algorithm.

## Write quantum programs, not quantum circuits

In the early days of quantum computing algorithms were visualized as diagrams similarly to circuit diagrams in classical computing.
While the circuit model has been useful for many years in quantum computing research, here at Microsoft, we believe that developers can go beyond quantum circuits and develop quantum algorithms and applications using Q#.
The Q# language was built to take advantage of what we’ve learned through decades of classical software development, and empower quantum developers with high-level language functionality targeted for quantum computing.

## How does Q# work?

The Q# programming language provides you with an intuitive set of types, operations, and logic expressions to develop algorithms without having to worry about the internal logic of the quantum computer.

One of the fundamental building blocks of Q# is the `Qubit` type, which cannot be copied or directly accessed, just like a real qubit.
Instead, we can measure it and store the outcome of the measurement in a `Result` variable, a Q# type that can take two possible values: `Zero` and `One`.
Constructs like this one guarantee that algorithms always respect the laws of quantum physics and can run correctly on quantum computers or simulators.

Q# also includes classical logic features like conditionals and loops with some subtleties to make sure that all the quantum rules are being respected.
For example, constraining the way loops are executed to ensure that quantum operations are not called within functions which may only contain deterministic classical subroutines.

Q# programs are often paired with a host program written in C# or Python, which can provide convenient organization of classical and quantum code.
In addition to supporting languages such as C# and Python, the QDK provides Jupyter Notebook support with the IQ# Jupyter kernel.

## What can I use Q# for?

### Use Q# to learn quantum computing

Until now, to learn quantum computing you needed to learn the circuit model to understand the algorithms in the form of ordered sequences of quantum gates and measurements. With Q# you can take another path: learn quantum computing by writing quantum programs.

### Use Q# to design quantum algorithms

Q# provides you with an increasing number of libraries and user-defined types that will help you to implement tools and build advanced quantum algorithms. For example, you need to entangle two-qubits q1 and q2? Instead of applying individually the necessary gates to get the qubits entangled you can use the already built-in operation `PrepareEntangledState([q1], [q2])`.

### Use Q# to estimate quantum resources

You can simulate the execution of your Q# program using the full state quantum simulator that is provided with the Quantum Development Kit (QDK).  The QDK also provides resource estimators that give you insights on the performance of Q# programs that are too large to be run on a simulator.  This is highly valuable for algorithm designers, because they can tune their programs to use fewer resources (e.g. fewer number of qubits running for fewer numbers of operations), to run on earlier smaller scale quantum hardware.

### Use Q# to validate hardware performance

The beauty of Q# is that a program can be written once and run on quantum simulators for debugging, and run on different quantum computer hardware.  Benchmark programs written in Q# can be run to validate hardware performance and compare results as quantum computers evolve and new quantum computers become available.  

## Next steps

* [How do I learn about quantum computing?](xref:microsoft.quantum.overview.learn)
* [Get started with the Microsoft Quantum Development Kit](xref:microsoft.quantum.welcome)
